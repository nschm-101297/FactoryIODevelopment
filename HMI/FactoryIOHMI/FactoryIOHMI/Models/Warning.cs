using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryIOHMI.Models
{
    public class Warning : IErrorWarning, INotifyPropertyChanged
    {
        #region Properties
        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsActive)));
            }
        }
        public string Message { get; set; }
        public DateTime Activation { get; set; }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructors
        public Warning()
        {
            IsActive = true;
            Message = String.Empty;
            Activation = new DateTime();
        }
        public Warning(string message)
        {
            IsActive = true;
            Message = message;
            Activation = DateTime.Now;
        }
        #endregion

        #region Command-Methods

        #endregion

        #region Methods

        #endregion
    }
}
