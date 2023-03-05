using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ContractsService.Data.Models;

namespace ContractsService.Data.Repositories
{
    internal class ContractsRepository : IRepository<ContractEntity>
    {
        private readonly ApplicationContext _context;
        internal ContractsRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public List<TResult> Select<TResult>(Expression<Func<ContractEntity, TResult>> selector)
        {
            if (selector == null) 
                throw new ArgumentNullException(nameof(selector));

            return _context.Contracts.Select(selector).ToList();
        }

        public bool Update(ContractEntity item)
        {
            var entity = _context.Contracts.FirstOrDefault(x => x.Id == item.Id);
            if (entity == null)
            {
                return false;
            }

            _context.Entry(entity).CurrentValues.SetValues(item);
            return true;
        }

        public void Add(ContractEntity item)
        {
            _context.Contracts.Add(item);
        }
    }
}