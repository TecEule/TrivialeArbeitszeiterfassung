using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using teLogIn;

namespace StarterMain
{
  /// <summary>
  /// Interaktionslogik für "App.xaml"
  /// </summary>
  public partial class App : Application
  {

    private void Application_Startup(object sender, StartupEventArgs e)
    {
      StarterMain.MainWindow window = new MainWindow();


      // Create LogIn page
      if (!JsonFile.Instance.existFile())
      {
        LogIn.FirstLogin first = new LogIn.FirstLogin();
        bool? result = first.ShowDialog();
        if ((bool)result)
        {
          LogIn.Gui.LoginGui.Instance.ShowDialog();
        }

      }
      else
      {
        LogIn.Gui.LoginGui.Instance.ShowDialog();
      }

      if (!LogIn.Gui.LoginGui.Instance.correctLogIn)
      {
        // Cancel
        this.MainWindow?.Close();
        window?.Close();
        window = null;
        this.Shutdown();
      }

      
    }
  }
}
