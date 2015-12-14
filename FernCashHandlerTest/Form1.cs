using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FernCashHandler;
using FernCashHandler.CashInsightAPI;

namespace FernCashHandlerTest
{
    public partial class Form1 : Form
    {
        CashHandler cashHandler = new CashHandler();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username, password;

            username = txtUsername.Text;
            password = txtPassword.Text;

            cashHandler.Login(username, password);

            List<string> deviceList = cashHandler.GetDeviceListExternal();

            comboDevice.DataSource = deviceList;
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            long amount, remainder;
            int position, device;
            string currency, authUsername, authPassword;
            bool authorisation;

            if (!long.TryParse(txtAmount.Text, out amount)) amount = 0;

            currency = comboCurrency.SelectedItem.ToString();
            position = Convert.ToInt32(comboPosition.SelectedItem);
            device = comboDevice.SelectedIndex;
            authorisation = chkboxAuth.Checked;
            authUsername = txtAuthUsername.Text;
            authPassword = txtAuthPassword.Text;

            //DenominationResult dispensableInventory = cashHandler.GetDispensableInventory(currency, device);
            DataTable dispensableInventory = cashHandler.GetDispensableInventory(currency, device);

            //Mix mix = cashHandler.CreateMix(amount, currency, device, position, authorisation, authUsername, authPassword);
            DataTable mix = cashHandler.CreateMix(amount, currency, device, position, authorisation, authUsername, authPassword);

            dispensableInventory.Columns.Add("Requested", typeof(int));

            for(int i = 0; i < dispensableInventory.Rows.Count; i++)
            {
                DataRow row = dispensableInventory.Rows[i];                
                row["Requested"] = mix.Rows[i]["Requested"];
                //row["Requested"] = mix.mix.items[i].count;
                //dispensableInventory.Rows.Add(row);
            }

            dataGridMix.DataSource = dispensableInventory;

            //dataGridMix.DataSource = dispensableInventory.Select(o => new 
            //    { Currency = o.currency, Value = o.value, Available = o.count }).ToList();

            remainder = Convert.ToInt64(mix.Rows[0]["Remainder"]);

            if (remainder > 0)
            {
                labelRemainder.Text = "Withdrawal Remainder: " + remainder.ToString();
            }
            else
            {
                labelRemainder.Text = "No Withdrawal Remainder";
            }

            //TODO: Edit how mix is generated and update dispense with this
            //cashHandler.Withdrawal(amount, currency, device, position, authorisation, authUsername, authPassword);
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            long amount;
            int position, device;
            string currency, authUsername, authPassword;
            bool authorisation;

            if (!long.TryParse(txtAmount.Text, out amount)) amount = 0;
            currency = comboCurrency.SelectedItem.ToString();
            position = comboPosition.SelectedIndex;
            device = comboDevice.SelectedIndex;
            authorisation = chkboxAuth.Checked;
            authUsername = txtAuthUsername.Text;
            authPassword = txtAuthPassword.Text;

            cashHandler.Deposit(amount, currency, device, position, authorisation, authUsername, authPassword);
        }

        private void btnDispense_Click(object sender, EventArgs e)
        {
            long amount;
            int position, device;
            string currency, authUsername, authPassword;
            bool authorisation;

            if (!long.TryParse(txtAmount.Text, out amount)) amount = 0;

            currency = comboCurrency.SelectedItem.ToString();
            position = Convert.ToInt32(comboPosition.SelectedItem);
            device = comboDevice.SelectedIndex;
            authorisation = chkboxAuth.Checked;
            authUsername = txtAuthUsername.Text;
            authPassword = txtAuthPassword.Text;

            cashHandler.Dispense(amount, currency, device, position, authorisation, authUsername, authPassword);
        }
    }
}
