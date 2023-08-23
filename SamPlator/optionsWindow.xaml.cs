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
using System.Drawing;
using System.IO;

namespace SamPlator
{
    /// <summary>
    /// Interaction logic for optionsWindow.xaml
    /// </summary>
    public partial class optionsWindow : Window
    {
        byte a = 120;                                                    //To store Color Alpha component
        byte r = 15;                                                     //To store Color Red component
        byte g = 15;                                                     //To store Color Green component
        byte b = 15;                                                     //To store Color Blue component
        SolidColorBrush scb;                                        //To store color as SolidColorBrush
        SolidColorBrush bck;                                        //To store backup of currentSolidColorBrush
        MainWindow mw;
        FluentBlur fb;
        /*ColorDialog*/
        System.Windows.Forms.ColorDialog cd = new System.Windows.Forms.ColorDialog();
        public optionsWindow(MainWindow dmw)
        {
            InitializeComponent();
            fb = new FluentBlur(this);
            mw = dmw;
            this.Background = mw.Background;
            /*Setting initial component values from current transparency value*/
            try
            {
                StreamReader sr = new StreamReader("ColorConfig");
                a = Byte.Parse(sr.ReadLine());
                r = Byte.Parse(sr.ReadLine());
                g = Byte.Parse(sr.ReadLine());
                b = Byte.Parse(sr.ReadLine());
                sr.Close();
            }
            catch
            {
                a = 120;
                r = 15;
                g = 15;
                b = 15;
            }
            trpSlider.Value = (a / 255.0) * 100;
            opacityLevelLabel.Content = "" + Math.Round(trpSlider.Value, 0);
            /*Checking altKey state*/
            if(mw.altKey == true)
            {
                altPage.IsChecked = true;
            }
            else
            {
                altPage.IsChecked = false;
            }
        }
        
        /*Showing colorDialog cd*/
        private void showColor_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("WARNING ! Setting custom color will remove translusency effect.\nTo restore translusency, set color to default");
            cd.ShowDialog();
            /*Applying color*/
            a = cd.Color.A;                                            //Storing alpha component
            r = cd.Color.R;                                            //Storing red component
            g = cd.Color.G;                                            //Storing green component
            b = cd.Color.B;                                            //Storing blue component
            /*Storing as SolidColorBrush*/
            scb = new SolidColorBrush(System.Windows.Media.Color.FromArgb(a, r, g, b));
            /*Applying SolidColorBrush*/
            this.Background = scb;                                     //To optionsWindow
            mw.Background = scb;                                       //To mainWindow
        }
        
        private void defaultColor_Click(object sender, RoutedEventArgs e)
        {
            a = 120;
            r = 0;
            g = 0;
            b = 0;
            /*Storing as SolidColorBrush*/
            scb = new SolidColorBrush(System.Windows.Media.Color.FromArgb(a, r, g, b));
            /*Applying SolidColorBrush*/
            this.Background = scb;                              //To optionsWindow
            mw.Background = scb;                                //To mainWindow
        }

