namespace AncientCities.Data.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get; }
        ICityTypeRepository CityTypeRepository { get; }

        void Save();
    }
}
