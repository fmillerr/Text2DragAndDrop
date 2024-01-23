using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Text2DragAndDrop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {
            if (args.Length > 0 && args[0] == "open")
            {
                using (var main = new Text2DragAndDropDialog())
                {
                    main.ZeigeDialog();
                }
                
                Application.Exit();
            }
            
            if (Util.PriorProcess() != null)
            {
                MessageBox.Show("App already running");
                return;
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MyCustomApplicationContext());
        }
    }

    public class MyCustomApplicationContext : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public MyCustomApplicationContext()
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                ContextMenuStrip = new ContextMenuStrip()
                {
                    Items =
                    {
                        new ToolStripMenuItem("Text to Clippyfile", null, (a, e) => { OpenDialog(); }),
                        new ToolStripMenuItem("Exit", null, (a, e) => Exit(null, null))
                    },
                    Width = 400
                },
                Visible = true
            };

            Bitmap bitmap = (Bitmap)Image.FromFile("Properties/file.png");
            trayIcon.Icon = Icon.FromHandle(bitmap.GetHicon());

#if DEBUG
            OpenDialog();
#endif
        }

        private void OpenDialog()
        {
            using (var main = new Text2DragAndDropDialog())
            {
                main.ZeigeDialog();
            }
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            Application.Exit();
        }
    }

    public static class Util
    {
        public static Process PriorProcess()
            // Returns a System.Diagnostics.Process pointing to
            // a pre-existing process with the same name as the
            // current one, if any; or null if the current process
            // is unique.
        {
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) &&
                    (p.MainModule.FileName == curr.MainModule.FileName))
                    return p;
            }

            return null;
        }
    }
}