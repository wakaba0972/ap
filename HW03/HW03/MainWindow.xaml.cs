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
using System.Windows.Threading;

namespace HW03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int LEFT = 0;
        const int RIGHT = 800;
        const int TOP = 0;
        const int BOTTOM = 300;
        int dt = 25;
        int vx = 5, vy = 5;
        int cx = 0, cy = 0;
        bool cr = false;
        bool colorful_b = false;
        bool size_b = false;
        bool time_b = false;

        Random rnd;
        DispatcherTimer dtimer;

        public MainWindow()
        {
            InitializeComponent();

            rnd = new Random();

            dtimer = new DispatcherTimer();
            dtimer.Tick += new EventHandler(tick);
            dtimer.Interval = TimeSpan.FromMilliseconds(dt);
            dtimer.Start();

            //img.Source = new BitmapImage(new Uri("/HW03;component/kirito.png", UriKind.Relative));
            //MessageBox.Show(img.Source.ToString());
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(dtimer != null) dtimer.Interval = TimeSpan.FromMilliseconds(51 - slide.Value);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox rb = (CheckBox)sender;
            string key = rb.Content.ToString();

            switch (key)
            {
                case "colorful":
                    colorful_b = true;
                    break;

                case "size":
                    size_b = true;
                    break;

                case "time":
                    time_b = true;
                    break;

                case "dvd":
                    tb.IsEnabled = false;
                    cb.IsEnabled = false;

                    obj.Visibility = Visibility.Hidden;
                    img.Visibility = Visibility.Visible;
                    break;

                default:
                    break;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox rb = (CheckBox)sender;
            string key = rb.Content.ToString();

            switch (key)
            {
                case "colorful":
                    colorful_b = false;
                    break;

                case "size":
                    size_b = false;
                    break;

                case "time":
                    time_b = false;
                    break;

                case "dvd":
                    tb.IsEnabled = true;
                    cb.IsEnabled = true;

                    obj.Visibility = Visibility.Visible;
                    img.Visibility = Visibility.Hidden;
                    break;

                default:
                    break;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            string key = rb.Content.ToString();

            switch (key)
            {
                case "horizon":
                    cx = 1;
                    cy = 0;
                    cr = false;
                    break;

                case "vertical":
                    cx = 0;
                    cy = 1;
                    cr = false;
                    break;

                case "jump":
                    cx = 1;
                    cy = 1;
                    cr = false;
                    break;

                case "random":
                    cx = 0;
                    cy = 0;
                    cr = true;
                    break;

                default:
                    break;
            }
        }

        private void tick(object sender, EventArgs e){
            // update position
            if ((obj.Margin.Left >= RIGHT - obj.Width && vx > 0) || (obj.Margin.Left <= LEFT && vx < 0)) vx = -vx;
            if ((obj.Margin.Top >= BOTTOM - obj.Height && vy > 0) || (obj.Margin.Top <= TOP && vy < 0)) vy = -vy;
            obj.Margin = new Thickness(obj.Margin.Left + cx * vx, obj.Margin.Top + cy * vy, 0, 0);

            if ((img.Margin.Left >= RIGHT - img.Width && vx > 0) || (img.Margin.Left <= LEFT && vx < 0)) vx = -vx;
            if ((img.Margin.Top >= BOTTOM - img.Height && vy > 0) || (img.Margin.Top <= TOP && vy < 0)) vy = -vy;
            img.Margin = new Thickness(img.Margin.Left + cx * vx, img.Margin.Top + cy * vy, 0, 0);

            // random position
            if (cr)
            {
                int l = rnd.Next(LEFT, RIGHT - (int)img.Width);
                int t = rnd.Next(TOP, BOTTOM- (int)img.Height);
                obj.Margin = new Thickness(l, t, 0, 0);
                img.Margin = new Thickness(l, t, 0, 0);
            }

            // update color
            if (colorful_b)
            {
                Color color = Color.FromRgb((byte)rnd.Next(255), (byte)rnd.Next(255), (byte)rnd.Next(255));
                obj.Foreground = new SolidColorBrush(color);
            }

            // update size
            if (size_b)
            {
                obj.FontSize = rnd.Next(5, 30);
                int s = rnd.Next(50, 300);
                img.Width = s;
                img.Height = 320 / 230 * s;
            }

            // show date
            if (time_b) obj.Content = DateTime.Now.ToString();
            else obj.Content = "٩(´ᗜ`*)୨";

        }
    }
}