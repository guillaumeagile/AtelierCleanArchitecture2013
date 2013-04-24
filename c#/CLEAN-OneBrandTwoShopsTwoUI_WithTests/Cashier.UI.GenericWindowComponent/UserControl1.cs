using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cashier.UseCases;
using Cashier.Model;

namespace Cashier.UI.GenericWindowComponent
{
    public partial class UserControl1 : UserControl, IAmAUserInterfaceForCalculateur
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public UserControl1(string shopName) : base()
        {
            this.txtTitle.Text = shopName;
        }

        ICanCalculate Calculator;

        public void GiveAWayToCalculate(ICanCalculate calculator)
        {
            Calculator = calculator;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            var typing = new CashierTyping { Number = int.Parse(this.cmbQtte.SelectedText), Reference = txtRef.Text };
            Calculator.ProcessEntry(typing);
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            var total = Calculator.CalculateTotal();
            txtTotal.Text = total.ToString();
        }

        public void Run()
        {
        
        }

    }
}
