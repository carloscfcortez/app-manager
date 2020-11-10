﻿using System.Threading.Tasks;
using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces;
using AppManager.Infrastructure.Data.Context;
using System.Linq;

namespace AppManager.Infrastructure.Data.Repositories
{
  public class HarvestRepository : RepositoryBase<Harvest>, IHarvestRepository
  {
        public HarvestRepository(DataContext context): base(context) { }
    }
}
