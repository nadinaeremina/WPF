using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace My_MVVM
{
    public class Class_Dialog : DialogInterface
    {
        public string FilePath { get; set; }

        public bool OpenFileDialog()
        {
            OpenFileDialog of = new OpenFileDialog();
            if (of.ShowDialog() == true)
            {
                FilePath = of.FileName;
                return true;
            }
            return false;
        }
        public bool SaveFileDialog()
        {
            SaveFileDialog sf = new SaveFileDialog();
            if (sf.ShowDialog() == true)
            {
                FilePath = sf.FileName;
                return true;
            }
            return false;

        }
        public void Show_my(string message)
        {
            MessageBox.Show(message);
        }
    }

    public interface DialogInterface
    {
        string FilePath { get; set; }
        bool OpenFileDialog();
        bool SaveFileDialog();
        void Show_my(string message);
    }
}
