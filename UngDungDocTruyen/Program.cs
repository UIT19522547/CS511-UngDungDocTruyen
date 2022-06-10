using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UngDungDocTruyen
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< Updated upstream
            Application.Run(new Form1());
=======
            //Application.Run(new Reading("Harry Potter và Hòn Đá Phù Thủy","jkrowling","sandrabrown"));
            Application.Run(new Form1(""));
            //Application.Run(new WritingBook("jkrowling", ""));
            //Application.Run(new WritingBook("jkrowling", ""))
>>>>>>> Stashed changes
        }
    }
}
