/*******************************************************************************
 * Filename   : Multi-Monitor.cs
 * Author     : jhlicc@gmai1.c0m
 * Date       : 27 Aug 2007
 * Description: Programming Multi-Monitor application with MS .Net on Windows XP
 ******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MM
{
  class MM
  {
    [STAThread]
    static void Main()
    {
      for (int i = 0; i != Screen.AllScreens.Length; i++)
      {
        Form frm = new Form();
        WebBrowser brs = new WebBrowser();

        brs.Dock = DockStyle.Fill;
        brs.ScrollBarsEnabled = false;
        if (Screen.AllScreens[i].Primary)
          brs.Navigate(new Uri("http://www.cyberspace.org/~jhl"));
        else
          brs.Navigate(new Uri("http://www.c-faq.com"));
        frm.Controls.Add(brs);
        frm.FormBorderStyle = FormBorderStyle.None;
        frm.Show();
        frm.DesktopBounds = Screen.AllScreens[i].Bounds;

        /*Compile this console project as Windows Application at: Project/...
          Properties/Application/Output type: Windows Application, this hides
          the console window. Override FormClosed event triggered by keystroke
          ALT+F4 and exit the application at the close of the last form.*/
        frm.FormClosed += delegate(object obj, FormClosedEventArgs args)
        {
          if (Application.OpenForms.Count == 0)
            Application.Exit();
        };
      }
      Application.Run();
    }
  }
}

