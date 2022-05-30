using System;
using System.Collections.Generic;
using System.Linq;

namespace JustifiedPrint
{
    //Author: Kevin Wennes
    class Program
    {
        static void Main(string[] args)
        {
            var baseString = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.";
            var lineLimit = 30;
            var result = "";

            var allWords = baseString.Split(' ');

            var lineLength = 0;
            var wordsInLine = new List<string>();

            for (var i = 0; i < allWords.Count(); i++)
            {
                //+1 accounts for appended spaces
                if (lineLength + allWords[i].Length + 1 <= lineLimit + 1)
                {
                    lineLength += allWords[i].Length + 1;
                    wordsInLine.Add(allWords[i]);
                }
                else
                {
                    result += AddSpaces(lineLimit, wordsInLine, lineLength);

                    i--;
                    wordsInLine = new List<string>();
                    lineLength = 0;
                }
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static string AddSpaces(int lineLimit, List<string> wordsInLine, int lineLength)
        {
            var result = "";
            var wordsCharCount = lineLength - wordsInLine.Count();
            var counter = 0;
            var spaceLength = wordsInLine.Count() - 1;
            var lineSpaces = Enumerable.Range(0, wordsInLine.Count() - 1).Select(s => " ").ToList();

            while (spaceLength + wordsCharCount <= lineLimit)
            {
                lineSpaces[counter] += " ";
                counter = counter == lineSpaces.Count() - 1 ? 0 : counter + 1;

                spaceLength += 1;
            }

            for (var j = 0; j < lineSpaces.Count(); j++)
            {
                result += wordsInLine[j] + lineSpaces[j];
            }

            result += wordsInLine.Last() + "\n";
            return result;
        }
    }
}
