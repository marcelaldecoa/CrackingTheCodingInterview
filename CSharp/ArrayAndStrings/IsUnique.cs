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
        public static void Run(){

            var content = new char[256];
            for (int i = 0; i < 256; i++) {
                content[i] = (char)i;
            }

            //Prepare input
            var input = new String(content);


            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
 
            for (int i = 0; i < 100; i++) {
               var isUnique = BruteForce(input);                 
            }
          
            watch.Stop();            
            Console.WriteLine($"BruteForce - Elapsed Time: { watch.Elapsed}");
            
            
            watch = System.Diagnostics.Stopwatch.StartNew();  
            
            for (int i = 0; i < 100; i++) {                
                Optimized(input);
            }
            
            watch.Stop();
            Console.WriteLine($"Optimized - Elapsed Time: { watch.Elapsed}");
        }


        //Target Time Complexity: O(n log n)
        //Time Complexity: ????
        static bool Optimized(string input){
            
            System.Collections.BitArray bitArray = new System.Collections.BitArray(256);
            bitArray.SetAll(false);
    
            for (int i = 0; i < input.Length; i++) {
                var charInt = (int)input[i];

                if(charInt > 255 || bitArray.Get(charInt)) {
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
