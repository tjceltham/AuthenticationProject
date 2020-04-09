using System;

namespace AuthenticationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Here we are testing the subroutines/functions before we used them
            // This is one of the advantages of subroutines we can test in isolation
            // We can also reuse them and they are make our code easier to read and maintain
            // JUST LIKE LEGO!!!

            register("Collins", "Hello");
            register("John", "goodbye");
            if (authenticate("John", "Hello") == false)
            {
                Console.WriteLine("Test1 Passed");
            }
            else
            {
                Console.WriteLine("Test 1 Failed");
            }

            if (authenticate("Collins", "goodbye") == false)
            {
                Console.WriteLine("Test 2 Passed");
            }
            else
            {
                Console.WriteLine("Test 2 Failed");
            }



            if (authenticate("Collins", "Hello") == true)
            {
                Console.WriteLine("Test 3 Passed");
            }
            else
            {
                Console.WriteLine("Test 3 Failed");
            }



        }



        static void register(string username, string password)
        {
            System.IO.StreamWriter fw;

            
            try
            {
                // create stream writer in append mode
                fw = new System.IO.StreamWriter("usernameandpassword.csv",true);

                // add username and password to the end of the file using writeline
                fw.WriteLine(username + "," + password);
                // close file
                fw.Close();

            }catch 
            {
                Console.WriteLine("File Handling error-could not open file");

            }



        }

        static bool authenticate(string user, string pass)
        {
            // declare(create) all variables you are going to use in a function/subroutine at the start of the functiion
            // this allows the reader to understand what how your subroutine works and avoids creating variables in loops
            // a big NO NO
            bool validUsernameAndPassword = false;
            System.IO.StreamReader fr;
            string lineOfTheFile;
            try
            {
                // open StreamReader
                fr = new System.IO.StreamReader("usernameandpassword.csv");
                // use while loop to keep reading a line of the file until we reach the end of the file while fr.peek()!=-1
                while (fr.Peek() != -1)
                {
                    // read the next line of the file into lineOfTheFile variable
                    lineOfTheFile = fr.ReadLine();
                // if lineOfFill == user +"," + password password username combination has been found so set valid to true
                    if(lineOfTheFile == user + "," + pass)
                    {
                        validUsernameAndPassword = true;
                    }
                // End While loop
                
                }
                // Close StreamReader
                fr.Close();
            }
            catch
            {
                Console.WriteLine("File Handling Error-Could not open file");

            }


            return validUsernameAndPassword;
        }
    }
}
