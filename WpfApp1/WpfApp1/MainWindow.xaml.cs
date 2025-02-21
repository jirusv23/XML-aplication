using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private float cislo;
        private string displayValue;
        private string pridavanaHodnota;
        private bool isCarka = false;
        private int carkaCounter = 0;

        private bool scitani = false;
        private bool odcitani = false;
        private bool nasobeni = false;
        private bool deleni = false;
        private bool procentro = false;

        public MainWindow()
        {
            InitializeComponent();
            cislo = 0;
            displayValue = "";
            pridavanaHodnota = "";

            // Number buttons
            Cislo_0.Click += (sender, e) => AppendNumber("0");
            Cislo_1.Click += (sender, e) => AppendNumber("1");
            Cislo_2.Click += (sender, e) => AppendNumber("2");
            Cislo_3.Click += (sender, e) => AppendNumber("3");
            Cislo_4.Click += (sender, e) => AppendNumber("4");
            Cislo_5.Click += (sender, e) => AppendNumber("5");
            Cislo_6.Click += (sender, e) => AppendNumber("6");
            Cislo_7.Click += (sender, e) => AppendNumber("7");
            Cislo_8.Click += (sender, e) => AppendNumber("8");
            Cislo_9.Click += (sender, e) => AppendNumber("9");

            // Operation buttons
            ZapornyToggle.Click += (sender, e) => NegateValue();
            Carka.Click += (sender, e) => CarkaOnClick();
            Plus.Click += (sender, e) => PlusOnClick();
            Minus.Click += (sender, e) => MinusOnClick();
            Krat.Click += (sender, e) => KratOnClick(); // Multiply
            Deleno.Click += (sender, e) => DelenoOnClick(); // Divide
            RovnaSe.Click += (sender, e) => CalculateResult();
            CE.Click += (sender, e) => ClearAll();
            Smazat.Click += (sender, e) => deleteChar();
            Procento.Click += (sender, e) => procentoOnlcik();
        }



        private void AppendNumber(string numberString)
        {
            if (scitani || odcitani || nasobeni || deleni)
            {
                pridavanaHodnota += numberString;

                if (!pridavanaHodnota.EndsWith(".") && float.TryParse(pridavanaHodnota, out float result))
                {
                    // Store second operand temporarily
                }
                Label.Content = pridavanaHodnota;
            }
            else
            {
                displayValue += numberString;

                if (!displayValue.EndsWith(".") && float.TryParse(displayValue, out float result))
                {
                    cislo = result;
                }
                Label.Content = displayValue;
            }
        }

        private void NegateValue()
        {
            if (scitani || odcitani || nasobeni || deleni)
            {
                if (!string.IsNullOrEmpty(pridavanaHodnota))
                {
                    if (pridavanaHodnota.StartsWith("-"))
                    {
                        pridavanaHodnota = pridavanaHodnota.Substring(1);
                    }
                    else
                    {
                        pridavanaHodnota = "-" + pridavanaHodnota;
                    }
                    Label.Content = pridavanaHodnota;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(displayValue))
                {
                    if (displayValue.StartsWith("-"))
                    {
                        displayValue = displayValue.Substring(1);
                    }
                    else
                    {
                        displayValue = "-" + displayValue;
                    }

                    if (!displayValue.EndsWith(".") && float.TryParse(displayValue, out float result))
                    {
                        cislo = result;
                    }
                    Label.Content = displayValue;
                }
            }
        }

        private void CarkaOnClick()
        {
            if (scitani || odcitani || nasobeni || deleni)
            {
                if (!pridavanaHodnota.Contains("."))
                {
                    if (string.IsNullOrEmpty(pridavanaHodnota))
                    {
                        pridavanaHodnota = "0.";
                    }
                    else
                    {
                        pridavanaHodnota += ".";
                    }
                    Label.Content = pridavanaHodnota;
                }
            }
            else
            {
                if (!displayValue.Contains("."))
                {
                    if (string.IsNullOrEmpty(displayValue))
                    {
                        displayValue = "0.";
                    }
                    else
                    {
                        displayValue += ".";
                    }
                    Label.Content = displayValue;
                }
            }
        }

        private void procentoOnlcik()
        {
            if (!string.IsNullOrEmpty(pridavanaHodnota) && (scitani || odcitani || nasobeni || deleni))
            {
                CalculateResult();
            }

            scitani = false;
            odcitani = false;
            nasobeni = false;
            deleni = false;
            procentro = true;
            pridavanaHodnota = "";
        }

        private void PlusOnClick()
        {
            if (!string.IsNullOrEmpty(pridavanaHodnota) && (scitani || odcitani || nasobeni || deleni))
            {
                CalculateResult();
            }

            scitani = true;
            odcitani = false;
            nasobeni = false;
            deleni = false;
            procentro = false;
            pridavanaHodnota = "";
        }

        private void MinusOnClick()
        {
            if (!string.IsNullOrEmpty(pridavanaHodnota) && (scitani || odcitani || nasobeni || deleni))
            {
                CalculateResult();
            }

            odcitani = true;
            scitani = false;
            nasobeni = false;
            deleni = false;
            procentro = false;
            pridavanaHodnota = "";
        }

        private void KratOnClick()
        {
            if (!string.IsNullOrEmpty(pridavanaHodnota) && (scitani || odcitani || nasobeni || deleni))
            {
                CalculateResult();
            }

            nasobeni = true;
            scitani = false;
            odcitani = false;
            deleni = false;
            procentro = false;
            pridavanaHodnota = "";
        }

        private void DelenoOnClick()
        {
            if (!string.IsNullOrEmpty(pridavanaHodnota) && (scitani || odcitani || nasobeni || deleni))
            {
                CalculateResult();
            }

            deleni = true;
            scitani = false;
            odcitani = false;
            nasobeni = false;
            procentro = false;
            pridavanaHodnota = "";
        }

        private void CalculateResult()
        {
            if (!string.IsNullOrEmpty(pridavanaHodnota) && float.TryParse(pridavanaHodnota, out float secondOperand))
            {
                if (scitani)
                {
                    if (!procentro)
                        cislo += secondOperand;
                    else if (procentro)
                        cislo = cislo * (secondOperand / 100);
                }
                else if (odcitani)
                {
                    if (!procentro)
                        cislo -= secondOperand;
                    else if (procentro)
                        cislo = cislo * (secondOperand / 100);
                }
                else if (nasobeni)
                {
                    cislo *= secondOperand;
                }
                else if (deleni)
                {
                    if (secondOperand != 0)
                    {
                        cislo /= secondOperand;
                    }
                    else
                    {
                        Label.Content = "Error";
                        return;
                    }
                }

                displayValue = cislo.ToString();
                Label.Content = displayValue;

                pridavanaHodnota = "";
                scitani = false;
                odcitani = false;
                nasobeni = false;
                deleni = false;
                procentro = false;
            }
        }

        private void ClearAll()
        {
            cislo = 0;
            displayValue = "";
            pridavanaHodnota = "";
            scitani = false;
            odcitani = false;
            nasobeni = false;
            deleni = false;
            procentro = false;
            Label.Content = "";
        }

        private void deleteChar()
        {
            if (scitani || odcitani || nasobeni || deleni)
            {
                if (!string.IsNullOrEmpty(pridavanaHodnota))
                {
                    pridavanaHodnota = pridavanaHodnota.Remove(pridavanaHodnota.Length - 1);
                    Label.Content = string.IsNullOrEmpty(pridavanaHodnota) ? "0" : pridavanaHodnota;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(displayValue))
                {
                    displayValue = displayValue.Remove(displayValue.Length - 1);
                    cislo = float.TryParse(displayValue, out float result) ? result : 0;
                    Label.Content = string.IsNullOrEmpty(displayValue) ? "0" : displayValue;
                }
            }
        }

        private void Label_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
