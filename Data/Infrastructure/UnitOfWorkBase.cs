﻿
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public abstract class UnitOfWorkBase : Object, IUnitOfWorkBase
    {
		public UnitOfWorkBase(Tools.Options options) : base()
		{
			Options = options;
		}
		protected Tools.Options Options { get; set; }
		private DatabaseContext _databaseContext;

		/// <summary>
		/// Lazy Loading = Lazy Initialization
		/// </summary>
		internal DatabaseContext DatabaseContext
		{
			get
			{
				if (_databaseContext == null)
				{
					var optionsBuilder =
						new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<DatabaseContext>();

					switch (Options.Provider)
					{
						case Tools.Enums.Provider.SqlServer:
							{
								optionsBuilder.UseSqlServer
									(connectionString: Options.ConnectionString).LogTo(Console.Write, Microsoft.Extensions.Logging.LogLevel.Information);

								break;
							}

						case Tools.Enums.Provider.MySql:
							{
								//optionsBuilder.UseMySql
								//	(connectionString: Options.ConnectionString);

								break;
							}

						case Tools.Enums.Provider.Oracle:
							{
								//optionsBuilder.UseOracle
								//	(connectionString: Options.ConnectionString);

								break;
							}

						case Tools.Enums.Provider.PostgreSQL:
							{
								//optionsBuilder.UsePostgreSQL
								//	(connectionString: Options.ConnectionString);

								break;
							}

						case Tools.Enums.Provider.InMemory:
							{
								//optionsBuilder.UseInMemoryDatabase(databaseName: "Temp");

								break;
							}

						default:
							{
								break;
							}
					}

					_databaseContext =
						new DatabaseContext(options: optionsBuilder.Options);
				}

				return _databaseContext;
			}
		}

		RepositoryBase<T> IUnitOfWorkBase.GetRepository<T>()
		{
			return new RepositoryBase<T>(databaseContext: DatabaseContext);
		}

		public virtual void Save()
		{
			
			DatabaseContext.SaveChanges();
		}

		public virtual async System.Threading.Tasks.Task SaveAsync()
		{
			await DatabaseContext.SaveChangesAsync();
		}

		// **********
		/// <summary>
		/// To detect redundant calls
		/// </summary>
		public bool IsDisposed { get; protected set; }
		// **********

		/// <summary>
		/// Public implementation of Dispose pattern callable by consumers.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);

			System.GC.SuppressFinalize(this);
		}

		/// <summary>
		/// https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (IsDisposed)
			{
				return;
			}

			if (disposing)
			{
				// TODO: dispose managed state (managed objects).

				if (_databaseContext != null)
				{
					_databaseContext.Dispose();
					_databaseContext = null;
				}
			}

			// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
			// TODO: set large fields to null.

			IsDisposed = true;
		}

		~UnitOfWorkBase()
		{
			Dispose(false);
		}
	}
}