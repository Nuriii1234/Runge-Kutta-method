using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runge_Kutta_method
{
    internal class TRunge_Kutta_method
    {
        void PrintVector(double[] Vector)
        {
            for (int i = 0; i < Vector.Length; i++)
            {
                Console.Write(Vector[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        double Function(double x, double y) 
        {
            double F;
            F = Math.Exp(x - y) + Math.Exp(x);
            return F;
        }
        double Original_Function(double x)
        {
            double F;
            F = Math.Log(Math.Exp(Math.Exp(x)) - 1);
            return F;
        }
        double[] Search_vector_K(double x, double y, double h) 
        {
            double[] vector_K = new double[4];
            vector_K[0] = h * Function(x , y);
            vector_K[1] = h * Function(x + 0.5 * h , y + 0.5 * vector_K[0]);
            vector_K[2] = h * Function(x + 0.5 * h, y + 0.5 * vector_K[1]);
            vector_K[3] = h * Function(x + h, y + vector_K[2]);
            return vector_K;
        }
        void Method()
        {
            int k = 11;
            double x = 0;
            double y = 0.541325;
            double [] vector_x = new double[k];
            double [] vector_y = new double[k];
            double[] vector_original_y = new double[k - 1];
            double [] vector_Eps = new double[k - 1];
            vector_x[0] = x;
            vector_y[0] = y;
            double h = 0.1;
            double delta_Y;
            int i = 0;
            while (x < 0.95)
            {
                var vector_K = Search_vector_K(x, y, h);
                vector_original_y[i] = Original_Function(x);
                delta_Y = (vector_K[0] + 2 * vector_K[1] + 2 * vector_K[2] + vector_K[3]) / 6;
                y += delta_Y;
                x += h;
                vector_Eps[i] = Math.Abs(y - Original_Function(x));
                i++;
                vector_x[i] = x;
                vector_y[i] = y;
            }
            Console.WriteLine("Значения Х:");
            PrintVector(vector_x);
            Console.WriteLine("Значения У по методу Рунге-Кутта:");
            PrintVector(vector_y);
            Console.WriteLine("Значения У по точному уравнению:");
            PrintVector(vector_original_y);
            Console.WriteLine("Ошибка У для каждого Х:");
            PrintVector(vector_Eps);
        }
        public void Start()
        {
            Method();
        }
    }
}
