// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to the Pig Latin Translator!");
        bool goOn = true;
        do
        {
            Console.WriteLine("Enter a line to be translated:");
            string str = Console.ReadLine();
            if (str != "")
            {
                string[] strArr = str.Split();
                string[] strLatinArr = new string[strArr.Length];
                Console.Write($"{str} become: ");
                for (int i = 0; i < strArr.Length; i++)
                {
                    strLatinArr[i] = LatinWord(strArr[i]);
                    Console.Write(strLatinArr[i]);
                    Console.Write(" ");
                }
                Console.WriteLine();
                goOn = Continue();
            }
            else
            {
                goOn = true;
            }

        } while (goOn == true);

    }

    //method to check if continue to enter.
    public static bool Continue()
    {
        Console.WriteLine("would you like to translate another words? yes/no");
        string a = Console.ReadLine().ToLower();

        if (a == "yes")
        {
            return true;
        }
        else if (a == "no")
        {
            Console.WriteLine("Goodbye!");
            return false;
        }
        else
        {
            Console.WriteLine("Enter wrong.");
            return Continue();
        }
    }
     
    //method to change a string to Latin.
    public static string LatinWord(string str)
    {
        string strLower = str.ToLower();
        string strLatin = "";
        if (StrNoVowel(str) || StrWithNum(str) || StrWithSymbols(str))
        {
            strLatin = str;
            return strLatin;
        }
        else if ("aoeiu".Contains(strLower[0]))
        {
            strLatin = str + "way";
            return strLatin;
        }
     
        else
        {
            for (int i = 1; i < str.Length; i++)
            {
                if ("aoeiu".IndexOf(strLower[i]) >= 0)

                {
                    strLatin = str.Substring(i) + str.Substring(0, i) + "ay";
                    break;
                }
            }
            return strLatin;
        }
    }

    //method to check if a string with vowel.
    public static bool StrNoVowel(string str)
    { 
        for (int i=0;i<str.Length; i++)
        {
            bool vowel = "aoeiu".Contains(str.ToLower()[i]);
            if (vowel)
            {
                return false;
            }
        }
        return true;
    }

    //Method to check if a string with number.
    public static bool StrWithNum(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            bool strWNum = "1234567890".Contains(str[i]);
            if (strWNum)
            {
                return true;
        
            }
        }
        return false;

    }


    //method to check if a string with symbols.
    public static bool StrWithSymbols(string str)
    {
        string sym = "#@&$";
        for (int i = 0; i < str.Length; i++)
        {
            bool withSym = char.IsSymbol(str[i]) || sym.Contains(str[i]);
            if (withSym)
            {
                return true;
            }
          
        }
        return false;
    }

   

}

