using System;
using System.Collections.Generic;
using System.Text;

namespace AppManager.Infrastructure.Data.Context
{
    public static class DbInitialize
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
