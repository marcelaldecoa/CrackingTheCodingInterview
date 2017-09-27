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
            //Prepare input
            var inputSize = 256;
            var input = new char[inputSize];

            for (int i=0; i < inputSize; i++) {
                input[i] = (char)i;    
            }


            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
 
            Optimized(new String(input));
            watch.Stop();
            Console.WriteLine($"Elapsed Time: { watch.Elapsed}");
            
            watch = System.Diagnostics.Stopwatch.StartNew();  
            BruteForce(new String(input)); 
            watch.Stop();
            Console.WriteLine($"Elapsed Time: { watch.Elapsed}");
        }


        //Target Time Complexity: O(n log n)
        //Time Complexity: ????
        static void Optimized(string input){
            
            System.Collections.Hashtable characterMap = new System.Collections.Hashtable();
           
            //Para cada caracter da string exceto o primeiro caracter
            for (int i = 0; i < input.Length; i++) {
                characterMap[input[i]] = 1;
            }

            bool isUnique = input.Length == characterMap.Count;
            
            Console.WriteLine($"Optimized - The text has unique characteres: {isUnique}");
        }

        //Time Complexity: O(n^2)
        static void BruteForce(string input){
            bool isUnique = true;
            //Para cada caracter da string
            for (int outer = 0; outer < input.Length; outer++) {

                int inner = outer + 1;

                //Percorre todos os outros caracteres para verificar se é unico
                while (inner < input.Length) {
                    if(input[outer] == input[inner]) {
                        isUnique = false;
                        break;
                    }

                    inner++;
                }                            

                if(!isUnique){
                    break;
                }
            }

            Console.WriteLine($"Brute Force - The text has unique characteres: {isUnique}");
        }
    }
}
