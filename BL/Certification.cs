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
    public class Certification
    {

        /// 
        public bool CreateUpdateCertification(string requesterId, BE.Certification __certification)
        {
            DL.Certification _certificationDL = new DL.Certification();
            return _certificationDL.CreateUpdateCertification(requesterId, __certification);
        }

        public BE.Certification GetCertification(string requesterId)
        {
            DL.Certification _certificationlDL = new DL.Certification();
            return _certificationlDL.GetCertification(requesterId);
        }

    }
}
