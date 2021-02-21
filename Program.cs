using System;

namespace Flags
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User(UserRights.Moderator);
            Check(user);
            Console.ReadKey();
        }
        public static void Check(User user)
        {
            if ((user.Rights & UserRights.None) == UserRights.None) Console.WriteLine("You have no rights");
            if ((user.Rights & UserRights.ReadComments) == UserRights.ReadComments) Console.WriteLine("You can read comments");
            if ((user.Rights & UserRights.WriteComments) == UserRights.WriteComments) Console.WriteLine("You can write comments");
            if ((user.Rights & UserRights.CreateUsers) == UserRights.CreateUsers) Console.WriteLine("You can create users");
            if ((user.Rights & UserRights.DeleteUsers) == UserRights.DeleteUsers) Console.WriteLine("You can delete users");
        }
    }

    [Flags]
    public enum UserRights : int
    {
        None = 0b00000001,
        ReadComments = 0b00000010,
        WriteComments = 0b00000100,
        CreateUsers = 0b00001000,
        DeleteUsers = 0b00010000,

        Moderator = ReadComments | WriteComments, // equals 0b00000110
        ModeratorInBinary = 0b00000110, // equals ReadComments | WriteComments (Moderator)

        Administrator = ReadComments | WriteComments | CreateUsers | DeleteUsers, // equals 0b00011110
        AdministratorInBinary = 0b00011110 // equals ReadComments | WriteComments | CreateUsers | DeleteUsers (Administrator)
    }
    public class User
    {
        public UserRights Rights { get; set; }
        public User(UserRights userRights) => Rights = userRights;
    }
}