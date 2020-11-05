using DemoApi.Domain;

namespace DemoApi.DataInterface
{
    public interface ICreateLocationRepository
    {
        void Save(CreateLocationRequest request);
    }
}