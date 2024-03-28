// 1% OOP
// 99% If-Else and String Processing
// How tf it works??

using System.Windows;
using System.Windows.Controls;

namespace HW02
{
    public partial class MainWindow : Window
    {
        readonly Dictionary<string, string> map = new Dictionary<string, string>()
        {
            {"NumPad9", "9"},
            {"NumPad8", "8"},
            {"NumPad7", "7"},
            {"NumPad6", "6"},
            {"NumPad5", "5"},
            {"NumPad4", "4"},
            {"NumPad3", "3"},
            {"NumPad2", "2"},
            {"NumPad1", "1"},
            {"NumPad0", "0"},
            {"D9", "9"},
            {"D8", "8"},
            {"D7", "7"},
            {"D6", "6"},
            {"D5", "5"},
            {"D4", "4"},
            {"D3", "3"},
            {"D2", "2"},
            {"D1", "1"},
            {"D0", "0"},
            {"Add", "+"},
            {"Subtract", "-"},
            {"Multiply", "*"},
            {"Divide", "/"},
            {"Decimal", "."},
            {"Return", "enter"},
            {"Back", "back"},
            {"C", "c"},
            {"c", "c"},
            {"M", "mod"},
            {"m", "mod"},
            {"H", "help"},
            {"h", "help"},
            {"OemMinus", "-"},
            {"OemPlus", "enter"},
            {"OemQuestion", "/"},
            {"OemPeriod", "."},
        };

        private string str1 = "", str2 = "", soper = "";

        private void dispkay()
        {
            textbox_A.Text = str2 + ' ' + soper;
            textbox_B.Text = str1;
        }

        private void process(string s)
        {
            switch (s)
            {
                case "+":
                    if (soper != "+")
                    {
                        calc();
                        soper = "+";
                        dispkay();
                    }

                    calc();

                    break;
                case "-":
                    if (soper == "" && str2 == "")
                    {
                        str2 = str1;
                        str1 = "";
                        soper = "-";
                        dispkay();

                        //return;
                    }
                    if (soper != "-" && str1 == "")
                    {
                        soper = "-";
                        dispkay();

                        //return;
                    }
                    else if (soper != "-")
                    {
                        calc();
                        soper = "-";
                        dispkay();
                    }

                    calc();

                    break;
                case "*":
                    if (soper == "" && str2 == "")
                    {
                        str2 = str1;
                        str1 = "";
                        soper = "*";
                        dispkay();

                        //return;
                    }

                    else if (soper != "*" && str1 == "")
                    {
                        soper = "*";
                        dispkay();

                        //return;
                    }

                    else if (soper != "*")
                    {
                        calc();
                        soper = "*";
                        dispkay();
                    }

                    calc();

                    break;

                case "/":
                    if (soper == "" && str2 == "")
                    {
                        str2 = str1;
                        str1 = "";
                        soper = "/";
                        dispkay();

                        //return;
                    }

                    else if (soper != "/" && str1 == "")
                    {
                        soper = "/";
                        dispkay();

                        //return;
                    }

                    else if (soper != "/")
                    {
                        calc();
                        soper = "/";
                        dispkay();

                        return;
                    }

                    calc();
                    break;

                case "mod":
                    if (soper == "" && str2 == "")
                    {
                        str2 = str1;
                        str1 = "";
                        soper = "mod";
                        dispkay();

                        return;
                    }

                    else if (soper != "mod" && str1 == "")
                    {
                        soper = "mod";
                        dispkay();

                        //return;
                    }

                    else if (soper != "mod")
                    {
                        calc();
                        soper = "mod";
                        dispkay();

                        return;
                    }

                    calc();
                    break;

                case ".":
                    Dot();
                    break;

                case "enter":
                    Enter();
                    break;

                case "c":
                    Clear();
                    break;

                case "back":
                    Back();
                    break;

                case "help":
                    Help();
                    break;

                default:
                    if (char.IsDigit(s[0])) Num(s);
                    break;
            }
        }

