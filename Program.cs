using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace IDParser
{
    class Program
    {
        static void Main(string[] args)
        {
            const string textMarker = "|11=";
            Random random = new Random();
            
            //Check if file exists
            if (!File.Exists(args[0]))
                {
                    Console.WriteLine(args[0] + " does not exist");
                    return;
                }

            //check if file is empty
            if (new FileInfo(args[0]).Length == 0)
            {
                Console.WriteLine(args[0] + " is empty");
                return;
            }

         
            //main functionality starts here 
            using (StreamReader reader = new StreamReader(args[0]))
            using (StreamWriter writer = new StreamWriter(args[1]))
            {
                    while (!reader.EndOfStream)
                {
                    string lineComingIn = reader.ReadLine();
                    string lineGoingOut = lineComingIn;
                    if (lineComingIn.Contains(textMarker))
                    {
                        int markerIndex = lineComingIn.IndexOf(textMarker) + textMarker.Length;
                        int counter = 0;
                        char isThisEnd = ' ';
                        while (!isThisEnd.Equals('|'))
                        {
                            counter++;
                            isThisEnd = lineComingIn[markerIndex + counter];
                        }
                        int newNumber = random.Next();

                        string lineModifying = lineComingIn.Remove(markerIndex, counter);
                        lineGoingOut = lineModifying.Insert(markerIndex, newNumber.ToString());
                    }

                    writer.WriteLine(lineGoingOut);
                    }
            }    
        }
    }
}
