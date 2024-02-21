using Application.Services.Repositories;
using Core.Presistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class BrandRepository : EFRepositoryBase<Brand, Guid, BaseDbContext>, IBrandRepository
{
	public BrandRepository(BaseDbContext context) : base(context)
	{
	}
}
