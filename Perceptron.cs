using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerceptronAlgorithm
{
    class Perceptron
    {
        //take in a n sized [n][3] array for omega1 (first col will be x values and second col will be y values andthird will be which set it belongs)
        //example = {[0,0,1] , [0,1,1] , [1,1,-1] , [1,0,-1]}
        double [] w;
        double [,] data_set;
        double scale;
        int data_amount;
        int[] classifier;// an n sized array, 0= incorrect, 1 = correct;
        public Perceptron(int n, double[,] set, double step)//constructor
        {
            setValues(n, set,step);
        }
        public void setValues(int n, double[,]set, double step)//set the values
        {
            classifier = new int[n];
            data_amount = n;
            data_set = set;
            scale = step;
            w = new double[3] { 0, 0, 0 };
            for (int i = 0; i < n; i++)//initialize to zero
                classifier[i] = 0;
        }
        public void printValues()//print the 2d array
        {
            for (int i = 0; i < data_set.GetLength(0); i++)
            {
                for (int k = 0; k < data_set.GetLength(1); k++)
                {
                    System.Console.Write(data_set[i, k]);
                }

                System.Console.WriteLine();
            }
        }
        public void LearningAlgorithm()
        {
            //set 1 = 1
            //set 2 = -1

            //1. select random sample from training set as input
            //2. if classifcation is correct do nothing
            //3. if classifcation is incorrect modify the weight
                // wi = wi +(scale)*d(n)(xi(n)
            //4. keep going until all has been classified correctly
            do 
            {
                // select random sample
                int indexSample = 0;
                List<int> missclassified = new List<int>();
                for (int i = 0; i < classifier.Length; i++) //select an index that has not been classified correctly
                {
                    missclassified.Add(i); //load up the list of indexes
                }
                Random rnd = new Random();
                indexSample = rnd.Next(missclassified.Count);//get a random sample

                double setNumber = data_set[indexSample, 2];// 1 or -1

                 if (setNumber == 1)
                 {
                     if ((w[0] * 1 + w[1] * data_set[indexSample, 0] + w[2] * data_set[indexSample, 1]) > 0)
                     {
                      // do nothing
                     }
                     else
                     {
                         //modify weight vector
                         w[0] = w[0] + (scale * setNumber * 1);
                         w[1] = w[1] + (scale * setNumber * data_set[indexSample, 0]);
                         w[2] = w[2] + (scale * setNumber * data_set[indexSample, 1]);
                     }
                 }
                 else
                 {
                     if ((w[0] * 1 + w[1] * data_set[indexSample, 0] + w[2] * data_set[indexSample, 1]) < 0)
                     {
                        // do nothing
                     }
                     else
                     {
                         //modify weight vector
                         w[0] = w[0] + (scale * setNumber * 1);
                         w[1] = w[1] + (scale * setNumber * data_set[indexSample, 0]);
                         w[2] = w[2] + (scale * setNumber * data_set[indexSample, 1]);
                     }
                 }

            } while (!classification());
            //repeat until all has been classified correctly
        }
        private bool classification() // returns false if there is incorrect classification in the training set
            //return true if there is none
            //update the classifier array
        {
            bool ifCorrect = true;
            
            for (int pointIndex = 0; pointIndex < data_set.GetLength(0); pointIndex++)//iterate by row
            {
                double setNumber = data_set[pointIndex, 2]; // 1 or -1
                //check if classification is correct
                if (classifier[pointIndex] == 0)
                {
                    if (setNumber == 1)
                    {
                        if ((w[0]*1 + w[1]*data_set[pointIndex,0] + w[2]*data_set[pointIndex,1])> 0) //(w(sub t)*x > 0)
                        {
                           // do nothing
                        }
                        else
                        {
                            ifCorrect = false;
                        }
                    }
                    else
                    {
                        if ((w[0] * 1 + w[1] * data_set[pointIndex, 0] + w[2] * data_set[pointIndex, 1]) < 0)//(w(sub t)*x < 0)
                        {
                            //do nothing
                        }
                        else
                        {
                            ifCorrect = false;
                        }
                    }
                }
             }
            return ifCorrect;
        }
        public double[] GetWeight()
        {
            return w;
        }
    }
}
