using System.IO;
using System.Security.Policy;
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

namespace HW04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //object[] posters = { new Poster(), new ticket(), new Page1() };
        Poster poster = new Poster();
        ticket ticket1 = new ticket();
        Page1 page1 = new Page1();

        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(poster);
            ticket1.set_car(page1);
            page1.bind(car);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(poster);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frame.Navigate(ticket1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            frame.Navigate(page1);
        }
    }
}