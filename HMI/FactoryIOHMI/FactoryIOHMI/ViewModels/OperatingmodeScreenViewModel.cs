using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FactoryIOHMI.Commands;
using FactoryIOHMI.Models;
using FactoryIOHMI.Services;

namespace FactoryIOHMI.ViewModels
{
    class OperatingmodeScreenViewModel : INotifyPropertyChanged
    {
        #region Properties
        public AdsClientService ADSClient { get; private set; }
        public ObservableCollection<OperatingMode> MachineSegmentsOperatingMode { get; set; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public OperatingmodeScreenViewModel()
        {
            ADSClient = null;
            MachineSegmentsOperatingMode = new ObservableCollection<OperatingMode>();
            Commissingmethod();
        }
        public OperatingmodeScreenViewModel(AdsClientService adsClient)
        {
            ADSClient = adsClient;
            MachineSegmentsOperatingMode = new ObservableCollection<OperatingMode>();
            Commissingmethod();
        }
        #endregion

        #region Command-Methods

        #endregion

        #region Methods
        public void Commissingmethod()
        {
            MachineSegmentsOperatingMode.Add(new OperatingMode("Förderbänder"));
            MachineSegmentsOperatingMode.Add(new OperatingMode("Hochregallager"));
            MachineSegmentsOperatingMode.Add(new OperatingMode("Aufzug"));
            MachineSegmentsOperatingMode.Add(new OperatingMode("Portale"));
            MachineSegmentsOperatingMode.Add(new OperatingMode("Umsetzer"));
        }
        #endregion
    }
}
