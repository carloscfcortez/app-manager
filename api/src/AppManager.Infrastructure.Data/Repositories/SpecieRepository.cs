﻿using System.Threading.Tasks;
using AppManager.Domain.Entities;
using AppManager.Domain.Interfaces;
using AppManager.Infrastructure.Data.Context;
using System.Linq;

namespace AppManager.Infrastructure.Data.Repositories
{
    public class SpecieRepository : RepositoryBase<Specie>, ISpecieRepository
    {
        public SpecieRepository(DataContext context) : base(context) { }
    }
}
