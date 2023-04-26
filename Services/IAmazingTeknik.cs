namespace SUT22_AmaingTeknik.Services
{
    public interface IAmazingTeknik<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetSingel(int id);

        Task<T> Add(T newEntity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);

    }
}
