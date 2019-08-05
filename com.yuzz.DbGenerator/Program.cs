using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DBFramework.vo;
using DBFramework.util;
using com.cgWorkstudio.BIMP;
using com.cgWorkstudio.BIMP.MySQL;

namespace DBFramework {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Main());
            //Application.Run(new Form_MySQL());
        }
    }
}
