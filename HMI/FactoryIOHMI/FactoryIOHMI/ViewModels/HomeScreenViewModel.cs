using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FactoryIOHMI.Commands;
using FactoryIOHMI.Services;

namespace FactoryIOHMI.ViewModels
{
    public class HomeScreenViewModel
    {
        #region Properties
        public ICommand HomeScreen {  get; set; }
        public ICommand WarningScreen { get; set; }
        public ICommand SettingScreen { get; set; }
        public MainScreenViewModel ParentViewModel { get; private set; }
        public AdsClientService ADSClient { get; private set; }

        #endregion

        #region Events

        #endregion

        #region Constructors
        public HomeScreenViewModel()
        {
            HomeScreen = new RelayCommand(HomeScreenExecute, HomeScreenCanExecute);
            WarningScreen = new RelayCommand(WarningScreenExecute, WarningScreenCanExecute);
            SettingScreen = new RelayCommand(SettingScreenExecute, SettingScreenCanExecute);
            ParentViewModel = null;
            ADSClient = null;
        }
        public HomeScreenViewModel(MainScreenViewModel viewModel)
        {
            HomeScreen = new RelayCommand(HomeScreenExecute, HomeScreenCanExecute);
            WarningScreen = new RelayCommand(WarningScreenExecute, WarningScreenCanExecute);
            SettingScreen = new RelayCommand(SettingScreenExecute, SettingScreenCanExecute);
            ParentViewModel = viewModel;
            ADSClient = null;
        }
        public HomeScreenViewModel(MainScreenViewModel viewModel, AdsClientService adsClient)
        {
            HomeScreen = new RelayCommand(HomeScreenExecute, HomeScreenCanExecute);
            WarningScreen = new RelayCommand(WarningScreenExecute, WarningScreenCanExecute);
            SettingScreen = new RelayCommand(SettingScreenExecute, SettingScreenCanExecute);
            ParentViewModel = viewModel;
            ADSClient = adsClient;
        }
        #endregion

        #region Command-Methods
        public void HomeScreenExecute(object parameter)
        {
            if (ParentViewModel == null)
            {
                return;
            }
            ParentViewModel.CurrentSubScreen = new OverviewComponentsScreenViewModel(ParentViewModel);
        }
        public bool HomeScreenCanExecute(object parameter)
        {
            return true;
        }
        public void WarningScreenExecute(object parameter)
        {
            if (ParentViewModel == null)
            {
                return;
            }
            ParentViewModel.CurrentSubScreen = new ErrorWarningScreenViewModel(ADSClient);

        }
        public bool WarningScreenCanExecute(object parameter)
        {
            return true;
        }
        public void SettingScreenExecute(object parameter)
        {
            if(ParentViewModel == null)
            {
                return;
            }
            ParentViewModel.CurrentSubScreen = new SettingScreenViewModel(ParentViewModel, ADSClient);
        }
        public bool SettingScreenCanExecute(object parameter)
        {
            return true;
        }
        #endregion

        #region Methods

        #endregion
    }
}
