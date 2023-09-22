using eShop.Catalog.Application.Mappers;
using eShop.Catalog.Application.Queries;
using eShop.Catalog.Application.Responses;
using eShop.Catalog.Core.Repositories.Interfaces;
using MediatR;

namespace eShop.Catalog.Application.Handlers
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypesResponse>>
    {
        private readonly ITypeRepository _repository;

        public GetAllTypesHandler(ITypeRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<IList<TypesResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var types = await _repository.GetTypes();

            var typesResponse = ProductMapper.Mapper.Map<IList<TypesResponse>>(types);

            return typesResponse;
        }
    }
}
