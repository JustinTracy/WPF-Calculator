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
        
        private bool isOnFirstNum = true;
        private bool isAdding;
        private bool isSubtracting;
        private bool isMultiplying;
        private bool isDividing;
        
        public MainWindow()
        {
            InitializeComponent();
            SetUniqueColors();
        }

        private void Equals(object sender, RoutedEventArgs routedEventArgs)
        {
            if (BottomTextBox.Text.Equals("")) return;
            
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
        }

        private void Square(object sender, RoutedEventArgs routedEventArgs)
        {
            if (isOnFirstNum)
            {
                firstNum = (Double.Parse(firstNum) * Double.Parse(firstNum)).ToString();
                BottomTextBox.Text = firstNum;
                Console.WriteLine(1);
            }
            else
            {
                secondNum = (Double.Parse(secondNum) * Double.Parse(secondNum)).ToString();
                BottomTextBox.Text = secondNum;
                Console.WriteLine(2);
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
            BottomTextBox.AppendText(".");
        }

        private void Add(object sender, RoutedEventArgs routedEventArgs)
        {
            ClearOperators();
            isAdding = true;
            isOnFirstNum = false;
            TopTextBox.Text = firstNum;
            BottomTextBox.Clear();
            TopTextBox.AppendText(" + ");
        }
        
        private void Subtract(object sender, RoutedEventArgs routedEventArgs)
        {
            ClearOperators();
            isSubtracting = true;
            isOnFirstNum = false;
            TopTextBox.Text = firstNum;
            BottomTextBox.Clear();
            TopTextBox.AppendText(" - ");
        }
        
        private void Multiply(object sender, RoutedEventArgs routedEventArgs)
        {
            ClearOperators();
            isMultiplying = true;
            isOnFirstNum = false;
            TopTextBox.Text = firstNum;
            BottomTextBox.Clear();
            TopTextBox.AppendText(" * ");
        }
        
        private void Divide(object sender, RoutedEventArgs routedEventArgs)
        {
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

            if (isOnFirstNum)
            {
                BottomTextBox.AppendText(tag.ToString());
                firstNum = BottomTextBox.Text;
            }
            else
            {
                BottomTextBox.AppendText(tag.ToString());
                secondNum = BottomTextBox.Text;
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