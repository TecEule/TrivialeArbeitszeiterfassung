﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teLogIn
{
  public class AccountModelView
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }

  public class Accounts
  {
    public List<AccountModelView> Konten { get; set; }
  }
}
