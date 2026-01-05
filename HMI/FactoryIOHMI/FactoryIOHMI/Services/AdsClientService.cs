using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TwinCAT;
using TwinCAT.Ads;
using TwinCAT.Ads.TypeSystem;
using TwinCAT.TypeSystem;

namespace FactoryIOHMI.Services
{
    public sealed class AdsClientService
    {
        #region Properties
        private AdsClient _adsClient;
        private ISymbolLoader _symbolLoader;
        private ObservableCollection<Subscription> _subscriptions = new ObservableCollection<Subscription>();
        #endregion

        #region Events
        public EventHandler<ConnectionStateChangedEventArgs>? ConnectionStateChanged;
        #endregion

        #region Constructors
        public AdsClientService()
        {
            _adsClient = new AdsClient();
        }
        #endregion

        #region Command-Methods

        #endregion

        #region Methods
        public void ClientConnect(string amsNetId, int portNumber)
        {
            AmsNetId netId = new AmsNetId(amsNetId);
            _adsClient.Connect(netId, portNumber);
            _symbolLoader = SymbolLoaderFactory.Create(_adsClient, SymbolLoaderSettings.Default);
        }
        public bool IsConnected()
        {
            return _adsClient.IsConnected;
        }
        public StateInfo GetConnectionState()
        {
            return _adsClient.ReadState();
        }
        public async Task<ResultValue<T>> ReadValuevOfVariable<T>(string nameVariable, CancellationToken token)
        {
            ResultValue<T> readResult = await _adsClient.ReadValueAsync<T>(nameVariable, token);
            return readResult;
        }
        public async Task<ResultWrite> WriteValuevOfVariable(string nameVariable, object writeValue,CancellationToken token)
        {
            ResultWrite writeResult = await _adsClient.WriteValueAsync(nameVariable, writeValue, token);
            return writeResult;
        }
        public IDisposable? SubscripeVariable(string symbolName, Action<object?> onChangedEventHandler, AdsTransMode transMode = AdsTransMode.OnChange, int updateTime = 500)
        {
            if(_symbolLoader == null)
            {
                MessageBox.Show("Erst Verbindung zum ADS-Client aufbauen!", 
                                "ADS-Verbindung fehlt ...",
                                MessageBoxButton.OK, 
                                MessageBoxImage.Error);
                return null;
            }

            Symbol symbol = (Symbol)_symbolLoader.Symbols[symbolName];
            symbol.NotificationSettings = new NotificationSettings(transMode, updateTime, 0);

            EventHandler<ValueChangedEventArgs> valueVariableChangedEventHandler = (_, e) =>
            {
                onChangedEventHandler(e.Value);
            };

            symbol.ValueChanged += valueVariableChangedEventHandler;

            Subscription createdSubscription = new Subscription(symbolName, symbol, valueVariableChangedEventHandler);
            _subscriptions.Add(createdSubscription);

            return createdSubscription;
        }
        #endregion

        #region Eventhandler
        private void RuntimeClient_ConnectionStateChanged(object? sender, ConnectionStateChangedEventArgs e)
        {
            ConnectionStateChanged?.Invoke(this, e);
        }
        #endregion
    }
}
