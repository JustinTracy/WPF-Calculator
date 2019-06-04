using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calculator
{
    public partial class MainWindow
    {
        private string firstNum = "";
        private string secondNum = "";
        private string power = "";
        
        private bool isOnFirstNum = true;
        private bool isAdding;
        private bool isSubtracting;
        private bool isMultiplying;
        private bool isDividing;
        private bool isCarreting;
        private int counter;
        
        public MainWindow()
        {
            InitializeComponent();
            SetUniqueColors();
        }

        private void Equals(object sender, RoutedEventArgs routedEventArgs)
        {
            if (BottomTextBox.Text.Equals("")) return;
            if (firstNum.Equals("-"))
            {
                firstNum = "0";
            }
            if (secondNum.Equals("-"))
            {
                secondNum = "0";
            }

            if (isCarreting)
            {
                if (isOnFirstNum)
                {
                    int index = BottomTextBox.Text.IndexOf("^", StringComparison.Ordinal);
                    firstNum = BottomTextBox.Text.Substring(0, index);
                    double total = Math.Pow(Double.Parse(firstNum), Double.Parse(power));
                    TopTextBox.Clear();
                    secondNum = "";
                    BottomTextBox.Text = total.ToString();
                    firstNum = total.ToString();
                }
                else
                {
                    double total = Math.Pow(Double.Parse(secondNum), Double.Parse(power));
                    TopTextBox.Clear();
                    secondNum = "";
                    BottomTextBox.Text = total.ToString();
                    secondNum = total.ToString();
                }
            }
            if (isMultiplying)
            {
                double total = Double.Parse(firstNum) * Double.Parse(secondNum);
                TopTextBox.Clear();
                secondNum = "";
                BottomTextBox.Text = total.ToString();
                firstNum = total.ToString();
            }
            if (isDividing)
            {
                double total = Double.Parse(firstNum) / Double.Parse(secondNum);
                TopTextBox.Clear();
                secondNum = "";
                BottomTextBox.Text = total.ToString();
                firstNum = total.ToString();
            }
            if (isAdding)
            {
                if (counter > 1)
                {
                    double total = Double.Parse(firstNum) + Double.Parse(secondNum);
                    TopTextBox.Clear();
                    secondNum = total.ToString();
                    BottomTextBox.Text = total.ToString();
                    firstNum = total.ToString();
                }
                else
                {
                    double total = Double.Parse(firstNum) + Double.Parse(secondNum);
                    TopTextBox.Clear();
                    secondNum = "";
                    BottomTextBox.Text = total.ToString();
                    firstNum = total.ToString();
                }
            }
            if (isSubtracting)
            {
                double total = Double.Parse(firstNum) - Double.Parse(secondNum);
                TopTextBox.Clear();
                secondNum = "";
                BottomTextBox.Text = total.ToString();
                firstNum = total.ToString();
            }
            
            isOnFirstNum = true;
            isAdding = false;
            isSubtracting = false;
            isMultiplying = false;
            isDividing = false;
            isCarreting = false;
            power = "";
            counter = 0;
        }

        private void Caret(object sender, RoutedEventArgs routedEventArgs)
        {
            if (!isCarreting)
            {
                if (isOnFirstNum)
                {
                    if (firstNum.Equals("") || firstNum.Contains("^")) return;
                    BottomTextBox.AppendText("^");
                    isCarreting = true;
                }
                else
                {
                    if (secondNum.Equals("") || secondNum.Contains("^")) return;
                    BottomTextBox.AppendText("^");
                    isCarreting = true;
                }
            }
        }

        private void Inverse(object sender, RoutedEventArgs routedEventArgs)
        {
            if (isOnFirstNum)
            {
                if (firstNum.Equals("")) return;
                firstNum = (1 / Double.Parse(firstNum)).ToString();
                BottomTextBox.Text = firstNum;
            }
            else
            {
                if (secondNum.Equals("")) return;
                secondNum = (1 / Double.Parse(secondNum)).ToString();
                BottomTextBox.Text = firstNum;
            }
        }

        private void SquareRoot(object sender, RoutedEventArgs routedEventArgs)
        {
            if (isOnFirstNum)
            {
                if (firstNum.Equals("")) return;
                firstNum = Math.Sqrt(Double.Parse(firstNum)).ToString();
                BottomTextBox.Text = firstNum;
            }
            else
            {
                if (secondNum.Equals("")) return;
                secondNum = Math.Sqrt(Double.Parse(secondNum)).ToString();
                BottomTextBox.Text = secondNum;
            }
        }

        private void Square(object sender, RoutedEventArgs routedEventArgs)
        {
            if (isOnFirstNum)
            {
                if (firstNum.Equals("")) return;
                firstNum = (Double.Parse(firstNum) * Double.Parse(firstNum)).ToString();
                BottomTextBox.Text = firstNum;
            }
            else
            {
                if (secondNum.Equals("")) return;
                secondNum = (Double.Parse(secondNum) * Double.Parse(secondNum)).ToString();
                BottomTextBox.Text = secondNum;
            }
        }

        private void SwitchSigns(object sender, RoutedEventArgs routedEventArgs)
        {
            if (!isCarreting)
            {
                if (isOnFirstNum)
                {
                    if (!firstNum.Equals(""))
                    {
                        if (firstNum.Substring(0, 1).Equals("-"))
                        {
                            if (firstNum.Equals("-"))
                            {
                                firstNum = "";
                                BottomTextBox.Text = firstNum;
                            }
                            else
                            {
                                firstNum = (Double.Parse(firstNum) * -1).ToString();
                                BottomTextBox.Text = firstNum;
                            }
                        }
                        else
                        {
                            firstNum = (Double.Parse(firstNum) * -1).ToString();
                            BottomTextBox.Text = firstNum;
                        }
                    }
                    else
                    {
                        firstNum = "-";
                        BottomTextBox.Text = firstNum;
                    }
                }
                else
                {
                    if (!secondNum.Equals(""))
                    {
                        if (secondNum.Substring(0, 1).Equals("-"))
                        {
                            if (secondNum.Equals("-"))
                            {
                                secondNum = "";
                                BottomTextBox.Text = secondNum;
                            }
                            else
                            {
                                secondNum = (-Double.Parse(secondNum)).ToString();
                                BottomTextBox.Text = secondNum;
                            }
                        }
                        else
                        {
                            secondNum = (Double.Parse(secondNum) * -1).ToString();
                            BottomTextBox.Text = secondNum;
                        }
                    }
                    else
                    {
                        secondNum = "-";
                        BottomTextBox.Text = secondNum;
                    }
                }
            }
            else
            {
                if (power.Equals(""))
                {
                    power = "-";
                    BottomTextBox.AppendText(power);
                }
                else if (power.Equals("-"))
                {
                    string currentString = BottomTextBox.Text.Substring(0, BottomTextBox.Text.Length - 1);
                    power = "";
                    BottomTextBox.Text = currentString;
                }
                else if (power.Contains("-"))
                {
                    string currentString = BottomTextBox.Text.Substring(0, BottomTextBox.Text.Length - power.Length);
                    power = (-Double.Parse(power)).ToString();
                    BottomTextBox.Text = currentString + power;
                }
                else
                {
                    string currentString = BottomTextBox.Text.Substring(0, BottomTextBox.Text.Length - power.Length);
                    power = (-Double.Parse(power)).ToString();
                    BottomTextBox.Text = currentString + power;
                }
            }
        }

        private void Decimal(object sender, RoutedEventArgs routedEventArgs)
        {
            if (isOnFirstNum)
            {
                if (firstNum.Contains(".")) return;
                if (!firstNum.Equals(""))
                {
                    if (!firstNum.Equals("0."))
                    {
                        firstNum += ".";
                        BottomTextBox.AppendText(".");
                    }
                }
                else
                {
                    firstNum = "0.";
                    BottomTextBox.Text = "0.";
                }
            }
            else
            {
                if (secondNum.Contains(".")) return;
                if (!secondNum.Equals(""))
                {
                    if (!secondNum.Equals("0."))
                    {
                        secondNum += ".";
                        BottomTextBox.AppendText(".");
                    }
                }
                else
                {
                    secondNum = "0.";
                    BottomTextBox.Text = "0.";
                }
            }
        }

        private void Add(object sender, RoutedEventArgs routedEventArgs)
        {
            if (firstNum.Equals("-"))
            {
                firstNum = "0";
            }

            if (counter < 1)
            {
                ClearOperators();
                isAdding = true;
                isOnFirstNum = false;
                TopTextBox.Text = firstNum;
                BottomTextBox.Clear();
                TopTextBox.AppendText(" + ");
            }
            else
            {
                isAdding = true;
                isOnFirstNum = false;
                Equals(sender, routedEventArgs);
                isAdding = true;
                isOnFirstNum = false;
                TopTextBox.Text = firstNum;
                BottomTextBox.Clear();
                TopTextBox.AppendText(" + ");
            }

            counter++;
        }
        
        private void Subtract(object sender, RoutedEventArgs routedEventArgs)
        {
            if (firstNum.Equals("-"))
            {
                firstNum = "0";
            }
            ClearOperators();
            isSubtracting = true;
            isOnFirstNum = false;
            TopTextBox.Text = firstNum;
            BottomTextBox.Clear();
            TopTextBox.AppendText(" - ");
        }
        
        private void Multiply(object sender, RoutedEventArgs routedEventArgs)
        {
            if (firstNum.Equals("-"))
            {
                firstNum = "0";
            }
            ClearOperators();
            isMultiplying = true;
            isOnFirstNum = false;
            TopTextBox.Text = firstNum;
            BottomTextBox.Clear();
            TopTextBox.AppendText(" * ");
        }
        
        private void Divide(object sender, RoutedEventArgs routedEventArgs)
        {
            if (firstNum.Equals("-"))
            {
                firstNum = "0";
            }
            ClearOperators();
            isDividing = true;
            isOnFirstNum = false;
            TopTextBox.Text = firstNum;
            BottomTextBox.Clear();
            TopTextBox.AppendText(" / ");
        }

        private void DisplayNumber(object sender, RoutedEventArgs routedEventArgs)
        {
            var tag = ((Button)sender).Tag;
            
            if (isCarreting)
            {
                power += tag.ToString();
            }
            if (isOnFirstNum)
            {
                BottomTextBox.AppendText(tag.ToString());
                firstNum = BottomTextBox.Text;
            }
            else
            {
                BottomTextBox.AppendText(tag.ToString());
                if (!isCarreting)
                {
                    secondNum = BottomTextBox.Text;
                }
            }
        }

        private void BackSpace(object sender, RoutedEventArgs routedEventArgs)
        {
            string currentString;
            int textLength;

            if (isOnFirstNum)
            {
                if (!BottomTextBox.Text.Equals(""))
                {
                    textLength = BottomTextBox.Text.Length;
                    currentString = BottomTextBox.Text.Substring(0, textLength - 1);
                    BottomTextBox.Text = currentString;
                    firstNum = currentString;
                    Console.WriteLine(1);
                }
            }
            else
            {
                if (!BottomTextBox.Text.Equals(""))
                {
                    textLength = BottomTextBox.Text.Length;
                    currentString = BottomTextBox.Text.Substring(0, textLength - 1);
                    BottomTextBox.Text = currentString;
                    secondNum = currentString;
                }
            }

            if (isCarreting && !BottomTextBox.Text.Contains("^"))
            {
                isCarreting = false;
            }
        }

        private void ClearDisplay(object sender, RoutedEventArgs routedEventArgs)
        {
            TopTextBox.Clear();
            BottomTextBox.Clear();
            firstNum = "";
            secondNum = "";
            power = "";
            isOnFirstNum = true;
            
            isAdding = false;
            isSubtracting = false;
            isMultiplying = false;
            isDividing = false;
            isCarreting = false;
            counter = 0;
        }

        private void ClearOperators()
        {
            isAdding = false;
            isSubtracting = false;
            isMultiplying = false;
            isDividing = false;
        }
        
        private void SetUniqueColors()
        {
            Brush numberColor = new SolidColorBrush(Color.FromRgb(255,234,165));
            Brush operatorColor = new SolidColorBrush(Color.FromRgb(64,167,152));
            Brush equalsColor = new SolidColorBrush(Color.FromRgb(245,139,84));
            Brush functionColor = new SolidColorBrush(Color.FromRgb(64,167,152));
            Brush deleteColor = new SolidColorBrush(Color.FromRgb(228,23,73));

            OneButton.Background = numberColor;
            TwoButton.Background = numberColor;
            ThreeButton.Background = numberColor;
            FourButton.Background = numberColor;
            FiveButton.Background = numberColor;
            SixButton.Background = numberColor;
            SevenButton.Background = numberColor;
            EightButton.Background = numberColor;
            NineButton.Background = numberColor;
            ZeroButton.Background = numberColor;

            DivideButton.Background = operatorColor;
            MultiplyButton.Background = operatorColor;
            MinusButton.Background = operatorColor;
            PlusButton.Background = operatorColor;

            EqualsButton.Background = equalsColor;

            BlankButton.Background = functionColor;
            CaretButton.Background = functionColor;
            SqrRootButton.Background = functionColor;
            SqrButton.Background = functionColor;
            InverseButton.Background = functionColor;
            SwitchSignButton.Background = functionColor;
            DecimalButton.Background = functionColor;

            ClearButton.Background = deleteColor;
            BackButton.Background = deleteColor;
        }
    }
}