namespace EventHorizon.Blazor.Dynamic.Scripting.Impl
{
    using EventHorizon.Blazor.Interop;
    using EventHorizon.Blazor.Dynamic.Scripting.Services;

    public class ClientInteropImplementation
        : IClientInterop
    {
        public void Alert()
        {
            EventHorizonBlazorInterop.RunScript(
                "alert",
                "alert('hi')",
                new { }
            );
        }
    }
}
