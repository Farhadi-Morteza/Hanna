
namespace Data
{
    public interface IUnitOfWorkBase : System.IDisposable
    {
		bool IsDisposed { get; }

		void Save();

		System.Threading.Tasks.Task SaveAsync();

		RepositoryBase<T> GetRepository<T>() where T : Models.EntityBase;
	}
}
