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
    /// Interaction logic for volumeControl.xaml
    /// </summary>
    public partial class volumeControl : Window
    {
        MainWindow mw;
        FluentBlur fb;
        int[] pn;
        /*Array to store slider references*/
        Slider[] vs;
        public volumeControl(MainWindow dmw, int[] dpn)
        {
            InitializeComponent();
            fb = new FluentBlur(this);
            mw = dmw;                                           //Storing object of MainWindow
            pn = dpn;
            /*Setting this windows's background same as mainWindow*/
            this.Background = mw.Background;
            /*Initialising array for slider references*/
            vs = new Slider[] { null, null, null, null, volumeSlider_p1, volumeSlider_p2, volumeSlider_p3, volumeSlider_p4, volumeSlider_p5, volumeSlider_p6, volumeSlider_p7, volumeSlider_p8, volumeSlider_p9, volumeSlider_p10, volumeSlider_p11, volumeSlider_p12, volumeSlider_p13, volumeSlider_p14, volumeSlider_p15, volumeSlider_p16, volumeSlider_p17, volumeSlider_p18, volumeSlider_p19, volumeSlider_p20, volumeSlider_p21, volumeSlider_p22, volumeSlider_p23, volumeSlider_p24, volumeSlider_p25, volumeSlider_p26, volumeSlider_p27, volumeSlider_p28, volumeSlider_p29, volumeSlider_p30, volumeSlider_p31, volumeSlider_p32, volumeSlider_p33, volumeSlider_p34, volumeSlider_p35, volumeSlider_p36, volumeSlider_p37, volumeSlider_p38, volumeSlider_p39, volumeSlider_p40, volumeSlider_p41, volumeSlider_p42, volumeSlider_p43, volumeSlider_p44, volumeSlider_p45, volumeSlider_p46, volumeSlider_p47, volumeSlider_p48, volumeSlider_p49, volumeSlider_p50, volumeSlider_p51, volumeSlider_p52, volumeSlider_p53, volumeSlider_p54, volumeSlider_p55, volumeSlider_p56, volumeSlider_p57, volumeSlider_p58, volumeSlider_p59, volumeSlider_p60, volumeSlider_p61, volumeSlider_p62, volumeSlider_p63, volumeSlider_p64, volumeSlider_p65, volumeSlider_p66 };
            /*Reflecting current volume in volumeSlider*/
            for(int i = 4 ; i < 70 ; i++)
            {
                /*For pageA*/
                if(pn[0] == 1)
                {
                    vs[i].Value = mw.pA[i].Volume;
                }
                /*For pageB*/
                else if (pn[1] == 1)
                {
                    vs[i].Value = mw.pB[i].Volume;
                }
                /*For pageC*/
                else if (pn[2] == 1)
                {
                    vs[i].Value = mw.pC[i].Volume;
                }
                /*For pageD*/
                else if (pn[3] == 1)
                {
                    vs[i].Value = mw.pD[i].Volume;
                }
                /*For pageE*/
                else if (pn[4] == 1)
                {
                    vs[i].Value = mw.pE[i].Volume;
                }
                /*For pageF*/
                else if (pn[5] == 1)
                {
                    vs[i].Value = mw.pF[i].Volume;
                }
                /*For pageG*/
                else if (pn[6] == 1)
                {
                    vs[i].Value = mw.pG[i].Volume;
                }
                /*For pageH*/
                else if (pn[7] == 1)
                {
                    vs[i].Value = mw.pH[i].Volume;
                }
            }
            mw.Cursor = System.Windows.Input.Cursors.Arrow;
        }

        /*Detecting and applying change in value of volumeSliders*/
        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                for (int i = 0; i < 70; i++)
                {
                    if (sender == vs[i] && vs[i] != null)
                    {
                        /*For pageA*/
                        if(pn[0] == 1)
                        {
                            mw.pA[i].Volume = Math.Round(e.NewValue, 1);
                        }
                        /*For pageB*/
                        else if (pn[1] == 1)
                        {
                            mw.pB[i].Volume = Math.Round(e.NewValue, 1);
                        }
                        /*For pageC*/
                        else if (pn[2] == 1)
                        {
                            mw.pC[i].Volume = Math.Round(e.NewValue, 1);
                        }
                        /*For pageD*/
                        else if (pn[3] == 1)
                        {
                            mw.pD[i].Volume = Math.Round(e.NewValue, 1);
                        }
                        /*For pageE*/
                        else if (pn[4] == 1)
                        {
                            mw.pE[i].Volume = Math.Round(e.NewValue, 1);
                        }
                        /*For pageF*/
                        else if (pn[5] == 1)
                        {
                            mw.pF[i].Volume = Math.Round(e.NewValue, 1);
                        }
                        /*For pageG*/
                        else if (pn[6] == 1)
                        {
                            mw.pG[i].Volume = Math.Round(e.NewValue, 1);
                        }
                        /*For pageH*/
                        else if (pn[7] == 1)
                        {
                            mw.pH[i].Volume = Math.Round(e.NewValue, 1);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        /*Moving volumeSliders with mouseWheel*/
        private void volumeSlider_p1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            for(int i = 4 ; i < 70 ; i++)
            {
                if(sender == vs[i])
                {
                    vs[i].Value += e.Delta / 1200.0;
                    break;
                }
            }
        }

        /*To reset all volumes and exit volumeControl*/
        private void resetVolume_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 4 ; i < 70 ; i++)
            {
                /*For pageA*/
                if(pn[0] == 1)
                {
                    mw.pA[i].Volume = 1.0;
                }
                /*For pageB*/
                else if (pn[1] == 1)
                {
                    mw.pB[i].Volume = 1.0;
                }
                /*For pageC*/
                else if (pn[2] == 1)
                {
                    mw.pC[i].Volume = 1.0;
                }
                /*For pageD*/
                else if (pn[3] == 1)
                {
                    mw.pD[i].Volume = 1.0;
                }
                /*For pageE*/
                else if (pn[4] == 1)
                {
                    mw.pE[i].Volume = 1.0;
                }
                /*For pageF*/
                else if (pn[5] == 1)
                {
                    mw.pF[i].Volume = 1.0;
                }
                /*For pageG*/
                else if (pn[6] == 1)
                {
                    mw.pG[i].Volume = 1.0;
                }
                /*For pageH*/
                else if (pn[7] == 1)
                {
                    mw.pH[i].Volume = 1.0;
                }
            }
            this.Close();
        }

        /*To apply all volumes and exit volumeControl*/
        private void applyVolume_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void volumeControl1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Show();
            fb = null;
            MainWindow.vcc = 0;
        }

        private void volumeControl1_Loaded(object sender, RoutedEventArgs e)
        {
            fb.EnableBlur();
        }
                
    }
}
