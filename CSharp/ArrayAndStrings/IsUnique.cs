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
            BruteForce("abcd");            
            Optimized("abcd");
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
            
            Console.WriteLine($"The text {input} has unique characteres: {isUnique}");
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

            Console.WriteLine($"The text {input} has unique characteres: {isUnique}");
        }
    }
}
