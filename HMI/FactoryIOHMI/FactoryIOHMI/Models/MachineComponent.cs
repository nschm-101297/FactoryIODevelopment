using FactoryIOHMI.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FactoryIOHMI.Models
{
    public class MachineComponent
    {
        #region Properties
        public string Name { get; set; }
        public string LinkPage { get; set; }
        public ICommand OpenMachineComponent { get; set; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public MachineComponent()
        {
            Name = String.Empty;
            LinkPage = String.Empty;
            OpenMachineComponent = new RelayCommand(OpenMachineComponentExecute, OpenMachineComponentCanExecute);
        }
        public MachineComponent(string name, string linkPage)
        {
            Name = name;
            LinkPage = linkPage;
            OpenMachineComponent = new RelayCommand(OpenMachineComponentExecute, OpenMachineComponentCanExecute);
        }
        #endregion

        #region Command-Methods
        public void OpenMachineComponentExecute(object par)
        {

        }
        public bool OpenMachineComponentCanExecute(object par)
        {
            return true;
        }
        #endregion

        #region Methods

        #endregion



    }
}
