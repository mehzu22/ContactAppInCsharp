using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppInCsharp.Model
{
    internal class ContactList
    {
        public static int contactIdCounter = 1;
        public int ContactId { get; set; }
        public string ContactName { get; set; }
       
        public List<ContactInfoList> contactInfo { get; set; }

        public ContactList(string contactName)
        {
            ContactId=contactIdCounter++;
            ContactName = contactName;
            contactInfo = new List<ContactInfoList> ();
        }

        public void UpdateContactName(string newContactName)
        {
            ContactName=newContactName;
        }

        
        public ContactInfoList CreateContactInfo(string parameter,string value)
        {
            var newContactInfo = new ContactInfoList(parameter, value);
            contactInfo.Add(newContactInfo);
            return  newContactInfo;
        }

        public void DisplayContactInfo()
        {
            foreach (var item in contactInfo)
            {
                Console.WriteLine($"Contact Info Id : {item.ContactInfoId}" +
                    $"\tContact Type : {item.TypeOfContact}" +
                    $"\tValue : {item.ValueOfcontact}");
            }
        }
        public void UpdateUserTypeOfContactInfo(int contactinfoId,string newType)
        {
            var foundContactInfo = GetAllContactInfoById(contactinfoId);
            foundContactInfo.UpdateTypeOfContactInfo(newType);
            
        }
        public void UpdateUserValueOfContactInfo(int contactinfoId,string newValue)
        {
            var foundContactInfo = GetAllContactInfoById(contactinfoId);
            foundContactInfo.UpdateValueOfContactInfo(newValue);
        }
        public ContactInfoList GetAllContactInfoById(int contactInfoId)
        {
            var findContactInfo = contactInfo.Find(x => x.ContactInfoId == contactInfoId);
            if (findContactInfo == null)
                throw new Exception("Contact info not found");
            return findContactInfo;
        }

        public void DeleteContactInfo(int contactinfoId)
        {
            var foundContactInfo = GetAllContactInfoById(contactinfoId);
            contactInfo.Remove(foundContactInfo);
            
        }
        public List<ContactInfoList> GetAllContactInfo()
        {
            return contactInfo;
        }
    }
}
