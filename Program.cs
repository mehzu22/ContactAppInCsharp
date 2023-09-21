using ContactAppInCsharp.Model;

namespace ContactAppInCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create users
            User user1 = User.CreateUser("Mehzu", 22, "F");
            User user2 = User.CreateUser("Izzy", 20, "F");
            User user3 = User.CreateUser("Cubby", 19, "M");
            Console.WriteLine("-------------All Users ---------------");
            user1.DisplayAllUsers();

            //get user by id and display info
            //var user=user1.GetUserById(2);
            //Console.WriteLine("\nUser with ID 2 is _-->" +
            //    "\nID : " + user.UserID +
            //    "\nName : " +user.UserName+
            //    "\nGender : "+user.UserGender);

            //update user3 
            user3.UpdateUser(2, "Jake", 19, "M");
            Console.WriteLine("\n---------- Updated User 3 --------- \n"+user3.ReadUser(3));

            //delete user
            user1.DeleteUser(2);
            Console.WriteLine("\n------------Users list Afetr user 2 deleted --------------");
            user1.DisplayAllUsers();

            Console.WriteLine("\n------- User1 Contacts --------");
            user1.CreateContact("Leeza");
            user1.CreateContact("Arbina");
            user1.CreateContact("Saba");
            user1.CreateContact("Muskan");
            user1.DisplayUserContact(1);

            Console.WriteLine("\n------- User3 Contacts --------");
            user3.CreateContact("Harry");
            user3.CreateContact("Hermione");
            user3.DisplayUserContact(3);

            user1.UpdateUserContact(1, "Uzma");
            Console.WriteLine("\n-------Update user1's contact no 1-------");
            user1.DisplayUserContact(1);

            Console.WriteLine("\n--------- Delete User Contact no 3 ---------");
            user1.DeleteUserContact(3);
            user1.DisplayUserContact(1);

            Console.WriteLine("\n--------- User1 Contact no 1's Contact Infos -------- ");
            user1.CreateContactInfo(1, "Email", "abc@mail.com");
            user1.CreateContactInfo(1, "Work", "123400");
            user1.CreateContactInfo(2, "Email", "bcd@mail.com");
            user1.CreateContactInfo(2, "Work",  "679809");
            user1.DisplayUserContactInfo(1);
            Console.WriteLine("\n--------- User1 Contact no 2's Contact Infos -------- ");
            user1.DisplayUserContactInfo(2);

            Console.WriteLine("\n---------- user1 contcat no 1's updated type --------");
            user1.UpdateContactInfoType(1, 1, "Home");
            user1.DisplayUserContactInfo(1);
            
            Console.WriteLine("\n---------- user1 contcat no 2's updated value --------");
            user1.UpdateContactInfoValue(2, 4, "563487");
            user1.DisplayUserContactInfo(2);

            Console.WriteLine("\n--------- user1 delete contact no 1's contact info -------");
            user1.DeleteContactInfo(1, 1);
            user1.DisplayUserContactInfo(1);
            
            Console.WriteLine("\n--------- user2 delete contact no 1's contact info -------");
            user1.DeleteContactInfo(2, 1);

            Console.WriteLine("\n--------- Display all users with contact ---------");
            user1.DisplayAllUsersWithContacts();

        }
    }
}