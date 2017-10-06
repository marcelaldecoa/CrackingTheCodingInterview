using System;

namespace ArrayAndStrings {

    /***********************************************************************************************
    * Implement an algorithm to determine if a string has all unique characters. What if you cannot
    * use additional data structures?
    ************************************************************************************************
    * Hints
    *  44 Try a hashtable
    *  117 Could a bit vector be useful?
    *  132 Can you solve it in O(N log N) time? What might a solution like that look like?
    ***********************************************************************************************/
    class IsUnique {
        public static void Run() {

            string input = string.Empty;

            for(int ix = 1; ix < 256; ix++) {

                var content = new char[ix];
                for (int i = 0; i < ix; i++) {
                    content[i] = (char)i;
                }
                input = new String(content);
            }
            
            RunHelper.Stress( (i) => BruteForce(input), 
                              (i) => Optimized(input), 
                              100);
        }


        //Target Time Complexity: O(n log n)
        //Time Complexity: O(log N)
        static bool Optimized(string input) {

            System.Collections.BitArray bitArray = new System.Collections.BitArray(256, false);
    
            for (int i = 0; i < input.Length; i++) {
                var charInt = (int)input[i];

                if(charInt >= bitArray.Length || bitArray.Get(charInt)) {
                    return false;
                }

                bitArray.Set(charInt, true);
            }

            return true;
        }

        //Time Complexity: O(n^2)
        static bool BruteForce(string input){
            //Para cada caracter da string
            for (int outer = 0; outer < input.Length; outer++) {

                int inner = outer + 1;

                //Percorre todos os outros caracteres para verificar se é unico
                while (inner < input.Length) {
                    if(input[outer] == input[inner]) {
                        return false;
                    }

                    inner++;
                }        
            }

            return true;
            
        }
    }
}
