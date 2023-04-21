int numChoice = 0;
string[] uNameArray = new string[100];
string[] pwArray = new string[100];
string uName;
string pwInput;
string requiredPw;
string numLetterPw;
string numSymPw;
string symLetterPw;
string numLetterSymPw;
string file = "../../../accounts.txt";
char menuChoice = 'D';



while (menuChoice > 'C' || menuChoice < 'A')
{
    Console.WriteLine("Choose from the following:" +
        "\nA. Log in" +
        "\nB. Register" +
        "\nC. Exit");
    string rawMenuChoice = Console.ReadLine();
    if (rawMenuChoice.Length != 1)
    {
        Console.WriteLine("Invalid choice.  Please choose A,B or C");
    }
    else
    {
        menuChoice = rawMenuChoice.ToUpper().ToCharArray()[0];
        if (menuChoice > 'C' || menuChoice < 'A')
        {
            Console.WriteLine("Invalid choice.  Please choose A,B or C.");
        }
    }

}



if (menuChoice == 'A')
{
    bool uNameIsValid = false;
    bool pwIsValid = false;
    do
    {
        //ReadFile(file);
        int indexFound;
        do
        {
            ReadFile(file);

            Console.WriteLine("Please enter your username:");
            uName = Console.ReadLine();
            indexFound = Array.IndexOf(uNameArray, uName);

            if (indexFound < 0)
            {
                Console.WriteLine("Invalid username");
            }
            else
            {
                uNameIsValid = true;
                string pwRequired = pwArray[indexFound];
                do
                {
                    Console.WriteLine("Please enter password");
                    pwInput = Console.ReadLine();
                    if (pwInput == pwRequired)
                    {
                        pwIsValid = true;
                    }
                    else if (pwInput != pwRequired)
                    {
                        Console.WriteLine("Invalid Password");
                    }
                } while (!pwIsValid);


            }


        }
        while (indexFound < 0);


        //if (testname == "user")
        //{
        //    uNameIsValid = true;
        //}



        if (!uNameIsValid || !pwIsValid)
        {
            Console.WriteLine("Username and/or password are invalid.");
            uNameIsValid = false;// reset all values to false
            pwIsValid = false;// reset all values to false
            continue;
        }

    }
    while (!uNameIsValid || !pwIsValid);

    if (uNameIsValid && pwIsValid)
    {
        numChoice = 0;
        do
        {
            Console.WriteLine("You are logged in. Choose one of the following options:" +
            "\n1.View accounts" +
            "\n2. Exit");
            numChoice = NumValidator(Console.ReadLine());

            if (numChoice == 1)
            {
                // Console.WriteLine(ReadOrganisedFile(file));
                Console.WriteLine("These are the users in your application");
                ////foreach (string username in uNameArray) // turn this into a forloop***********************************************************************
                //// {
                ////     Console.WriteLine("{0}", username);
                //// }
                for (int i = 0; i < uNameArray.Length; i++)
                {
                    Console.WriteLine($"{uNameArray[i]}\t \t{pwArray[i]}");
                }

            }
            else if (numChoice == 2)
            {
                Console.WriteLine("Use Exit Method. You've chosen to exit. See you again.");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
        while (numChoice <= 0 || numChoice > 2);



    }

}
else if (menuChoice == 'B')// Register
{
    int indexFound;
    do
    {
        ReadFile(file);

        Console.WriteLine("Please create a unique username to register for an account");
        uName = Console.ReadLine();
        indexFound = Array.IndexOf(uNameArray, uName);

        if (indexFound < 0)
        {

            WriteTextData(file, uName);
            do
            {
                Console.WriteLine("Select" +
                "\n1 to create your own password or " +
                "\n2 to generate a password with NUMBERS and LETTERS or " +
                "\n3 to generate a password with NUMBERS and SYMBOLS or " +
                "\n4 to generate a password with LETTERS and SYMBOLS or " +
                "\n5 to generate a password with LETTERS, SYMBOLS and NUMBERS");
                numChoice = NumValidator(Console.ReadLine());

                if (numChoice == 1)
                {
                    Console.WriteLine("Please type a password");
                    string newPw = Console.ReadLine();
                    WritePw(file, newPw);
                }
                else if (numChoice == 2)// NUMBERS and LETTERS
                {
                    Console.WriteLine("How long would you like your password to be?");
                    int length = int.Parse(Console.ReadLine());
                    NumLettersGen(length);//random numbers and letters method to return a string
                    Console.Write($"Generated password: {numLetterPw}");
                    string newPw = numLetterPw;
                    WritePw(file, newPw);
                }
                else if (numChoice == 3)// NUMBERS and SYMBOLS 
                {
                    Console.WriteLine("How long would you like your password to be?");
                    int length = int.Parse(Console.ReadLine());
                    NumSymGen(length);//random numbers and symbols method to return a string
                    Console.Write($"Generated password: {numSymPw}");
                    string newPw = numSymPw;
                    WritePw(file, newPw);
                }
                else if (numChoice == 4) //LETTERS and SYMBOL
                {
                    Console.WriteLine("How long would you like your password to be?");
                    int length = int.Parse(Console.ReadLine());
                    SymLettersGen(length);//random numbers and letters method to return a string
                    Console.Write($"Generated password: {symLetterPw}");
                    string newPw = symLetterPw;
                    WritePw(file, newPw);
                }
                else if (numChoice == 5) //LETTERS, SYMBOLS and NUMBERS
                {
                    Console.WriteLine("How long would you like your password to be?");
                    int length = int.Parse(Console.ReadLine());
                    NumLettersSymGen(length);//random numbers and letters method to return a string
                    Console.Write($"Generated password: {numLetterSymPw}");
                    string newPw = numLetterSymPw;
                    WritePw(file, newPw);
                }
                else if (numChoice > 5 || numChoice < 1)
                {
                    Console.WriteLine("You've entered an invalid option");
                }

            } while (numChoice > 5 || numChoice < 1);



        }
        else
        {
            Console.WriteLine("Username has been taken");

        }


    }
    while (indexFound >= 0);


}
else if (menuChoice == 'C')// exit
{
    Console.WriteLine("Use Exit Method. You've chosen to exit. See you again.");
    Thread.Sleep(2000);
    Environment.Exit(0);
}



//METHODS***********

//method takes a string input, tries to parse it as an integer and if it is valid(true), outputs an int called numChoice.
int NumValidator(string input) //method takes a string input, tries to parse it as an integer and if it is valid(true), outputs an int called numChoice.
{
    try
    {
        bool isNum = int.TryParse(input, out int numChoice);
        return numChoice;
    }
    catch
    {
        return 0;
    }

}

//method that reads the entire contents of a file and splits it into a username array and a pw array
void ReadFile(string file) //  turn this into a void method
{
    try
    {
        string credentialsAll = "";// string contains entire file of credentials separated by spaces (declare it where we're using it if we're not using it elsewhere)
        StreamReader reader = new StreamReader(file);
        while (!reader.EndOfStream)
        {

            if (credentialsAll != "")
            {
                credentialsAll += " ";// credentialsAll = credentialsAll + " "
            }
            credentialsAll += reader.ReadLine();
            //            credentialsAll = credentialsAll + reader.ReadLine() + " ";

        }
        reader.Close();
        string[] credentialsArray = credentialsAll.Split(' ');
        int i = 0;
        uNameArray = new string[credentialsArray.Length];
        pwArray = new string[credentialsArray.Length];
        while (i < (credentialsArray.Length / 2))
        {
            uNameArray[i] = credentialsArray[i * 2];
            pwArray[i] = credentialsArray[(i * 2) + 1];
            i++;
        }

    }
    catch (Exception e)
    {
        Console.WriteLine("ERROR: " + e.Message);
    }
}



string FindReqPW() //************NEEDS  FIXING
{

    //Console.WriteLine("Enter username");
    uName = Console.ReadLine();
    int indexFound;
    try // just check for -1. if user doesn't exist, return null
    {
        indexFound = Array.IndexOf(uNameArray, uName);
        requiredPw = pwArray[indexFound];
        return requiredPw;
    }
    catch
    {
        return "User not found, please try again";
    }
}

bool CheckPw(string input)
{
    pwInput = Console.ReadLine();
    if (pwInput == requiredPw)
    {
        return true;
    }
    else
    {
        return false;
    }
}


void WriteTextData(string file, string content)
{
    try
    {
        StreamWriter writer = new StreamWriter(file, true);
        writer.Write(content);
        writer.Close();
    }
    catch
    {
        Console.WriteLine("Error");
    }
}

//EnterPWCheck() takes string as input, then checks against rules and outputs bool TRUE if rules are followed
//GeneratePW() no input, random gen, output string

void WritePw(string file, string newPw)
{
    try
    {
        StreamWriter writer = new StreamWriter(file, true);
        writer.WriteLine(" " + newPw);
        writer.Close();
    }
    catch
    {
        Console.WriteLine("Error");
    }
}

string NumLettersGen(int length = 10)
{
    string[] ofNumAndLetters = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    Random r = new Random();
    int j;
    int i = 0;
    numLetterPw = "";
    while (i < length)
    {
        j = r.Next(0, ofNumAndLetters.Length);
        numLetterPw += ofNumAndLetters[j];
        i++;
    }

    return $"{numLetterPw}";


}

string NumSymGen(int length = 10)
{
    string[] ofNumAndSym = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "=", "_", "+", "?" };
    Random r = new Random();
    int j;
    int i = 0;
    numSymPw = "";
    while (i < length)
    {
        j = r.Next(0, ofNumAndSym.Length);
        numSymPw += ofNumAndSym[j];
        i++;
    }

    return $"{numSymPw}";


}

string SymLettersGen(int length = 10)
{
    string[] ofSymAndLetters = new string[] { "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "=", "_", "+", "?", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    Random r = new Random();
    int j;
    int i = 0;
    symLetterPw = "";
    while (i < length)
    {
        j = r.Next(0, ofSymAndLetters.Length);
        symLetterPw += ofSymAndLetters[j];
        i++;
    }

    return $"{symLetterPw}";


}

string NumLettersSymGen(int length = 10)
{
    string[] ofNumAndLettersSym = new string[] { "~", "`", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "=", "_", "+", "?", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    Random r = new Random();
    int j;
    int i = 0;
    numLetterSymPw = "";
    while (i < length)
    {
        j = r.Next(0, ofNumAndLettersSym.Length);
        numLetterSymPw += ofNumAndLettersSym[j];
        i++;
    }

    return $"{numLetterSymPw}";

}