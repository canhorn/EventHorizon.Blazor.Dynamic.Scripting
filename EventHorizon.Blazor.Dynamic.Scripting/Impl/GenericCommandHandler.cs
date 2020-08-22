namespace EventHorizon.Blazor.Dynamic.Scripting.Impl
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using EventHorizon.Blazor.Dynamic.Scripting.Events;
    using MediatR;

    public class GenericCommandHandler
        : IRequestHandler<GenericCommand>
    {
        public Task<Unit> Handle(
            GenericCommand request,
            CancellationToken cancellationToken
        )
        {
            Console.WriteLine(
                $"From Client Handler: {request.Echo}"
            );
            return Unit.Task;
        }
    }
}
