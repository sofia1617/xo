using System;
using System.Collections;
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

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        int a;
        Random rand = new Random();
        int b;
        int robotik = 1;
        int tblk;
        bool c = false;
        List<Button> buttons = new List<Button>();
        public MainWindow()
        {
            InitializeComponent();
            buttons.Add(Button1);
            buttons.Add(Button2);
            buttons.Add(Button3);
            buttons.Add(Button4);
            buttons.Add(Button5);
            buttons.Add(Button6);
            buttons.Add(Button7);
            buttons.Add(Button8);
            buttons.Add(Button9);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tblk++;
            if (robotik == 0)
            {
                ((Button)sender).Content = "X";
                ((Button)sender).IsEnabled = false;
                winner();
                if (c == false & tblk < 9) RoboRandom();
            }
            else if (robotik == 1)
            {
                ((Button)sender).Content = "0";
                ((Button)sender).IsEnabled = false;
                winner();
                if (c == false & tblk < 9) RoboRandom();
            }
        }
        private void winner()
        {
            if ((string)Button1.Content == "0" && (string)Button2.Content == "0" && (string)Button3.Content == "0"
                || (string)Button4.Content == "0" && (string)Button5.Content == "0" && (string)Button6.Content == "0"
                || (string)Button7.Content == "0" && (string)Button8.Content == "0" && (string)Button9.Content == "0"
                || (string)Button1.Content == "0" && (string)Button5.Content == "0" && (string)Button9.Content == "0"
                || (string)Button3.Content == "0" && (string)Button5.Content == "0" && (string)Button7.Content == "0"
                || (string)Button1.Content == "0" && (string)Button4.Content == "0" && (string)Button7.Content == "0"
                || (string)Button2.Content == "0" && (string)Button5.Content == "0" && (string)Button8.Content == "0"
                || (string)Button3.Content == "0" && (string)Button6.Content == "0" && (string)Button9.Content == "0")
            {
                c = true;
                showtext.Text = "ПОБЕДИЛИ НОЛИКИ";
                Enabled(false);
            }
            else if ((string)Button1.Content == "X" && (string)Button2.Content == "X" && (string)Button3.Content == "X"
                || (string)Button4.Content == "X" && (string)Button5.Content == "X" && (string)Button6.Content == "X"
                || (string)Button7.Content == "X" && (string)Button8.Content == "X" && (string)Button9.Content == "X"
                || (string)Button1.Content == "X" && (string)Button5.Content == "X" && (string)Button9.Content == "X"
                || (string)Button3.Content == "X" && (string)Button5.Content == "X" && (string)Button7.Content == "X"
                || (string)Button1.Content == "X" && (string)Button4.Content == "X" && (string)Button7.Content == "X"
                || (string)Button2.Content == "X" && (string)Button5.Content == "X" && (string)Button8.Content == "X"
                || (string)Button3.Content == "X" && (string)Button6.Content == "X" && (string)Button9.Content == "X")
            {
                c = true;
                showtext.Text = "ПОБЕДИЛИ КРЕСТИКИ";
                Enabled(false);
            }
            else if (((tblk % 9) == 0 && tblk != 0) & c == false)
            {       
                showtext.Text = "НИЧЬЯ";
            }
        }
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            tblk = 0;
            c = false;
            showtext.Text = "КРЕСТИКИ-НОЛИКИ";
            switch (robotik)
            {
                case 0:
                    robotik = 1;
                    break;
                case 1:
                    robotik = 0;
                    break;
            }
            Enabled(true);
            foreach (var button in buttons)
            {
                button.Content = "";
            }
            if (robotik == 1) RoboRandom();
        }
        private void RoboRandom()
        {
            a++;
            b = rand.Next(0, 8);
            if (robotik == 0 & (string)buttons[b].Content == "")
            {
                tblk++;
                buttons[b].Content = "0";
                buttons[b].IsEnabled = false;
                winner();
            }
            else if (robotik == 1 & (string)buttons[b].Content == "")
            {
                tblk++;
                buttons[b].Content = "X";
                buttons[b].IsEnabled = false;
                winner();
            }
            else if (tblk == 8)
            {
                foreach (var button in buttons)
                {
                    if ((string)button.Content == "")
                    {
                        if (robotik == 0)
                        {
                            button.Content = "0";
                            button.IsEnabled = false;
                            showtext.Text = "НИЧЬЯ";
                        }
                        if (robotik == 1)
                        {
                            button.Content = "X";
                            button.IsEnabled = false;
                            showtext.Text = "НИЧЬЯ";
                        }
                    }
                }
            }
            else
            {
                RoboRandom();
            }

        }
        private void Enabled(bool isEnabled)
        {
            foreach (var button in buttons)
            {
                button.IsEnabled = isEnabled;
            }
        }
    }
}