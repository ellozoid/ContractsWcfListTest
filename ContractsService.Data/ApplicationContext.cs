using ContractsService.Data.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace ContractsService.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(string connectionString)
            : base(connectionString)
        {

        }

        public virtual DbSet<ContractEntity> Contracts { get; set; }
    }
}