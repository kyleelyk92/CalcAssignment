using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcAssignment
{
    public partial class Form1 : Form
    {
        public static double? CurrVal { get; set; }
        public static double? N1 { get; set; }
        public static double? N2 { get; set; }
        public static double? DisplayVal { get; set; }
        public static double? LastVal { get; set; }
        public double LastNum { get; set; }
        public static string CurrentOperation { get;set; }
        public static string LastInput { get; set; }
        public static string LastOperation { get; set; }

        //Type a  number as long as like ... 8 digits into N1
        //then, one of the action buttons are pressed (multiply, divide, etc.)
        //then start typing in N2

        public Form1()
        {
            InitializeComponent();
            CurrVal = 0;
            DisplayVal = 0;
            LastVal = 0;
            N1 = 0;
            N2 = 0;
            CurrentOperation = "";
        }
        #region NumberInputs
        private void ZEROButton_Click(object sender, EventArgs e)
        {
            if (LastInput != "num")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "0";
            LastInput = "num";
        }
        private void ONEButton_Click(object sender, EventArgs e)
        {
            if (LastInput != "num")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "1";
            LastInput = "num";
        }
        private void TWOButton_Click(object sender, EventArgs e)
        {
            if (LastInput != "num")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "2";
            LastInput = "num";
        }
        private void THREEButton_Click(object sender, EventArgs e)
        {
            if (LastInput != "num")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "3";
            LastInput = "num";
        }
        private void FOURButton_Click(object sender, EventArgs e)
        {
            if (LastInput != "num")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "4";
            LastInput = "num";
        }
        private void FIVEButton_Click(object sender, EventArgs e)
        {
            if (LastInput != "num")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "5";
            LastInput = "num";
        }
        private void SIXButton_Click(object sender, EventArgs e)
        {
            if (LastInput != "num")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "6";
            LastInput = "num";
        }

        private void SEVENButton_Click(object sender, EventArgs e)
        {
            if (LastInput != "num")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "7";
            LastInput = "num";
        }
        private void EIGHTButton_Click(object sender, EventArgs e)
        {
            if (LastInput != "num")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "8";
            LastInput = "num";
        }
        private void NINEButton_Click(object sender, EventArgs e)
        {
            if (LastInput != "num")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "9";
            LastInput = "num";
        }

        
        #endregion

        #region SimpleOperationsSection

        //this is the addition button, the naming in this is fucky
        private void AdditionButton_Click(object sender, EventArgs e)
        {
            if(LastInput == "num")
            {
                var operation = (double)Int32.Parse(mainTextBox.Text) > 0 ? "add" : "subtract";
                var num = mainTextBox.Text[0] == '-' ? (double)Int32.Parse(mainTextBox.Text.Substring(1)) : (double)Int32.Parse(mainTextBox.Text);
                LastNum = num;

                if (operation == "add")
                {
                    ExecuteOperation("add", num);
                }
                else
                {
                    ExecuteOperation("subtract", num);
                }

                LastInput = "operation";
                LastOperation = "add";
                DisplayVal = CurrVal;
                mainTextBox.Text = DisplayVal.ToString();
            }
        }
        private void SubtractionButton_Click(object sender, EventArgs e)
        {
            if (LastInput == "num")
            {
                var operation = (double)Int32.Parse(mainTextBox.Text) > 0 ? "subtract" : "add";
                var num = mainTextBox.Text[0] == '-' ? (double)Int32.Parse(mainTextBox.Text.Substring(1)) : (double)Int32.Parse(mainTextBox.Text);
                LastNum = num;

                if (operation == "add")
                {
                    ExecuteOperation("add", num);
                }
                else
                {
                    ExecuteOperation("subtract", num);
                }

                LastInput = "operation";
                LastOperation = "subtract";
                DisplayVal = CurrVal;
                mainTextBox.Text = DisplayVal.ToString();
            }
        }
        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            ExecuteOperation("multiply", (double)Int32.Parse(mainTextBox.Text));
            mainTextBox.Text = CurrVal.ToString();
        }
        private void DivideButton_Click(object sender, EventArgs e)
        {
            ExecuteOperation("divide", (double)Int32.Parse(mainTextBox.Text));
            mainTextBox.Text = CurrVal.ToString();
        }

        public void ExecuteOperation(string operation, double N)
        {
            switch (operation)
            {
                case "add":
                    CurrVal += N;
                    break;
                case "subtract":
                    CurrVal -= N;
                    break;
                case "multiply":
                    CurrVal *= N;
                    break;
                case "divide":
                    CurrVal /= N;
                    break;
            }
        }
        #endregion




        private void Button16_Click(object sender, EventArgs e)
        {

        }



        private void MainTextBox_TextChanged(object sender, EventArgs e)
        {
        }


        public void UpdateDisplayVal(string valToChange, double val, string action)
        {
            
        }
        //function to run in every operator click, to cache the last value and save the operation;


        private void MinusSwitchButton_Click(object sender, EventArgs e)
        {
            if (!mainTextBox.Text[0].Equals('-')) 
            {
                mainTextBox.Text = mainTextBox.Text.Insert(0, "-");
            }
            else
            {
                mainTextBox.Text = mainTextBox.Text = mainTextBox.Text.Substring(1);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            LastVal = CurrVal;
            CurrVal = 0;
            DisplayVal = 0;
            N1 = 0;
            N2 = 0;
            CurrentOperation = "";
            mainTextBox.Text = "";
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            double lastnum = Int32.Parse(mainTextBox.Text);
            if (LastInput == "equals")
            {
                lastnum = LastNum;
            }
            string lastop = LastOperation;
            

            ExecuteOperation(lastop, lastnum);

            DisplayVal = CurrVal;
            mainTextBox.Text = DisplayVal.ToString();
            LastInput = "equals";
        }
    }
}
