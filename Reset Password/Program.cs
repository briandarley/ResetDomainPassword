using System;
using System.DirectoryServices.AccountManagement;

namespace Reset_Password
{
    class Program
    {

        static void Main(string[] args)
        {

            try
            {
                string accountName;
                string password;

                if (args == null || args.Length < 2)
                {
                    Console.WriteLine("Account Name (omit @gotropics.com)?");
                    accountName = Console.ReadLine();
                    Console.WriteLine("Password?");
                    password = Console.ReadLine();
                }
                else
                {
                    accountName = args[0];
                    password = args[1];
                }
                
                if (string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Password is empty");
                    Console.ReadLine();
                    return;
                }
                accountName = accountName + "@gotropics.com";


                using (var ctx = new PrincipalContext(ContextType.Domain))
                {
                    // find a user
                    var user = UserPrincipal.FindByIdentity(ctx, accountName);

                    if (user == null)
                    {
                        Console.WriteLine("User does not exist");
                        return;
                    }

                    user.ChangePassword(password , "MuddButt1");
                    Console.WriteLine("Resetting Password To: " + "MuddButt1");


                    int i;
                    for (i = 1; i < 20; i++)
                    {
                        user.ChangePassword("MuddButt" + i, "MuddButt" + (i + 1));
                        Console.WriteLine("Resetting Password To: " + "MuddButt" + (i + 1));

                    }

                    user.ChangePassword("MuddButt" + i, password);
                    Console.WriteLine("Password is now reset to " + password);


                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

            Console.ReadLine();
        }
    }
}
