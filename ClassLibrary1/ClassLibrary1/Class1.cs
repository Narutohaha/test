using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using WpfApp1;
using System.Runtime.InteropServices;

namespace ClassLibrary1
{

    [Transaction(TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {

        public delegate bool EnumWindowsProc(int hWnd, int lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern int GetWindowText(int hWnd, IntPtr lpString, int nMaxCount);
        List<string> list = new List<string>();
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //IntPtr intPtr = Autodesk.Windows.ComponentManager.ApplicationWindow;
            // EnumChildWindows(intPtr, this.EnumWindowsMethod, IntPtr.Zero);

            // TaskDialog.Show("dasda", list.Count.ToString());

            TaskDialog.Show("", "");
            MainWindow win = new MainWindow();
            win.Show();

            return Result.Succeeded;
        }


        private bool EnumWindowsMethod(int hWnd, int lParam)
        {
            IntPtr lpString = Marshal.AllocHGlobal(200);
            GetWindowText(hWnd, lpString, 200);
            var text = Marshal.PtrToStringAnsi(lpString);

            list.Add(text);
            return true;
        }


    }
}
