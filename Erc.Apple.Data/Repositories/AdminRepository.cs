using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Erc.Apple.Data.Repositories
{
	public class AdminRepository : RepositoryBase<Erc.Apple.Data.Models.Admin>
	{
		public Erc.Apple.Data.Models.Admin GetByEmail(string email)
		{
			if (string.IsNullOrEmpty(email))
				return null;

			return (from a in this.GetAll() where a.Email == email select a) .FirstOrDefault();
		}
	}
}
