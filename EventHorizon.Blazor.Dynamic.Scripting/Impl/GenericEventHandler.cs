namespace EventHorizon.Blazor.Dynamic.Scripting.Impl
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using EventHorizon.Blazor.Dynamic.Scripting.Events;
    using MediatR;

    public class GenericEventHandler
        : INotificationHandler<GenericEvent>
    {
        public Task Handle(
            GenericEvent notification,
            CancellationToken cancellationToken
        )
        {
            Console.WriteLine(
                $"From Event Handler: {notification.Echo}"
            );

            return Task.CompletedTask;
        }
    }
}
