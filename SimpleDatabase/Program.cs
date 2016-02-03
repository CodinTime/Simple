using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleDatabase.Database;
using SimpleDatabase.Models;

namespace SimpleDatabase
{
    class Program
    {
        static Events.FileSaver saver;
        
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            saver = new Events.FileSaver();
            saver.afterSaveEvent += (() => Console.WriteLine("before save"));
            Console.WriteLine("wpisz imie: ");
            firstName = Console.ReadLine();
            Console.WriteLine("wpisz nazwisko:");
            lastName = Console.ReadLine();
            if (!validate(firstName,lastName))
            {
                Console.WriteLine("Za krótkie imie lub nazwisko (min 3 znaki)");
                Console.ReadLine();
                return;
            }
            if (contains(firstName,lastName))
            {
                Console.WriteLine(string.Format("witaj ponownie {0} {1}", firstName, lastName));
            }
            else
            {
                add(firstName, lastName);
                

        }
        static private bool validate(string FirstName, string LastName)
        {
            if (FirstName.Length < 3)
                return false;
            if (LastName.Length < 3)
            {
                return false;
            }
            return true;
        }
        static private void view()
        {
            using (SimpleDbContext ctx = new SimpleDbContext())
            {
                List<User> users = ctx.Users.SqlQuery("select * from users").ToList<User>();
                Console.WriteLine();
                Console.WriteLine("Lista userów:");
                foreach (var user in users)
                {
                    Console.WriteLine(user);
                }
                Console.ReadLine();
            }
        }
        static private bool contains(string FirstName, string LastName)
        {
            using (SimpleDbContext ctx = new SimpleDbContext())
            {
                if (ctx.Users.Where<User>(u => u.LastName == LastName).Where<User>(u => u.FirstName == FirstName).Any<User>())
                {
                    return true;
                }
            }
            return false;
        }

        static private bool add(string FirstName, string LastName)
        {
            using (SimpleDbContext ctx = new SimpleDbContext())
            {
                ctx.Users.Add(new User() { FirstName = FirstName, LastName = LastName });
                ctx.SaveChanges();
            }
            return false;
        }
    }
}
