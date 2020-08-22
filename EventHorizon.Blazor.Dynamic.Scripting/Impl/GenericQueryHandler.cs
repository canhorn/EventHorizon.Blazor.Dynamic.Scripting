namespace EventHorizon.Blazor.Dynamic.Scripting.Impl
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using EventHorizon.Blazor.Dynamic.Scripting.Events;
    using EventHorizon.Blazor.Dynamic.Scripting.Model;
    using MediatR;

    public class GenericQueryHandler
        : IRequestHandler<GenericQuery, IEnumerable<GenericModel>>
    {
        public Task<IEnumerable<GenericModel>> Handle(
            GenericQuery request,
            CancellationToken cancellationToken
        )
        {
            IEnumerable<GenericModel> result = new List<GenericModel>
            {
                new GenericModel
                {
                    Value = "GenericModel.Value 1"
                },
                new GenericModel
                {
                    Value = "GenericModel.Value 2"
                },
                new GenericModel
                {
                    Value = "GenericModel.Value 3"
                },
                new GenericModel
                {
                    Value = "GenericModel.Value 4"
                },
            };
            return Task.FromResult(
                result
            );
        }
    }
}
