using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int cislo;
        private string displayValue;

        public MainWindow()
        {
            InitializeComponent();
            cislo = 0;
            displayValue = "";

            Cislo_0.Click += (sender, e) => AppendNumber(0, "0");
            Cislo_1.Click += (sender, e) => AppendNumber(1, "1");
            Cislo_2.Click += (sender, e) => AppendNumber(2, "2");
            Cislo_3.Click += (sender, e) => AppendNumber(3, "3");
            Cislo_4.Click += (sender, e) => AppendNumber(4, "4");
            Cislo_5.Click += (sender, e) => AppendNumber(5, "5");
            Cislo_6.Click += (sender, e) => AppendNumber(6, "6");
            Cislo_7.Click += (sender, e) => AppendNumber(7, "7");
            Cislo_8.Click += (sender, e) => AppendNumber(8, "8");
            Cislo_9.Click += (sender, e) => AppendNumber(9, "9");

            ZapornyToggle.Click += (sender, e) => NegateValue();

            Label.Content = displayValue;
        }
        private void AppendNumber(int number, string numberString)
        {
            displayValue += numberString;
            cislo = int.Parse(numberString);
        }
        private void NegateValue()
        {
            // when negative already
            if (displayValue[0] == '-')
            {
                // displayValue is now everythng from 1st index to end (cuts off 1st)
                displayValue = displayValue[1..];
                cislo *= -1;
            }
            // when positive
            else
            {
                displayValue = "-" + displayValue;
                cislo *= -1;
            }
        }

        private void Label_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}