using System;
using System.Linq;

namespace ArrayAndStrings {

    /***********************************************************************************************
    * 
    ************************************************************************************************
    * Hints
    ***********************************************************************************************/
    class StringComparison {
        public static void Run() {

            
            Console.WriteLine("--------------------------------- 6.StringComparison -------------------------------------------");

            var shoudCompress = "aaaabbbbbccccaaa";            
            var shouldNotCompress = "aaaabca";
            
        //     Console.WriteLine("Brute Force:");
        //    Console.WriteLine($"Compressed : {BruteForce(shoudCompress) != shoudCompress}");            
        //    Console.WriteLine($"Compressed : {BruteForce(shouldNotCompress) != shouldNotCompress}");           
            
        //     Console.WriteLine("Optimized:");
        //    Console.WriteLine($"Compressed : {Optimized(shoudCompress) != shoudCompress}");            
        //    Console.WriteLine($"Compressed : {Optimized(shouldNotCompress) != shouldNotCompress}");



            Console.WriteLine($"Input size = {shouldNotCompress.Length}");
            RunHelper.Stress( (i) => BruteForce(shouldNotCompress),
                              (i) => Optimized(shouldNotCompress),
                              100);

            Console.WriteLine($"Input size = {shoudCompress.Length}");
            RunHelper.Stress( (i) => BruteForce(shoudCompress),
                              (i) => Optimized(shoudCompress),
                              100);
            
            var input = "aaaaaaaaaaabcdefghijklmnooooooooooooooooprstuvwxyzabcdeffffffffgabccccccdefghijklmnoprstuvwwwwwwwwwwwwwwwwwxyzabcdeffffffffffffffffffgabcdeeeeefghijklmnoprstuwwwwvwwwwwwwwwwxyzabcdefgabcdefghijklmnoprstuvwxyzabcdefg";            
            Console.WriteLine($"Input size = {input.Length}");
            RunHelper.Stress( (i) => BruteForce(input),
                              (i) => Optimized(input),
                              100);
           
            input = "aaaaaaaaaaabcfffffffffffffffffffffffffflllllllllllllllllllllllllllllllllllllrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrraaaaaaaaaaaaaaaaaaaaaannnnnnnnnnnnnnnnnnnVVVVVVVVVVVVVVVVVVVVVVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEeeeudsjsndlsnffsdjkfjkdsfkfnfdkffnskjfnvnnjjfnpfnnnnnnnnnnneiijrewnrmwnrmfkjfksjfksnfjnfjfjksjkfdskjkfjskjfkssjjjjjjjjjjdefghijklmnooooooooooooooooprstuvwxyzabcdeffffffffgabccccccdefghijklmnoprstuvwwwwwwwwwwwwwwwwwxyzabcdeffffffffffffffffffgabcdeeeeefghijklmnoprstuwwwwvwwwwwwwwwwxyzabcdefgabcdefghijklmnoprstuvwxyzabcdefg";            
            input += input += input += input;
            Console.WriteLine($"Input size = {input.Length}");
            RunHelper.Stress( (i) => BruteForce(input),
                              (i) => Optimized(input),
                              100);

            input += input += input += input;
            Console.WriteLine($"Input size = {input.Length}");
            RunHelper.Stress( (i) => BruteForce(input),
                              (i) => Optimized(input),
                              100);
           
        }

        //Target Time Complexity:
        //Time Complexity: 
        static string BruteForce(string input) {
            int index = 1;
            var currentChar = input[index];
            int qty = 1;
            string compressed = "";
            while(index < input.Length){

                if(currentChar == input[index])
                {
                    qty++;
                }
                else{
                    compressed = compressed + currentChar + qty;
                    qty=1;
                }

                currentChar = input[index];
                index++;
            }

            compressed = compressed + currentChar + qty;
            compressed = compressed.Length > input.Length ? input : compressed;

            // Console.WriteLine($"Input: {input}");
            // Console.WriteLine($"Compressed: {compressed}");

            return compressed;
        }

        static string Optimized(string input) {
            int index = 1;
            int qty = 1;

            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            while(index < input.Length){

                if(input[index-1] == input[index]) {
                    qty++;
                }
                else {
                    builder.Append(input[index-1]);
                    builder.Append(qty);
                    qty=1;
                }

                index++;
            }

            builder.Append(input[index-1]);
            builder.Append(qty);

            var compressed = builder.ToString();
            compressed = compressed.Length > input.Length ? input : compressed;

            // Console.WriteLine($"Input: {input}");
            // Console.WriteLine($"Compressed: {compressed}");

            return compressed;
        }
    }
}
