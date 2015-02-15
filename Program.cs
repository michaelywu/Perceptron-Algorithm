using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] values = new double[4, 3] { { 0, 0, 1 }, { 0, 1, -1 }, { 1, 1, -1 }, { 1, 0, 1 } };
            double[,] values1 = new double[6, 3] { { 1, 1, 1 }, { 2, -2, -1 }, { -1, -1.5, -1 }, { -2, -1, -1 },{-2,1,1},{1.5,-0.5, 1} };
            Perceptron algorithm = new Perceptron(6,values1,.2);
            algorithm.printValues();
            algorithm.LearningAlgorithm();
            double[] W = algorithm.GetWeight();// 0 = W[0] + W[1]x + W[2]Y <==a line representation

            foreach (double val in W)
                System.Console.WriteLine(val);
        }
    }
}
