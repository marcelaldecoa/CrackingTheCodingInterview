using System;

namespace ArrayAndStrings {

    /***********************************************************************************************
    *  Threre are three types of edits that can be performed on strings: insert a character, remove a character, 
    * or replace a character. Given two strings, write a function to check if they are one edit (or zero edits) away.
    ************************************************************************************************
    * Hints
    *  23 Start with the easy thing. Can you  check each of the conditions separately?
    *  97  What is the relationship between the "insert character" ooption and the "remove character" option? Do these need to be two separate checks?
    *  130 Can you do all three checks in a single pass?
    ***********************************************************************************************/
    public class OneWay {
        public static void Run() {

            //Console.WriteLine(BruteForce("pale", "pavle"));
            var input = "aanxxxaanxxxaanxxxaanxxxqawsqasw";   
            var input2 = input; 
            
            Console.WriteLine(BruteForce("pale", "bake"));
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
            var editType = original.Length - edited.Length;
            var numberOfEdits = 0;

            if(System.Math.Abs(editType) > 1) {
                return false;
            }

            string swap;

            // IF ADD
            if(editType < 0){
                swap = original;
                original = edited;
                edited = swap;
            }
            
            int counter = 0;
            int index = 0;

            while(numberOfEdits <= 1  
                  && counter < original.Length
                  && index < edited.Length) {                

                bool isEqual = original[counter] == edited[index];

                if(!isEqual) {
                    numberOfEdits++;

                    if(editType != 0){
                        index--;
                    }
                }

                index++;
                counter++;                  
            }

            return numberOfEdits <= 1;
        }

        //Target Time Complexity: 
        //Time Complexity: 
        static bool BruteForce(string original, string edited) {
            var sizeDiff = original.Length - edited.Length;
            var numberOfEdits = 0;

            if(System.Math.Abs(sizeDiff) > 1) {
                return false;
            }

            int counter = 0;
            int index = 0;

            while(numberOfEdits <= 1  
                  && counter < original.Length
                  && index < edited.Length) {                

                bool isEqual = original[counter] == edited[index];

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
