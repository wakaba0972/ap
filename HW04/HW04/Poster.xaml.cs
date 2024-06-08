using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace HW04
{
    /// <summary>
    /// Poster.xaml 的互動邏輯
    /// </summary>

    public partial class Poster : Page
    {
        int position = 0;
        string[] movies_path;
        DispatcherTimer dtimer;
        double op = 0;
        short phase = 0;
        int countdown = 20;

        void get_movies()
        {
            movies_path = Directory.GetFiles(@".\image", "*.jpg");
           // display_img.Source = new BitmapImage(new Uri(d[2], UriKind.Relative));
        }

        private void tick(object sender, EventArgs e)
        {
            if(phase == 0)
            {
                if (display_img.Opacity < 1) display_img.Opacity += 0.02;
                else phase = 1;
            }
             if(phase == 1)
            {
                if (countdown > 0) countdown--;
                else
                {
                    countdown = 20;
                    phase = 2;
                }
            }

             if(phase == 2)
            {
                if (display_img.Opacity > 0.01) display_img.Opacity -= 0.02;
                else phase = 3;
            }

             if(phase == 3)
            {
                position = (position + 1) % movies_path.Length;
                display_img.Source = new BitmapImage(new Uri(movies_path[position], UriKind.Relative));
                phase = 0;
            }
        }

        public Poster()
        {
            InitializeComponent();
            get_movies();

            dtimer = new DispatcherTimer();
            dtimer.Tick += new EventHandler(tick);
            dtimer.Interval = TimeSpan.FromMilliseconds(10);  
            dtimer.Start();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dtimer.Stop();
            position = (position + 1) % movies_path.Length;
            display_img.Source = new BitmapImage(new Uri(movies_path[position], UriKind.Relative));
            dtimer.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dtimer.Stop();
            position = ((position - 1) + movies_path.Length) % movies_path.Length;
            display_img.Source = new BitmapImage(new Uri(movies_path[position], UriKind.Relative));
            dtimer.Start();
        }
    }

    
}
