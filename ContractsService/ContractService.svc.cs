using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using ContractsService.Data.Models;
using ContractsService.Data.Repositories;
using ContractsService.Models;

namespace ContractsService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public sealed class ContractService : IContractService, IDisposable
    {
        private readonly ApplicationUnitOfWork _applicationUoW;
        private bool _disposed;

        public ContractService()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ApplicationContext"].ConnectionString;
            _applicationUoW = new ApplicationUnitOfWork(connectionString);
            _disposed = false;
        }
        
        public List<Contract> GetContracts()
        {
            return _applicationUoW.ContractRepository
                .Select(x => new Contract
            {
                Id = x.Id,
                CreateDate = x.CreateDate,
                ModifyDate = x.ModifyDate,
                Number = x.Number
            }); 
        }

        public bool UpdateContract(Contract contract)
        {
            var result = _applicationUoW.ContractRepository.Update(new ContractEntity
            {
                Id = contract.Id,
                CreateDate = contract.CreateDate,
                ModifyDate = contract.ModifyDate,
                Number = contract.Number
            });

            _applicationUoW.Save();

            return result;
        }

        public void AddContract(Contract contract)
        {
            _applicationUoW.ContractRepository.Add(new ContractEntity
            {
                CreateDate = contract.CreateDate,
                ModifyDate = contract.ModifyDate,
                Number = contract.Number
            });

            _applicationUoW.Save();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _applicationUoW.Dispose();
            _disposed = true;
        }
    }
}
