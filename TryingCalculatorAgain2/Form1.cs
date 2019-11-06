using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryingCalculatorAgain2
{
    public partial class Form1 : Form
    {
        public static decimal Total { get; set; }
        public static string WholeString { get; set; }
        public static decimal DisplayValue { get; set; }
        public static string LastInput { get; set; }
        public static decimal LastNumber { get; set; }
        public static decimal CurrentValue { get; set; }
        public static string LastOperation { get; set; }

        public Form1()
        {
            WholeString = "";
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #region numbers
        private void ZeroButton_Click(object sender, EventArgs e)
        {
            if (LastInput == "operation")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "0";
            LastInput = "number";
            WholeString += "0";
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            if (LastInput == "operation")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "1";
            LastInput = "number";
            WholeString += "1";
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            if (LastInput == "operation")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "2";
            LastInput = "number";
            WholeString += "2";
        }
        private void ThreeButton_Click(object sender, EventArgs e)
        {
            if (LastInput == "operation")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "3";
            LastInput = "number";
            WholeString += "3";
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            if (LastInput == "operation")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "4";
            LastInput = "number";
            WholeString += "4";
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            if (LastInput == "operation")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "5";
            LastInput = "number";
            WholeString += "5";
        }
        private void SixButton_Click(object sender, EventArgs e)
        {
            if (LastInput == "operation")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "6";
            LastInput = "number";
            WholeString += "6";
        }
        private void SevenButton_Click(object sender, EventArgs e)
        {
            if (LastInput == "operation")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "7";
            LastInput = "number";
            WholeString += "7";
        }

        private void EightButton_Click(object sender, EventArgs e)
        {
            if (LastInput == "operation")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "8";
            LastInput = "number";
            WholeString += "8";
        }

        private void NineButton_Click(object sender, EventArgs e)
        {
            if (LastInput == "operation")
            {
                mainTextBox.Text = "";
            }
            mainTextBox.Text += "9";
            LastInput = "number";
            WholeString += "9";
        }
        #endregion


        #region simple operations
        private void AdditionButton_Click(object sender, EventArgs e)
        {

            //get the value from the text box
            if (LastInput != "operation")
            {
                WholeString += "+";

                if (LastInput == "number")
                {
                    Total += CurrentValue;
                }
                mainTextBox.Text = Total.ToString();
                LastInput = "operation";
                LastOperation = "addition";
                trackerbox.Text = WholeString;
            }

        }

        private void SubtractionButton_Click(object sender, EventArgs e)
        {
            //get the value from the text box

            if (LastInput != "operation")
            {
                WholeString += "-";
                if (LastInput == "number")
                {
                    //do the operation on the new number
                    Total -= CurrentValue;
                }
                mainTextBox.Text = Total.ToString();
                LastInput = "operation";
                LastOperation = "subtraction";
                trackerbox.Text = WholeString;
            }
        }

        private void MultiplicationButton_Click(object sender, EventArgs e)
        {
            if (LastInput != "operation")
            {
                WholeString += "*";

                LastInput = "operation";
                LastOperation = "multiplication";
                trackerbox.Text = WholeString;
            }
        }

        private void DivisionButton_Click(object sender, EventArgs e)
        {

            if (LastInput != "operation")
            {
                WholeString += "/";
                LastInput = "operation";
                LastOperation = "multiplication";
                trackerbox.Text = WholeString;
            }
        }
        #endregion




        #region equals and clear buttons
        private void EqualsButton_Click(object sender, EventArgs e)
        {

            var checkit = WholeString;
            trackerbox.Text = WholeString;
            //run the function to evaluate the string
            ResolveOperationString(WholeString);
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            Total = 0;
            DisplayValue = 0;
            LastInput = "clear";
            LastOperation = "";
            LastNumber = 0;
            mainTextBox.Text = "";
            WholeString = "";
            trackerbox.Text = WholeString;
        }
        #endregion

        private void ResolveOperationString(string input)
        {
            //these are all the operations, and functions to resolve them, just have to pass the numbers in
            string[] operators = new string[] { "+", "-", "/", "*", "^" };
            Func<double, double, double>[] operations = {
                (n1, n2) => n1 + n2,
                (n1, n2) => n1 - n2,
                (n1, n2) => n1 / n2,
                (n1, n2) => n1 * n2,
                (n1, n2) => Math.Pow(n1, n2)
            };
            string myRegexString = @"(\+| -|\/|\*|\^)";

            string[] splitUp = Regex.Split(input, @"(\+|-|\/|\*|\^\\AND\\OR\\NOT)");

            //get the first number and use that as the first number
            double runningTotal = Convert.ToDouble(splitUp[0]);


            for (var x = 0; x < splitUp.Length; x++)
            {
                if (splitUp[x] == "+" || splitUp[x] == "-" || splitUp[x] == "/" || splitUp[x] == "*" || splitUp[x] == "^")
                {
                    //perform operation with current number and the newly encountered number on the
                    //other side of the operator
                    var whichFunction = operations[Array.IndexOf(operators, splitUp[x])];
                    //this is the number
                    runningTotal = operations[Array.IndexOf(operators, splitUp[x])](runningTotal, Convert.ToDouble(splitUp[x + 1]));
                }
                if (splitUp[x] == "√")
                {
                    runningTotal += Math.Sqrt(Convert.ToDouble(splitUp[x + 1]));
                }
                if (splitUp[x] == "^")
                {
                    runningTotal += Math.Pow(Convert.ToDouble(splitUp[x - 1]), Convert.ToDouble(splitUp[x + 1]));
                }
            }

            if(BinaryRadio.Checked != true)
            {
                mainTextBox.Text = runningTotal.ToString();
            }
            else
            {
                mainTextBox.Text = ConvertToBinary(Convert.ToInt32(runningTotal));
            }
            
            //find the first operation, then you find the two numbers that it's working on


        }
        //maybe write a recursive function for parentheses



        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SquareRootButton_Click(object sender, EventArgs e)
        {
            WholeString += "√";
        }

        private void PowerButton_Click(object sender, EventArgs e)
        {
            WholeString += "^";
        }

        private void AndButton_Click(object sender, EventArgs e)
        {
            if(LastOperation != "ANDORNOT")
            {
                WholeString += "AND";
                trackerbox.Text += "AND ";
                LastOperation = "ANDORNOT";
                LastInput = "AND";
            }
        }

        private void OrButton_Click(object sender, EventArgs e)
        {
            if (LastOperation != "ANDORNOT")
            {
                WholeString += "OR";
                trackerbox.Text += "OR ";
                LastOperation = "ANDORNOT";
                LastInput = "OR";
            }
        }

        private void NotButton_Click(object sender, EventArgs e)
        {
            if (LastOperation != "ANDORNOT")
            {
                WholeString += "NOT";
                trackerbox.Text += "NOT ";
                LastOperation = "ANDORNOT";
                LastInput = "NOT";
            }
        }

        private void TrueButton_Click(object sender, EventArgs e)
        {
            if (LastOperation != "TRUEFALSE")
            {
                if (!WholeString.Any(x => Regex.IsMatch(x.ToString(), @"[0-9]|\+|-|\/|\*|\^/g")))
                {
                    WholeString += "TRUE";
                    trackerbox.Text += "TRUE ";
                    LastInput = "TRUE";
                    LastOperation = "TRUEFALSE";
                }
            }
        }

        private void trackerbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FalseButton_Click(object sender, EventArgs e)
        {
            if (LastOperation != "TRUEFALSE")
            {
                if (!WholeString.Any(x => Regex.IsMatch(x.ToString(), @"[0-9]|\+|-|\/|\*|\^/g")))
                {
                    WholeString += "FALSE ";
                    trackerbox.Text += "FALSE";
                    LastInput = "FALSE";
                    LastOperation = "TRUEFALSE";
                }
            }
        }

        private void BinaryRadio_CheckedChanged(object sender, EventArgs e)
        {
            if(BinaryRadio.Checked == true)
            {
                //Regex.IsMatch(x.ToString(), @"[0-9]|\+|-|\/|\*|\^/g")
                //bottom regex checks for any binary numbers, all numbers have to be 1 or 0
                //!Regex.IsMatch(mainTextBox.Text, @"[^A-Za-z2-9]/g")
                if (mainTextBox.Text.Length > 0)
                {
                    if(Convert.ToDouble(mainTextBox.Text) < 256)
                    {
                        var ans = ConvertToBinary(Convert.ToInt32(mainTextBox.Text));
                        mainTextBox.Text = ans;
                    }
                    else
                    {
                        mainTextBox.Text = "Can only convert numbers smaller than 256 to binary";
                    }
                }
                else
                {
                    mainTextBox.Text = "Something went wrong";
                }

                TwoButton.Enabled = false;
                ThreeButton.Enabled = false;
                FourButton.Enabled = false;
                FiveButton.Enabled = false;
                SixButton.Enabled = false;
                SevenButton.Enabled = false;
                EightButton.Enabled = false;
                NineButton.Enabled = false;
            }
        }

        private void DecimalRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (DecimalRadio.Checked == true)
            {
                if(!Regex.IsMatch(mainTextBox.Text, @"[^A-Za-z2-9]/g"))
                {
                    mainTextBox.Text = ConvertBinaryToDouble(mainTextBox.Text.ToString()).ToString();
                }
                TwoButton.Enabled = true;
                ThreeButton.Enabled = true;
                FourButton.Enabled = true;
                FiveButton.Enabled = true;
                SixButton.Enabled = true;
                SevenButton.Enabled = true;
                EightButton.Enabled = true;
                NineButton.Enabled = true;
            }
        }

        static string ConvertToBinary(int n)
        {
            List<string> result = new List<string>(); 

            while (n > 0)
            {
                int remainder = n % 2;
                
                result.Add(remainder.ToString());
                n = n / 2;
            }
            return String.Join("", result.ToArray());
        }

        static double ConvertBinaryToDouble(string binaryNum)
        {
            double myAns = 0;
            int n = 0;
            //take a binary number, and return the integer value

            for(var i = binaryNum.ToString().Length - 1; i >= 0; i--)
            {
                if(binaryNum[i].ToString() == "1")
                {
                    myAns += Math.Pow(2, n);
                }
                n++;
            }
            return myAns;
        }

        private bool IsBinary(string input)
        {
            bool check = false;
            if(input.Length > 7)
            {
                return false;
            }

            for(var i = 0; i < input.Length; i++)
            {
                if(input[i].ToString() == "0" || input[i].ToString() == "1")
                {
                    check = true;
                }
                else
                {
                    check = false;
                }
            }
            return check;
        }

        private string ANDOperator(string input1, string input2)
        {
            string ans = "";

            for(var i = 0; i < input1.Length; i++)
            {

            }
            return ans;
        }
        //private string OROperator(string input1, string input2)
        //{

        //}
        //private string XOROperator(string input1, string input2)
        //{

        //}
    }
}
