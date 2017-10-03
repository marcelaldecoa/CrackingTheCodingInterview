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
            
           System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(BruteForce("a", "a"));           
           watch.Stop();
           Console.WriteLine($"{1} - {watch.Elapsed}");

           watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(BruteForce("ab", "ba"));           
           watch.Stop();
           Console.WriteLine($"{2} - {watch.Elapsed}");
           
           watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(BruteForce("abcd", "cdba"));           
           watch.Stop();
           Console.WriteLine($"{4} - {watch.Elapsed}");

           watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(BruteForce("abcdefgh", "efcdbagh"));           
           watch.Stop();
           Console.WriteLine($"{8} - {watch.Elapsed}");

           watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(BruteForce("abcdefghijklmnop", "emifcdnbjaoglhkp"));          
           watch.Stop();
           Console.WriteLine($"{16} - {watch.Elapsed}");

           watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(BruteForce("abcdefghijklmnoprstuvwxyzabcdefg", "ermabscditfeufcgwdzxnybjavoglhkp"));           
           watch.Stop();
           Console.WriteLine($"{32} - {watch.Elapsed}");   

            watch = System.Diagnostics.Stopwatch.StartNew();
            Console.WriteLine(BruteForce("abcdefghijklmnoprstuvwxyzabcdefgabcdefghijklmnoprstuvwxyzabcdefg", "ermabscditfeufcgwdzxnybjavoglhkpermabscditfeufcgwdzxnybjavoglhkp"));           
           watch.Stop();
           Console.WriteLine($"{64} - {watch.Elapsed}");          
           
           
        }

        //Target Time Complexity:
        //Time Complexity: 
        static bool Optimized(string input){
            throw new NotImplementedException();
        }

        //Time Complexity: 
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