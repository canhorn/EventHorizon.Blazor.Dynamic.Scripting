namespace EventHorizon.Blazor.Dynamic.Scripting.Pages
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Loader;
    using System.Threading.Tasks;
    using CSScriptLib;
    using EventHorizon.Blazor.Dynamic.Scripting.Services;
    using MediatR;
    using Microsoft.AspNetCore.Components;

    public class IndexModel : ComponentBase
    {
        [Inject]
        public ScriptDllClient Http { get; set; }
        [Inject]
        public IClientInterop ClientInterop { get; set; }
        [Inject]
        public IMediator Mediator { get; set; }

        public async Task HandleRunScript()
        {
            var dllResult = await Http.GetContentAsync();
            var bytes = Convert.FromBase64String(
                dllResult.dllContent
            );
            // https://docs.microsoft.com/en-us/dotnet/core/dependency-loading/understanding-assemblyloadcontext
            var assembly = AssemblyLoadContext.Default.LoadFromStream(
                new MemoryStream(
                    bytes
                )
            );
            dynamic script = assembly.CreateObject(
                "css_root+Scripts_Assets_Tree_Create"
            );
            var data = new Dictionary<string, object>
            {
                { "arg1", "Argument from Client" },
            };

            dynamic result = await script.Run(
                Mediator,
                ClientInterop,
                data
            );
            Console.WriteLine(
                $"Script.Run(): {result.Value}"
            );
        }
    }
}
