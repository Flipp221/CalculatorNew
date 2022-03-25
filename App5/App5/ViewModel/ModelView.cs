using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace App5.ViewModel
{
    public class ModelView : INotifyPropertyChanged
    {
        private string resultText;
        public string ResultText { get => resultText; set { resultText = value; OnPropertyChanged("ResultText"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<ModelView> modelViews { get; set; }
        public ICommand Ravno { protected set; get; }
        public ICommand X2 { protected set; get; }
        public ICommand Chisla { protected set; get; }
        public ICommand Delenie { protected set; get; }
        public ICommand Delete { protected set; get; }
        public INavigation Navigation { get; set; }

        int currentState = 1;
        string myoperator;
        double firstNumber, secondNumber;

        public ModelView()
        {
            Ravno = new Command(OnCalculate);
            X2 = new Command(squareclicked);
            Chisla = new Command(OnSelectNumber);
            Delenie = new Command(OnSelectOperator);
            Delete = new Command(OnClear);
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void OnSelectNumber(object sender)
        {
            Button button = (Button)sender;


            string pressed = button.Text;
            if (ResultText == "0" || currentState < 0)
            {
                ResultText = "";

                if (currentState < 0)
                    currentState *= -1;
            }

            ResultText += pressed;

            double number;
            if (double.TryParse(ResultText, out number))
            {
                ResultText = number.ToString("N0");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }

        private void OnSelectOperator(object exp)
        {
            currentState = -2;
            Button button = (Button)exp;
            string pressed = button.Text;
            myoperator = pressed;
        }

        private void OnClear(object sender)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            ResultText = "0";
        }

        private void OnPercentage(object sender, EventArgs e)
        {

            if ((currentState == -1) || (currentState == 1))
            {


                var result = firstNumber / 100;
                ResultText = result.ToString();
                firstNumber = result;
                currentState = -1;

            }


        }
        private void OnCalculate(object cal)
        {
            if (currentState == 2)
            {
                var result = OperatorHelper.Calculate(firstNumber, secondNumber, myoperator);

                ResultText = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }
        private void OnSquareRoot(object sender, EventArgs e)
        {
            if ((currentState == -1) || (currentState == 1))
            {

                var result = Math.Sqrt(firstNumber);

                ResultText = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }


        private void squareclicked(object clic)
        {

            if ((currentState == -1) || (currentState == 1))
            {

                var result = firstNumber * firstNumber;
                ResultText = result.ToString();
                firstNumber = result;
                currentState = -1;
            }
        }

    }
    public static class OperatorHelper
    {
        public static double Calculate(double value1, double value2, string myoperator)
        {
            double result = 0;
            switch (myoperator)
            {
                case "÷":
                    result = value1 / value2;
                    break;
                case "*":
                    result = value1 * value2;
                    break;
                case "+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 - value2;
                    break;

            }
            return result;

        }
    }
}