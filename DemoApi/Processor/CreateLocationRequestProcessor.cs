using System;
using DemoApi.DataInterface;
using DemoApi.Domain;

namespace DemoApi.Processor
{
    public class CreateLocationRequestProcessor
    {
        private ICreateLocationRepository _createLocationRepository;

        public CreateLocationRequestProcessor(ICreateLocationRepository createLocationRepository)
        {
            _createLocationRepository = createLocationRepository;
        }

        public CreateLocationResult createLocation(CreateLocationRequest locationRequest){
            if(locationRequest == null)
                throw new ArgumentNullException(nameof(locationRequest));
            _createLocationRepository.Save(locationRequest);
            
            return new CreateLocationResult{
                Name = locationRequest.Name
            };
        }
    }
}