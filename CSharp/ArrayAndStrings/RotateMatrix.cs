using System;
using System.Linq;

namespace ArrayAndStrings {

    /***********************************************************************************************
    * Given an image represented by an NxN matrix, where each pixel in the image is 4 bytes. 
    * Write a method to rotate the image by 90 degrees. 
    * Can you do this in place?
    ************************************************************************************************
    * Hints
    * 51 Try thinking about layer by layer. Can you rotate a specific layer?
    * 100 Rotating a specific layer would just mean swapping the values in four arrays. If you were asked to swap the values
    *     in two arrays, could you do this? Can tou then extend it to four arrays?
    ************************************************************************************************
    Rotation rule:
    0,0 -> 3,0
    1,0 -> 3,1
    2,0 -> 3,2
    3,0 -> 3,3

    0,1 -> 2,0
    1,1 -> 2,1
    2,1 -> 2,2
    3,1 -> 2,3

    0,2 -> 1,0
    1,2 -> 1,1
    2,2 -> 1,2
    3,2 -> 1,3

    0,3 -> 0,0
    1,3 -> 0,1
    2,3 -> 0,2
    3,3 -> 0,3
    ***********************************************************************************************/
    
    class RotateMatrix {
        public static void Run() {
            
            Console.WriteLine("--------------------------------- 7.RotateMatrix -------------------------------------------");

            var image = new int[4,4]{
                {1, 2, 3, 4},
                {4, 1, 2, 3},
                {3, 4, 1, 2},
                {2, 3, 4, 1}
            };            
            
            var expected = new int[4,4]{
                {2, 3, 4, 1},
                {3, 4, 1, 2},
                {4, 1, 2, 3},
                {1, 2, 3, 4}
            };
            
            var isRotated = Compare(expected, BruteForce(image));
            Console.WriteLine($"The result { (isRotated ? "IS a rotation" : "IS NOT a rotation")} of the original matrix");

            RunHelper.Stress( (i) => BruteForce(image), null, 100);
           
        }

        static bool Compare(int[,] input1, int[,] input2){
            for (int line= 0; line < input1.GetLength(0); line++){
                for (int col = 0; col < input1.GetLength(1); col++){
                    if(input1[line,col] != input2[line,col]){
                        return false;
                    }
                }
            }
            
            return true;
        }

        static int[,] BruteForce(int[,] image) {
            int columns = image.GetLength(1);
            int rows = image.GetLength(0);

            int[,] rotated = new int[rows,columns];

            for (int line = 0; line < rows; line++){
                int y = line;

                for (int col = 0; col < columns; col++){
                    int x = rows - col - 1;
                    rotated[line,col] = image[x,y];           
                }
            }    
            return rotated;
        }

        static void Optimized() {
           
        }
    }
}
