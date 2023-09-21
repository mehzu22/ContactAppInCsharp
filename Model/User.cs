using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactAppInCsharp.Model
{
    internal class User
    {
        public static List<User> users = new List<User>();
        public static int userIDCounter = 1;

        public int UserID { get; set; }
        public string UserName { get; set; }
        public int UserAge { get; set; }
        public string UserGender { get; set; }

        public List<ContactList> contacts;

        public User(string userName, int userAge, string userGender)
        {
            UserID = userIDCounter++;
            UserName = userName;
            UserAge = userAge;
            UserGender = userGender;
            contacts = new List<ContactList>();
        }

        public static User CreateUser(string name, int age, string gender)
        {
            if (name == null || age < 0 || gender == null)
            {
                throw new Exception("Invalid Input");
            }
            User newUser = new User(name, age, gender) ;
            users.Add(newUser);
            return newUser;
            
        }
        //display all user by using user object
        public void DisplayAllUsers()
        {
            
            
            foreach (var user in users)
            {
                Console.WriteLine($"UserID: {user.UserID}, " +
                    $"\tName: {user.UserName}, " +
                    $"\tAge: {user.UserAge}, " +
                    $"\tGender: {user.UserGender}" );
            }
            

        }
        //Get user by its ID
        public User GetUserById(int id)
        {
            var findUser = users.Find(x => x.UserID == id);

            if (findUser == null)
                throw new Exception("User not Found");

            return findUser;

        }
        //disply user by id 
        public string ReadUser(int id)
        {
            var user = GetUserById(id);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }
            return $"Id : {user.UserID}\tName : {user.UserName}\tAge : {user.UserAge}\t" +
                $"Gender : {user.UserGender}";
        }
        //this method will update all user info
        public void UpdateUser(int id,string newName, int newAge,string newGender)
        {
            try
            {
                var userToBeUpdated = GetUserById(id);

                if (userToBeUpdated == null)
                    throw new Exception("User to be updated not Found");

                else if (newAge < 0)
                    throw new Exception("Not a valid age");

                userToBeUpdated.UserName = newName;
                userToBeUpdated.UserAge = newAge;
                userToBeUpdated.UserGender = newGender;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
        //update user name only
        public void UpdateUserName(int id,string userName)
        {
            try
            {
                var userToBeUpdated = GetUserById(id);
                if (userToBeUpdated == null)
                    throw new Exception("User to be updated not Found");
                

                userToBeUpdated.UserName = userName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        //update user age only
        public void UpdateUserAge(int id,int newAge)
        {
            try
            {
                var userToBeUpdated = GetUserById(id);
                if (userToBeUpdated == null)
                    throw new Exception("User to be updated not Found");
                else if (newAge < 0)
                    throw new Exception("Not a valid age");

                userToBeUpdated.UserAge = newAge;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        //update user gender only
        public void UpdateUserGender(int id,string newGender)
        {
            try
            {
                var userToBeUpdated = GetUserById(id);
                if (userToBeUpdated == null)
                    throw new Exception("User to be updated not Found");
                

                userToBeUpdated.UserGender = newGender;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        //delete user by id
        public void DeleteUser(int id)
        {
            try
            {
                var userToBeDeleted = GetUserById(id);
                if (userToBeDeleted == null)
                    throw new Exception("User to be deleted not Found");

                users.Remove(userToBeDeleted);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            
        }
        public void DisplayAllUsersWithContacts()
        {
            foreach (var user in users)
            {
                Console.WriteLine($"UserID: {user.UserID}, " +
                    $"Name: {user.UserName}, " +
                    $"Age: {user.UserAge}, " +
                    $"Gender: {user.UserGender}");

                Console.WriteLine("Contacts:");
                foreach (var contact in user.contacts)
                {
                    Console.WriteLine($"  Contact ID: {contact.ContactId}, " +
                        $"Contact Name: {contact.ContactName}");

                }

                Console.WriteLine(); 
            }
        }

        //get all users
        public List<User> GetAllUsers()
        { 
           return users;
            
        }


        //-----------------------------------------------------------------------------------------
        // user create contact
        public void CreateContact(string contactName)
        {
            try
            {
                if (contactName == null)
                    throw new Exception("Contact name can't be empty");

                var newContact = new ContactList(contactName);
                contacts.Add(newContact);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        //user read all of its contact
        public void DisplayUserContact(int id)
        {
            try
            {
                var findUserContact = GetUserById(id);

                if(findUserContact==null)
                    throw new Exception("User not found");
                
                var usercontact= findUserContact.GetAllUserContact();
                
                foreach (var contact in usercontact)
                {
                    Console.WriteLine($"Contact Id : {contact.ContactId}" +
                        $"\tContact name : {contact.ContactName}");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        //get user contact by id
        public ContactList GetContactsById(int id)
        {
            var findContact = contacts.Find( x => x.ContactId == id);
            if (findContact == null)
                throw new Exception("Contact not Found");
            return findContact;
        }
        // update user contact name by id
        public void UpdateUserContact(int id,string newContactName)
        {
            try
            {
                var findUserContact = GetContactsById(id);

                if (findUserContact == null)
                    throw new Exception("User not found");

                findUserContact.UpdateContactName(newContactName);

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //delete user contact by id
        public void DeleteUserContact(int id)
        {
            try
            {
                var findUserContact = GetContactsById(id);

                if (findUserContact == null)
                    throw new Exception("User not found");

                contacts.Remove(findUserContact);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        // get all users contact
        public List<ContactList> GetAllUserContact()
        {
            return contacts;
        }

        
        //-------------------------------------------------------------------------------------------
        //user create contact info
        public void CreateContactInfo(int id,string parameter,string value)
        {
            try
            {
                
                var findUserContact = GetContactsById(id);
                if(findUserContact==null)
                    throw new Exception("Contact not found");
                findUserContact.CreateContactInfo(parameter, value);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //display all contact info of user's contact
        public void DisplayUserContactInfo(int id)
        {
            try
            {
                var findUserContact = GetContactsById(id);
                if (findUserContact == null)
                    throw new Exception("Contact not found");

                findUserContact.DisplayContactInfo();
            }
            catch (Exception e) 
            { 
                Console.WriteLine(e.Message); 
            }
        }
        //update contact info type
        public void UpdateContactInfoType(int contactId,int contactInfoId,string contactType)
        {
            try
            {
                var findContact = GetContactsById(contactId);
                if (findContact == null)
                    throw new Exception("Contact not Found");
                findContact.UpdateUserTypeOfContactInfo(contactInfoId, contactType);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

        }
        //update contact info value
        public void UpdateContactInfoValue(int  contactId, int contactInfoId,string contactValue)
        {
            try
            {
                var findContact = GetContactsById(contactId);
                if (findContact == null)
                    throw new Exception("Contact not Found");
                findContact.UpdateUserValueOfContactInfo(contactInfoId, contactValue);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //delete contact info by contact info id
        public void DeleteContactInfo(int contactId,int contactInfoId)
        {
            try
            {
                var findContact = GetContactsById(contactId);
                if (findContact == null)
                    throw new Exception("Contcat not found");

                findContact.DeleteContactInfo(contactInfoId);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
