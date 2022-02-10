using System.Net;
using API.DTOs.Vehicle;
using API.Exceptions;
using API.Repositories.Vehicle;
using API.Utilities.Messages;
using AutoMapper;
using MediatR;

namespace API.Handlers.Vehicle;

public class RetrieveVehiclesByLocation
{
    public class Query : IRequest<List<RetrieveVehicleDTO>>
    {
        public string? Location { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, List<RetrieveVehicleDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _repository;

        public Handler(IVehicleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RetrieveVehicleDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var record = await _repository
                .RetrieveVehiclesByLocation(
                    request.Location,
                    cancellationToken
                );
            if (!record.Any())
                throw new ApiException(
                    HttpStatusCode.NotFound,
                    ApiErrorMessages.NotFound
                );
            return _mapper.Map<List<Models.Vehicle>, List<RetrieveVehicleDTO>>(record);
        }
    }
}