using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppInCsharp.Model
{
    public class ContactInfoList
    {
        public static int contactInfoIdCounter = 1;
        public int ContactInfoId { get; set; }
        public string TypeOfContact { get; set; }
        public string ValueOfcontact { get; set; }

        public ContactInfoList(string typeOfContact, string valueOfContact) 
        {
            ContactInfoId = contactInfoIdCounter++;
            TypeOfContact = typeOfContact;
            ValueOfcontact = valueOfContact;
        }

        public void UpdateTypeOfContactInfo(string newTypeOfContact)
        {
            TypeOfContact = newTypeOfContact;
        }

        public void UpdateValueOfContactInfo(string newValueOfContact)
        {
            ValueOfcontact = newValueOfContact;
        }
    }
}
