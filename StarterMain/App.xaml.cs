using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StarterMain
{
  /// <summary>
  /// Interaktionslogik für "App.xaml"
  /// </summary>
  public partial class App : Application
  {

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Create LogIn page
            LogIn.Gui.MainWindow.Instance.ShowDialog();

            if (!LogIn.Gui.MainWindow.Instance.correctLogIn)
            {  
                this.MainWindow?.Close();
            }
        }
  }
}