        /*Saving color data to File*/
        private void saveColor_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("ColorConfig");
            sw.WriteLine("" + a);                               //Storing alpha component
            sw.WriteLine("" + r);                               //Storing red component
            sw.WriteLine("" + g);                               //Storing green component
            sw.WriteLine("" + b);                               //Storing blues component
            sw.Close();                                         //Closing file
            this.Close();                                       //Closing window
        }

        /*Loading previous color data from file*/
        private void cancelColor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("ColorConfig");
                a = Byte.Parse(sr.ReadLine());                      //Storing alpha component
                r = Byte.Parse(sr.ReadLine());                      //Storing red component
                g = Byte.Parse(sr.ReadLine());                      //Storing green component
                b = Byte.Parse(sr.ReadLine());                      //Storing blues component
                sr.Close();                                         //Closing file
            }
            catch
            {
                a = 120;                                            //Storing default alpha component
                r = 15;                                             //Storing default red component
                g = 15;                                             //Storing default green component
                b = 15;                                             //Storing default blue component
            }
            finally
            {
                /*Storing color as backup SolidColorBrush*/
                bck = new SolidColorBrush(System.Windows.Media.Color.FromArgb(a, r, g, b));
                this.Background = bck;                              //Restoring Color for this
                mw.Background = bck;                                //Restoring Color for MainWindow
                this.Close();                                       //Closing window
            }
        }

        /*Event while closing this window*/
        private void optionsWindow1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Show();
            fb = null;
            MainWindow.owc = 0;
        }

        /*Closing optionsWindow*/
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /*Applying BlueEffect on Window Load*/
        private void optionsWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            fb.EnableBlur();
        }

        /*Changing alpha component*/
        private void trpSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int d = (int)Math.Ceiling(trpSlider.Value);
            d = (int)Math.Ceiling((d / 100.0) * 255);
            a = (byte)d;
            /*Storing as SolidColorBrush*/
            scb = new SolidColorBrush(System.Windows.Media.Color.FromArgb(a, r, g, b));
            /*Applying SolidColorBrush*/
            this.Background = scb;                                     //To optionsWindow
            mw.Background = scb;                                       //To mainWindow
            /*Changing label value*/
            opacityLevelLabel.Content = "" + Math.Round(trpSlider.Value, 0);
        }

        /*Changing slider with mouseWheel*/
        private void trpSlider_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            try
            {
                trpSlider.Value += e.Delta / 120.0;
            }
            catch
            {

            }
        }

        /*Event to use alternative page keys*/
        private void altPage_Checked(object sender, RoutedEventArgs e)
        {
            mw.altKey = true;
            /*Changing keys*/
            mw.p[0] = Key.D1;
            mw.p[1] = Key.D2;
            mw.p[2] = Key.D3;
            mw.p[3] = Key.D4;
            mw.p[4] = Key.D5;
            mw.p[5] = Key.D6;
            mw.p[6] = Key.D7;
            mw.p[7] = Key.D8;
            /*Hiding used num key buttons*/
            for(int i = 4 ; i <= 6 ; i++)
            {
                /*For page A*/
                mw.bA[i].Visibility = System.Windows.Visibility.Hidden;
                mw.bA[i+12].Visibility = System.Windows.Visibility.Hidden;
                if(i < 6)
                {
                    mw.bA[i + 24].Visibility = System.Windows.Visibility.Hidden;
                }
                /*For page B*/
                mw.bB[i].Visibility = System.Windows.Visibility.Hidden;
                mw.bB[i + 12].Visibility = System.Windows.Visibility.Hidden;
                if (i < 6)
                {
                    mw.bB[i + 24].Visibility = System.Windows.Visibility.Hidden;
                }
                /*For page C*/
                mw.bC[i].Visibility = System.Windows.Visibility.Hidden;
                mw.bC[i + 12].Visibility = System.Windows.Visibility.Hidden;
                if (i < 6)
                {
                    mw.bC[i + 24].Visibility = System.Windows.Visibility.Hidden;
                }
                /*For page D*/
                mw.bD[i].Visibility = System.Windows.Visibility.Hidden;
                mw.bD[i + 12].Visibility = System.Windows.Visibility.Hidden;
                if (i < 6)
                {
                    mw.bD[i + 24].Visibility = System.Windows.Visibility.Hidden;
                }
                /*For page E*/
                mw.bE[i].Visibility = System.Windows.Visibility.Hidden;
                mw.bE[i + 12].Visibility = System.Windows.Visibility.Hidden;
                if (i < 6)
                {
                    mw.bE[i + 24].Visibility = System.Windows.Visibility.Hidden;
                }
                /*For page F*/
                mw.bF[i].Visibility = System.Windows.Visibility.Hidden;
                mw.bF[i + 12].Visibility = System.Windows.Visibility.Hidden;
                if (i < 6)
                {
                    mw.bF[i + 24].Visibility = System.Windows.Visibility.Hidden;
                }
                /*For page G*/
                mw.bG[i].Visibility = System.Windows.Visibility.Hidden;
                mw.bG[i + 12].Visibility = System.Windows.Visibility.Hidden;
                if (i < 6)
                {
                    mw.bG[i + 24].Visibility = System.Windows.Visibility.Hidden;
                }
                /*For page H*/
                mw.bH[i].Visibility = System.Windows.Visibility.Hidden;
                mw.bH[i + 12].Visibility = System.Windows.Visibility.Hidden;
                if (i < 6)
                {
                    mw.bH[i + 24].Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }

        /*Event to use defualt page keys*/
        private void altPage_Unchecked(object sender, RoutedEventArgs e)
        {
            mw.altKey = false;
            /*Changing keys*/
            mw.p[0] = Key.Insert;
            mw.p[1] = Key.Home;
            mw.p[2] = Key.PageUp;
            mw.p[3] = Key.Delete;
            mw.p[4] = Key.End;
            mw.p[5] = Key.PageDown;
            mw.p[6] = Key.Left;
            mw.p[7] = Key.Right;
            /*Hiding used num key buttons*/
            for (int i = 4; i <= 6; i++)
            {
                /*For page A*/
                mw.bA[i].Visibility = System.Windows.Visibility.Visible;
                mw.bA[i + 12].Visibility = System.Windows.Visibility.Visible;
                if (i < 6)
                {
                    mw.bA[i + 24].Visibility = System.Windows.Visibility.Visible;
                }
                /*For page B*/
                mw.bB[i].Visibility = System.Windows.Visibility.Visible;
                mw.bB[i + 12].Visibility = System.Windows.Visibility.Visible;
                if (i < 6)
                {
                    mw.bB[i + 24].Visibility = System.Windows.Visibility.Visible;
                }
                /*For page C*/
                mw.bC[i].Visibility = System.Windows.Visibility.Visible;
                mw.bC[i + 12].Visibility = System.Windows.Visibility.Visible;
                if (i < 6)
                {
                    mw.bC[i + 24].Visibility = System.Windows.Visibility.Visible;
                }
                /*For page D*/
                mw.bD[i].Visibility = System.Windows.Visibility.Visible;
                mw.bD[i + 12].Visibility = System.Windows.Visibility.Visible;
                if (i < 6)
                {
                    mw.bD[i + 24].Visibility = System.Windows.Visibility.Visible;
                }
                /*For page E*/
                mw.bE[i].Visibility = System.Windows.Visibility.Visible;
                mw.bE[i + 12].Visibility = System.Windows.Visibility.Visible;
                if (i < 6)
                {
                    mw.bE[i + 24].Visibility = System.Windows.Visibility.Visible;
                }
                /*For page F*/
                mw.bF[i].Visibility = System.Windows.Visibility.Visible;
                mw.bF[i + 12].Visibility = System.Windows.Visibility.Visible;
                if (i < 6)
                {
                    mw.bF[i + 24].Visibility = System.Windows.Visibility.Visible;
                }
                /*For page G*/
                mw.bG[i].Visibility = System.Windows.Visibility.Visible;
                mw.bG[i + 12].Visibility = System.Windows.Visibility.Visible;
                if (i < 6)
                {
                    mw.bG[i + 24].Visibility = System.Windows.Visibility.Visible;
                }
                /*For page H*/
                mw.bH[i].Visibility = System.Windows.Visibility.Visible;
                mw.bH[i + 12].Visibility = System.Windows.Visibility.Visible;
                if (i < 6)
                {
                    mw.bH[i + 24].Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

    }
}
