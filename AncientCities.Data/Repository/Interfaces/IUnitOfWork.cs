namespace AncientCities.Data.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }
        ICityTypeRepository CityTypeRepository { get; }
        ICityImageRepository CityImageRepository { get; }

        void Save();
    }
}
