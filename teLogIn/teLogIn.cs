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

    public bool checkLogIn(AccountModelView account, string key)
    {
      return checkLogIn(account.Username, account.Password, key);
    }
    public bool checkLogIn(string benutzer, string passwort, string key)
    {
      bool correct = false;

      correct = compareData(benutzer, passwort, key);

      return correct;
    }

    private bool compareData(string benutzer, string passwort, string key)
    {
      bool correct = false;


      string passwortFromFile = getPasswort(benutzer, key);

      if (passwort.Equals(passwortFromFile))
      {
        correct = true;
      }

      return correct;
    }

    private string getPasswort(string benutzer, string key)
    {
      string password = string.Empty;

      password = readPasswordFromFile(benutzer, key);

      return password;
    }

    private string readPasswordFromFile(string benutzer, string key)
    {
      string password = string.Empty;

      password = JsonFile.Instance.readUserPasswordFromFile<string>(benutzer, key, "");

      return password;
    }
  }
}
