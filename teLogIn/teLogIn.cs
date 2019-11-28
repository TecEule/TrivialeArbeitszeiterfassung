using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teLogIn
{
  public class teLogIn
  {

    private static teLogIn _instance;
    public static teLogIn Instance
    {
      get
      {
        if (_instance == null)
          _instance = new teLogIn();

        return _instance;
      }
    }

    private teLogIn()
    {

    }

    public bool checkLogIn(AccountModelView account)
    {
      return checkLogIn(account.Username, account.Password);
    }
    public bool checkLogIn(string benutzer, string passwort)
    {
      bool correct = false;

      correct = compareData(benutzer, passwort);

      return correct;
    }

    private bool compareData(string benutzer, string passwort)
    {
      bool correct = false;


      string passwortFromFile = getPasswort(benutzer);

      if (passwort.Equals(passwortFromFile))
      {
        correct = true;
      }

      return correct;
    }

    private string getPasswort(string benutzer)
    {
      string password = string.Empty;

      password = readPasswordFromFile(benutzer);

      return password;
    }

    private string readPasswordFromFile(string benutzer)
    {
      string password = string.Empty;

      return password;
    }
  }
}
