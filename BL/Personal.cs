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
    public class Personal
    {
       
        /// 
        public bool CreateUpdatePersonal(string requesterId, BE.Personal _personal)
        {
            DL.Personal _personalDL = new DL.Personal();
            return _personalDL.CreateUpdatePersonal(requesterId, _personal);
        }

        public BE.Personal GetPersonal(string requesterId)
        {
            DL.Personal _personalDL = new DL.Personal();
            return _personalDL.GetPersonal(requesterId);
        }

      
    }
}
