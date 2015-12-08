using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FernCashHandler.CashInsightAPI;

namespace FernCashHandler
{
    public class CashHandler
    {
        CashInsightAPIServicePortTypeClient client = new CashInsightAPIServicePortTypeClient("CashInsightAPIServiceHttpSoap11Endpoint");
        StringResult session = new StringResult();

        //public CashInsightAPIServicePortTypeClient Start()
        //{
        //    CashInsightAPIServicePortTypeClient client = new CashInsightAPIServicePortTypeClient("CashInsightAPIServiceHttpSoap11Endpoint");

        //    return client;
        //}

        //public StringResult Login(string username, string password)
        //{
        //    StringResult session = client.logon(username, password, false);
            
        //    return session;
        //}

        public void Login(string username, string password)
        {
            session = client.logon(username, password, false);
        }

        public void Withdrawal(long amount, string currency, int deviceNumber, int position, bool authorisationRequired, string secondUsername, string secondPassword)
        {
            DeviceList deviceList = GetDeviceList();
            Device device = new Device();

            device = deviceList.data[deviceNumber];

            StringResult dispenseTransaction = new StringResult();

            if (authorisationRequired)
            {
                dispenseTransaction = client.startTransaction(session.data, amount, currency, deviceList, position, secondUsername, secondPassword, 0);
            }
            else
            {
                dispenseTransaction = client.startTransaction(session.data, amount, currency, deviceList, position, "", "", 0);
            }

            string transactionID = dispenseTransaction.data;

            IntegerListResult integerListResult = client.getMixes(session.data, device);
            IntegerList integerList = integerListResult.data;
            int algorithm = Convert.ToInt32(integerList.list[0]);

            //TODO: HANDLE REMAINDER AFTER A MIX IS GENERATED
            MixResult mixResult = client.generateMix(session.data, transactionID, amount, currency, device, algorithm);
            Mix mix = mixResult.data;
            
            Denomination mixDenomination = mix.mix;

            DenominationResult dispenseResult = client.dispense(session.data, transactionID, mixDenomination, device);

            if (dispenseResult.resultCode == 0)
            {
                StandardResult transactionResult = client.endTransaction(session.data, transactionID, 0);
            }
            else
            {
                StandardResult transactionResult = client.endTransaction(session.data, transactionID, 1);
            }
        }

        public void Deposit(long amount, string currency, int deviceNumber, int position, bool authorisationRequired, string secondUsername, string secondPassword)
        {
            DeviceList deviceList= GetDeviceList();
            Device device = new Device();

            device = deviceList.data[deviceNumber];

            StringResult depositTransaction = new StringResult();

            if (authorisationRequired)
            {
                depositTransaction = client.startTransaction(session.data, amount, currency, deviceList, position, secondUsername, secondPassword, 1);
            }
            else
            {
                depositTransaction = client.startTransaction(session.data, amount, currency, deviceList, position, "", "", 1);
            }

            string transactionID = depositTransaction.data;

            StandardResult depositResult = client.cashInStart(session.data, transactionID, device);
            DenominationResult cashin = client.cashIn(session.data, transactionID, device);
            DenominationResult cashinResult = client.cashInEnd(session.data, transactionID, device);

            if (depositTransaction.resultCode == 0)
            {
                StandardResult transactionResult = client.endTransaction(session.data, transactionID, 0);
            }
            else
            {
                StandardResult transactionResult = client.endTransaction(session.data, transactionID, 1);
            }
        }

        //public DeviceListResult GetDeviceList()
        //{
        //    DeviceListResult deviceListResult = client.listDevices(session.data);
        //    return deviceListResult;
        //}

        public DeviceList GetDeviceList()
        {
            DeviceListResult deviceListresult = client.listDevices(session.data);
            DeviceList deviceList = new DeviceList();

            deviceList.data = deviceListresult.data.data;

            return deviceList;
        }

        public MixResult CreateMix(string transactionID, long amount, string currency, Device device, int algorithm)
        {
            MixResult mixResult =  client.generateMix(session.data, transactionID, amount, currency, device, algorithm);
            return mixResult;
        }
    }
}
