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
    /// Interaction logic for balanceControl.xaml
    /// </summary>
    public partial class balanceControl : Window
    {
        MainWindow mw;
        FluentBlur fb;
        int[] pn;
        /*Array to store slider references*/
        Slider[] bs;
        public balanceControl(MainWindow dmw, int[] dpn)
        {
            InitializeComponent();
            mw = dmw;                                           //Storing object of MainWindow
            fb = new FluentBlur(this);
            pn = dpn;
            /*Setting this windows's background same as mainWindow*/
            this.Background = mw.Background;
            /*Initialising array for slider references*/
            bs = new Slider[] { null, null, null, null, balanceSlider_p1, balanceSlider_p2, balanceSlider_p3, balanceSlider_p4, balanceSlider_p5, balanceSlider_p6, balanceSlider_p7, balanceSlider_p8, balanceSlider_p9, balanceSlider_p10, balanceSlider_p11, balanceSlider_p12, balanceSlider_p13, balanceSlider_p14, balanceSlider_p15, balanceSlider_p16, balanceSlider_p17, balanceSlider_p18, balanceSlider_p19, balanceSlider_p20, balanceSlider_p21, balanceSlider_p22, balanceSlider_p23, balanceSlider_p24, balanceSlider_p25, balanceSlider_p26, balanceSlider_p27, balanceSlider_p28, balanceSlider_p29, balanceSlider_p30, balanceSlider_p31, balanceSlider_p32, balanceSlider_p33, balanceSlider_p34, balanceSlider_p35, balanceSlider_p36, balanceSlider_p37, balanceSlider_p38, balanceSlider_p39, balanceSlider_p40, balanceSlider_p41, balanceSlider_p42, balanceSlider_p43, balanceSlider_p44, balanceSlider_p45, balanceSlider_p46, balanceSlider_p47, balanceSlider_p48, balanceSlider_p49, balanceSlider_p50, balanceSlider_p51, balanceSlider_p52, balanceSlider_p53, balanceSlider_p54, balanceSlider_p55, balanceSlider_p56, balanceSlider_p57, balanceSlider_p58, balanceSlider_p59, balanceSlider_p60, balanceSlider_p61, balanceSlider_p62, balanceSlider_p63, balanceSlider_p64, balanceSlider_p65, balanceSlider_p66 };
            /*Reflecting current balance in balanceSlider*/
            for (int i = 4; i < 70; i++)
            {
                /*Changing pageA balances*/
                if(dpn[0] == 1)
                {
                    bs[i].Value = mw.pA[i].Balance;
                }
                /*Changing pageB balances*/
                else if (dpn[1] == 1)
                {
                    bs[i].Value = mw.pB[i].Balance;
                }
                /*Changing pageC balances*/
                else if (dpn[2] == 1)
                {
                    bs[i].Value = mw.pC[i].Balance;
                }
                /*Changing pageD balances*/
                else if (dpn[3] == 1)
                {
                    bs[i].Value = mw.pD[i].Balance;
                }
                /*Changing pageE balances*/
                else if (dpn[4] == 1)
                {
                    bs[i].Value = mw.pE[i].Balance;
                }
                /*Changing pageF balances*/
                else if (dpn[5] == 1)
                {
                    bs[i].Value = mw.pF[i].Balance;
                }
                /*Changing pageG balances*/
                else if (dpn[6] == 1)
                {
                    bs[i].Value = mw.pG[i].Balance;
                }
                /*Changing pageH balances*/
                else if (dpn[7] == 1)
                {
                    bs[i].Value = mw.pH[i].Balance;
                }
            }
            mw.Cursor = System.Windows.Input.Cursors.Arrow;
        }

        /*Detecting and applying change in value of balanceSliders*/
        private void balanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                for (int i = 0; i < 70; i++)
                {
                    if (sender == bs[i] && bs[i] != null)
                    {
                        /*For pageA*/
                        if(pn[0] == 1)
                        {
                            mw.pA[i].Balance = Math.Round(e.NewValue, 1);
                        }
                        /*For pageB*/
                        else if (pn[1] == 1)
                        {
                            mw.pB[i].Balance = Math.Round(e.NewValue, 1);
                        }
                        /*For pageC*/
                        else if (pn[2] == 1)
                        {
                            mw.pC[i].Balance = Math.Round(e.NewValue, 1);
                        }
                        /*For pageD*/
                        else if (pn[3] == 1)
                        {
                            mw.pD[i].Balance = Math.Round(e.NewValue, 1);
                        }
                        /*For pageE*/
                        else if (pn[4] == 1)
                        {
                            mw.pE[i].Balance = Math.Round(e.NewValue, 1);
                        }
                        /*For pageF*/
                        else if (pn[5] == 1)
                        {
                            mw.pF[i].Balance = Math.Round(e.NewValue, 1);
                        }
                        /*For pageG*/
                        else if (pn[6] == 1)
                        {
                            mw.pG[i].Balance = Math.Round(e.NewValue, 1);
                        }
                        /*For pageH*/
                        else if (pn[7] == 1)
                        {
                            mw.pH[i].Balance = Math.Round(e.NewValue, 1);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        /*Changing balanceSlider with mouseWheel*/
        private void balanceSlider_p1_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            for(int i = 4 ; i < 70 ; i++)
            {
                if(sender == bs[i])
                {
                    bs[i].Value += e.Delta / 1200.0;
                    break;
                }
            }
        }

        /*To reset all balances and exit balanceControl*/
        private void resetBalance_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 4; i < 70; i++)
            {
                /*For pageA*/
                if(pn[0] == 1)
                {
                    mw.pA[i].Balance = 0.0;
                }
                /*For pageB*/
                else if (pn[1] == 1)
                {
                    mw.pB[i].Balance = 0.0;
                }
                /*For pageC*/
                else if (pn[2] == 1)
                {
                    mw.pC[i].Balance = 0.0;
                }
                /*For pageD*/
                else if (pn[3] == 1)
                {
                    mw.pD[i].Balance = 0.0;
                }
                /*For pageE*/
                else if (pn[4] == 1)
                {
                    mw.pE[i].Balance = 0.0;
                }
                /*For pageF*/
                else if (pn[5] == 1)
                {
                    mw.pF[i].Balance = 0.0;
                }
                /*For pageG*/
                else if (pn[6] == 1)
                {
                    mw.pG[i].Balance = 0.0;
                }
                /*For pageH*/
                else if (pn[7] == 1)
                {
                    mw.pH[i].Balance = 0.0;
                }
            }
            this.Close();
        }

        /*To apply all balances and exit balanceControl*/
        private void applyBalance_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void balanceControl1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Show();
            fb = null;
            MainWindow.bcc = 0;
        }

        private void balanceControl1_Loaded(object sender, RoutedEventArgs e)
        {
            fb.EnableBlur();
        }

    }
}
