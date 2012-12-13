using System.Collections.Generic;
using Erc.Apple.Data.Models;
using System.Configuration;
using System;
using System.Linq;

namespace Erc.Apple.Data.Repositories
{
	public abstract class RepositoryBase<T> : IDisposable where T : EntityBase
	{
		private readonly AppleDataContext _context;

		public RepositoryBase()
		{
			_context = new AppleDataContext(ConfigurationManager.ConnectionStrings["SiteDBConnectionString"].ConnectionString);
		}

		public AppleDataContext Context
		{
			get { return _context; }
		}

		public IQueryable<T> GetAll()
		{
			return _context.GetTable<T>();
		}

		public T GetByID(int ID)
		{
			return _context.GetTable<T>().FirstOrDefault(e => e.ID.Equals(ID));
		}

		public void Save()
		{
			_context.SubmitChanges();
		}

		public void Add(T entity)
		{
			_context.GetTable<T>().InsertOnSubmit(entity);
		}

		public void Delete(T entity)
		{
			if (!entity.IsNew)
			{
				_context.GetTable<T>().Attach(entity);
				_context.GetTable<T>().DeleteOnSubmit(entity);
			}
		}

		public void Dispose()
		{
			if (_context != null)
				_context.Dispose();
		}
	}
}