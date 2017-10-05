using System;

namespace ArrayAndStrings {

    /***********************************************************************************************
    *  Write a method to replace all spaces in a string with '%20'. 
    *  You may assume that the string has sufficient space at the end to hold the additional characters, 
    *  and that you are given the "true" length of the string. 
    *  
    *  (Note: If implementing in Java, please use a character array so that you can perform this operation in place.) 
    *  EXAMPLE Input:  "Mr John Smith ", 13 
               Output: "Mr%20John%20Smith" 
    ************************************************************************************************
    * Hints
    *  53 It's often easiest to modify strings by going from the end of the string to the beginning
    *  118 You might find you need to know the number of spaces. Can you just count them?
    ***********************************************************************************************/
    class URLify {
        public static void Run() {
           Console.WriteLine(BruteForce("BRUNO OLIVEIRA  ", 14)); 
           Console.WriteLine(BruteForce("BRUNO LINS DE OLIVEIRA      ", 22));
        }


        //Target Time Complexity: 
        //Time Complexity: 
        static bool Optimized(string input) {
            throw new NotImplementedException();            
        }

        //Time Complexity: O (N)
        static string BruteForce(string input, int size){
            char[] output = new char[input.Length];

            int currentPosition = output.Length-1;

            for (int i = size -1; i >= 0; i--)
            {
                if(char.IsWhiteSpace(input[i])){
                    output[currentPosition] = '0';
                    output[currentPosition - 1] = '2';
                    output[currentPosition - 2] = '%';
                    currentPosition = currentPosition - 2;
                } else {
                    output[currentPosition] = input[i];
                }

                currentPosition--;
            }

            return new String(output).TrimStart();
        }
    }
}
