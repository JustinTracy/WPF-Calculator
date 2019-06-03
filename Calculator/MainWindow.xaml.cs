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
        private string firstNum;
        private string secondNum;

        private bool isOnFirstNum = true;
        public MainWindow()
        {
            InitializeComponent();
            SetUniqueColors();
        }

        private void DisplayNumber(object sender, RoutedEventArgs routedEventArgs)
        {
            var tag = ((Button)sender).Tag;

            if (isOnFirstNum)
            {
                firstNum += tag.ToString();
                BottomTextBox.AppendText(tag.ToString());
            }
            else
            {
                secondNum += tag.ToString();
                TopTextBox.AppendText(tag.ToString());
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
                }
            }
            else
            {
                textLength = TopTextBox.ToString().Length;
                currentString = TopTextBox.Text.Substring(0, textLength - 1);
                TopTextBox.Text = currentString;
                secondNum = currentString;
            }
        }

        private void ClearDisplay(object sender, RoutedEventArgs routedEventArgs)
        {
            TopTextBox.Clear();
            BottomTextBox.Clear();
            firstNum = "";
            secondNum = "";
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