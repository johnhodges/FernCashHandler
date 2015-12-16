namespace FernCashHandlerTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboDevice = new System.Windows.Forms.ComboBox();
            this.comboCurrency = new System.Windows.Forms.ComboBox();
            this.chkboxAuth = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAuthPassword = new System.Windows.Forms.TextBox();
            this.txtAuthUsername = new System.Windows.Forms.TextBox();
            this.comboPosition = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.labelRemainder = new System.Windows.Forms.Label();
            this.dataGridMix = new System.Windows.Forms.DataGridView();
            this.btnRecalculate = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCashbox = new System.Windows.Forms.TextBox();
            this.labelUnallocated = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMix)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeposit
            // 
            this.btnDeposit.Location = new System.Drawing.Point(15, 361);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(75, 23);
            this.btnDeposit.TabIndex = 9;
            this.btnDeposit.Text = "Deposit";
            this.btnDeposit.UseVisualStyleBackColor = true;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(96, 361);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(75, 23);
            this.btnWithdraw.TabIndex = 10;
            this.btnWithdraw.Text = "Withdraw";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            this.btnWithdraw.Click += new System.EventHandler(this.btnWithdraw_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(179, 29);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(73, 6);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(73, 32);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(73, 92);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Currency";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Device";
            // 
            // comboDevice
            // 
            this.comboDevice.FormattingEnabled = true;
            this.comboDevice.Location = new System.Drawing.Point(73, 145);
            this.comboDevice.Name = "comboDevice";
            this.comboDevice.Size = new System.Drawing.Size(121, 21);
            this.comboDevice.TabIndex = 5;
            // 
            // comboCurrency
            // 
            this.comboCurrency.FormattingEnabled = true;
            this.comboCurrency.Items.AddRange(new object[] {
            "EUR"});
            this.comboCurrency.Location = new System.Drawing.Point(73, 118);
            this.comboCurrency.Name = "comboCurrency";
            this.comboCurrency.Size = new System.Drawing.Size(121, 21);
            this.comboCurrency.TabIndex = 4;
            // 
            // chkboxAuth
            // 
            this.chkboxAuth.AutoSize = true;
            this.chkboxAuth.Location = new System.Drawing.Point(17, 258);
            this.chkboxAuth.Name = "chkboxAuth";
            this.chkboxAuth.Size = new System.Drawing.Size(133, 17);
            this.chkboxAuth.TabIndex = 14;
            this.chkboxAuth.Text = "Authorisation Required";
            this.chkboxAuth.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Authorisation Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 291);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Authorisation Username";
            // 
            // txtAuthPassword
            // 
            this.txtAuthPassword.Location = new System.Drawing.Point(137, 317);
            this.txtAuthPassword.Name = "txtAuthPassword";
            this.txtAuthPassword.Size = new System.Drawing.Size(100, 20);
            this.txtAuthPassword.TabIndex = 8;
            // 
            // txtAuthUsername
            // 
            this.txtAuthUsername.Location = new System.Drawing.Point(137, 288);
            this.txtAuthUsername.Name = "txtAuthUsername";
            this.txtAuthUsername.Size = new System.Drawing.Size(100, 20);
            this.txtAuthUsername.TabIndex = 7;
            // 
            // comboPosition
            // 
            this.comboPosition.FormattingEnabled = true;
            this.comboPosition.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboPosition.Location = new System.Drawing.Point(73, 175);
            this.comboPosition.Name = "comboPosition";
            this.comboPosition.Size = new System.Drawing.Size(121, 21);
            this.comboPosition.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Position";
            // 
            // labelRemainder
            // 
            this.labelRemainder.AutoSize = true;
            this.labelRemainder.Location = new System.Drawing.Point(270, 242);
            this.labelRemainder.Name = "labelRemainder";
            this.labelRemainder.Size = new System.Drawing.Size(117, 13);
            this.labelRemainder.TabIndex = 22;
            this.labelRemainder.Text = "Withdrawal Remainder:";
            // 
            // dataGridMix
            // 
            this.dataGridMix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMix.Location = new System.Drawing.Point(273, 12);
            this.dataGridMix.Name = "dataGridMix";
            this.dataGridMix.Size = new System.Drawing.Size(537, 215);
            this.dataGridMix.TabIndex = 23;
            // 
            // btnRecalculate
            // 
            this.btnRecalculate.Location = new System.Drawing.Point(273, 281);
            this.btnRecalculate.Name = "btnRecalculate";
            this.btnRecalculate.Size = new System.Drawing.Size(75, 23);
            this.btnRecalculate.TabIndex = 24;
            this.btnRecalculate.Text = "Recalculate";
            this.btnRecalculate.UseVisualStyleBackColor = true;
            this.btnRecalculate.Click += new System.EventHandler(this.btnRecalculate_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(367, 286);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Cashbox";
            // 
            // txtCashbox
            // 
            this.txtCashbox.Location = new System.Drawing.Point(421, 281);
            this.txtCashbox.Name = "txtCashbox";
            this.txtCashbox.Size = new System.Drawing.Size(100, 20);
            this.txtCashbox.TabIndex = 26;
            // 
            // labelUnallocated
            // 
            this.labelUnallocated.AutoSize = true;
            this.labelUnallocated.Location = new System.Drawing.Point(270, 317);
            this.labelUnallocated.Name = "labelUnallocated";
            this.labelUnallocated.Size = new System.Drawing.Size(67, 13);
            this.labelUnallocated.TabIndex = 27;
            this.labelUnallocated.Text = "Unallocated:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(418, 317);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(34, 13);
            this.labelTotal.TabIndex = 28;
            this.labelTotal.Text = "Total:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 475);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelUnallocated);
            this.Controls.Add(this.txtCashbox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnRecalculate);
            this.Controls.Add(this.dataGridMix);
            this.Controls.Add(this.labelRemainder);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboPosition);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtAuthPassword);
            this.Controls.Add(this.txtAuthUsername);
            this.Controls.Add(this.chkboxAuth);
            this.Controls.Add(this.comboCurrency);
            this.Controls.Add(this.comboDevice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnWithdraw);
            this.Controls.Add(this.btnDeposit);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboDevice;
        private System.Windows.Forms.ComboBox comboCurrency;
        private System.Windows.Forms.CheckBox chkboxAuth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAuthPassword;
        private System.Windows.Forms.TextBox txtAuthUsername;
        private System.Windows.Forms.ComboBox comboPosition;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelRemainder;
        private System.Windows.Forms.DataGridView dataGridMix;
        private System.Windows.Forms.Button btnRecalculate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCashbox;
        private System.Windows.Forms.Label labelUnallocated;
        private System.Windows.Forms.Label labelTotal;
    }
}

