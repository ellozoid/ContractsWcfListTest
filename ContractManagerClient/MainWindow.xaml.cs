using ContractManagerClient.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Windows;

namespace ContractManagerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly ContractServiceClient contractsService;
        public MainWindow()
        {
            InitializeComponent();

            contractsService = GetClientInstance();

            var contracts = contractsService.GetContracts();

            ContractsGrid.ItemsSource = contracts.Select(x => new ContractModel 
            { 
                Number = x.Number,
                CreationDate = x.CreateDate,
                LastUpdateDate = x.ModifyDate
            });
        }

        private ContractServiceClient GetClientInstance()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            var serviceAddress = ConfigurationManager.AppSettings["ContractsServiceAddress"];
            EndpointAddress address =
               new EndpointAddress(serviceAddress);
            return new ContractServiceClient(binding, address);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            var contracts = contractsService.GetContracts();

            ContractsGrid.ItemsSource = contracts.Select(x => new ContractModel
            {
                Number = x.Number,
                CreationDate = x.CreateDate,
                LastUpdateDate = x.ModifyDate
            });
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            foreach (var contract in ContractsGrid.Items.OfType<ContractModel>())
            {
                contractsService.UpdateContract(new ContractsService.Models.Contract
                {
                    Id = contract.Id,
                    ModifyDate = contract.LastUpdateDate,
                    CreateDate = contract.CreationDate,
                    Number = contract.Number
                });
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            foreach (var contract in ContractsGrid.Items.OfType<ContractModel>())
            {
                contractsService.UpdateContract(new ContractsService.Models.Contract
                {
                    Id = contract.Id,
                    ModifyDate = contract.LastUpdateDate,
                    CreateDate = contract.CreationDate,
                    Number = contract.Number
                });
            }
        }
    }
}