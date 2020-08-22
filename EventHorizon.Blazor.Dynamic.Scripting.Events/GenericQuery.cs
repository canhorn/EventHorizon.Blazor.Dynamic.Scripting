namespace EventHorizon.Blazor.Dynamic.Scripting.Events
{
    using System.Collections.Generic;
    using EventHorizon.Blazor.Dynamic.Scripting.Model;
    using MediatR;

    public class GenericQuery
        : IRequest<IEnumerable<GenericModel>>
    {
    }
}
