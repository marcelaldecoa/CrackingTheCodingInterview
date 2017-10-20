using System;
using System.Linq;

namespace ArrayAndStrings {

    /***********************************************************************************************
    *  Palindrome Permutation: Given a string, write a function to check if 
    * it is a permutation of a palin­drome. A palindrome is a word or phrase 
    * that is the same forwards and backwards. A permutation is a 
    * rearrangement of letters. The palindrome does not need to be limited to
    * just dictionary words.  
    
    EXAMPLE 
        Input: Tact Coa 
        Output: True (permutations: "taco cat", "atcocta", etc.)
    ************************************************************************************************
    * Hints
    *  106 You do not have to - and should not - generate all permutations. This would be very inefficient
    *  121 What characteristics would a string that is a permutation of a palindrome have?
    *  134 Have you tried a hash table? you should be able to get this down to O(N) time
    *  136 Can you reduce the space usage by using a bit vector
    ***********************************************************************************************/
    public class PalindromePermutation {
        public static void Run() {

            
            Console.WriteLine("--------------------------------- 4.PalindromePermutation -------------------------------------------");

            var input = "aanxxx naa aanxxx naa aanxxx naa aanxxx naa aanxxx naa"; 
            
            Console.WriteLine($"Input Size: {input.Length}");          
            RunHelper.Stress( (i) => BruteForce(input), 
                              (i) => Optimized(input), 
                              100);

            input += input;           
            Console.WriteLine($"Input Size: {input.Length}");          
            RunHelper.Stress( (i) => BruteForce(input), 
                              (i) => Optimized(input), 
                              100);

            input += input;                 
            Console.WriteLine($"Input Size: {input.Length}");          
            RunHelper.Stress( (i) => BruteForce(input), 
                              (i) => Optimized(input), 
                              100);

            input += input;                  
            Console.WriteLine($"Input Size: {input.Length}");          
            RunHelper.Stress( (i) => BruteForce(input), 
                              (i) => Optimized(input), 
                              100);
            input += input;                  
            Console.WriteLine($"Input Size: {input.Length}");          
            RunHelper.Stress( (i) => BruteForce(input), 
                              (i) => Optimized(input), 
                              100);

            input += input;                  
            Console.WriteLine($"Input Size: {input.Length}");          
            RunHelper.Stress( (i) => BruteForce(input), 
                              (i) => Optimized(input), 
                              100);

            input += input;                  
            Console.WriteLine($"Input Size: {input.Length}");          
            RunHelper.Stress( (i) => BruteForce(input), 
                              (i) => Optimized(input), 
                              100);

            input += input;                  
            Console.WriteLine($"Input Size: {input.Length}");          
            RunHelper.Stress( (i) => BruteForce(input), 
                              (i) => Optimized(input), 
                              100);
        }


        static bool Optimized(string input) {
             input = input.ToLower();

            int[] arrayx = new int[256];
            int spaces = 0;

            for (int i = 0; i < input.Length; i++) {
                if (input[i] != 32) {
                    arrayx[input[i]]++;
                }
                else{
                    spaces++;
                }
            }

             bool even = (input.Length - spaces) % 2 == 0;
            
            for (int i = 0; i < arrayx.Length; i++) {
                if (arrayx[i] != 0){
                    if(arrayx[i] == 1 && even) {
                        return false;
                    }
                }
            }

            return true;
        }

        //Target Time Complexity: 
        //Time Complexity: 
        static bool BruteForce(string input) {

            input = input.ToLower();

            int[,] arrayx = new int[256,1]; //Size = (256*32)*2
            int spaces = 0;

            for (int i = 0; i < input.Length; i++) {
                if (input[i] != 32) {
                    arrayx[input[i], 0]++;
                }
                else{
                    spaces++;
                }
            }

             bool even = (input.Length - spaces) % 2 == 0;
            
            for (int i = 0; i < arrayx.Length; i++) {
                if (arrayx[i,0] != 0){
                    if(arrayx[i,0] == 1 && even) {
                        return false;
                    }
                }
            }

            return true; 
        }
    }
}
