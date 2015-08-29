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
    public class Professional
    {

        /// 
        public bool CreateUpdateProfessional(string requesterId, BE.Professional _professional)
        {
            DL.Professional _professionalDL = new DL.Professional();
            return _professionalDL.CreateUpdateProfessional(requesterId, _professional);
        }


        public BE.Professional GetProfessional(string requesterId)
        {
            DL.Professional _professionalDL = new DL.Professional();
            return _professionalDL.GetProfessional(requesterId);
        }

    }
}
