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

namespace SamPlator
{
    /// <summary>
    /// Interaction logic for aboutWindow.xaml
    /// </summary>
    public partial class aboutWindow : Window
    {
        MainWindow mw;
        FluentBlur fb;
        public aboutWindow(MainWindow dmw)
        {
            InitializeComponent();
            fb = new FluentBlur(this);
            mw = dmw;
            /*Setting this windows's background same as mainWindow*/
            this.Background = mw.Background;
        }

        private void aboutWindow1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Show();
            MainWindow.awc = 0;
        }

        /*Closing aboutWindow*/
        private void aboutClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /*Loading BlueEffect*/
        private void aboutWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            fb.EnableBlur();
        }

    }
}
