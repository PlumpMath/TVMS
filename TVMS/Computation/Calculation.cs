using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace TVMS.Computation
{
    public class Calculation
    {
        public double Alpha;
        public double n;
        public double ExpectationX { get; set; }
        public double ExpectationY { get; set; }
        public double VarianceX { get; set; }
        public double VarianceY { get; set; }
        public double SigmaX { get; set; }
        public double SigmaY { get; set; }
        public double Covariation { get; set; }
        public double Correlation { get; set; }
        public double YieldPoint { get; set; }
        public double Delta { get; set; }
        public bool pValue { get; set; }
        public double[] Koefficients { get; set; }

        public Calculation()
        {
            
        }

        public Calculation(double[] x, double[] y, double alpha)
        {
            if (x.Length != y.Length) return;
            Alpha = alpha;
            n = x.Length;
            ExpectationX = GetExpectation(x);
            ExpectationY = GetExpectation(y);
            VarianceX = GetVariance(x);
            VarianceY = GetVariance(y);
            SigmaX = GetSigma(x);
            SigmaY = GetSigma(y);
            Covariation = GetCovariation(x, y);
            Correlation = GetCorrelation(x, y);
            YieldPoint = GetYieldPoint(n, Alpha);
            Delta = GetTDelta(x, y);
            pValue = PValue(Delta, Alpha);
            Koefficients = Koefs(x, y);
        }

        /// <summary>
        /// Таблица Стьюдента
        /// </summary>
        public double[,] Student = 
            {
                { 0, 0.05, 0.01, 0.001 },
                { 1, 12.7, 64.65, 636.61 },
                { 2, 4.303, 9.925, 31.602 },
                { 3, 3.182, 5.841, 12.923 },
                { 4, 2.776, 4.604, 8.61 },
                { 5, 2.571, 4.032, 6.869 },
                { 6, 2.447, 3.707, 5.959 },
                { 7, 2.365, 3.499, 5.408 },
                { 8, 2.306, 3.355, 5.041 },
                { 9, 2.262, 3.250, 4.781 },
                { 10, 2.228, 3.169, 4.587 },
                { 11, 2.201, 3.106, 4.437 },
                { 12, 2.179, 3.055, 4.318 },
                { 13, 2.16, 3.012, 4.221 },
                { 14, 2.145, 2.977, 4.140 },
                { 15, 2.131, 2.947, 4.14 },
                { 16, 2.12, 2.921, 4.015 },
                { 17, 2.11, 2.898, 3.965 },
                { 18, 2.101, 2.878, 3.922 },
                { 19, 2.093, 2.861, 3.883 },
                { 20, 2.086, 2.845, 3.85 }
            };


        public double GetVariancel { get; set; }

        /// <summary>
        /// Возвращает квадрат выборки
        /// </summary>
        /// <param name="x">
        /// Значения выборки
        /// </param>
        /// <returns></returns>
        public double[] SquartThis(double[] x)
        {
            double[] squart = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                squart[i] = x[i]*x[i];
            }
            return squart;
        }

        /// <summary>
        /// Математическое ожидание выборки
        /// </summary>
        /// <param name="x">
        /// Значения выборки
        /// </param>
        /// <returns>
        /// Математическое ожидание
        /// </returns>
        public double GetExpectation(double[] x)
        {
            double n = x.Length;
            this.n = n;
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += x[i];
            }
            return sum/n;
        }

        /// <summary>
        /// Дисперсия выборки
        /// </summary>
        /// <param name="x">
        /// Значения выборки
        /// </param>
        /// <returns>
        /// Дисперсия
        /// </returns>
        public double GetVariance(double[] x)
        {
            return GetExpectation(SquartThis(x)) - Math.Pow(GetExpectation(x), 2);
        }

        /// <summary>
        /// Среднее квадратическое отклонение выборки
        /// </summary>
        /// <param name="x">
        /// Выборка
        /// </param>
        /// <returns>
        /// Среднее квадратическое отклонение
        /// </returns>
        public double GetSigma(double[] x)
        {
            return Math.Sqrt(GetVariance(x));
        }

        /// <summary>
        /// Ковариация выборки
        /// </summary>
        /// <param name="x">
        /// Выборка по X
        /// </param>
        /// <param name="y">
        /// Выборка по Y
        /// </param>
        /// <returns>
        /// Коэффициент ковариации
        /// </returns>
        public double GetCovariation(double[] x, double[] y)
        {
            double n = x.Length == y.Length ? x.Length : 0;
            if (n == 0) return 0;

            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += (x[i] - GetExpectation(x))*(y[i] - GetExpectation(y));
            }
            return sum/n;
        }

        /// <summary>
        /// Корелляция выборки
        /// </summary>
        /// <param name="x">
        /// Выборка по X
        /// </param>
        /// <param name="y">
        /// Выборка по Y
        /// </param>
        /// <returns>
        /// Коэффициент корреляции
        /// </returns>
        public double GetCorrelation(double[] x, double[] y)
        {
            return GetCovariation(x, y)/(GetSigma(x)*GetSigma(y));
        }

        /// <summary>
        /// Т-набл выборки
        /// </summary>
        /// <param name="x">
        /// Выборка по X
        /// </param>
        /// <param name="y">
        /// Выборка по Y
        /// </param>
        /// <returns>
        /// Т-набл
        /// </returns>
        public double GetTDelta(double[] x, double[] y)
        {
            double n = x.Length == y.Length ? x.Length : 0;
            if ((int)n == 0) return 0;

            return GetCorrelation(x, y)*Math.Sqrt(n-2)/Math.Sqrt(1-Math.Pow(GetCorrelation(x, y), 2));
        }

        /// <summary>
        /// Проверка на нулевую гипотезу
        /// </summary>
        /// <param name="tDelta">
        /// Т-набл выборки
        /// </param>
        /// <param name="alpha">
        /// Уровень значимости
        /// </param>
        /// <returns>
        /// Решение об отвержении нулевой гипотезы
        /// </returns>
        public bool PValue(double tDelta, double alpha)
        {
            return Math.Abs(tDelta) <= GetYieldPoint(n, alpha);
        }

        /// <summary>
        /// Ткр по таблице Стьюдента
        /// </summary>
        /// <param name="n">
        /// Размер выборки
        /// </param>
        /// <param name="alpha">
        /// Уровень значимости
        /// </param>
        /// <returns>
        /// Критерий Ткр
        /// </returns>
        public double GetYieldPoint(double n, double alpha)
        {
            double df = n - 2;
            int line = 0, column = 0;
            
            //only now
            alpha = Alpha;
            for (int i = 1; i <= Student.GetLength(0); i++)
            {
                if (Student[i, 0] != df) continue;
                line = i;
                break;
            }
            
                for (int i = 1; i <= Student.GetLength(1); i++)
                {
                    if (Student[0, i] != alpha) continue;
                    column = i;
                    break;
                }
            
            return line == 0 && column == 0 ? 0 : Student[line, column];
        }

        public double Sum(double[] a)
        {
            return a.Sum();
        }

        public double[] Koefs(double[] x, double[] y)
        {
            if (x.Length != y.Length) return null;

            //Затычка
            var koefs = new[] {0.0, 0.0};

            
            var xy = new double[x.Length];
            var xSq = SquartThis(x);

            for (int i = 0; i < x.Length; i++)
            {
                xy[i] = x[i]*y[i];
            }

            //Величины для рассчета
            var sumX = Sum(x);
            var sumY = Sum(y);
            var sumXSq = Sum(xSq);
            var sumXY = Sum(xy);
            var max = x.Length;

            //Общий знаменатель
            var denominator = max*sumXSq - sumX*sumX;

            //Коэффицент a
            koefs[0] = (max*sumXY - sumX*sumY)/denominator;
            
            //Коэффицент b
            koefs[1] = (sumY*sumXSq - sumX*sumXY)/denominator;

            return koefs;
        }
    }
}
