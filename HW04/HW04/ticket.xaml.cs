using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Xml.Linq;

namespace HW04
{
    /// <summary>
    /// ticket.xaml 的互動邏輯
    /// </summary>
    /// 

    public partial class ticket : Page
    {

        DispatcherTimer[] dtimers = new DispatcherTimer[3];
        short[] ticket_form = new short[3];
        bool[] plus_form = new bool[5];
        short position = 0;
        double opc0 = 0;
        double opc1 = 0;
        double opc2 = 0;
        int price = 0;
        int pa = 0;
        int pb = 0;
        int pc = 0;
        Page1 car;

        private void tick0(object sender, EventArgs e)
        {
            if(opc0 < 1)
            {
                t1.Opacity = opc0;
                t2.Opacity = opc0;
                g1.Opacity = opc0;
            }
            else
            {
                dtimers[0].Stop();
            }
            opc0 += 0.1;
        }

        private void tick1(object sender, EventArgs e)
        {
            if (opc1 < 1)
            {
                t3.Opacity = opc1;
                t4.Opacity = opc1;
                g2.Opacity = opc1;
            }
            else
            {
                dtimers[1].Stop();
            }
            opc1 += 0.1;
        }

        private void tick2(object sender, EventArgs e)
        {
            if (opc2 < 1)
            {
                t5.Opacity = opc2;
                t6.Opacity = opc2;
                g3.Opacity = opc2;
                b0.Opacity = opc2;
            }
            else
            {
                dtimers[2].Stop();
            }
            opc2 += 0.1;
        }

        private void set_timer()
        {
            dtimers[0] = new DispatcherTimer();
            dtimers[1] = new DispatcherTimer();
            dtimers[2] = new DispatcherTimer();

            dtimers[0].Tick += new EventHandler(tick0);
            dtimers[1].Tick += new EventHandler(tick1);
            dtimers[2].Tick += new EventHandler(tick2);

            dtimers[0].Interval = TimeSpan.FromMilliseconds(20);
            dtimers[1].Interval = TimeSpan.FromMilliseconds(20);
            dtimers[2].Interval = TimeSpan.FromMilliseconds(20);
        }

        public void set_car(Page1 _car)
        {
            car = _car;
        }

        public ticket()
        {
            InitializeComponent();
            set_timer();
        }

        private void Movie_Checked(object sender, RoutedEventArgs e)
        {
            if(position == 0)
            {
                dtimers[0].Start();
                position++;
            }

            RadioButton r = (RadioButton)sender;
            string name = r.Content.ToString();

            switch (name)
            {
                case "冰雪奇緣":
                    ticket_form[0] = 0;
                    break;
                case "黑魔女：沉睡魔咒":
                    ticket_form[0] = 1;
                    break;
                case "動物方城市":
                    ticket_form[0] = 2;
                    break;
                case "美女與野獸":
                    ticket_form[0] = 3;
                    break;
                case "可可夜總會":
                    ticket_form[0] = 4;
                    break;
                case "刀劍神域":
                    ticket_form[0] = 5;
                    break;
            }
        }

        private void Room_Checked(object sender, RoutedEventArgs e)
        {
            if (position == 1)
            {
                dtimers[1].Start();
                position++;
            }

            RadioButton r = (RadioButton)sender;
            string name = r.Content.ToString();

            switch(name)
            {
                case "2D":
                    ticket_form[1] = 0;
                    pa = 20;
                    break;
                case "3D         +40$":
                    ticket_form[1] = 1;
                    pa = 40;
                    break;
                case "4DX      +60$":
                    ticket_form[1] = 2;
                    pa = 60;
                    break;
                case "IMAX    +80$":
                    ticket_form[1] = 3;
                    pa = 80;
                    break;
            }

            price = pa + pb + pc;
            but.Content = price + "元";
        }

        private void Ticket_Checked(object sender, RoutedEventArgs e)
        {
            if (position == 2)
            {
                dtimers[2].Start();
                position++;
            }

            RadioButton r = (RadioButton)sender;
            string name = r.Content.ToString();

            switch (name)
            {
                case "全票       200$":
                    ticket_form[2] = 0;
                    pb = 200;
                    break;
                case "愛心票   150$":
                    ticket_form[2] = 1;
                    pb = 150;
                    break;
                case "敬老票   160$":
                    ticket_form[2] = 2;
                    pb = 160;
                    break;
                case "優待票   170$":
                    ticket_form[2] = 3;
                    pb = 170;
                    break;
                case "會員票   180$":
                    ticket_form[2] = 4;
                    pb = 180;
                    break;
            }

            price = pa + pb + pc;
            but.Content = price + "元";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            plus_form[0] = (c0.IsChecked == true);
            plus_form[1] = (c1.IsChecked == true);
            plus_form[2] = (c2.IsChecked == true);
            plus_form[3] = (c3.IsChecked == true);
            plus_form[4] = (c4.IsChecked == true);

            string mvn = "";
            string thea = "";
            string tck = "";

            switch (ticket_form[0])
            {
                case 0:
                    mvn = "冰雪奇緣";
                    break;
                case 1:
                    mvn = "黑魔女：沉睡魔咒";
                    break;
                case 2:
                    mvn = "動物方城市";
                    break;
                case 3:
                    mvn = "美女與野獸";
                    break;
                case 4:
                    mvn = "可可夜總會";
                    break;
                case 5:
                    mvn = "刀劍神域";
                    break;
            }

            switch (ticket_form[1])
            {
                case 0:
                    thea = "2D";
                    break;
                case 1:
                    thea = "3D";
                    break;
                case 2:
                    thea = "4DX";
                    break;
                case 3:
                    thea = "IAMX";
                    break;
            }

            switch (ticket_form[2])
            {
                case 0:
                    tck = "全票";
                    break;
                case 1:
                    tck = "愛心票";
                    break;
                case 2:
                    tck = "敬老票";
                    break;
                case 3:
                    tck = "優待票";
                    break;
                case 4:
                    tck = "會員票";
                    break;
            }

            car.add(mvn, thea, tck, price, plus_form);
        }

        private void ccheck(object sender, RoutedEventArgs e)
        {
            CheckBox r = (CheckBox)sender;
            string name = r.Content.ToString();

            switch (name)
            {
                case "1) 爆米花                +50$":
                    pc += 50;
                    break;
                case "2) 肥宅快樂水        +20$":
                    pc += 20;
                    break;
                case "3) S級食材雜燴兔  +48763$":
                    pc += 48763;
                    break;
                case "4) 蟾蜍肉                +20$":
                    pc += 20;
                    break;
                case "5) 會飛的高麗菜    +100$":
                    pc += 100;
                    break;
            }

            price = pa + pb + pc;
            but.Content = price + "元";
        }

        private void cuncheck(object sender, RoutedEventArgs e)
        {
            CheckBox r = (CheckBox)sender;
            string name = r.Content.ToString();

            switch (name)
            {
                case "1) 爆米花                +50$":
                    pc -= 50;
                    break;
                case "2) 肥宅快樂水        +20$":
                    pc -= 20;
                    break;
                case "3) S級食材雜燴兔  +48763$":
                    pc -= 48763;
                    break;
                case "4) 蟾蜍肉                +20$":
                    pc -= 20;
                    break;
                case "5) 會飛的高麗菜    +100$":
                    pc -= 100;
                    break;
            }

            price = pa + pb + pc;
            but.Content = price + "元";
        }
    }
}

