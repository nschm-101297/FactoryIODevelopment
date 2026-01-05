using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT;
using TwinCAT.Ads.TypeSystem;
using TwinCAT.TypeSystem;

namespace FactoryIOHMI.Services
{
    public sealed class Subscription : IDisposable
    {
        #region Properties
        public string VariableName { get; set; }
        private Symbol _symbol;
        private EventHandler<ValueChangedEventArgs> _variableChangedHandler;
        private bool _disposed;
        #endregion

        #region Events

        #endregion

        #region Constructors
        public Subscription(string variableName, Symbol symbol, EventHandler<ValueChangedEventArgs> variableChangedHandler)
        {
            VariableName = variableName;
            _symbol = symbol;
            _variableChangedHandler = variableChangedHandler;
        }
        #endregion

        #region Command-Methods

        #endregion

        #region Methods
        public void Dispose()
        {
            if(_disposed) return;
            _disposed = true;

            _symbol.ValueChanged -= _variableChangedHandler;
        }
        #endregion
    }
}
