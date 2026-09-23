namespace Restaurant.Models.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(int Id, T entity);
        void Delete(int Id, T entity);
        List<T> ViewAdmin();
        List<T> ViewClient();
        void Active(int Id);
        T Find(int Id);
    }
    public interface ITransactionRepository<T>
    {
        void Add(T entity);
        void Delete(int Id, T entity);
        List<T> ViewAdmin();
        T Find(int Id);
    }
}
