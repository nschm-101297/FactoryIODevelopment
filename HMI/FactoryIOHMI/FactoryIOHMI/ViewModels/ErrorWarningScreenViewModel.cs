using FactoryIOHMI.Models;
using FactoryIOHMI.Services;
using FactoryIOHMI.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FactoryIOHMI.ViewModels
{
    public class ErrorWarningScreenViewModel : INotifyPropertyChanged
    {
        #region Properties
        private int _selectedErrorWarning;

        public int SelectedErrorWarning
        {
            get { return _selectedErrorWarning; }
            set 
            { 
                _selectedErrorWarning = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedErrorWarning)));
            }
        }

        public ObservableCollection<IErrorWarning> ErrorWarnings { get; set; }
        public AdsClientService ADSClient { get; private set; }
        public ICommand QuitAll { get; set; }
        public ICommand Quit { get; set; }

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public ErrorWarningScreenViewModel()
        {
            SelectedErrorWarning = -1;
            ErrorWarnings = new ObservableCollection<IErrorWarning>();
            ADSClient = null;
            QuitAll = new RelayCommand(QuitAllExecute, QuitAllCanExecute);
            Quit = new RelayCommand(QuitExecute, QuitCanExecute);
        }
        public ErrorWarningScreenViewModel(AdsClientService adsClient)
        {
            SelectedErrorWarning = -1;
            ErrorWarnings = new ObservableCollection<IErrorWarning>();
            ADSClient = adsClient;
            QuitAll = new RelayCommand(QuitAllExecute, QuitAllCanExecute);
            Quit = new RelayCommand(QuitExecute, QuitCanExecute);
            CommissingMethod();
        }
        #endregion

        #region Command-Methods
        public void QuitAllExecute(object par)
        {

        }
        public bool QuitAllCanExecute(object par)
        {
            return true;
        }
        public void QuitExecute(object par)
        {

        }
        public bool QuitCanExecute(object par)
        {
            return true;
        }
        #endregion

        #region Methods
        private void CommissingMethod()
        {
            ErrorWarnings.Add(new Error("Not-Aus betätigt! Bedienpanel 1!"));
            ErrorWarnings.Add(new Error("Schutzgitter durchbrochen Schublade 3!"));
            ErrorWarnings.Add(new Error("Druckabfall Hauptventil!"));
            ErrorWarnings.Add(new Warning("Verschleißzähler Bolzen 1 Warngrenze erreicht!"));
            ErrorWarnings.Add(new Warning("Temperatur erste Warngrenze erreicht!"));
            ErrorWarnings.Add(new Warning("Füllstand Klebefass Min-Level erreicht!"));
        }
        #endregion
    }
}
