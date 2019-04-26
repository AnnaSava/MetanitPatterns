using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns.Misc
{
   static class FluentBuilderPattern
    {
        public static void Display()
        {
            User tom = new UserBuilder().SetName("Tom").SetCompany("Microsoft").SetAge(23);
            tom.Print();
            User alice = User.CreateBuilder().SetName("Alice").IsMarried.SetAge(25);
            alice.Print();
        }

        public class User
        {
            public string Name { get; set; }        // имя
            public string Company { get; set; }     // компания
            public int Age { get; set; }            // возраст
            public bool IsMarried { get; set; }      // женат/замужем

            public static UserBuilder CreateBuilder()
            {
                return new UserBuilder();
            }

            public void Print()
            {
                Console.WriteLine($"Name {Name} Company {Company} Age {Age} IsMarried {IsMarried}");
            }
        }

        public class UserBuilder
        {
            private User user;
            public UserBuilder()
            {
                user = new User();
            }
            public UserBuilder SetName(string name)
            {
                user.Name = name;
                return this;
            }
            public UserBuilder SetCompany(string company)
            {
                user.Company = company;
                return this;
            }
            public UserBuilder SetAge(int age)
            {
                user.Age = age > 0 ? age : 0;
                return this;
            }
            public UserBuilder IsMarried
            {
                get
                {
                    user.IsMarried = true;
                    return this;
                }
            }
            public static implicit operator User(UserBuilder builder)
            {
                return builder.user;
            }
        }
    }
}
