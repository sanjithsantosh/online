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
    public class Educational
    {

        
        public bool CreateUpdateEducational(string requesterId, BE.Educational _educational)
        {
            DL.Educational _educationalDL = new DL.Educational();
            return _educationalDL.CreateUpdateEducational(requesterId, _educational);
        }

        public BE.Educational GetEducational(string requesterId)
        {
            DL.Educational _educationalDL = new DL.Educational();
            return _educationalDL.GetEducational(requesterId);
        }
    }
}
