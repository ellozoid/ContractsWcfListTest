using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagerClient.Models
{
    public class ContractModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime CreationDate { get; set; }

        private DateTime lastUpdateDate;
        public DateTime LastUpdateDate
        {
            get => lastUpdateDate;
            set
            {
                lastUpdateDate = value;
                OnPropertyChanged(nameof(LastUpdateDate));
                OnPropertyChanged(nameof(IsRelevant));
            }
        }

        public bool IsRelevant => (DateTime.Now - LastUpdateDate).TotalDays < 60;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
