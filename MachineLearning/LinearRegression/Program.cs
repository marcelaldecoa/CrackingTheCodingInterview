using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] dataSetThreeSum = GetThreeSumDataSet();
            double[,] dataSetThreeSumDeluxe = GetThreeSumDataSetDeluxe();
            double[,] dataSetSampleBruteForce = GetSampleBruteForce();
            double[,] dataSetSampleOptimized = GetSampleOptimized();

            // Apply Log-Log
            LogLog(ref dataSetThreeSum);
            LogLog(ref dataSetThreeSumDeluxe);
            LogLog(ref dataSetSampleBruteForce);
            LogLog(ref dataSetSampleOptimized);

            // Find coefficients
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Training coefficients for ThreeSum dataset...");
            Console.ForegroundColor = ConsoleColor.White;
            StochasticGradientDescent(dataSetThreeSum);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Training coefficients for ThreeSumDeluxe dataset...");
            Console.ForegroundColor = ConsoleColor.White;
            StochasticGradientDescent(dataSetThreeSumDeluxe);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Training coefficients for SampleBruteForce dataset...");
            Console.ForegroundColor = ConsoleColor.White;
            StochasticGradientDescent(dataSetSampleBruteForce);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Training coefficients for SampleOptimized dataset...");
            Console.ForegroundColor = ConsoleColor.White;
            StochasticGradientDescent(dataSetSampleOptimized);
            Console.WriteLine();

            Console.ReadKey();

        }

        static void StochasticGradientDescent(double[,] dataSet)
        {
            double x = 0;
            double y = 0;
            double prediction = 0;
            double error = 0;
            double mse = 0;

            // Number of epochs
            int max_epochs = 50000;

            // Learning rate
            double learning_rate = 0.01;

            // Initialize coefficients
            double m = 0;
            double b = 0;

            for (int epoch = 1; epoch <= max_epochs; epoch++)
            {

                if (epoch % 10000 == 0)
                {
                    mse = GetMSE(dataSet, m, b);
                    Console.Write("epoch = " + epoch);
                    Console.WriteLine("  error = " + mse.ToString("F4"));
                }

                for (int row = 0; row < dataSet.GetLength(0); row++)
                {
                    // Read row
                    x = dataSet[row, 0];
                    y = dataSet[row, 1];

                    prediction = m * x + b;

                    error = prediction - y;

                    m = m - learning_rate * error * x;
                    b = b - learning_rate * error;

                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(String.Format("Final coefficients >> m={0}, b={1}", m, b));

        }

        static double GetMSE(double[,] dataSet, double m, double b)
        {
            double x = 0;
            double y = 0;
            double prediction = 0;
            double sumSquaredError = 0.0;

            for (int row = 0; row < dataSet.GetLength(0); row++)
            {
                // Read row
                x = dataSet[row, 0];
                y = dataSet[row, 1];

                prediction = m * x + b;
                sumSquaredError += (prediction - y) * (prediction - y);

            }
            return sumSquaredError / dataSet.GetLength(0);
        }

        static void LogLog(ref double[,] dataSet)
        {
            for (int row = 0; row < dataSet.GetLength(0); row++)
            {
                dataSet[row, 0] = Math.Log(dataSet[row, 0], 2);
                dataSet[row, 1] = Math.Log(dataSet[row, 1], 2);
            }
        }

        static double[,] GetThreeSumDataSet()
        {
            return new double[,] {
                {1000, 0.1},
                {2000, 0.8},
                {4000, 6.4},
                {8000, 51.1}
            };
        }

        static double[,] GetThreeSumDataSetDeluxe()
        {
            return new double[,] {
                {1000, 0.14},
                {2000, 0.18},
                {4000, 0.34},
                {8000, 0.96},
                {16000, 3.67},
                {32000, 14.88},
                {64000, 59.16},
                {128000, 554.6}
            };
        }

        static double[,] GetSampleBruteForce()
        {
            return new double[,] {
                {4, 7},
                {8, 7},
                {16, 11},
                {32, 41},
                {64, 151},
                {128, 585}
            };
        }

        static double[,] GetSampleOptimized()
        {
            return new double[,] {
                {4, 3},
                {8, 3},
                {16, 3},
                {32, 7},
                {64, 11},
                {128, 22}
            };
        }
    }
}
