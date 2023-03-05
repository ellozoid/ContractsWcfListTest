using ContractManagerClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Refresh();
        }

        private void Refresh()
        {
            var contracts = contractsService.GetContracts();

            ContractsGrid.ItemsSource = contracts.Select(x => new ContractModel
            {
                Id = x.Id,
                Number = x.Number,
                CreationDate = x.CreateDate,
                LastUpdateDate = x.ModifyDate
            }).ToList();
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
            Refresh();
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
            var addContractWindow = new ContractAddWindow();
            if (addContractWindow.ShowDialog() == true)
            {
                var contract = addContractWindow.GetContract();
                var contracts = (List<ContractModel>)ContractsGrid.ItemsSource;
                contracts.Add(contract);

                contractsService.AddContract(new ContractsService.Models.Contract 
                { 
                    Number = contract.Number,
                    CreateDate = contract.CreationDate,
                    ModifyDate = contract.LastUpdateDate
                });

                Refresh();
            }
        }
    }
}