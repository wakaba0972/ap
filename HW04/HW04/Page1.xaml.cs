using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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

namespace HW04
{
    /// <summary>
    /// Page1.xaml 的互動邏輯
    /// </summary>
    public partial class Page1 : Page
    {
        Button car;
        List<int> list = new List<int>();

        public void bind(Button _car)
        {
            car = _car;
        }

        public Page1()
        {
            InitializeComponent();
        }

        public void add(string movie, string theater, string ticket, int tp, bool[] plus)
        {
            list.Add(tp);
            string p = "";
            for (int i= 0; i < plus.Length; i++)
            {
                if (plus[i]) p += (i+1).ToString() + ",";
            }

            if(p == "") lstb.Items.Add(movie + ",  " + theater + ",  " + ticket + ",  無加購,  共" + tp + "元");
            else
            {
                lstb.Items.Add(movie + ",  " + theater + ",  " + ticket + ",  加購 " + p + "  共" + tp + "元");
            }
            change_car_num(lstb.Items.Count);
            result.Content = "數目: " + list.Count.ToString() + "  總價: " + list.Sum().ToString() + "元";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int size = lstb.Items.Count;
            for (int i=0; i < size; i++)
            {
                lstb.Items.RemoveAt(0);
                list.RemoveAt(0);
            }
            change_car_num(lstb.Items.Count);
            result.Content = "數目: " + list.Count.ToString() + "  總價: " + list.Sum().ToString() + "元";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int index = lstb.SelectedIndex;
            if (index >= 0)
            {
                lstb.Items.RemoveAt(index);
                list.RemoveAt(index);
            }
            change_car_num(lstb.Items.Count);
            result.Content = "數目: " + list.Count.ToString() + "  總價: " + list.Sum().ToString() + "元";
        }

        public void change_car_num(int num)
        {
            car.Content = "購物車(" + num + ")";
        }
    }
}
