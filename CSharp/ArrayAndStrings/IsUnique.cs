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
            var input ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam faucibus lectus eros, sit amet facilisis nibh tempor vulputate. Fusce scelerisque pharetra risus, non varius ante mollis non. Nam turpis mauris, vehicula quis rhoncus sit amet, egestas efficitur leo. Donec eget leo laoreet turpis duis. ";


            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
 
          
            var  isUnique = BruteForce(input);
            watch.Stop();
            Console.WriteLine($"Brute Force - The text has unique characteres: {isUnique}");
            Console.WriteLine($"Elapsed Time: { watch.Elapsed}");
            
            watch = System.Diagnostics.Stopwatch.StartNew();  

            isUnique = Optimized(input);
            watch.Stop();
            Console.WriteLine($"Optimized - The text has unique characteres: {isUnique}");
            Console.WriteLine($"Elapsed Time: { watch.Elapsed}");
        }


        //Target Time Complexity: O(n log n)
        //Time Complexity: ????
        static bool Optimized(string input){
            
            System.Collections.Hashtable characterMap = new System.Collections.Hashtable();

            for (int i = 0; i < input.Length; i++) {
                characterMap[input[i]] = 1;
            }

           return input.Length == characterMap.Count;
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
