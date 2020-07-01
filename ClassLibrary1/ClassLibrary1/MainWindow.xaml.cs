using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate bool EnumWindowsProc(int hWnd, int lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hWnd, IntPtr lpString, int nMaxCount);

        [DllImport("USER32.DLL", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, string lParam);

        List<IntPtr> list = new List<IntPtr>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            IntPtr intPtr = Autodesk.Windows.ComponentManager.ApplicationWindow;
            MessageBox.Show("58888");
            EnumChildWindows(intPtr, this.EnumWindowsMethod, IntPtr.Zero);
            MessageBox.Show("7777777");
            MessageBox.Show(list.Count.ToString());
        }

        private void hahha()
        {
            MessageBox.Show("666666");

        }

        private bool EnumWindowsMethod(int hWnd, int lParam)
        {
            IntPtr lpString = Marshal.AllocHGlobal(200);
            GetWindowText(hWnd, lpString, 200);
            var text = Marshal.PtrToStringAnsi(lpString);
            if (text.Contains("宽度"))
            {
                MessageBox.Show(text);
            }
            list.Add(new IntPtr(hWnd));
            return true;
        }
    }
}
