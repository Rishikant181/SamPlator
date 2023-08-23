using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.IO;

namespace SamPlator
{
    /// <summary>
    /// Interaction logic for settingsWindow.xaml
    /// </summary>
    public partial class settingsWindow : Window
    {
        MainWindow mw;
        StreamWriter cfg = new StreamWriter("Config.cfg");
        public settingsWindow(MainWindow dmw)
        {
            InitializeComponent();
            /*File to store configuration*/
            /*Initialisations*/
            mw = dmw;                                               //MainWindow's object
            MainWindow.swc = 0;
            /*Setting radioButton from previous color*/
            if(mw.Background == Brushes.Black)
            {
                darkTheme.IsChecked = true;
            }
            else if(mw.Background == Brushes.White)
            {
                lightTheme.IsChecked = true;
            }
        }

        private void themeSelect_Click(object sender, RoutedEventArgs e)
        {
            if(sender == darkTheme)
            {
                mw.Background = Brushes.Black;
            }
            else
            {
                mw.Background = Brushes.White;
            }
        }

        /*saveConfig button Click event*/
        private void saveConfig_Click(object sender, RoutedEventArgs e)
        {
            /*Saving configuration to file*/
            cfg.WriteLine("" + mw.Background);
            cfg.Close();
        }

    }
}
