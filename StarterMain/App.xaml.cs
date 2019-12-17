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
      StarterMain.MainWindow window = new MainWindow();


      // Create LogIn page
      //LogIn.Gui.MainWindow.Instance.ShowDialog();
      LogIn.Gui.LoginGui main = new LogIn.Gui.LoginGui();
      main.ShowDialog();

      if (!LogIn.Gui.LoginGui.Instance.correctLogIn)
      {
        this.MainWindow?.Close();
        window?.Close();
        window = null;
        this.Shutdown();
      }

      
    }
  }
}
