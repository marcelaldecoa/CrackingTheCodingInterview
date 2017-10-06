using System;
using System.Linq;

namespace ArrayAndStrings {

    /***********************************************************************************************
    * Given two strings, write a method to decide if one is a permutation of the other
    ************************************************************************************************
    * Hints
    *  1 Describe what it means for two strings to be permutation of each other.
        Now, look at that definition you provide. Can you check the strings against that definition?
    *  84 There is one solution that is O (N log N) time. Another solution uses some space, but is O(N) time
    *  122 Could a hash table be useful
    *  131 Two strings that are permutations should have the same characters, but in different orders.
        Can you make the orders the same?
    ***********************************************************************************************/
    class CheckPermutation {
        public static void Run() {

            Console.WriteLine("Input size = 1");
            RunHelper.Stress( (i) => BruteForce("a", "a"),
                              (i) => Optimized("a", "a"),
                              100);

            Console.WriteLine("Input size = 2");
            RunHelper.Stress( (i) => BruteForce("ab", "ba"),
                              (i) => Optimized("ab", "ba"),
                              100);

            Console.WriteLine("Input size = 4");
            RunHelper.Stress( (i) => BruteForce("abcd", "cdba"),
                              (i) => Optimized("abcd", "cdba"),
                              100);

            Console.WriteLine("Input size = 8");
            RunHelper.Stress( (i) => BruteForce("abcdefgh", "efcdbagh"),
                              (i) => Optimized("abcdefgh", "efcdbagh"),
                              100);

            Console.WriteLine("Input size = 16");
            RunHelper.Stress( (i) => BruteForce("abcdefghijklmnop", "emifcdnbjaoglhkp"),
                              (i) => Optimized("abcdefghijklmnop", "emifcdnbjaoglhkp"),
                              100);

            Console.WriteLine("Input size = 32");
            RunHelper.Stress( (i) => BruteForce("abcdefghijklmnoprstuvwxyzabcdefg", "ermabscditfeufcgwdzxnybjavoglhkp"),
                              (i) => Optimized("abcdefghijklmnoprstuvwxyzabcdefg", "ermabscditfeufcgwdzxnybjavoglhkp"),
                              100);

            Console.WriteLine("Input size = 64");
            RunHelper.Stress( (i) => BruteForce("abcdefghijklmnoprstuvwxyzabcdefgabcdefghijklmnoprstuvwxyzabcdefg", "ermabscditfeufcgwdzxnybjavoglhkpermabscditfeufcgwdzxnybjavoglhkp"),
                              (i) => Optimized("abcdefghijklmnoprstuvwxyzabcdefgabcdefghijklmnoprstuvwxyzabcdefg", "ermabscditfeufcgwdzxnybjavoglhkpermabscditfeufcgwdzxnybjavoglhkp"),
                              100);
                              
            Console.WriteLine("Input size = 128");
            RunHelper.Stress( (i) => BruteForce("abcdefghijklmnoprstuvwxyzabcdefgabcdefghijklmnoprstuvwxyzabcdefgabcdefghijklmnoprstuvwxyzabcdefgabcdefghijklmnoprstuvwxyzabcdefg", "ermabscditfeufcgwdzxnybjavoglhkpermabscditfeufcgwdzxnybjavoglhkpermabscditfeufcgwdzxnybjavoglhkpermabscditfeufcgwdzxnybjavoglhkp"),
                              (i) => Optimized("abcdefghijklmnoprstuvwxyzabcdefgabcdefghijklmnoprstuvwxyzabcdefgabcdefghijklmnoprstuvwxyzabcdefgabcdefghijklmnoprstuvwxyzabcdefg", "ermabscditfeufcgwdzxnybjavoglhkpermabscditfeufcgwdzxnybjavoglhkpermabscditfeufcgwdzxnybjavoglhkpermabscditfeufcgwdzxnybjavoglhkp"),
                              100);

           
        }

        //Target Time Complexity:
        //Time Complexity: 
        static bool Optimized(string input, string input2) {

            if (input.Length != input2.Length)
                return false;

            int[,] arrayx = new int[256,1];

            for (int i = 0; i < input.Length; i++) {
                 arrayx[input[i], 0] += 1;
            }

            for (int i = 0; i < input2.Length; i++) {
                 arrayx[input2[i], 0] -= 1;

                 if(arrayx[i, 0] < 0) {
                     return false;
                 }
            }    

            return true;
        }

        //Time Complexity: O(n^2)
        static bool BruteForce(string input, string input2){

             if(input.Length != input2.Length) {
                return false;
            }

            System.Collections.Generic.List<char> input2Array = input2.ToList();
            bool isPermutation = true;

            for (int i = 0; i < input.Length; i++) {
                
                int indexOf = -1;

                for (int i2 = 0; i2 < input2Array.Count; i2++) {
                    if(input2Array[i2].Equals(input[i])) {
                        indexOf = i2;
                        break;
                    }
                }

                if(indexOf >= 0) {
                    input2Array.RemoveAt(indexOf);
                } else {
                    isPermutation = false;
                    break;
                }                
            }

            return isPermutation;
        }
    }
}