        private void Button_Oper(object sender, RoutedEventArgs e)
        {
            string s = ((Button)sender).Content.ToString();
            process(s);
        }

        private void Button_Dot(object sender, RoutedEventArgs e)
        {
            Dot();
        }

        private void Enter()
        {
            calc();
            soper = "";

            if(str1 == "")
            {
                str1 = str2;
                str2 = "";
            }
            dispkay();
        }

        private void Button_Enter(object sender, RoutedEventArgs e)
        {
            Enter();
        }

        private void Clear()
        {
            str1 = str2 = soper = "";
            dispkay();
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Back()
        {
            if (str1.Length == 0) return;

            str1 = str1.Remove(str1.Length - 1);
            dispkay();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            Back();
        }

        private void Num(string s)
        {
            if (str1.Length > 20) return;
            if (soper == "") str2 = "";
            str1 += s;
            dispkay();
        }

        private void Button_Num(object sender, RoutedEventArgs e)
        {
            string s = ((Button) sender).Content.ToString();

            Num(s);
        }

        private double s2d(string s)
        {
            double d;
            bool b = double.TryParse(s, out d);

            if (b) return d;
            else return 0.0;
        }

        private long s2l(string s)
        {
            long d;
            bool b = long.TryParse(s, out d);

            if (b) return d;
            else return 0;
        }

        private void calc()
        {
            switch (soper)
            {
                case "+":
                    str2 = Add(str1, str2);
                    str1 = "";
                    dispkay();

                    break;

                case "-":
                    str2 = Sub(str2, str1);
                    str1 = "";
                    dispkay();

                    break;

                case "*":
                    if (str1 == "") str1 = "1";
                    if (str2 == "") str2 = "1";

                    str2 = Mul(str2, str1);
                    str1 = "";
                    dispkay();

                    break;

                case "/":
                    if (str1 == "0")
                    {
                        str1 = str2 = soper = "";
                        dispkay();

                        return;
                    }

                    if (str1 == "") str1 = "1";
                    if (str2 == "") str2 = "1";

                    str2 = Div(str2, str1);
                    str1 = "";
                    dispkay();

                    break;

                case "mod":
                    if (str1 == "0")
                    {
                        str1 = str2 = soper = "";
                        textbox_A.Text = str2 + soper + '\n' + str1;

                        return;
                    }

                    if (str1 == "") return;
                    if (str2 == "") str2 = "1";

                    str2 = Mod(str2, str1);
                    str1 = "";
                    dispkay();

                    break;

                default:
                    break;
            }
        }
        private void Dot()
        {
            if (str1.IndexOf('.') != -1) return;

            str1 += '.';
            dispkay();
        }

        private string Add(string s1, string s2)
        {
            double res = s2d(s1) + s2d(s2);
            return res.ToString();
        }

        private string Sub(string s1, string s2)
        {
            double res = s2d(s1) - s2d(s2);
            return res.ToString();
        }

        private string Mul(string s1, string s2)
        {
            double res = s2d(s1) * s2d(s2);
            return res.ToString();
        }

        private string Div(string s1, string s2)
        {

                double res = s2d(s1) / s2d(s2);
                return res.ToString();
        }

        private string Mod(string s1, string s2)
        {
            double res = s2d(s1) % s2d(s2);
            return res.ToString();
        }

        private void Key_Listener(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //MessageBox.Show(e.Key.ToString());
            string key = e.Key.ToString();
            if(map.ContainsKey(key)) process(map[key]);
        }


        private void Help()
        {
            string msg = "鍵盤\t\t按鈕\n\n" +
                "0~9\t\t0~9\n" +
                "+\t\t+\n" +
                "-\t\t-\n" +
                "*\t\t*\n" +
                "/\t\t/\n" +
                ".\t\t.\n" +
                "Enter\t\t=\n" +
                "Back\t\t←\n" +
                "C/c\t\tc\n" +
                "M/m\t\tmod\n" +
                "H/h\t\thelp\n";

            MessageBox.Show(msg);
        }

        private void Help_Win(object sender, RoutedEventArgs e)
        {
            Help();
        }
    }
}