using System;

namespace ArrayAndStrings {

    /***********************************************************************************************
    *
    ************************************************************************************************
    * Hints
    ***********************************************************************************************/
    public class StringRotation {
        public static void Run() {

            
            Console.WriteLine("--------------------------------- 9.StringRotation -------------------------------------------");

            var original = "otorrinolaringologista";
            var rotated = "laringologistaotorrino";

            var isRotated = Optimized("otorrinolaringologista", "laringologistaotorrino");
            Console.WriteLine($"The value '{rotated}' { (isRotated ? "IS a rotation" : "IS NOT a rotation")} of '{original}' ");            

            //Stress test
            RunHelper.Stress( null,
                              (i) => Optimized("otorrinolaringologista", "laringologistaotorrino"), 
                              1000000000); 

        }
 
        static bool Optimized(string original, string rotated) {

            if(original.Length != rotated.Length) {
                return false;
            }

            rotated += rotated;
            return IsSubstring(rotated, original);
        }

        private static bool IsSubstring(string input1, string input2){
            return input1.Contains(input2);
        }

    }
}
