using System;
using System.Runtime.Remoting.Channels;
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
        private string firstNum;
        private string secondNum;
        
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
            if (isAdding)
            {
                double total = Double.Parse(firstNum) + Double.Parse(secondNum);
                TopTextBox.Clear();
                secondNum = "";
                BottomTextBox.Text = total.ToString();
                firstNum = total.ToString();
                isAdding = false;
            }

            isOnFirstNum = true;
        }

        private void Add(object sender, RoutedEventArgs routedEventArgs)
        {
            isAdding = true;
            isOnFirstNum = false;
            TopTextBox.Text = firstNum;
            BottomTextBox.Clear();
            TopTextBox.AppendText(" + ");
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