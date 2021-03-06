﻿using System;

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
            if (user.Rights.HasFlag(UserRights.ReadComments)) Console.WriteLine("You can read comments");
            if (user.Rights.HasFlag(UserRights.WriteComments)) Console.WriteLine("You can write comments");
            if (user.Rights.HasFlag(UserRights.CreateUsers)) Console.WriteLine("You can create users");
            if (user.Rights.HasFlag(UserRights.DeleteUsers)) Console.WriteLine("You can delete users");
        }
    }

    [Flags]
    public enum UserRights : int
    {
        ReadComments = 0b00000001,
        WriteComments = 0b00000010,
        CreateUsers = 0b00000100,
        DeleteUsers = 0b00001000,

        Moderator = ReadComments | WriteComments, // equals 0b00000011
        ModeratorInBinary = 0b00000011, // equals ReadComments | WriteComments (Moderator)

        Administrator = ReadComments | WriteComments | CreateUsers | DeleteUsers, // equals 0b00001111
        AdministratorInBinary = 0b00001111 // equals ReadComments | WriteComments | CreateUsers | DeleteUsers (Administrator)
    }
    public class User
    {
        public UserRights Rights { get; set; }
        public User(UserRights userRights) => Rights = userRights;
    }
}