using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FactoryIOHMI.Commands;

namespace FactoryIOHMI.Models
{
    public class OperatingMode
    {
        #region Properties
        public string GroupNameMachine { get; set; }
        public ICommand Manuel { get; set; }
        public ICommand Automatic { get; set; }
        public ICommand Start { get; set; }
        public ICommand Stop { get; set; }
        public ICommand Homing { get; set; }
        public ICommand Reset { get; set; }
        #endregion

        #region Events

        #endregion

        #region Constructors
        public OperatingMode()
        {
            GroupNameMachine = String.Empty;
            Manuel = new RelayCommand(ManuelExecute, ManuelCanExecute);
            Automatic = new RelayCommand(AutomaticExecute, AutomaticCanExecute);
            Start = new RelayCommand(StartExecute, StartCanExecute);
            Stop = new RelayCommand(StopExecute, StopCanExecute);
            Homing = new RelayCommand(HomingExecute, HomingCanExecute);
            Reset = new RelayCommand(ResetExecute, ResetCanExecute);
        }
        public OperatingMode(string groupNameMachine)
        {
            GroupNameMachine = groupNameMachine;
            Manuel = new RelayCommand(ManuelExecute, ManuelCanExecute);
            Automatic = new RelayCommand(AutomaticExecute, AutomaticCanExecute);
            Start = new RelayCommand(StartExecute, StartCanExecute);
            Stop = new RelayCommand(StopExecute, StopCanExecute);
            Homing = new RelayCommand(HomingExecute, HomingCanExecute);
            Reset = new RelayCommand(ResetExecute, ResetCanExecute);
        }
        #endregion

        #region Command-Methods
        public void ManuelExecute(object par)
        {

        }
        public bool ManuelCanExecute(object par)
        {
            return true;
        }
        public void AutomaticExecute(object par)
        {

        }
        public bool AutomaticCanExecute(object par)
        {
            return true;
        }
        public void StartExecute(object par)
        {

        }
        public bool StartCanExecute(object par)
        {
            return true;
        }
        public void StopExecute(object par)
        {

        }
        public bool StopCanExecute(object par)
        {
            return true;
        }
        public void HomingExecute(object par)
        {

        }
        public bool HomingCanExecute(object par)
        {
            return true;
        }
        public void ResetExecute(object par)
        {

        }
        public bool ResetCanExecute(object par)
        {
            return true;
        }
        #endregion

        #region Methods

        #endregion
    }
}
