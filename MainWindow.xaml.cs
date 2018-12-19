using BarcodeScanner;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace SMQDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //BardCodeHooK  BarCode = new BardCodeHooK(); 
        ScanerHook scanerHook = new ScanerHook();

        public MainWindow()
        {
            InitializeComponent();

            //BarCode.BarCodeEvent += new BardCodeHooK.BardCodeDeletegate(BarCode_BarCodeEvent);
            scanerHook.ScanerEvent += new ScanerHook.ScanerDelegate(ScanerHook_BarCodeEvent);
        }

        // private delegate void ShowInfoDelegate(BardCodeHooK.BarCodes barCode);

        private delegate void ShowInfoDelegateScaner(ScanerHook.ScanerCodes scanerCodes);

        //private void ShowInfo(BardCodeHooK.BarCodes barCode)
        //{ 
        //    //if (barCode.IsValid)
        //    //{
        //    //    textBox1.Text = barCode.KeyName;
        //    //    textBox2.Text = barCode.VirtKey.ToString();
        //    //    textBox3.Text = barCode.ScanCode.ToString();
        //    //    textBox4.Text = barCode.Ascll.ToString();
        //    //    textBox5.Text = barCode.Chr.ToString();
        //    //    textBox6.Text = barCode.IsValid ? barCode.BarCode : "";//是否为扫描枪输入，如果为true则是 否则为键盘输入
        //    //    textBox7.Text += barCode.KeyName;

        //    //}
        //    //MessageBox.Show(barCode.IsValid.ToString());

        //}
        //C#中判断扫描枪输入与键盘输入
        //Private DateTime _dt = DateTime.Now;  //定义一个成员函数用于保存每次的时间点
        //private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    DateTime tempDt = DateTime.Now;          //保存按键按下时刻的时间点
        //    TimeSpan ts = tempDt .Subtract(_dt);     //获取时间间隔
        //    if (ts.Milliseconds > 50)                           //判断时间间隔，如果时间间隔大于50毫秒，则将TextBox清空
        //        textBox1.Text = "";
        //    dt = tempDt ;
        //}

        private void BarCode_BarCodeEvent(BardCodeHooK.BarCodes barCode)
        {
            //ShowInfo(barCode);
        }



        private void ShowInfo(ScanerHook.ScanerCodes scanerCodes)
        {

            textBox1.Text = scanerCodes.CurrentChar;
            textBox2.Text = scanerCodes.KeyDownCount.ToString();


            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < scanerCodes.KeyboardState.Length; i++) 
            { 
                sb.Append(scanerCodes.KeyboardState[i].ToString("X2"));

            }

            textBox3.Text = sb.ToString();

          textBox3.Text =System.Text.Encoding.ASCII.GetString (scanerCodes.KeyboardState);
            textBox4.Text = scanerCodes.isShift.ToString();
            textBox5.Text = scanerCodes.CurrentKey.ToString();
            //textBox6.Text = scanerCodes.IsValid ? barCode.BarCode : "";//是否为扫描枪输入，如果为true则是 否则为键盘输入
            textBox7.Text = scanerCodes.Result;


        }
        private void ScanerHook_BarCodeEvent(ScanerHook.ScanerCodes scanerCodes)
        {
            ShowInfo(scanerCodes);
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //  BarCode.Start();
            scanerHook.Start();
        }
        private void Window_Closed(object sender, EventArgs cancelEventArgs)
        {
            scanerHook.Stop();
            // BarCode.Stop();
            // 析构
        }

    }
}
