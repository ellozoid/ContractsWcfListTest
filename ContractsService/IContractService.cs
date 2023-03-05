using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ContractsService.Models;

namespace ContractsService
{
    [ServiceContract]
    public interface IContractService
    {
        [OperationContract]
        List<Contract> GetContracts();

        [OperationContract]
        bool UpdateContract(Contract contract);

        [OperationContract]
        void AddContract(Contract contract);
    }
}
