// Date Created             : August 27 2015
// Author                   : Sanjith
// 
// Change History
//
// Date Modified            : 
// Changed By               : 
// Change Description       : 

using System;
using System.Collections.Generic;
using System.Linq;
using DL;
using BE;
using BE.Common;
using System.Net.Mail;
namespace BL
{
    public class Login
    {

        /// 
        public bool CreateUser(BE.Login _login)
        {
            DL.Login _loginDL = new DL.Login();
            return _loginDL.CreateUser(_login);
        }

        public bool CheckUser(BE.Login _login)
        {
            DL.Login _loginDL = new DL.Login();
            return _loginDL.CheckUser(_login);
        }


    }
}
