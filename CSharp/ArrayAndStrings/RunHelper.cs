using System;

namespace ArrayAndStrings {

    public static class RunHelper {

        public static void Stress(Action<int> bruteForce, Action<int> optimized, int iterations) {
            
            if(bruteForce != null) {                
                Run(bruteForce, "Brute Force", iterations);
            }

            if(optimized != null) {                
                Run(optimized, "Optimized", iterations);
            }
        }

        private static void Run(Action<int> operation, string name, int iterations) {
            
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
           
            for(int i = 0; i < iterations; i++) {
                operation(i);
            }

            watch.Stop();
            Console.WriteLine($"{name} - {watch.Elapsed / iterations}");
        }
    }
}