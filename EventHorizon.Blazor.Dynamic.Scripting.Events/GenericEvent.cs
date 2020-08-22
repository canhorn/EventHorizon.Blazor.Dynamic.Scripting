namespace EventHorizon.Blazor.Dynamic.Scripting.Events
{
    using MediatR;

    public class GenericEvent
        : INotification
    {
        public string Echo { get; set; }
    }
}
