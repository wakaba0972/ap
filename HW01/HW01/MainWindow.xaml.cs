using System.Windows;
using System.Windows.Input;


namespace HW01 { 
    public partial class MainWindow : Window
    {
        int start = 0;
        char[] chr = new char[3] {'A', 'B', 'C'};

        private void Label_Left_Shift()
        {
            start = (start + 1) % 3;
            label0.Content = chr[start];
            label1.Content = chr[(start + 1) % 3];
            label2.Content = chr[(start + 2) % 3];
        }

        private void Label_Right_Shift()
        {
            start = (start - 1 + 3) % 3;
            label0.Content = chr[start];
            label1.Content = chr[(start + 1) % 3];
            label2.Content = chr[(start + 2) % 3];
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Left_Click(object sender, RoutedEventArgs e)
        {
            Label_Left_Shift();

        }

        private void Button_Right_Click(object sender, RoutedEventArgs e)
        {
            Label_Right_Shift();
        }

        private void Button_Key_Down(object sender, KeyEventArgs e)
        {
            switch(e.Key.ToString())
            {
                case "Left":
                    Label_Left_Shift();
                    break;

                case "Right":
                    Label_Right_Shift();
                    break;

                default:
                    break;
            }
        }
    }
}