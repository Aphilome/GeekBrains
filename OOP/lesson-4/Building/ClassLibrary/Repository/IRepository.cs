namespace ClassLibrary.Repository
{
	// CRUD
	public interface IRepository<K, T>
	{
		void Create(T instance);
		
		T Read(K key);
		
		void Update(T instance);
		
		void Delete(T instance);
		
		void Delete(K instance);
	}
}