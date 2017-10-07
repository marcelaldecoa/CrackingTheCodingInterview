using System;
using System.Linq;

namespace ArrayAndStrings {

    /***********************************************************************************************
    *  
    ************************************************************************************************
    * Hints
    *  23 
    *  97 
    *  130
    ***********************************************************************************************/
    public class OneWay {
        public static void Run() {

            //Console.WriteLine(BruteForce("pale", "pavle"));
            var input = "aanxxxaanxxxaanxxxaanxxxqawsqasw";   
            var input2 = input; 
            
            Console.WriteLine(BruteForce("pale", "paale"));
            Console.WriteLine(input.Length);  
            RunHelper.Stress( (i) => BruteForce(input, input2), 
                              null, 
                              1000); 

            input = "aanxxxaanxxxaanxxxaanxxxqawsqaswaanxxxaanxxxaanxxxaanxxxqawsqasw";   
            input2 = input; 
            Console.WriteLine(input.Length);          
            RunHelper.Stress( (i) => BruteForce(input, input2), 
                              null, 
                              1000);

            input = "aanxxxaanxxxaanxxxaanxxxqawsqaswaanxxxaanxxxaanxxxaanxxxqawsqaswaanxxxaanxxxaanxxxaanxxxqawsqaswaanxxxaanxxxaanxxxaanxxxqawsqasw";   
            input2 = input; 
            Console.WriteLine(input.Length);          
            RunHelper.Stress( (i) => BruteForce(input, input2), 
                              null, 
                              1000);

            input = "aanxxxaanxxxaanxxxaanxxxqawsqaswaanxxxaanxxxaanxxxaanxxxqawsqaswaanxxxaanxxxaanxxxaanxxxqawsqaswaanxxxaanxxxaanxxxaanxxxqawsqaswaanxxxaanxxxaanxxxaanxxxqawsqaswaanxxxaanxxxaanxxxaanxxxqawsqaswaanxxxaanxxxaanxxxaanxxxqawsqaswaanxxxaanxxxaanxxxaanxxxqawsqasw";   
            input2 = input; 
            Console.WriteLine(input.Length);          
            RunHelper.Stress( (i) => BruteForce(input, input2), 
                              null,
                              1000);
        }


        //Target Time Complexity: 
        //Time Complexity: 
        static bool Optimized(string input, string input2) {
            throw new NotImplementedException();
        }

        //Target Time Complexity: 
        //Time Complexity: 
        static bool BruteForce(string input, string input2) {
            var sizeDiff = input.Length - input2.Length;
            var numberOfEdits = 0;

            if(System.Math.Abs(sizeDiff) > 1) {
                return false;
            }

            int counter = 0;
            var index = 0;

            while(numberOfEdits <= 1  
                  && counter < input.Length
                  && index < input2.Length) {                

                bool isEqual = input[counter] == input2[index];

                if(!isEqual) {
                    numberOfEdits++;

                    if(sizeDiff == -1) {
                      counter--;
                    } else if(sizeDiff == 1) {
                        index--;
                    }
                }

                index++;
                counter++;                  
            }

            return numberOfEdits <= 1; 
        }
    }
}
