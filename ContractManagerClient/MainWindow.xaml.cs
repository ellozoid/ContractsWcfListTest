using System;
using System.Diagnostics.Contracts;
using System.Windows;

namespace ContractManagerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly IContractsService contractsService = new ContractsServiceClient();
        
        public MainWindow()
        {
            InitializeComponent();
            var contracts = contractsService.GetContracts();
            foreach (var contract in contracts)
            {
                contract.IsRelevant = (DateTime.Now - contract.LastUpdateDate).TotalDays < 60;
            }
            ContractsGrid.ItemsSource = contracts;
        }
        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var contract in ContractsGrid.Items)
            {
                contractsService.UpdateContract((Contract)contract);
            }
        }
    }
}