using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TwinCAT;
using TwinCAT.Ads;

namespace FactoryIOHMI.Services
{
    public sealed class AdsClientService
    {
        #region Properties
        private AdsClient _adsClient;
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
        #endregion

        #region Eventhandler
        private void RuntimeClient_ConnectionStateChanged(object? sender, ConnectionStateChangedEventArgs e)
        {
            ConnectionStateChanged?.Invoke(this, e);
        }
        #endregion
    }
}
