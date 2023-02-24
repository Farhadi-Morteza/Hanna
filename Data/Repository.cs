using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Repository<T> : RepositoryBase<T> where T : Models.ExtendedEntityBase
    {
        internal Repository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

		public override void Insert(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException(paramName: nameof(entity));
			}

			entity.InsertDate = Models.Utility.Now;
			entity.UpdateDate = Models.Utility.Now;

			DbSet.Add(entity);
		}

		public override async Task InsertAsync(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException(paramName: nameof(entity));
			}

			entity.InsertDate = Models.Utility.Now;
			entity.UpdateDate = Models.Utility.Now;

			await DbSet.AddAsync(entity);
		}

		public override void Update(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException(paramName: nameof(entity));
			}

			entity.UpdateDate = Models.Utility.Now;
			DbSet.Update(entity);
		}

		public override async Task UpdateAsync(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException(paramName: nameof(entity));
			}

			entity.UpdateDate = Models.Utility.Now;
			await System.Threading.Tasks.Task.Run(() =>
			{
				DbSet.Update(entity);
			});
		}

		public override void Delete(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException(paramName: nameof(entity));
			}

            entity.IsDeleted = true;
            entity.DeleteDate = Models.Utility.Now;
            DbSet.Update(entity);
            //DbSet.Remove(entity);
        }

		public override async Task DeleteAsync(T entity)
		{
			if (entity == null)
			{
				throw new System.ArgumentNullException(paramName: nameof(entity));
			}

			entity.IsDeleted = true;
			entity.DeleteDate = Models.Utility.Now;
			await System.Threading.Tasks.Task.Run(() =>
			{
				Update(entity);
			});
		}

		public override bool DeleteById(Guid id)
		{
			T entity = GetById(id);

			if (entity == null)
			{
				return false;
			}
			entity.IsDeleted = true;
			entity.DeleteDate = Models.Utility.Now;
			UpdateAsync(entity);

			return true;
		}

		public override async Task<bool> DeleteByIdAsync(Guid id)
		{
			T entity =
				await GetByIdAsync(id);

			if (entity == null)
			{
				return false;
			}

			entity.IsDeleted = true;
			entity.DeleteDate = Models.Utility.Now;
			await UpdateAsync(entity);

			return true;
		}

		public override IList<T> GetAll()
		{
			var result =
				DbSet.Where(current => current.IsDeleted == false).ToList();

			return result;
		}

		public override async Task<IList<T>> GetAllAsync()
		{
			var result =
				await DbSet.Where(current => current.IsDeleted == false).OrderBy(order => order.InsertDate).ToListAsync();

			return result;
		}

	}
}
