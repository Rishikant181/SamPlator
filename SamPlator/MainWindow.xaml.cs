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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Effects;
using System.Media;
using System.Windows.Forms;
using System.IO;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace SamPlator
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*Variable declarations*/
        int pmn = 0;                                                                      //Store no. of times playMode is clicked
        int[] pn = new int[] {1, 0, 0, 0, 0, 0, 0, 0};                                    //Store how many times each pae is clicked or activated
        public static int vcc = 0;                                                        //Count how many times volumeControl is opened
        public static int bcc = 0;                                                        //Count how many times balanceControl is opened
        public static int awc = 0;                                                        //Count how many times aboutWindow is opened
        public static int owc = 0;                                                        //Count how many times optionsWindow is opened
        public bool altKey = false;                                                       //Store whether alternate page keys are used
        volumeControl vc = null;                                                          //Obj reference to store volumeControl's object
        balanceControl bc = null;                                                         //Obj reference to store balanceControl's object
        aboutWindow aw = null;                                                            //Obj reference to store aboutWindow's object
        optionsWindow ow = null;                                                          //Obj reference to store optionsWindow's object
        /*Array of location Strings*/
        String[] aslA = new String[70];                                                   //Array to store Audio Samples' location of pageA
        String[] aslB = new String[70];                                                   //Array to store Audio Samples' location of pageB
        String[] aslC = new String[70];                                                   //Array to store Audio Samples' location of pageC
        String[] aslD = new String[70];                                                   //Array to store Audio Samples' location of pageD
        String[] aslE = new String[70];                                                   //Array to store Audio Samples' location of pageE
        String[] aslF = new String[70];                                                   //Array to store Audio Samples' location of pageF
        String[] aslG = new String[70];                                                   //Array to store Audio Samples' location of pageG
        String[] aslH = new String[70];                                                   //Array to store Audio Samples' location of pageH
        Key[] k;                                                                          //Array to store Keyboard keys for buttons
        public Key[] p;                                                                   //Array to store Keyboard keys for pageButtons
        /*Array of page Buttons*/
        public System.Windows.Controls.Button[] bA;                                       //Array to store buttons of pageA
        public System.Windows.Controls.Button[] bB;                                       //Array to store buttons of pageB
        public System.Windows.Controls.Button[] bC;                                       //Array to store buttons of pageC
        public System.Windows.Controls.Button[] bD;                                       //Array to store buttons of pageD
        public System.Windows.Controls.Button[] bE;                                       //Array to store buttons of pageE
        public System.Windows.Controls.Button[] bF;                                       //Array to store buttons of pageF
        public System.Windows.Controls.Button[] bG;                                       //Array to store buttons of pageG
        public System.Windows.Controls.Button[] bH;                                       //Array to store buttons of pageH
        /*Duplicate buttons*/
        System.Windows.Controls.Button db = null;
        /*Arrays of openFileDialog boxes*/
        OpenFileDialog[] ofd_asA = new OpenFileDialog[70];                                //Array to store openFileDialog boxes of pageA
        OpenFileDialog[] ofd_asB = new OpenFileDialog[70];                                //Array to store openFileDialog boxes of pageB
        OpenFileDialog[] ofd_asC = new OpenFileDialog[70];                                //Array to store openFileDialog boxes of pageC
        OpenFileDialog[] ofd_asD = new OpenFileDialog[70];                                //Array to store openFileDialog boxes of pageD
        OpenFileDialog[] ofd_asE = new OpenFileDialog[70];                                //Array to store openFileDialog boxes of pageE
        OpenFileDialog[] ofd_asF = new OpenFileDialog[70];                                //Array to store openFileDialog boxes of pageF
        OpenFileDialog[] ofd_asG = new OpenFileDialog[70];                                //Array to store openFileDialog boxes of pageG
        OpenFileDialog[] ofd_asH = new OpenFileDialog[70];                                //Array to store openFileDialog boxes of pageH
        SaveFileDialog sfd = new SaveFileDialog();                                        //SaveFileDialog to save preset
        OpenFileDialog ofd = new OpenFileDialog();                                        //OpenFileDialog to load preset
        /*Array of soundPlayers*/
        MediaPlayer[] lA = new MediaPlayer[4];                                            //Array to store continuous MediaPlayers of pageA
        MediaPlayer[] lB = new MediaPlayer[4];                                            //Array to store continuous MediaPlayers of pageB
        MediaPlayer[] lC = new MediaPlayer[4];                                            //Array to store continuous MediaPlayers of pageC
        MediaPlayer[] lD = new MediaPlayer[4];                                            //Array to store continuous MediaPlayers of pageD
        MediaPlayer[] lE = new MediaPlayer[4];                                            //Array to store continuous MediaPlayers of pageE
        MediaPlayer[] lF = new MediaPlayer[4];                                            //Array to store continuous MediaPlayers of pageF
        MediaPlayer[] lG = new MediaPlayer[4];                                            //Array to store continuous MediaPlayers of pageG
        MediaPlayer[] lH = new MediaPlayer[4];                                            //Array to store continuous MediaPlayers of pageH
        /*Array of mediaPlyers*/
        public MediaPlayer[] pA = new MediaPlayer[70];                                    //Array to store MediaPlayers of pageA
        public MediaPlayer[] pB = new MediaPlayer[70];                                    //Array to store MediaPlayers of pageB
        public MediaPlayer[] pC = new MediaPlayer[70];                                    //Array to store MediaPlayers of pageC
        public MediaPlayer[] pD = new MediaPlayer[70];                                    //Array to store MediaPlayers of pageD
        public MediaPlayer[] pE = new MediaPlayer[70];                                    //Array to store MediaPlayers of pageE
        public MediaPlayer[] pF = new MediaPlayer[70];                                    //Array to store MediaPlayers of pageF
        public MediaPlayer[] pG = new MediaPlayer[70];                                    //Array to store MediaPlayers of pageG
        public MediaPlayer[] pH = new MediaPlayer[70];                                    //Array to store MediaPlayers of pageH
        /*Array of BlurEffects*/
        BlurEffect[] beA = new BlurEffect[70];                                            //Array to store BlurEffect of pageA
        BlurEffect[] beB = new BlurEffect[70];                                            //Array to store BlurEffect of pageB
        BlurEffect[] beC = new BlurEffect[70];                                            //Array to store BlurEffect of pageC
        BlurEffect[] beD = new BlurEffect[70];                                            //Array to store BlurEffect of pageD
        BlurEffect[] beE = new BlurEffect[70];                                            //Array to store BlurEffect of pageE
        BlurEffect[] beF = new BlurEffect[70];                                            //Array to store BlurEffect of pageF
        BlurEffect[] beG = new BlurEffect[70];                                            //Array to store BlurEffect of pageG
        BlurEffect[] beH = new BlurEffect[70];                                            //Array to store BlurEffect of pageH
        StreamReader sr;                                                                  //Read input Config File
        StreamWriter sw;                                                                  //Write output config File
        int[] clA = new int[4] { 0, 0, 0, 0 };                                            //Variable to count how many times loop is pressed for pageA
        int[] clB = new int[4] { 0, 0, 0, 0 };                                            //Variable to count how many times loop is pressed for pageB
        int[] clC = new int[4] { 0, 0, 0, 0 };                                            //Variable to count how many times loop is pressed for pageC
        int[] clD = new int[4] { 0, 0, 0, 0 };                                            //Variable to count how many times loop is pressed for pageD
        int[] clE = new int[4] { 0, 0, 0, 0 };                                            //Variable to count how many times loop is pressed for pageE
        int[] clF = new int[4] { 0, 0, 0, 0 };                                            //Variable to count how many times loop is pressed for pageF
        int[] clG = new int[4] { 0, 0, 0, 0 };                                            //Variable to count how many times loop is pressed for pageG
        int[] clH = new int[4] { 0, 0, 0, 0 };                                            //Variable to count how many times loop is pressed for pageH
        /*Array to store all pages' grids*/
        Grid[] pg;
        /*Array to store page buttons*/
        System.Windows.Controls.Button[] pb;
        bool isPlaying = false;                                                           //To store if loop is being played
        MediaPlayer dl;                                                                   //Store duplicate loop
        /*Vars for lights*/
        Brush dupBrush = null;                                                            //Store duplicate Brush background
        System.Windows.Controls.Button dupButton = null;                                  //Store duplicate Button

        /*Constructor*/
        public MainWindow()
        {
            InitializeComponent();
            pg = new Grid[] { PageA, PageB, PageC, PageD, PageE, PageF, PageG, PageH };
            pb = new System.Windows.Controls.Button[] { buttonPageA, buttonPageB, buttonPageC, buttonPageD, buttonPageE, buttonPageF, buttonPageG, buttonPageH };
            ofd.FileName = "CustomPreset";
            sfd.FileName = "CustomPreset";
            /*Reading and applying color from file*/
            {
                try
                {
                    sr = new StreamReader("ColorConfig");                           //Reading Color Input File
                    byte al = Byte.Parse(sr.ReadLine());                            //Storing alpha
                    byte re = Byte.Parse(sr.ReadLine());                            //Storing red
                    byte gr = Byte.Parse(sr.ReadLine());                            //Storing green
                    byte bl = Byte.Parse(sr.ReadLine());                            //Storing blue
                    /*Creating SolidColorBrush for argb values*/
                    SolidColorBrush scb = new SolidColorBrush(System.Windows.Media.Color.FromArgb(al, re, gr, bl));
                    sr.Close();
                    /*Applying SolidColorBrush*/
                    this.Background = scb;
                }
                catch
                {
                    System.Windows.MessageBox.Show("Could not find Config File ............ Loading default colors");
                    sr.Close();                                                     //Closing Input Stream before reading
                    sw = new StreamWriter("ColorConfig");
                    sw.WriteLine("120");
                    sw.WriteLine("15");
                    sw.WriteLine("15");
                    sw.WriteLine("15");
                    sw.Close();                                                     //Closing Output Stream
                    /*Creating SolidColorBrush from default values*/
                    SolidColorBrush scb = new SolidColorBrush(System.Windows.Media.Color.FromArgb(120 ,15, 15, 15));
                    /*Applying default colors*/
                    this.Background = scb;
                }
            }
            /*Initialisations*/
            /*Initialising array of Keyboard keys*/
            k = new Key[] { Key.D0, Key.OemMinus, Key.OemPlus, Key.Oem5, Key.D1, Key.D2, Key.D3, Key.Q, Key.W, Key.E, Key.A, Key.S, Key.D, Key.Z, Key.X, Key.C, Key.D4, Key.D5, Key.D6, Key.R, Key.T, Key.Y, Key.F, Key.G, Key.H, Key.V, Key.B, Key.N, Key.D7, Key.D8, Key.D9, Key.U, Key.I, Key.O, Key.J, Key.K, Key.L, Key.M, Key.OemComma, Key.OemPeriod, Key.Divide, Key.Multiply, Key.Subtract, Key.NumPad7, Key.NumPad8, Key.NumPad9, Key.NumPad4, Key.NumPad5, Key.NumPad6, Key.NumPad1, Key.NumPad2, Key.NumPad3, Key.F1, Key.F2, Key.F3, Key.F4, Key.F5, Key.F6, Key.F7, Key.F8, Key.F9, Key.F10, Key.F11, Key.F12, Key.P, Key.OemOpenBrackets, Key.Oem6, Key.Oem1, Key.OemQuotes, Key.OemQuestion };
            p = new Key[] { Key.Insert, Key.Home, Key.PageUp, Key.Delete, Key.End, Key.PageDown, Key.Left, Key.Right };
            /*Initilisations of array of buttons*/
            /*Initialising array of buttons of pageA*/
            bA = new System.Windows.Controls.Button[] { loopA1, loopA2, loopA3, loopA4, padA11, padA12, padA13, padA14, padA15, padA16, padA17, padA18, padA19, padA110, padA111, padA112, padA21, padA22, padA23, padA24, padA25, padA26, padA27, padA28, padA29, padA210, padA211, padA212, padA31, padA32, padA33, padA34, padA35, padA36, padA37, padA38, padA39, padA310, padA311, padA312, padA41, padA42, padA43, padA44, padA45, padA46, padA47, padA48, padA49, padA410, padA411, padA412, padA51, padA52, padA53, padA54, padA55, padA56, padA57, padA58, padA59, padA510, padA511, padA512, padA61, padA62, padA63, padA64, padA65, padA66 };
            /*Initialising array of buttons of pageB*/
            bB = new System.Windows.Controls.Button[] { loopB1, loopB2, loopB3, loopB4, padB11, padB12, padB13, padB14, padB15, padB16, padB17, padB18, padB19, padB110, padB111, padB112, padB21, padB22, padB23, padB24, padB25, padB26, padB27, padB28, padB29, padB210, padB211, padB212, padB31, padB32, padB33, padB34, padB35, padB36, padB37, padB38, padB39, padB310, padB311, padB312, padB41, padB42, padB43, padB44, padB45, padB46, padB47, padB48, padB49, padB410, padB411, padB412, padB51, padB52, padB53, padB54, padB55, padB56, padB57, padB58, padB59, padB510, padB511, padB512, padB61, padB62, padB63, padB64, padB65, padB66 };
            /*Initialising array of buttons of pageC*/
            bC = new System.Windows.Controls.Button[] { loopC1, loopC2, loopC3, loopC4, padC11, padC12, padC13, padC14, padC15, padC16, padC17, padC18, padC19, padC110, padC111, padC112, padC21, padC22, padC23, padC24, padC25, padC26, padC27, padC28, padC29, padC210, padC211, padC212, padC31, padC32, padC33, padC34, padC35, padC36, padC37, padC38, padC39, padC310, padC311, padC312, padC41, padC42, padC43, padC44, padC45, padC46, padC47, padC48, padC49, padC410, padC411, padC412, padC51, padC52, padC53, padC54, padC55, padC56, padC57, padC58, padC59, padC510, padC511, padC512, padC61, padC62, padC63, padC64, padC65, padC66 };
            /*Initialising array of buttons of pageD*/
            bD = new System.Windows.Controls.Button[] { loopD1, loopD2, loopD3, loopD4, padD11, padD12, padD13, padD14, padD15, padD16, padD17, padD18, padD19, padD110, padD111, padD112, padD21, padD22, padD23, padD24, padD25, padD26, padD27, padD28, padD29, padD210, padD211, padD212, padD31, padD32, padD33, padD34, padD35, padD36, padD37, padD38, padD39, padD310, padD311, padD312, padD41, padD42, padD43, padD44, padD45, padD46, padD47, padD48, padD49, padD410, padD411, padD412, padD51, padD52, padD53, padD54, padD55, padD56, padD57, padD58, padD59, padD510, padD511, padD512, padD61, padD62, padD63, padD64, padD65, padD66 };
            /*Initialising array of buttons of pageE*/
            bE = new System.Windows.Controls.Button[] { loopE1, loopE2, loopE3, loopE4, padE11, padE12, padE13, padE14, padE15, padE16, padE17, padE18, padE19, padE110, padE111, padE112, padE21, padE22, padE23, padE24, padE25, padE26, padE27, padE28, padE29, padE210, padE211, padE212, padE31, padE32, padE33, padE34, padE35, padE36, padE37, padE38, padE39, padE310, padE311, padE312, padE41, padE42, padE43, padE44, padE45, padE46, padE47, padE48, padE49, padE410, padE411, padE412, padE51, padE52, padE53, padE54, padE55, padE56, padE57, padE58, padE59, padE510, padE511, padE512, padE61, padE62, padE63, padE64, padE65, padE66 };
            /*Initialising array of buttons of pageF*/
            bF = new System.Windows.Controls.Button[] { loopF1, loopF2, loopF3, loopF4, padF11, padF12, padF13, padF14, padF15, padF16, padF17, padF18, padF19, padF110, padF111, padF112, padF21, padF22, padF23, padF24, padF25, padF26, padF27, padF28, padF29, padF210, padF211, padF212, padF31, padF32, padF33, padF34, padF35, padF36, padF37, padF38, padF39, padF310, padF311, padF312, padF41, padF42, padF43, padF44, padF45, padF46, padF47, padF48, padF49, padF410, padF411, padF412, padF51, padF52, padF53, padF54, padF55, padF56, padF57, padF58, padF59, padF510, padF511, padF512, padF61, padF62, padF63, padF64, padF65, padF66 };
            /*Initialising array of buttons of pageG*/
            bG = new System.Windows.Controls.Button[] { loopG1, loopG2, loopG3, loopG4, padG11, padG12, padG13, padG14, padG15, padG16, padG17, padG18, padG19, padG110, padG111, padG112, padG21, padG22, padG23, padG24, padG25, padG26, padG27, padG28, padG29, padG210, padG211, padG212, padG31, padG32, padG33, padG34, padG35, padG36, padG37, padG38, padG39, padG310, padG311, padG312, padG41, padG42, padG43, padG44, padG45, padG46, padG47, padG48, padG49, padG410, padG411, padG412, padG51, padG52, padG53, padG54, padG55, padG56, padG57, padG58, padG59, padG510, padG511, padG512, padG61, padG62, padG63, padG64, padG65, padG66 };
            /*Initialising array of buttons of pageH*/
            bH = new System.Windows.Controls.Button[] { loopH1, loopH2, loopH3, loopH4, padH11, padH12, padH13, padH14, padH15, padH16, padH17, padH18, padH19, padH110, padH111, padH112, padH21, padH22, padH23, padH24, padH25, padH26, padH27, padH28, padH29, padH210, padH211, padH212, padH31, padH32, padH33, padH34, padH35, padH36, padH37, padH38, padH39, padH310, padH311, padH312, padH41, padH42, padH43, padH44, padH45, padH46, padH47, padH48, padH49, padH410, padH411, padH412, padH51, padH52, padH53, padH54, padH55, padH56, padH57, padH58, padH59, padH510, padH511, padH512, padH61, padH62, padH63, padH64, padH65, padH66 };
            /*Intialising array of BlueEffect*/
            for(int i = 0; i < 70; i++)
            {
                beA[i] = new BlurEffect();
                beB[i] = new BlurEffect();
                beC[i] = new BlurEffect();
                beD[i] = new BlurEffect();
                beE[i] = new BlurEffect();
                beF[i] = new BlurEffect();
                beG[i] = new BlurEffect();
                beH[i] = new BlurEffect();
            }
            /*Intialising location Strings*/
            for (int i = 0; i < 70; i++)
            {
                aslA[i] = "";
                aslB[i] = "";
                aslC[i] = "";
                aslD[i] = "";
                aslE[i] = "";
                aslF[i] = "";
                aslG[i] = "";
                aslH[i] = "";
            }            
            /*Initialising array of openFileDialog boxes*/
            for (int i = 0; i < 70; i++)
            {
                ofd_asA[i] = new OpenFileDialog();
                ofd_asB[i] = new OpenFileDialog();
                ofd_asC[i] = new OpenFileDialog();
                ofd_asD[i] = new OpenFileDialog();
                ofd_asE[i] = new OpenFileDialog();
                ofd_asF[i] = new OpenFileDialog();
                ofd_asG[i] = new OpenFileDialog();
                ofd_asH[i] = new OpenFileDialog();
            }
            /*Initialising continuous MediaPlayers*/
            for(int i = 0; i < 4; i++)
            {
                lA[i] = new MediaPlayer();
                lB[i] = new MediaPlayer();
                lC[i] = new MediaPlayer();
                lD[i] = new MediaPlayer();
                lE[i] = new MediaPlayer();
                lF[i] = new MediaPlayer();
                lG[i] = new MediaPlayer();
                lH[i] = new MediaPlayer();
            }
            /*Initialising MediaPlayers*/
            for(int i = 4 ;i < 70; i++)
            {
                pA[i] = new MediaPlayer();
                pB[i] = new MediaPlayer();
                pC[i] = new MediaPlayer();
                pD[i] = new MediaPlayer();
                pE[i] = new MediaPlayer();
                pF[i] = new MediaPlayer();
                pG[i] = new MediaPlayer();
                pH[i] = new MediaPlayer();
            }
            /*Initialising volume of MediaPlayers*/
            for (int i = 4; i < 70; i++)
            {
                pA[i].Volume = 1.0;
                pB[i].Volume = 1.0;
                pC[i].Volume = 1.0;
                pD[i].Volume = 1.0;
                pE[i].Volume = 1.0;
                pF[i].Volume = 1.0;
                pG[i].Volume = 1.0;
                pH[i].Volume = 1.0;
            }
            /*initialising balance of MediaPlayers*/
            for (int i = 4; i < 70; i++)
            {
                pA[i].Balance = 0.0;
                pB[i].Balance = 0.0;
                pC[i].Balance = 0.0;
                pD[i].Balance = 0.0;
                pE[i].Balance = 0.0;
                pF[i].Balance = 0.0;
                pG[i].Balance = 0.0;
                pH[i].Balance = 0.0;
            }
            /*Assignments*/
            /*Assignments of BlurEffects to buttons*/
            for (int i = 0; i < 70; i++)
            {
                bA[i].Effect = beA[i];
                bB[i].Effect = beB[i];
                bC[i].Effect = beC[i];
                bD[i].Effect = beD[i];
                bE[i].Effect = beE[i];
                bF[i].Effect = beF[i];
                bG[i].Effect = beG[i];
                bH[i].Effect = beH[i];
            }
            /*Assigning FileOk method to ofd_as*/
            for(int i = 0; i < 70; i++)
            {
                ofd_asA[i].FileOk += ofd_as_FileOk;
                ofd_asB[i].FileOk += ofd_as_FileOk;
                ofd_asC[i].FileOk += ofd_as_FileOk;
                ofd_asD[i].FileOk += ofd_as_FileOk;
                ofd_asE[i].FileOk += ofd_as_FileOk;
                ofd_asF[i].FileOk += ofd_as_FileOk;
                ofd_asG[i].FileOk += ofd_as_FileOk;
                ofd_asH[i].FileOk += ofd_as_FileOk;
            }
            /*Loading empty-pads for better stability*/
            load_Samples();
        }

        /*Custom Methods*/
        /*Method to enable Blur on loading Windows*/
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FluentBlur fb = new FluentBlur(this);
            fb.EnableBlur();
        }
        
        /*Method to save preset*/
        private void save_Preset(String fn)
        {
            StreamWriter sw = new StreamWriter(fn);
            /*Writing locations Strings*/
            for(int i = 0 ; i < 70 ; i++)
            {
                sw.WriteLine(aslA[i]);
                sw.WriteLine(aslB[i]);
                sw.WriteLine(aslC[i]);
                sw.WriteLine(aslD[i]);
                sw.WriteLine(aslE[i]);
                sw.WriteLine(aslF[i]);
                sw.WriteLine(aslG[i]);
                sw.WriteLine(aslH[i]);
            }
            /*Writing volumes*/
            for(int i = 4 ; i < 70 ; i++)
            {
                sw.WriteLine(pA[i].Volume);
                sw.WriteLine(pB[i].Volume);
                sw.WriteLine(pC[i].Volume);
                sw.WriteLine(pD[i].Volume);
                sw.WriteLine(pE[i].Volume);
                sw.WriteLine(pF[i].Volume);
                sw.WriteLine(pG[i].Volume);
                sw.WriteLine(pH[i].Volume);
            }
            /*Writing balances*/
            for (int i = 4; i < 70; i++)
            {
                sw.WriteLine(pA[i].Balance);
                sw.WriteLine(pB[i].Balance);
                sw.WriteLine(pC[i].Balance);
                sw.WriteLine(pD[i].Balance);
                sw.WriteLine(pE[i].Balance);
                sw.WriteLine(pF[i].Balance);
                sw.WriteLine(pG[i].Balance);
                sw.WriteLine(pH[i].Balance);
            }
            sw.Close();
        }

        /*Method to load preset*/
        private void load_Preset(String fn)
        {
            this.Cursor = System.Windows.Input.Cursors.Wait;
            StreamReader sr = new StreamReader(fn);
            for(int i = 0 ; i < 70 ; i++)
            {
                aslA[i] = sr.ReadLine();
                aslB[i] = sr.ReadLine();
                aslC[i] = sr.ReadLine();
                aslD[i] = sr.ReadLine();
                aslE[i] = sr.ReadLine();
                aslF[i] = sr.ReadLine();
                aslG[i] = sr.ReadLine();
                aslH[i] = sr.ReadLine();
            }
            /*Preloading loops*/
            for(int i = 0 ; i < 4 ; i++)
            {
                /*For loops of pageA*/
                if(aslA[i].CompareTo("") != 0)
                {
                    lA[i].Open(new Uri(@aslA[i]));
                    bA[i].Effect = null;
                    bA[i].Background = Brushes.DodgerBlue;
                }
                /*For loops of pageB*/
                if (aslB[i].CompareTo("") != 0)
                {
                    lB[i].Open(new Uri(@aslA[i]));
                    bB[i].Effect = null;
                    bB[i].Background = Brushes.DodgerBlue;
                }
                /*For loops of pageC*/
                if (aslC[i].CompareTo("") != 0)
                {
                    lC[i].Open(new Uri(@aslA[i]));
                    bC[i].Effect = null;
                    bC[i].Background = Brushes.DodgerBlue;
                }
                /*For loops of pageD*/
                if (aslD[i].CompareTo("") != 0)
                {
                    lD[i].Open(new Uri(@aslA[i]));
                    bD[i].Effect = null;
                    bD[i].Background = Brushes.DodgerBlue;
                }
                /*For loops of pageE*/
                if (aslE[i].CompareTo("") != 0)
                {
                    lE[i].Open(new Uri(@aslA[i]));
                    bE[i].Effect = null;
                    bE[i].Background = Brushes.DodgerBlue;
                }
                /*For loops of pageF*/
                if (aslF[i].CompareTo("") != 0)
                {
                    lF[i].Open(new Uri(@aslA[i]));
                    bF[i].Effect = null;
                    bF[i].Background = Brushes.DodgerBlue;
                }
                /*For loops of pageG*/
                if (aslG[i].CompareTo("") != 0)
                {
                    lG[i].Open(new Uri(@aslA[i]));
                    bG[i].Effect = null;
                    bG[i].Background = Brushes.DodgerBlue;
                }
                /*For loops of pageH*/
                if (aslH[i].CompareTo("") != 0)
                {
                    lH[i].Open(new Uri(@aslA[i]));
                    bH[i].Effect = null;
                    bH[i].Background = Brushes.DodgerBlue;
                }
            }
            /*Preloading pads of set1, set2, set3, set4*/
            for(int i = 4 ; i < 52 ; i++)
            {
                if(aslA[i].CompareTo("") != 0)
                {
                    bA[i].Effect = null;
                    bA[i].Background = Brushes.LimeGreen;
                }
                if (aslB[i].CompareTo("") != 0)
                {
                    bB[i].Effect = null;
                    bB[i].Background = Brushes.LimeGreen;
                }
                if (aslC[i].CompareTo("") != 0)
                {
                    bC[i].Effect = null;
                    bC[i].Background = Brushes.LimeGreen;
                }
                if (aslD[i].CompareTo("") != 0)
                {
                    bD[i].Effect = null;
                    bD[i].Background = Brushes.LimeGreen;
                }
                if (aslE[i].CompareTo("") != 0)
                {
                    bE[i].Effect = null;
                    bE[i].Background = Brushes.LimeGreen;
                }
                if (aslF[i].CompareTo("") != 0)
                {
                    bF[i].Effect = null;
                    bF[i].Background = Brushes.LimeGreen;
                }
                if (aslG[i].CompareTo("") != 0)
                {
                    bG[i].Effect = null;
                    bG[i].Background = Brushes.LimeGreen;
                }
                if (aslH[i].CompareTo("") != 0)
                {
                    bH[i].Effect = null;
                    bH[i].Background = Brushes.LimeGreen;
                }
            }
            /*Preloading pads of set5*/
            for (int i = 52; i < 64; i++)
            {
                if (aslA[i].CompareTo("") != 0)
                {
                    bA[i].Effect = null;
                    bA[i].Background = Brushes.Magenta;
                }
                if (aslB[i].CompareTo("") != 0)
                {
                    bB[i].Effect = null;
                    bB[i].Background = Brushes.Magenta;
                }
                if (aslC[i].CompareTo("") != 0)
                {
                    bC[i].Effect = null;
                    bC[i].Background = Brushes.Magenta;
                }
                if (aslD[i].CompareTo("") != 0)
                {
                    bD[i].Effect = null;
                    bD[i].Background = Brushes.Magenta;
                }
                if (aslE[i].CompareTo("") != 0)
                {
                    bE[i].Effect = null;
                    bE[i].Background = Brushes.Magenta;
                }
                if (aslF[i].CompareTo("") != 0)
                {
                    bF[i].Effect = null;
                    bF[i].Background = Brushes.Magenta;
                }
                if (aslG[i].CompareTo("") != 0)
                {
                    bG[i].Effect = null;
                    bG[i].Background = Brushes.Magenta;
                }
                if (aslH[i].CompareTo("") != 0)
                {
                    bH[i].Effect = null;
                    bH[i].Background = Brushes.Magenta;
                }
            }
            /*Preloading pads of set5*/
            for (int i = 64; i < 70; i++)
            {
                if (aslA[i].CompareTo("") != 0)
                {
                    bA[i].Effect = null;
                    bA[i].Background = Brushes.OrangeRed;
                }
                if (aslB[i].CompareTo("") != 0)
                {
                    bB[i].Effect = null;
                    bB[i].Background = Brushes.OrangeRed;
                }
                if (aslC[i].CompareTo("") != 0)
                {
                    bC[i].Effect = null;
                    bC[i].Background = Brushes.OrangeRed;
                }
                if (aslD[i].CompareTo("") != 0)
                {
                    bD[i].Effect = null;
                    bD[i].Background = Brushes.OrangeRed;
                }
                if (aslE[i].CompareTo("") != 0)
                {
                    bE[i].Effect = null;
                    bE[i].Background = Brushes.OrangeRed;
                }
                if (aslF[i].CompareTo("") != 0)
                {
                    bF[i].Effect = null;
                    bF[i].Background = Brushes.OrangeRed;
                }
                if (aslG[i].CompareTo("") != 0)
                {
                    bG[i].Effect = null;
                    bG[i].Background = Brushes.OrangeRed;
                }
                if (aslH[i].CompareTo("") != 0)
                {
                    bH[i].Effect = null;
                    bH[i].Background = Brushes.OrangeRed;
                }
            }
            /*Loading Volumes*/
            for (int i = 4; i < 70; i++)
            {
                pA[i].Volume = Double.Parse(sr.ReadLine());
                pB[i].Volume = Double.Parse(sr.ReadLine());
                pC[i].Volume = Double.Parse(sr.ReadLine());
                pD[i].Volume = Double.Parse(sr.ReadLine());
                pE[i].Volume = Double.Parse(sr.ReadLine());
                pF[i].Volume = Double.Parse(sr.ReadLine());
                pG[i].Volume = Double.Parse(sr.ReadLine());
                pH[i].Volume = Double.Parse(sr.ReadLine());
            }
            /*Loading Balances*/
            for (int i = 4; i < 70; i++)
            {
                pA[i].Balance = Double.Parse(sr.ReadLine());
                pB[i].Balance = Double.Parse(sr.ReadLine());
                pC[i].Balance = Double.Parse(sr.ReadLine());
                pD[i].Balance = Double.Parse(sr.ReadLine());
                pE[i].Balance = Double.Parse(sr.ReadLine());
                pF[i].Balance = Double.Parse(sr.ReadLine());
                pG[i].Balance = Double.Parse(sr.ReadLine());
                pH[i].Balance = Double.Parse(sr.ReadLine());
            }
            sr.Close();
            this.Cursor = System.Windows.Input.Cursors.Arrow;
        }

        /*Method to reset all pad*/
        private void reset_Pads()
        {
            /*Resetting buttons*/
            for (int i = 0; i < 70; i++)
            {
                /*CLosing AudioSamples*/
                if(i < 4)
                {
                    lA[i].Close();
                    lB[i].Close();
                    lC[i].Close();
                    lD[i].Close();
                    lE[i].Close();
                    lF[i].Close();
                    lG[i].Close();
                    lH[i].Close();
                }
                else
                {
                    pA[i].Close();
                    pB[i].Close();
                    pC[i].Close();
                    pD[i].Close();
                    pE[i].Close();
                    pF[i].Close();
                    pG[i].Close();
                    pH[i].Close();
                }
                if (i < 4)
                {
                    /*Reset loops*/
                    bA[i].Background = Brushes.DarkBlue;
                    bB[i].Background = Brushes.DarkBlue;
                    bC[i].Background = Brushes.DarkBlue;
                    bD[i].Background = Brushes.DarkBlue;
                    bE[i].Background = Brushes.DarkBlue;
                    bF[i].Background = Brushes.DarkBlue;
                    bG[i].Background = Brushes.DarkBlue;
                    bH[i].Background = Brushes.DarkBlue;
                }
                else if (i >= 4 && i < 52)
                {
                    /*Reset set1, set2, set3, set4 pads*/
                    bA[i].Background = Brushes.DarkGreen;
                    bB[i].Background = Brushes.DarkGreen;
                    bC[i].Background = Brushes.DarkGreen;
                    bD[i].Background = Brushes.DarkGreen;
                    bE[i].Background = Brushes.DarkGreen;
                    bF[i].Background = Brushes.DarkGreen;
                    bG[i].Background = Brushes.DarkGreen;
                    bH[i].Background = Brushes.DarkGreen;
                }
                else if (i >= 52 && i < 64)
                {
                    /*Reset set5 pads*/
                    bA[i].Background = Brushes.Purple;
                    bB[i].Background = Brushes.Purple;
                    bC[i].Background = Brushes.Purple;
                    bD[i].Background = Brushes.Purple;
                    bE[i].Background = Brushes.Purple;
                    bF[i].Background = Brushes.Purple;
                    bG[i].Background = Brushes.Purple;
                    bH[i].Background = Brushes.Purple;
                }
                else
                {
                    /*Reset set6 pads*/
                    bA[i].Background = Brushes.DarkRed;
                    bB[i].Background = Brushes.DarkRed;
                    bC[i].Background = Brushes.DarkRed;
                    bD[i].Background = Brushes.DarkRed;
                    bE[i].Background = Brushes.DarkRed;
                    bF[i].Background = Brushes.DarkRed;
                    bG[i].Background = Brushes.DarkRed;
                    bH[i].Background = Brushes.DarkRed;
                }
                bA[i].Effect = beA[i];
                bB[i].Effect = beB[i];
                bC[i].Effect = beC[i];
                bD[i].Effect = beD[i];
                bE[i].Effect = beE[i];
                bF[i].Effect = beF[i];
                bG[i].Effect = beG[i];
                bH[i].Effect = beH[i];
            }
            /*Resetiing location string*/
            for (int i = 0; i < 70; i++)
            {
                aslA[i] = "";
                aslB[i] = "";
                aslC[i] = "";
                aslD[i] = "";
                aslE[i] = "";
                aslF[i] = "";
                aslG[i] = "";
                aslH[i] = "";
            }
            /*Resetting volumes*/
            for (int i = 4; i < 70; i++)
            {
                pA[i].Volume = 1.0;
                pB[i].Volume = 1.0;
                pC[i].Volume = 1.0;
                pD[i].Volume = 1.0;
                pE[i].Volume = 1.0;
                pF[i].Volume = 1.0;
                pG[i].Volume = 1.0;
                pH[i].Volume = 1.0;
            }
            /*Resetting balances*/
            for (int i = 4; i < 70; i++)
            {
                pA[i].Balance = 0.0;
                pB[i].Balance = 0.0;
                pC[i].Balance = 0.0;
                pD[i].Balance = 0.0;
                pE[i].Balance = 0.0;
                pF[i].Balance = 0.0;
                pG[i].Balance = 0.0;
                pH[i].Balance = 0.0;
            }
            /*Loading empty-pads for better stability*/
            load_Samples();
        }
        
        /*Method to load samples*/
        private void load_Samples()
        {
            /*Promting user to wait*/
            this.Cursor = System.Windows.Input.Cursors.Wait;
            for (int i = 0; i < 70; i++)
            {
                if (i < 4)
                {
                    if (aslA[i].CompareTo("") != 0)
                    {
                        lA[i].Open(new Uri(@aslA[i]));
                    }
                    if (aslB[i].CompareTo("") != 0)
                    {
                        lB[i].Open(new Uri(@aslA[i]));
                    }
                    if (aslC[i].CompareTo("") != 0)
                    {
                        lC[i].Open(new Uri(@aslA[i]));
                    }
                    if (aslD[i].CompareTo("") != 0)
                    {
                        lD[i].Open(new Uri(@aslA[i]));
                    }
                    if (aslE[i].CompareTo("") != 0)
                    {
                        lE[i].Open(new Uri(@aslA[i]));
                    }
                    if (aslF[i].CompareTo("") != 0)
                    {
                        lF[i].Open(new Uri(@aslA[i]));
                    }
                    if (aslG[i].CompareTo("") != 0)
                    {
                        lG[i].Open(new Uri(@aslA[i]));
                    }
                    if (aslH[i].CompareTo("") != 0)
                    {
                        lH[i].Open(new Uri(@aslA[i]));
                    }
                }
                else
                {
                    if (aslA[i].CompareTo("") != 0)
                    {
                        pA[i].Open(new Uri(@aslA[i]));
                    }
                    if (aslB[i].CompareTo("") != 0)
                    {
                        pB[i].Open(new Uri(@aslB[i]));
                    }
                    if (aslC[i].CompareTo("") != 0)
                    {
                        pC[i].Open(new Uri(@aslC[i]));
                    }
                    if (aslD[i].CompareTo("") != 0)
                    {
                        pD[i].Open(new Uri(@aslD[i]));
                    }
                    if (aslE[i].CompareTo("") != 0)
                    {
                        pE[i].Open(new Uri(@aslE[i]));
                    }
                    if (aslF[i].CompareTo("") != 0)
                    {
                        pF[i].Open(new Uri(@aslF[i]));
                    }
                    if (aslG[i].CompareTo("") != 0)
                    {
                        pG[i].Open(new Uri(@aslG[i]));
                    }
                    if (aslH[i].CompareTo("") != 0)
                    {
                        pH[i].Open(new Uri(@aslH[i]));
                    }
                }
            }
            this.Cursor = System.Windows.Input.Cursors.Arrow;
        }

        /*Event Methods*/
        /*Showing openFileDialog on button click*/
        private void padButton_Click(object sender, EventArgs e)
        {
            for(int i = 0 ; i < 70 ; i++)
            {
                if(sender == bA[i])
                {
                    ofd_asA[i].ShowDialog();
                    break;
                }
                else if (sender == bB[i])
                {
                    ofd_asB[i].ShowDialog();
                    break;
                }
                else if (sender == bC[i])
                {
                    ofd_asC[i].ShowDialog();
                    break;
                }
                else if (sender == bD[i])
                {
                    ofd_asD[i].ShowDialog();
                    break;
                }
                else if (sender == bE[i])
                {
                    ofd_asE[i].ShowDialog();
                    break;
                }
                else if (sender == bF[i])
                {
                    ofd_asF[i].ShowDialog();
                    break;
                }
                else if (sender == bG[i])
                {
                    ofd_asG[i].ShowDialog();
                    break;
                }
                else if (sender == bH[i])
                {
                    ofd_asH[i].ShowDialog();
                    break;
                }
            }
        }

        /*Empty click event to diable pads from being clicked*/
        private void padButton_EmptyClick(object sender, EventArgs e)
        {
            //It does nothing ........ JUST nothing
        }

        /*Determining Audio samples' location from openFileDialog*/
        private void ofd_as_FileOk(object sender, EventArgs e)
        {
            for(int i = 0 ; i < 70 ; i++)
            {
                /*Checking which openFileDialog has been opened*/
                /*For pageA*/
                if(sender == ofd_asA[i])
                {
                    aslA[i] = ofd_asA[i].FileName;
                    if (i < 4 && (aslA[i].CompareTo("") != 0))
                    {
                        bA[i].Background = Brushes.DodgerBlue;                                       //Setting Background of loops to Blue
                        bA[i].Effect = null;                                                         //Removing BlurEffect from loops
                    }
                    else if (i >= 4 && i < 52 && (aslA[i].CompareTo("") != 0))
                    {
                        bA[i].Background = Brushes.LimeGreen;                                        //Setting Background of pads to Green
                        bA[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 52 && i < 64 && (aslA[i].CompareTo("") != 0))
                    {
                        bA[i].Background = Brushes.Magenta;                                          //Setting Background of pads to Orange
                        bA[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 64 && (aslA[i].CompareTo("") != 0))
                    {
                        bA[i].Background = Brushes.OrangeRed;                                        //Setting Background of pads to Orange
                        bA[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    break;
                }
                /*For pageB*/
                else if (sender == ofd_asB[i])
                {
                    aslB[i] = ofd_asB[i].FileName;
                    if (i < 4 && (aslB[i].CompareTo("") != 0))
                    {
                        bB[i].Background = Brushes.DodgerBlue;                                       //Setting Background of loops to Blue
                        bB[i].Effect = null;                                                         //Removing BlurEffect from loops
                    }
                    else if (i >= 4 && i < 52 && (aslB[i].CompareTo("") != 0))
                    {
                        bB[i].Background = Brushes.LimeGreen;                                        //Setting Background of pads to Green
                        bB[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 52 && i < 64 && (aslB[i].CompareTo("") != 0))
                    {
                        bB[i].Background = Brushes.Magenta;                                          //Setting Background of pads to Orange
                        bB[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 64 && (aslB[i].CompareTo("") != 0))
                    {
                        bB[i].Background = Brushes.OrangeRed;                                        //Setting Background of pads to Orange
                        bB[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    break;
                }
                /*For pageC*/
                else if (sender == ofd_asC[i])
                {
                    aslC[i] = ofd_asC[i].FileName;
                    if (i < 4 && (aslC[i].CompareTo("") != 0))
                    {
                        bC[i].Background = Brushes.DodgerBlue;                                       //Setting Background of loops to Blue
                        bC[i].Effect = null;                                                         //Removing BlurEffect from loops
                    }
                    else if (i >= 4 && i < 52 && (aslC[i].CompareTo("") != 0))
                    {
                        bC[i].Background = Brushes.LimeGreen;                                        //Setting Background of pads to Green
                        bC[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 52 && i < 64 && (aslC[i].CompareTo("") != 0))
                    {
                        bC[i].Background = Brushes.Magenta;                                          //Setting Background of pads to Orange
                        bC[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 64 && (aslC[i].CompareTo("") != 0))
                    {
                        bC[i].Background = Brushes.OrangeRed;                                        //Setting Background of pads to Orange
                        bC[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    break;
                }
                /*For pageD*/
                else if (sender == ofd_asD[i])
                {
                    aslD[i] = ofd_asD[i].FileName;
                    if (i < 4 && (aslD[i].CompareTo("") != 0))
                    {
                        bD[i].Background = Brushes.DodgerBlue;                                       //Setting Background of loops to Blue
                        bD[i].Effect = null;                                                         //Removing BlurEffect from loops
                    }
                    else if (i >= 4 && i < 52 && (aslD[i].CompareTo("") != 0))
                    {
                        bD[i].Background = Brushes.LimeGreen;                                        //Setting Background of pads to Green
                        bD[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 52 && i < 64 && (aslD[i].CompareTo("") != 0))
                    {
                        bD[i].Background = Brushes.Magenta;                                          //Setting Background of pads to Orange
                        bD[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 64 && (aslD[i].CompareTo("") != 0))
                    {
                        bD[i].Background = Brushes.OrangeRed;                                        //Setting Background of pads to Orange
                        bD[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    break;
                }
                /*For pageE*/
                else if (sender == ofd_asE[i])
                {
                    aslE[i] = ofd_asE[i].FileName;
                    if (i < 4 && (aslE[i].CompareTo("") != 0))
                    {
                        bE[i].Background = Brushes.DodgerBlue;                                       //Setting Background of loops to Blue
                        bE[i].Effect = null;                                                         //Removing BlurEffect from loops
                    }
                    else if (i >= 4 && i < 52 && (aslE[i].CompareTo("") != 0))
                    {
                        bE[i].Background = Brushes.LimeGreen;                                        //Setting Background of pads to Green
                        bE[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 52 && i < 64 && (aslE[i].CompareTo("") != 0))
                    {
                        bE[i].Background = Brushes.Magenta;                                          //Setting Background of pads to Orange
                        bE[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 64 && (aslE[i].CompareTo("") != 0))
                    {
                        bE[i].Background = Brushes.OrangeRed;                                        //Setting Background of pads to Orange
                        bE[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    break;
                }
                /*For pageF*/
                else if (sender == ofd_asF[i])
                {
                    aslF[i] = ofd_asF[i].FileName;
                    if (i < 4 && (aslF[i].CompareTo("") != 0))
                    {
                        bF[i].Background = Brushes.DodgerBlue;                                       //Setting Background of loops to Blue
                        bF[i].Effect = null;                                                         //Removing BlurEffect from loops
                    }
                    else if (i >= 4 && i < 52 && (aslF[i].CompareTo("") != 0))
                    {
                        bF[i].Background = Brushes.LimeGreen;                                        //Setting Background of pads to Green
                        bF[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 52 && i < 64 && (aslF[i].CompareTo("") != 0))
                    {
                        bF[i].Background = Brushes.Magenta;                                          //Setting Background of pads to Orange
                        bF[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 64 && (aslF[i].CompareTo("") != 0))
                    {
                        bF[i].Background = Brushes.OrangeRed;                                        //Setting Background of pads to Orange
                        bF[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    break;
                }
                /*For pageG*/
                else if (sender == ofd_asG[i])
                {
                    aslG[i] = ofd_asG[i].FileName;
                    if (i < 4 && (aslG[i].CompareTo("") != 0))
                    {
                        bG[i].Background = Brushes.DodgerBlue;                                       //Setting Background of loops to Blue
                        bG[i].Effect = null;                                                         //Removing BlurEffect from loops
                    }
                    else if (i >= 4 && i < 52 && (aslG[i].CompareTo("") != 0))
                    {
                        bG[i].Background = Brushes.LimeGreen;                                        //Setting Background of pads to Green
                        bG[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 52 && i < 64 && (aslG[i].CompareTo("") != 0))
                    {
                        bG[i].Background = Brushes.Magenta;                                          //Setting Background of pads to Orange
                        bG[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 64 && (aslG[i].CompareTo("") != 0))
                    {
                        bG[i].Background = Brushes.OrangeRed;                                        //Setting Background of pads to Orange
                        bG[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    break;
                }
                /*For pageH*/
                else if (sender == ofd_asH[i])
                {
                    aslH[i] = ofd_asH[i].FileName;
                    if (i < 4 && (aslH[i].CompareTo("") != 0))
                    {
                        bH[i].Background = Brushes.DodgerBlue;                                       //Setting Background of loops to Blue
                        bH[i].Effect = null;                                                         //Removing BlurEffect from loops
                    }
                    else if (i >= 4 && i < 52 && (aslH[i].CompareTo("") != 0))
                    {
                        bH[i].Background = Brushes.LimeGreen;                                        //Setting Background of pads to Green
                        bH[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 52 && i < 64 && (aslH[i].CompareTo("") != 0))
                    {
                        bH[i].Background = Brushes.Magenta;                                          //Setting Background of pads to Orange
                        bH[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    else if (i >= 64 && (aslH[i].CompareTo("") != 0))
                    {
                        bH[i].Background = Brushes.OrangeRed;                                        //Setting Background of pads to Orange
                        bH[i].Effect = null;                                                         //Removing BlueEffect from pads
                    }
                    break;
                }
            }
        }

        /*Detecting KeyDown event*/
        private void mainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            for (int i = 0; i < 70; i++)
            {
                /*De-Highlighting*/
                if(dupBrush != null && dupButton != null)
                {
                    dupButton.Background = dupBrush;
                }
                /*For page A*/
                if(pn[0] == 1)
                {
                    /*Playing loops*/
                    if (i < 4 && aslA[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        if(isPlaying == true)
                        {
                            return;
                        }
                        /*Playing loop[i] if not played*/
                        if (isPlaying == false)
                        {
                            lA[i].Open(new Uri(@aslA[i]));
                            lA[i].Play();
                            dl = lA[i];
                            isPlaying = true;
                            break;
                        }
                    }
                    /*Playing pads*/
                    else if (i >= 4 && aslA[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        pA[i].Open(new Uri(@aslA[i]));
                        pA[i].Play();
                        dupBrush = bA[i].Background;
                        bA[i].Background = Brushes.White;
                        dupButton = bA[i];
                        break;
                    }
                }
                /*For page B*/
                else if (pn[1] == 1)
                {
                    /*Playing loops*/
                    if (i < 4 && aslB[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        if (isPlaying == true)
                        {
                            return;
                        }
                        /*Playing loop[i] if not played*/
                        if (isPlaying == false)
                        {
                            lB[i].Open(new Uri(@aslA[i]));
                            lB[i].Play();
                            dl = lB[i];
                            isPlaying = true;
                            break;
                        }
                    }
                    /*Playing pads*/
                    else if (i >= 4 && aslB[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        pB[i].Open(new Uri(@aslB[i]));
                        pB[i].Play();
                        dupBrush = bB[i].Background;
                        bB[i].Background = Brushes.White;
                        dupButton = bB[i];
                        break;
                    }                    
                }
                /*For page C*/
                else if (pn[2] == 1)
                {
                    /*Playing loops*/
                    if (i < 4 && aslC[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        if (isPlaying == true)
                        {
                            return;
                        }
                        /*Playing loop[i] if not played*/
                        if (isPlaying == false)
                        {
                            lC[i].Open(new Uri(@aslA[i]));
                            lC[i].Play();
                            dl = lC[i];
                            isPlaying = true;
                            break;
                        }
                    }
                    /*Playing pads*/
                    else if (i >= 4 && aslC[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        pC[i].Open(new Uri(@aslC[i]));
                        pC[i].Play();
                        dupBrush = bC[i].Background;
                        bC[i].Background = Brushes.White;
                        dupButton = bC[i];
                        break;
                    }
                }
                /*For page D*/
                else if (pn[3] == 1)
                {
                    /*Playing loops*/
                    if (i < 4 && aslD[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        if (isPlaying == true)
                        {
                            return;
                        }
                        /*Playing loop[i] if not played*/
                        if (isPlaying == false)
                        {
                            lD[i].Open(new Uri(@aslA[i]));
                            lD[i].Play();
                            dl = lD[i];
                            isPlaying = true;
                            break;
                        }
                    }
                    /*Playing pads*/
                    else if (i >= 4 && aslD[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        pD[i].Open(new Uri(@aslD[i]));
                        pD[i].Play();
                        dupBrush = bD[i].Background;
                        bD[i].Background = Brushes.White;
                        dupButton = bD[i];
                        break;
                    }
                }
                /*For page E*/
                else if (pn[4] == 1)
                {
                    /*Playing loops*/
                    if (i < 4 && aslE[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        if (isPlaying == true)
                        {
                            return;
                        }
                        /*Playing loop[i] if not played*/
                        if (isPlaying == false)
                        {
                            lE[i].Open(new Uri(@aslA[i]));
                            lE[i].Play();
                            dl = lE[i];
                            isPlaying = true;
                            break;
                        }
                    }
                    /*Playing pads*/
                    else if (i >= 4 && aslE[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        pE[i].Open(new Uri(@aslE[i]));
                        pE[i].Play();
                        dupBrush = bE[i].Background;
                        bE[i].Background = Brushes.White;
                        dupButton = bE[i];
                        break;
                    }
                }
                /*For pageF*/
                else if (pn[5] == 1)
                {
                    /*Playing loops*/
                    if (i < 4 && aslF[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        if (isPlaying == true)
                        {
                            return;
                        }
                        /*Playing loop[i] if not played*/
                        if (isPlaying == false)
                        {
                            lF[i].Open(new Uri(@aslA[i]));
                            lF[i].Play();
                            dl = lF[i];
                            isPlaying = true;
                            break;
                        }
                    }
                    /*Playing pads*/
                    else if (i >= 4 && aslF[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        pF[i].Open(new Uri(@aslF[i]));
                        pF[i].Play();
                        dupBrush = bF[i].Background;
                        bF[i].Background = Brushes.White;
                        dupButton = bF[i];
                        break;
                    }
                }
                /*For page G*/
                else if (pn[6] == 1)
                {
                    /*Playing loops*/
                    if (i < 4 && aslG[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        if (isPlaying == true)
                        {
                            return;
                        }
                        /*Playing loop[i] if not played*/
                        if (isPlaying == false)
                        {
                            lG[i].Open(new Uri(@aslA[i]));
                            lG[i].Play();
                            dl = lG[i];
                            isPlaying = true;
                            break;
                        }
                    }
                    /*Playing pads*/
                    else if (i >= 4 && aslG[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        pG[i].Open(new Uri(@aslG[i]));
                        pG[i].Play();
                        dupBrush = bG[i].Background;
                        bG[i].Background = Brushes.White;
                        dupButton = bG[i];
                        break;
                    }
                }
                /*For page H*/
                else if (pn[7] == 1)
                {
                    /*Playing loops*/
                    if (i < 4 && aslH[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        if (isPlaying == true)
                        {
                            return;
                        }
                        /*Playing loop[i] if not played*/
                        if (isPlaying == false)
                        {
                            lH[i].Open(new Uri(@aslA[i]));
                            lH[i].Play();
                            dl = lH[i];
                            isPlaying = true;
                            break;
                        }
                    }
                    /*Playing pads*/
                    else if (i >= 4 && aslH[i].CompareTo("") != 0 && e.Key == k[i])
                    {
                        pH[i].Open(new Uri(@aslH[i]));
                        pH[i].Play();
                        dupBrush = bH[i].Background;
                        bH[i].Background = Brushes.White;
                        dupButton = bH[i];
                        break;
                    }
                }
            }
            /*Stopping all Audios if Esc is pressed*/
            if (e.Key == Key.Escape)
            {
                for (int i = 0; i < 70; i++)
                {
                    try
                    {
                        if (i < 4)
                        {
                            lA[i].Stop();
                            lB[i].Stop();
                            lC[i].Stop();
                            lD[i].Stop();
                            lE[i].Stop();
                            lF[i].Stop();
                            lG[i].Stop();
                            lH[i].Stop();
                        }
                        else
                        {
                            pA[i].Stop();
                            pB[i].Stop();
                            pC[i].Stop();
                            pD[i].Stop();
                            pE[i].Stop();
                            pF[i].Stop();
                            pG[i].Stop();
                            pH[i].Stop();
                        }
                    }
                    catch
                    {

                    }
                }
            }
            /*Switching pages*/
            for(int i = 0 ; i < 8 ; i++)
            {
                if(e.Key == p[i])
                {
                    pb[i].Background = Brushes.White;
                    pg[i].Visibility = System.Windows.Visibility.Visible;
                    pn[i] = 1;
                    /*Hiding others*/
                    for(int j = 0 ; j < 8 ; j++)
                    {
                        if(j != i)
                        {
                            pb[j].Background = Brushes.Black;
                            pg[j].Visibility = System.Windows.Visibility.Hidden;
                            pn[j] = 0;
                        }
                    }
                }
            }
        }

        /*Detecting KeyUp event*/
        private void mainWindow_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(isPlaying == false)
            {
                return;
            }
            if(dl != null)
            {
                dl.Stop();
                isPlaying = false;
            }
        }
        
        /*Events to save preset*/
        private void savePreset_Click(object sender, RoutedEventArgs e)
        {
            /*Assigining sfd_FileOk method to sfd*/
            sfd.FileOk += sfd_FileOk;
            sfd.ShowDialog();
        }

        /*FileOk method for saveFileDialog*/
        private void sfd_FileOk(object sender, EventArgs e)
        {
            save_Preset(sfd.FileName);
        }

        /*Event to load preset*/
        private void loadPreset_Click(object sender, RoutedEventArgs e)
        {
            /*Assigning ofd_FileOk method to ofd*/
            ofd.FileOk += ofd_FileOk;
            ofd.ShowDialog();   
        }

        /*FileOk method for openFileDialog*/
        private void ofd_FileOk(object sender, EventArgs e)
        {
            try
            {
                load_Preset(ofd.FileName);
            }
            catch
            {
                System.Windows.MessageBox.Show("Preset File corrupted ........ Loading last know custom preset");
                load_Preset("CustomPreset");
            }
        }

        /*Unassigning when right clicked*/
        private void padButton_RightClick(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < 70; i++)
            {
                /*For pageA*/
                if (sender == bA[i])
                {
                    /*Setting default colors*/
                    if (i < 4)
                    {
                        bA[i].Background = Brushes.DarkBlue;
                    }
                    else if (i >= 4 && i < 52)
                    {
                        bA[i].Background = Brushes.DarkGreen;
                    }
                    else if (i >= 52 && i < 64)
                    {
                        bA[i].Background = Brushes.Purple;
                    }
                    else if (i >= 64)
                    {
                        bA[i].Background = Brushes.DarkRed;
                    }
                    /*Setting BlurEffect*/
                    bA[i].Effect = beA[i];
                    /*Setting location to null*/
                    aslA[i] = "";
                }
                /*For pageB*/
                else if (sender == bB[i])
                {
                    /*Setting default colors*/
                    if (i < 4)
                    {
                        bB[i].Background = Brushes.DarkBlue;
                    }
                    else if (i >= 4 && i < 52)
                    {
                        bB[i].Background = Brushes.DarkGreen;
                    }
                    else if (i >= 52 && i < 64)
                    {
                        bB[i].Background = Brushes.Purple;
                    }
                    else if (i >= 64)
                    {
                        bB[i].Background = Brushes.DarkRed;
                    }
                    /*Setting BlurEffect*/
                    bB[i].Effect = beB[i];
                    /*Setting location to null*/
                    aslB[i] = "";
                }
                /*For pageC*/
                else if (sender == bC[i])
                {
                    /*Setting default colors*/
                    if (i < 4)
                    {
                        bC[i].Background = Brushes.DarkBlue;
                    }
                    else if (i >= 4 && i < 52)
                    {
                        bC[i].Background = Brushes.DarkGreen;
                    }
                    else if (i >= 52 && i < 64)
                    {
                        bC[i].Background = Brushes.Purple;
                    }
                    else if (i >= 64)
                    {
                        bC[i].Background = Brushes.DarkRed;
                    }
                    /*Setting BlurEffect*/
                    bC[i].Effect = beC[i];
                    /*Setting location to null*/
                    aslC[i] = "";
                }
                /*For pageD*/
                else if (sender == bD[i])
                {
                    /*Setting default colors*/
                    if (i < 4)
                    {
                        bD[i].Background = Brushes.DarkBlue;
                    }
                    else if (i >= 4 && i < 52)
                    {
                        bD[i].Background = Brushes.DarkGreen;
                    }
                    else if (i >= 52 && i < 64)
                    {
                        bD[i].Background = Brushes.Purple;
                    }
                    else if (i >= 64)
                    {
                        bD[i].Background = Brushes.DarkRed;
                    }
                    /*Setting BlurEffect*/
                    bD[i].Effect = beD[i];
                    /*Setting location to null*/
                    aslD[i] = "";
                }
                /*For pageE*/
                else if (sender == bE[i])
                {
                    /*Setting default colors*/
                    if (i < 4)
                    {
                        bE[i].Background = Brushes.DarkBlue;
                    }
                    else if (i >= 4 && i < 52)
                    {
                        bE[i].Background = Brushes.DarkGreen;
                    }
                    else if (i >= 52 && i < 64)
                    {
                        bE[i].Background = Brushes.Purple;
                    }
                    else if (i >= 64)
                    {
                        bE[i].Background = Brushes.DarkRed;
                    }
                    /*Setting BlurEffect*/
                    bE[i].Effect = beE[i];
                    /*Setting location to null*/
                    aslE[i] = "";
                }
                /*For pageF*/
                else if (sender == bF[i])
                {
                    /*Setting default colors*/
                    if (i < 4)
                    {
                        bF[i].Background = Brushes.DarkBlue;
                    }
                    else if (i >= 4 && i < 52)
                    {
                        bF[i].Background = Brushes.DarkGreen;
                    }
                    else if (i >= 52 && i < 64)
                    {
                        bF[i].Background = Brushes.Purple;
                    }
                    else if (i >= 64)
                    {
                        bF[i].Background = Brushes.DarkRed;
                    }
                    /*Setting BlurEffect*/
                    bF[i].Effect = beF[i];
                    /*Setting location to null*/
                    aslF[i] = "";
                }
                /*For pageG*/
                else if (sender == bG[i])
                {
                    /*Setting default colors*/
                    if (i < 4)
                    {
                        bG[i].Background = Brushes.DarkBlue;
                    }
                    else if (i >= 4 && i < 52)
                    {
                        bG[i].Background = Brushes.DarkGreen;
                    }
                    else if (i >= 52 && i < 64)
                    {
                        bG[i].Background = Brushes.Purple;
                    }
                    else if (i >= 64)
                    {
                        bG[i].Background = Brushes.DarkRed;
                    }
                    /*Setting BlurEffect*/
                    bG[i].Effect = beG[i];
                    /*Setting location to null*/
                    aslG[i] = "";
                }
                /*For pageH*/
                else if (sender == bH[i])
                {
                    /*Setting default colors*/
                    if (i < 4)
                    {
                        bH[i].Background = Brushes.DarkBlue;
                    }
                    else if (i >= 4 && i < 52)
                    {
                        bH[i].Background = Brushes.DarkGreen;
                    }
                    else if (i >= 52 && i < 64)
                    {
                        bH[i].Background = Brushes.Purple;
                    }
                    else if (i >= 64)
                    {
                        bH[i].Background = Brushes.DarkRed;
                    }
                    /*Setting BlurEffect*/
                    bH[i].Effect = beH[i];
                    /*Setting location to null*/
                    aslH[i] = "";
                }
            }
        }

        /*Showing assigned sample on button and corresponding keyboard Key*/
        private void padButton_MouseEnter(object sender, EventArgs e)
        {
            for(int i = 0 ; i < 70 ; i++)
            {
                if(sender == bA[i])
                {
                    sampleLabel.Content = "Sample : " + aslA[i];
                    keyLabel.Content = "Keyboard Key : " + k[i];
                }
                else if (sender == bB[i])
                {
                    sampleLabel.Content = "Sample : " + aslB[i];
                    keyLabel.Content = "Keyboard Key : " + k[i];
                }
                else if (sender == bC[i])
                {
                    sampleLabel.Content = "Sample : " + aslC[i];
                    keyLabel.Content = "Keyboard Key : " + k[i];
                }
                else if (sender == bD[i])
                {
                    sampleLabel.Content = "Sample : " + aslD[i];
                    keyLabel.Content = "Keyboard Key : " + k[i];
                }
                else if (sender == bE[i])
                {
                    sampleLabel.Content = "Sample : " + aslE[i];
                    keyLabel.Content = "Keyboard Key : " + k[i];
                }
                else if (sender == bF[i])
                {
                    sampleLabel.Content = "Sample : " + aslF[i];
                    keyLabel.Content = "Keyboard Key : " + k[i];
                }
                else if (sender == bG[i])
                {
                    sampleLabel.Content = "Sample : " + aslG[i];
                    keyLabel.Content = "Keyboard Key : " + k[i];
                }
                else if (sender == bH[i])
                {
                    sampleLabel.Content = "Sample : " + aslH[i];
                    keyLabel.Content = "Keyboard Key : " + k[i];
                }
            }
        }

        /*Showing volumeControl windows*/
        private void adjustVolume_Click(object sender, RoutedEventArgs e)
        {
            /*Checking if adjustVolume was clicked the first time*/
            if(vcc == 0)
            {
                this.Cursor = System.Windows.Input.Cursors.Wait;
                vcc++;
                vc = new volumeControl(this, pn);
                this.Hide();
                vc.Show();
            }
        }

        /*Showing balanceControl windows*/
        private void adjustBalance_Click(object sender, RoutedEventArgs e)
        {
            /*Checking if adjustBalance was clicked the first time*/
            if (bcc == 0)
            {
                this.Cursor = System.Windows.Input.Cursors.Wait;
                bcc++;
                bc = new balanceControl(this, pn);
                this.Hide();
                bc.Show();
            }
        }

        /*Showing aboutWindow*/
        private void about_Click(object sender, RoutedEventArgs e)
        {
            /*Checking if about was clicked the first time*/
            if (awc == 0)
            {
                awc++;
                aw = new aboutWindow(this);
                this.Hide();
                aw.Show();
            }
        }

        /*Showing optionsWindow*/
        private void options_Click(object sender, RoutedEventArgs e)
        {
            /*Checking if options was clicked the first time*/
            if (owc == 0)
            {
                owc++;
                ow = new optionsWindow(this);
                this.Hide();
                ow.Show();
            }
        }

        /*Method to pre-load all samples*/
        private void preLoad_Click(object sender, RoutedEventArgs e)
        {
            load_Samples();
        }

        /*Method to load last unsaved preset*/
        private void loadLastPreset_Click(object sender, RoutedEventArgs e)
        {
            load_Preset("CustomPreset");
        }  

        /*To reset all pads*/
        private void reset_Click(object sender, RoutedEventArgs e)
        {
            reset_Pads();
        }

        /*To deactivate/activate unassigned pads*/
        private void playMode_Click(object sender, RoutedEventArgs e)
        {
            /*Deactivating empty pads*/
            if (pmn % 2 == 0)
            {
                for (int i = 0; i < 70; i++)
                {
                    if (aslA[i] == "")
                    {
                        /*Hiding empty pads*/
                        bA[i].Visibility = System.Windows.Visibility.Hidden;
                    }
                    if (aslB[i] == "")
                    {
                        /*Hiding empty pads*/
                        bB[i].Visibility = System.Windows.Visibility.Hidden;
                    }
                    if (aslC[i] == "")
                    {
                        /*Hiding empty pads*/
                        bC[i].Visibility = System.Windows.Visibility.Hidden;
                    }
                    if (aslD[i] == "")
                    {
                        /*Hiding empty pads*/
                        bD[i].Visibility = System.Windows.Visibility.Hidden;
                    }
                    if (aslE[i] == "")
                    {
                        /*Hiding empty pads*/
                        bE[i].Visibility = System.Windows.Visibility.Hidden;
                    }
                    if (aslF[i] == "")
                    {
                        /*Hiding empty pads*/
                        bF[i].Visibility = System.Windows.Visibility.Hidden;
                    }
                    if (aslG[i] == "")
                    {
                        /*Hiding empty pads*/
                        bG[i].Visibility = System.Windows.Visibility.Hidden;
                    }
                    if (aslH[i] == "")
                    {
                        /*Hiding empty pads*/
                        bH[i].Visibility = System.Windows.Visibility.Hidden;
                    }
                    /*Hiding all other buttons except playMode*/
                    savePreset.Visibility = System.Windows.Visibility.Hidden;           //Hiding savePreset button
                    loadPreset.Visibility = System.Windows.Visibility.Hidden;           //Hiding loadPreset button
                    about.Visibility = System.Windows.Visibility.Hidden;                //Hiding about button
                    reset.Visibility = System.Windows.Visibility.Hidden;                //Hiding reset button
                    options.Visibility = System.Windows.Visibility.Hidden;              //Hiding options button
                    adjustVolume.Visibility = System.Windows.Visibility.Hidden;         //Hiding adjustVolume button
                    adjustBalance.Visibility = System.Windows.Visibility.Hidden;        //Hiding adjustBalance button
                    /*Deactivating pad Click*/
                    bA[i].Click -= padButton_Click;
                    bB[i].Click -= padButton_Click;
                    bC[i].Click -= padButton_Click;
                    bD[i].Click -= padButton_Click;
                    bE[i].Click -= padButton_Click;
                    bF[i].Click -= padButton_Click;
                    bG[i].Click -= padButton_Click;
                    bH[i].Click -= padButton_Click;
                    /*Deactivating pad right_Click*/
                    bA[i].MouseRightButtonDown -= padButton_RightClick;
                    bB[i].MouseRightButtonDown -= padButton_RightClick;
                    bC[i].MouseRightButtonDown -= padButton_RightClick;
                    bD[i].MouseRightButtonDown -= padButton_RightClick;
                    bE[i].MouseRightButtonDown -= padButton_RightClick;
                    bF[i].MouseRightButtonDown -= padButton_RightClick;
                    bG[i].MouseRightButtonDown -= padButton_RightClick;
                    bH[i].MouseRightButtonDown -= padButton_RightClick;
                    /*Hiding mouse cursor*/
                    this.Cursor = System.Windows.Input.Cursors.None;
                    /*Changing playMode label*/
                    playMode.Content = "Edit Mode";
                }
            }
            /*Activating empty pads*/
            else
            {
                for (int i = 0; i < 70; i++)
                {
                    if (aslA[i] == "")
                    {
                        /*Showing hidden pads*/
                        bA[i].Visibility = System.Windows.Visibility.Visible;
                    }
                    if (aslB[i] == "")
                    {
                        /*Showing hidden pads*/
                        bB[i].Visibility = System.Windows.Visibility.Visible;
                    }
                    if (aslC[i] == "")
                    {
                        /*Showing hidden pads*/
                        bC[i].Visibility = System.Windows.Visibility.Visible;
                    }
                    if (aslD[i] == "")
                    {
                        /*Showing hidden pads*/
                        bD[i].Visibility = System.Windows.Visibility.Visible;
                    }
                    if (aslE[i] == "")
                    {
                        /*Showing hidden pads*/
                        bE[i].Visibility = System.Windows.Visibility.Visible;
                    }
                    if (aslF[i] == "")
                    {
                        /*Showing hidden pads*/
                        bF[i].Visibility = System.Windows.Visibility.Visible;
                    }
                    if (aslG[i] == "")
                    {
                        /*Showing hidden pads*/
                        bG[i].Visibility = System.Windows.Visibility.Visible;
                    }
                    if (aslH[i] == "")
                    {
                        /*Showing hidden pads*/
                        bH[i].Visibility = System.Windows.Visibility.Visible;
                    }
                    /*Showing all other buttons except playMode*/
                    savePreset.Visibility = System.Windows.Visibility.Visible;         //Hiding savePreset button
                    loadPreset.Visibility = System.Windows.Visibility.Visible;         //Hiding loadPreset button
                    about.Visibility = System.Windows.Visibility.Visible;              //Hiding about button
                    reset.Visibility = System.Windows.Visibility.Visible;              //Hiding reset button
                    options.Visibility = System.Windows.Visibility.Visible;            //Hiding options button
                    adjustVolume.Visibility = System.Windows.Visibility.Visible;       //Hiding adjustVolume button
                    adjustBalance.Visibility = System.Windows.Visibility.Visible;      //Hiding adjustBalance button
                    /*Activating pad Click*/
                    bA[i].Click += padButton_Click;
                    bB[i].Click += padButton_Click;
                    bC[i].Click += padButton_Click;
                    bD[i].Click += padButton_Click;
                    bE[i].Click += padButton_Click;
                    bF[i].Click += padButton_Click;
                    bG[i].Click += padButton_Click;
                    bH[i].Click += padButton_Click;
                    /*Activating pad right_Click*/
                    bA[i].MouseRightButtonDown += padButton_RightClick;
                    bB[i].MouseRightButtonDown += padButton_RightClick;
                    bC[i].MouseRightButtonDown += padButton_RightClick;
                    bD[i].MouseRightButtonDown += padButton_RightClick;
                    bE[i].MouseRightButtonDown += padButton_RightClick;
                    bF[i].MouseRightButtonDown += padButton_RightClick;
                    bG[i].MouseRightButtonDown += padButton_RightClick;
                    bH[i].MouseRightButtonDown += padButton_RightClick;
                    /*Showing mouse cursor*/
                    this.Cursor = System.Windows.Input.Cursors.Arrow;
                    /*Chaning playMode label*/
                    playMode.Content = "Play Mode";
                }
            }
            pmn++;
        }
        
        /*To activate a page*/
        private void pageButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                if (sender == pb[i])
                {
                    pb[i].Background = Brushes.White;
                    pg[i].Visibility = System.Windows.Visibility.Visible;
                    pn[i] = 1;
                    /*Hiding others*/
                    for (int j = 0; j < 8; j++)
                    {
                        if (j != i)
                        {
                            pg[j].Visibility = System.Windows.Visibility.Hidden;
                            pb[j].Background = Brushes.Black;
                            pn[j] = 0;
                        }
                    }
                    break;
                }
            }
        }
        
        /*Button Close event to close mainWindows*/
        private void mainWindowsClose_Click(object sender, RoutedEventArgs e)
        {
            /*Storing custom recent preset to file*/
            save_Preset("CustomPreset");
            /*Closing VolumeControl if not closed*/
            if(vc != null)
            {
                vc.Close();
            }
            /*Closing BalanceControl if not closed*/
            if(bc != null)
            {
                bc.Close();
            }
            /*Closing AboutWindow if not closed*/
            if(aw != null)
            {
                aw.Close();
            }
            /*Closing OptionsWindow if not closed*/
            if(ow != null)
            {
                ow.Close();
            }
            mainWindow.Close();
        }                
                                      
    }
}
