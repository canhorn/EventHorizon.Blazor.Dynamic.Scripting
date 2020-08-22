namespace EventHorizon.Blazor.Dynamic.Scripting.Pages
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    public class ScriptDllClient
    {
        private readonly ILogger _logger;
        private readonly HttpClient client;

        public ScriptDllClient(
            ILogger<ScriptDllClient> logger,
            HttpClient client
        )
        {
            _logger = logger;
            this.client = client;
        }

        public async Task<ScriptDllResult> GetContentAsync()
        {
            var scriptDllResult = new ScriptDllResult();

            try
            {
                scriptDllResult = await client.GetFromJsonAsync<ScriptDllResult>(
                    "api/scripting/dll"
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                Console.WriteLine(ex.Message);
            }

            return scriptDllResult;
        }
        public class ScriptDllResult
        {
            public string dllContent { get; set; } = string.Empty;
        }
    }
}
