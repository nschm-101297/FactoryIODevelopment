using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FactoryIOHMI.Commands;
using FactoryIOHMI.Services;
using TwinCAT.Ads;

namespace FactoryIOHMI.ViewModels
{
    public class SettingScreenViewModel : INotifyPropertyChanged
    {
        #region Properties
        private string _connectionState;

        public string ConnectionState
        {
            get { return _connectionState; }
            set 
            { 
                _connectionState = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConnectionState)));
            }
        }
        private string _amsNetId;

        public string AMSNetId
        {
            get { return _amsNetId; }
            set 
            { 
                _amsNetId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AMSNetId)));
            }
        }
        private string _portNumber;

        public string PortNumber
        {
            get { return _portNumber; }
            set 
            { 
                _portNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PortNumber)));
            }
        }
        private string _timeout;

        public string Timeout
        {
            get { return _timeout; }
            set 
            { 
                _timeout = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Timeout)));
            }
        }

        public AdsClientService ADSClient { get; private set; }
        public MainScreenViewModel ParentScreenViewModel { get; private set; }
        public ICommand CloseRuntime { get; set; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public SettingScreenViewModel(MainScreenViewModel parentScreenViewModel, AdsClientService adsClient)
        {
            ConnectionState = String.Empty;
            AMSNetId = String.Empty;
            PortNumber = String.Empty;
            Timeout = String.Empty;
            ADSClient = adsClient;
            ParentScreenViewModel = parentScreenViewModel;
            CloseRuntime = new RelayCommand(CloseRuntimeExecute, CloseRuntimeCanExecute);
            LoadConnectionInformation();
        }
        #endregion

        #region Command-Methods
        public void CloseRuntimeExecute(object parameter)
        {
            ParentScreenViewModel.CurrentWindow.Close();
        }
        public bool CloseRuntimeCanExecute(object parameter)
        {
            return true;
        }
        #endregion

        #region Methods
        private void LoadConnectionInformation()
        {
            if (ADSClient == null)
            {
                ConnectionState = "Verbindung nicht aufgebaut";
                AMSNetId = String.Empty;
                PortNumber = String.Empty;
                Timeout = String.Empty;
            }
            if (ADSClient.IsConnected())
            {
                ConnectionState = "Verbunden";
            }
            else
            {
                ConnectionState = "Nicht verbunden";
            }
            AMSNetId = ADSClient.GetAMSNetId();
            PortNumber = ADSClient.GetPortNumber();
            Timeout = ADSClient.GetTimeout();            
        }
        #endregion
    }
}
