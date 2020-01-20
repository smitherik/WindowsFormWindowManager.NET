/*------------------------------------------------------------------------------
    Author     Erik Smith
    Created    2020-01-20
    Purpose    Control windows form applications such that at any point if there
               are no longer any application windows open the application will 
               close.
-------------------------------------------------------------------------------
    Modification History
  
    01/20/2020  Erik W. Smith
    [30:34]
        Initial Development
        Single line change from the default template for a windows form 
        application.
-----------------------------------------------------------------------------*/


using System;
using System.Windows.Forms;

namespace FormWindowManager
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //
            //
            Application.Run(new WindowManager());  // Using our window manager
            //
            //
        }
    }
}
