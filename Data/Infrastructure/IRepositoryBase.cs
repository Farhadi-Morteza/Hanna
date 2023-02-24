

namespace Data
{
    public interface IRepositoryBase<T> where T : Models.EntityBase
    {
		//Select ==============================================================================
		System.Collections.Generic.IList<T> GetAll();

		System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync();

		T GetById(System.Guid? id);

		System.Threading.Tasks.Task<T> GetByIdAsync(System.Guid? id);
		//select ==============================================================================

		//Insert ==============================================================================
		void Insert(T entity);

		System.Threading.Tasks.Task InsertAsync(T entity);
		System.Threading.Tasks.Task InsertRangeAsync(T entity);	
		//insert ==============================================================================

		//Update ==============================================================================
		void Update(T entity);

		System.Threading.Tasks.Task UpdateAsync(T entity);
		//update ==============================================================================

		//Delete ==============================================================================
		void Delete(T entity);

		System.Threading.Tasks.Task DeleteAsync(T entity);

		bool DeleteById(System.Guid id);

		System.Threading.Tasks.Task<bool> DeleteByIdAsync(System.Guid id);
		//delete ==============================================================================

		/// <summary>
		/// حضور این تابع اصلا حرفه‌ای نیست
		/// </summary>
		/// <returns></returns>
		//System.Linq.IQueryable<T> Get();


	}
}
