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

            DeviceList deviceList = cashHandler.GetDeviceList();
            List<string> devices = new List<string>();

            int count = 0;

            foreach (Device device in deviceList.data)
            {
                devices.Add(device.name + "@" + device.workstation);
                count++;
            }

            comboDevice.DataSource = devices;
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
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

            cashHandler.Withdrawal(amount, currency, device, position, authorisation, authUsername, authPassword);

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
    }
}
