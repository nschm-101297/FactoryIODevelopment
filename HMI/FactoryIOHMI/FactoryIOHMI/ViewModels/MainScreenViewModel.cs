using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryIOHMI.Views;
using FactoryIOHMI.Commands;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TwinCAT;
using TwinCAT.Ads;
using TwinCAT.Ads.TypeSystem;
using TwinCAT.TypeSystem;
using System.Windows;
using FactoryIOHMI.Services;
using FactoryIOHMI.Views;

namespace FactoryIOHMI.ViewModels
{
    public class MainScreenViewModel : INotifyPropertyChanged
    {
        #region Properties
        private AdsClientService _runtimeADSClient;
        private bool _runtimeConnected;

        public bool RuntimeConnected
        {
            get { return _runtimeConnected; }
            set 
            { 
                _runtimeConnected = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RuntimeConnected)));
            }
        }

        private object _currentSubScreen;

        public object CurrentSubScreen
        {
            get { return _currentSubScreen; }
            set 
            { 
                _currentSubScreen = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentSubScreen)));
            }
        }
        private ImageSource _currentMachineState;

        public ImageSource CurrentMachineState
        {
            get { return _currentMachineState; }
            set 
            { 
                _currentMachineState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentMachineState)));
            }
        }
        public MainScreen CurrentWindow { get; private set; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public MainScreenViewModel()
        {
            CurrentMachineState = LoadImageCurrentMachineState();
            RuntimeConnected = ConnectRuntime();
            CurrentSubScreen = new HomeScreenViewModel(this, _runtimeADSClient);
            CurrentWindow = null;
        }
        public MainScreenViewModel(MainScreen screen)
        {
            CurrentMachineState = LoadImageCurrentMachineState();
            RuntimeConnected = ConnectRuntime();
            CurrentSubScreen = new HomeScreenViewModel(this, _runtimeADSClient);
            CurrentWindow = screen;
        }
        #endregion

        #region Command-Methods

        #endregion

        #region Methods
        private bool ConnectRuntime()
        {
            bool connectionSucessfull = false;
            try
            {
                _runtimeADSClient = new AdsClientService();
                _runtimeADSClient.ClientConnect("199.4.42.250.1.1", 851);
                connectionSucessfull = _runtimeADSClient.IsConnected();
                _runtimeADSClient.ConnectionStateChanged += RuntimeClient_ConnectionStateChanged;
            }
            catch (Exception ex)
            {
                _runtimeADSClient = null;
                connectionSucessfull = false;
            }
            return connectionSucessfull;
        }

        private void RuntimeClient_ConnectionStateChanged(object? sender, ConnectionStateChangedEventArgs e)
        {
            ConnectionState connectionStateNew = e.NewState;
            RuntimeConnected = connectionStateNew == ConnectionState.Connected;
        }

        private ImageSource LoadImageCurrentMachineState()
        {
            Uri uriMachineState = new Uri(@"\Images\Machine_Stop.png", UriKind.Relative);
            BitmapImage bitmapCurrentMachineState = new BitmapImage(uriMachineState);
            ImageSource imageCurrentMachineState = bitmapCurrentMachineState;
            return imageCurrentMachineState;
        }
        #endregion
    }
}
