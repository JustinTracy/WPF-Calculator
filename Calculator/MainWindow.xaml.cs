using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
        private bool isOperating;
        
        //TODO to the negative power, chain operating
        
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
                    double total = Math.Pow(Double.Parse(firstNum), Double.Parse(power));
                    TopTextBox.Clear();
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
                double total = Double.Parse(firstNum) + Double.Parse(secondNum);
                TopTextBox.Clear();
                secondNum = "";
                BottomTextBox.Text = total.ToString();
                firstNum = total.ToString();
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
        }

        private void Caret(object sender, RoutedEventArgs routedEventArgs)
        {
            if (isOnFirstNum)
            {
                if (firstNum.Equals("") || firstNum.Contains("^")) return;
                BottomTextBox.AppendText("^");
                isCarreting = true;
                isOnFirstNum = false;
            }
            else
            {
                if (secondNum.Equals("") || secondNum.Contains("^")) return;
                BottomTextBox.AppendText("^");
                isCarreting = true;
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

//            if (isOperating)
//            {
//                Equals(sender, routedEventArgs);
//            }
            ClearOperators();
            isAdding = true;
            isOnFirstNum = false;
            TopTextBox.Text = firstNum;
            BottomTextBox.Clear();
            TopTextBox.AppendText(" + ");
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
        }

        private void ClearDisplay(object sender, RoutedEventArgs routedEventArgs)
        {
            TopTextBox.Clear();
            BottomTextBox.Clear();
            firstNum = "";
            secondNum = "";
            isOnFirstNum = true;
            
            isAdding = false;
            isSubtracting = false;
            isMultiplying = false;
            isDividing = false;
            isCarreting = false;
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
            Brush numberColor = Brushes.White;
            Brush operatorColor = Brushes.Teal;
            Brush equalsColor = Brushes.Orange;
            Brush functionColor = Brushes.Green;
            Brush deleteColor = Brushes.Crimson;

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