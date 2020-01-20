/*------------------------------------------------------------------------------
    Author     Erik Smith
    Created    2020-01-20
    Purpose    Control windows form applications such that at any point if there
               are no longer any application windows open the application will 
               close.
-------------------------------------------------------------------------------
    Modification History
  
    01/20/2020  Erik W. Smith
    [1:eof]
        Initial Development
-----------------------------------------------------------------------------*/


using System;
using System.Windows.Forms;

namespace FormWindowManager
{
    class WindowManager : ApplicationContext
    {
        //When each form closes, close the application if no other open forms
        private void OnFormClosed(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                ExitThread();
            }
        }

        //Any form which might be the last open form in the application should be created with this
        public T CreateForm<T>() where T : Form, new()
        {
            var ret = new T();
            ret.FormClosed += OnFormClosed;
            return ret;
        }

        //I'm using Lazy here, because an exception is thrown if any Forms have been
        //created before calling Application.SetCompatibleTextRenderingDefault(false)
        //in the Program class
        private static Lazy<WindowManager> _current = new Lazy<WindowManager>();
        public static WindowManager Current => _current.Value;

        //Startup forms should be created and shown in the constructor
        public WindowManager()
        {
            var f1 = CreateForm<Form1>(); // default form created within the constructor
            f1.Show();                    // yields modeless behavior
            //f1.ShowDialog();               yields modal behavior

        }

    }
}
