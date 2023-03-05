using ContractManagerClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ContractManagerClient
{
    /// <summary>
    /// Логика взаимодействия для ContractAddWindow.xaml
    /// </summary>
    public partial class ContractAddWindow : Window
    {
        private readonly AddContractViewModel _viewModel;

        public ContractAddWindow()
        {
            InitializeComponent();
            _viewModel = new AddContractViewModel(); ;
            DataContext = _viewModel;
        }

        public ContractModel GetContract()
        {
            return new ContractModel
            {
                CreationDate = DateTime.Now,
                Number = _viewModel.Number,
                LastUpdateDate = DateTime.Now
            };
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
