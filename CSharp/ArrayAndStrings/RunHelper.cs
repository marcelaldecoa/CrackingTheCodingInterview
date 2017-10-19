using System;

namespace ArrayAndStrings {

    public static class RunHelper {

       public static void Stress(Action<int> bruteForce, Action<int> optimized, int iterations) {
            double bruteForceTime = 0;
            double optimizedTime = 0;

            if(bruteForce != null) {                
                bruteForceTime = Run(bruteForce, "Brute Force", iterations);
            }

            if(optimized != null) {                
                optimizedTime = Run(optimized, "Optimized", iterations);
            }

            var optimizationDiff = bruteForceTime - optimizedTime;
            var optimizationIndex = (optimizationDiff / bruteForceTime) * 100;

            Console.WriteLine($"Optimization: {(int)optimizationIndex}%");
        }

        private static double Run(Action<int> operation, string name, int iterations) {
            
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
           
            for(int i = 0; i < iterations; i++) {
                operation(i);
            }

            watch.Stop();
            Console.WriteLine($"{name} - {watch.ElapsedTicks / iterations}");
            return (watch.ElapsedTicks * 1.0) / iterations;
        }
    }
}