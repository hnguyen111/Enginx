using API.DatabaseContext;
using API.DTOs.Vehicle;
using API.Repositories.Vehicle;
using API.Utilities.CredentialAccessor;
using AutoMapper;
using MediatR;

namespace API.Handlers.Vehicle;

public class RetrieveAllVehicles
{
    public class Query : IRequest<List<RetrieveAllVehicleDTO>>

    {
    }

    public class Handler : IRequestHandler<Query, List<RetrieveAllVehicleDTO>>

    {
        private readonly ICredentialAccessor _accessor;
        private readonly Context _database;
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _repository;

        public Handler(Context database, ICredentialAccessor accessor, IVehicleRepository repository, IMapper mapper)

        {
            _accessor = accessor;
            _repository = repository;
            _mapper = mapper;
            _database = database;
        }


        public async Task<List<RetrieveAllVehicleDTO>> Handle(Query request, CancellationToken cancellationToken)

        {
            var owner = _accessor.RetrieveAccountId();
            var records = await _repository.RetrieveAllVehicles(owner, cancellationToken);

            return _mapper.Map<List<Models.Vehicle>, List<RetrieveAllVehicleDTO>>(records);
        }
    }
}