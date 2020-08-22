namespace EventHorizon.Blazor.Dynamic.Scripting.Events
{
    using MediatR;

    public class GenericCommand
        : IRequest
    {
        public string Echo { get; set; }
    }
}
