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
            Smazat.Click += (sender, e) => DeleteChar();
            Procento.Click += (sender, e) => ProcentoOnClick();
            Odmocnina.Click += (sender, e) => OdmocninaOperace();
            naDruhou.Click += (sender, e) => naDruhouOperace();
            naMinusPrvou.Click += (sender, e) => naMinusPrvouOperace();
            C.Click += (sender, e) => clearAddedValue();

        }

        private void OdmocninaOperace()
        {
            float result = (float)Math.Sqrt(cislo);
            displayValue = result.ToString();
            cislo = result;

            Label.Content = displayValue;
        }

        private void naDruhouOperace()
        {
            float result = cislo * cislo;
            displayValue = result.ToString();
            cislo = result;

            Label.Content = displayValue;
        }

        private void naMinusPrvouOperace()
        {
            float result = 1 / cislo;
            displayValue = result.ToString();
            cislo = result;

            Label.Content = displayValue;
        }

        private void SetOperation(string operation)
        {
            scitani = operation == "scitani";
            odcitani = operation == "odcitani";
            nasobeni = operation == "nasobeni";
            deleni = operation == "deleni";
            procentro = operation == "procentro";
        }

        private void clearAddedValue()
        {
            if (scitani || odcitani || nasobeni || deleni || procentro)
            {
                pridavanaHodnota = "";
                Label.Content = pridavanaHodnota;
            }
        }

        private void AppendNumber(string numberString)
        {
            if (scitani || odcitani || nasobeni || deleni || procentro)
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
            if (scitani || odcitani || nasobeni || deleni || procentro)
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
            if (scitani || odcitani || nasobeni || deleni || procentro)
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

        private void ProcentoOnClick()
        {
            if (!string.IsNullOrEmpty(pridavanaHodnota) && (scitani || odcitani || nasobeni || deleni || procentro))
            {
                CalculateResult();
            }

            SetOperation("procentro");
            pridavanaHodnota = "";
        }

        private void PlusOnClick()
        {
            if (!string.IsNullOrEmpty(pridavanaHodnota) && (scitani || odcitani || nasobeni || deleni || procentro))
            {
                CalculateResult();
            }

            SetOperation("scitani");
            pridavanaHodnota = "";
        }

        private void MinusOnClick()
        {
            if (!string.IsNullOrEmpty(pridavanaHodnota) && (scitani || odcitani || nasobeni || deleni || procentro))
            {
                CalculateResult();
            }

            SetOperation("odcitani");
            pridavanaHodnota = "";
        }

        private void KratOnClick()
        {
            if (!string.IsNullOrEmpty(pridavanaHodnota) && (scitani || odcitani || nasobeni || deleni || procentro))
            {
                CalculateResult();
            }

            SetOperation("nasobeni");
            pridavanaHodnota = "";
        }

        private void DelenoOnClick()
        {
            if (!string.IsNullOrEmpty(pridavanaHodnota) && (scitani || odcitani || nasobeni || deleni || procentro))
            {
                CalculateResult();
            }

            SetOperation("deleni");
            pridavanaHodnota = "";
        }

        private void CalculateResult()
        {
            if (!string.IsNullOrEmpty(pridavanaHodnota) && float.TryParse(pridavanaHodnota, out float secondOperand))
            {
                if (scitani)
                {
                    cislo += secondOperand;
                }
                else if (odcitani)
                {
                    cislo -= secondOperand;
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
                else if (procentro)
                {
                    cislo = cislo * (secondOperand / 100);
                }

                displayValue = cislo.ToString();
                Label.Content = displayValue;

                pridavanaHodnota = "";
                SetOperation("");
            }
        }

        private void ClearAll()
        {
            cislo = 0;
            displayValue = "";
            pridavanaHodnota = "";
            SetOperation("");
            Label.Content = "0";
        }

        private void DeleteChar()
        {
            if (scitani || odcitani || nasobeni || deleni || procentro)
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