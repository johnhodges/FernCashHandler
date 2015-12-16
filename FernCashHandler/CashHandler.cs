using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FernCashHandler.CashInsightAPI;
using System.Data;

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
            DeviceList deviceList = GetDeviceListInternal();
            Device device = new Device();
            long remainder = 0;

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

            MixResult mixResult = client.generateMix(session.data, transactionID, amount, currency, device, algorithm);
            Mix mix = mixResult.data;

            if (mix.remainder > 0)
            {
                remainder = mixResult.data.remainder;
            }

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

        public DataTable CreateMix(long amount, string currency, int deviceNumber, int position, bool authorisationRequired, string secondUsername, string secondPassword)
        {
            DeviceList deviceList = GetDeviceListInternal();
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

            MixResult mixResult = client.generateMix(session.data, transactionID, amount, currency, device, algorithm);
            Mix mix = mixResult.data;

            DataTable dtMix = new DataTable();

            dtMix.Columns.Add("Requested", typeof(int));
            dtMix.Columns.Add("Remainder", typeof(long));

            for (int i = 0; i < mix.mix.items.Length; i++ )
            {
                var newRow = dtMix.NewRow();
                newRow["Requested"] = mix.mix.items[i].count;
                newRow["Remainder"] = mix.remainder;
                dtMix.Rows.Add(newRow);
            }

            if (dispenseTransaction.resultCode == 0)
            {
                StandardResult transactionResult = client.endTransaction(session.data, transactionID, 0);
            }
            else
            {
                StandardResult transactionResult = client.endTransaction(session.data, transactionID, 1);
            }

            return dtMix;
        }

        //TODO: Work out how to account for new input values - generate new mix, handle remainder - NEED TO DO CASHBOX DISPENSE
        //TODO: Display grand total of withdrawal as well as unallocated cash. Prevent dispense unless unallocated cash is equal to 0, and grand total is equal to requested amount.
        public void Recalculate(long amount, string currency, int deviceNumber, int position, bool authorisationRequired, string secondUsername, string secondPassword)
        {
            DeviceList deviceList = GetDeviceListInternal();
            Device device = new Device();
            long remainder = 0;

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

            //TODO: Handle remainder after a mix is generated, display along with mix generation screen.
            MixResult mixResult = client.generateMix(session.data, transactionID, amount, currency, device, algorithm);
            Mix mix = mixResult.data;

            if (mix.remainder > 0)
            {
                remainder = mixResult.data.remainder;
            }

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

        //TODO: Handle difference between amount entered, and amount put into machine. eg. Entered amount of 10, but put in a 5 and a 10 note.
        //TODO: Display deposit before it is confirmed.
        public void Deposit(long amount, string currency, int deviceNumber, int position, bool authorisationRequired, string secondUsername, string secondPassword)
        {
            DeviceList deviceList= GetDeviceListInternal();
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

        public DeviceList GetDeviceListInternal()
        {
            DeviceListResult deviceListresult = client.listDevices(session.data);
            DeviceList deviceList = new DeviceList();

            deviceList.data = deviceListresult.data.data;

            return deviceList;
        }

        public List<string> GetDeviceListExternal()
        {
            DeviceListResult deviceListresult = client.listDevices(session.data);
            DeviceList deviceList = new DeviceList();

            deviceList.data = deviceListresult.data.data;

            List<string> deviceNames = new List<string>();

            for (int i = 0; i < deviceList.data.Length; i++ )
            {
                deviceNames.Add(deviceList.data[i].name + "@" + deviceList.data[i].workstation);
            }

            DataTable dtDeviceList = new DataTable();

            dtDeviceList.Columns.Add("Name", typeof(string));
            dtDeviceList.Columns.Add("Workstation", typeof(string));

            for (int i = 0; i < deviceList.data.Length; i++)
            {
                var newRow = dtDeviceList.NewRow();
                newRow["Name"] = deviceList.data[i].name;
                newRow["Workstation"] = deviceList.data[i].workstation;
                dtDeviceList.Rows.Add(newRow);
            }
            return deviceNames;
        }

        public DataTable GetDispensableInventory(string currency, int deviceNumber)
        {
            DeviceList deviceList = GetDeviceListInternal();

            Device device = new Device();
            device = deviceList.data[deviceNumber];

            DenominationResult dispensableInveontry = client.retrieveDispensableInventory(session.data, device, currency);

            List<DenominationItem> inventoryItems = new List<DenominationItem>();

            foreach(DenominationItem item in dispensableInveontry.data.items)
            {
                inventoryItems.Add(item);
            }

            DataTable dt = new DataTable("Table");

            dt.Columns.AddRange(new DataColumn[]{
                new DataColumn("Currency", typeof(string)),
                new DataColumn("Count", typeof(int)),
                new DataColumn("Value", typeof(int))
            });

            for (int i = 0; i < dispensableInveontry.data.items.Length; i++ )
            {
                var newRow = dt.NewRow();
                newRow["Currency"] = dispensableInveontry.data.items[i].currency;
                newRow["Count"] = dispensableInveontry.data.items[i].count;
                newRow["Value"] = dispensableInveontry.data.items[i].value;
                dt.Rows.Add(newRow);
            }
            return dt;
        }
    }
}
