namespace HMSUserAPI.Interfaces
{
    public interface IRepo<T,K>
    {
        public Task<T?> Get(K key);
        public Task<List<T>?> GetAll();
        public Task<T?> Add(T entity);
        public Task<T?> Update(T entity);
        public Task<T?> Delete(T entity);

    }
}
