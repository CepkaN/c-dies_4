using System.Data.Common;
using System.Runtime.CompilerServices;

namespace c_dies_4
{
    internal class Program
    {
        class MyClass
        {
            int num { get; set; }
        }
        class MyClass2 : MyClass    // нет модификаторов доступа
        {

        }
        abstract class Abs
        {
            public int num;
            public virtual void AD()
            {
                Console.WriteLine("Hello");
            }
            public abstract void ADS();
        }
        class Abs2 : Abs
        {
            public override void ADS()
            {

            }
            public override void AD()
            {

            }
            public static int operator+(Abs2 a,Abs2 b)
            {
                return a + b;
            }
            public static int operator-(Abs2 a, Abs2 b)
            {
                return a - b;
            }
            public static bool operator true(Abs2 a)
            {
                if (1 == a.num)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool operator false(Abs2 a)
            {
                if (1 != a.num)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        sealed class Class2  // если не хотим, чтобы от класса кто-то наследовался. sealed
        {

        }
        class Matrix
        {
            public int _x;
            public int _y;
            public int[,] mass;
           
            public Matrix(int x,int y)
            {
                _x = x;
                _y = y;
                mass = new int[_x, _y];
                Random rnd = new Random();
                int Randomize = rnd.Next(1, 10);
                for (int i = 0; i < _x; ++i)
                {
                    for (int j = 0; j < _y; ++j)
                        mass[i,j] = rnd.Next(1, 10);
                }
            }
            public Matrix(int[,] m,int x,int y)
            {
                mass = m;_x = x;_y = y;
            }
            public void Mostra()
            {
                for (int i = 0; i < _x; ++i)
                {
                    for (int j = 0; j < _y; ++j)
                    { Console.Write(mass[i, j] + " "); }
                    Console.WriteLine();
                }
                Console.WriteLine();

            }
            public static Matrix operator+(Matrix m1,Matrix m2)
            {
                if (m1._x != m2._x && m1._y != m2._y)
                {
                    Console.WriteLine("Ошибка");
                    return m1;
                }
                int[,] m3=new int[m1._x,m1._y];
                for (int i = 0; i < m1._x; ++i)
                {
                    for (int j = 0; j < m1._y; ++j)
                    { m3[i,j]=m1.mass[i, j] + m2.mass[i,j]; }                   
                }
                return new Matrix(m3,m1._x,m1._y);
            }
            public static Matrix operator-(Matrix m1,Matrix m2)
            {
                if (m1._x != m2._x && m1._y != m2._y)
                {
                    Console.WriteLine("Ошибка");
                    return m1;
                }
                int[,] m3 = new int[m1._x, m1._y];
                for (int i = 0; i < m1._x; ++i)
                {
                    for (int j = 0; j < m1._y; ++j)
                    { m3[i, j] = m1.mass[i, j] - m2.mass[i, j]; }
                }
                return new Matrix(m3, m1._x, m1._y);
            }
            public static Matrix operator*(Matrix m1,Matrix m2)
            {
                if (m1._y != m2._x )
                {
                    Console.WriteLine("Ошибка");
                    return m1;
                }
                int[,] m3 = new int[m1._y, m2._x];
              
                for (int i = 0; i < m1._x; ++i)
                {
                    for (int j = 0; j < m2._y; ++j)
                    {
                        m3[i, j] = 0;

                        for (int k = 0; k < m1._y; ++k)
                        {
                            m3[i, j] += m1.mass[i, k] * m2.mass[k, j];
                        }
                    }
                }
                return new Matrix(m3, m1._y, m2._x);
            }
            public static Matrix operator*(Matrix m1,int a)
            {
                int[,] m3 = new int[m1._x, m1._y];
                for (int i = 0; i < m1._x; ++i)
                {
                    for (int j = 0; j < m1._y; ++j)
                    { m3[i, j] = m1.mass[i, j] * a; }
                }
                return new Matrix(m3, m1._x, m1._y);
            }
        }
        abstract class Human
        {
            public int _haut { get; set; }
            public int _ans { get; set; }
            public int _gravity { get; set; }
            public int _salary { get; set; }
            public Human(int haut, int ans, int gravity, int salary)
            {
                _haut = haut;
                _ans = ans;
                _gravity = gravity;
                _salary = salary;
            }
            public virtual void HHH()
            {
                Console.WriteLine(" я человек ");
            }
            public virtual void Mostra()
            {
                Console.WriteLine(" Рост " + _haut + "\n Возраст " + _ans + "\n Вес " + _gravity+"\n Зарплата "+_salary);
                Console.WriteLine();
            }
            public static int operator +(Human h1,int x)
            {
                h1._salary += x;
                return 0;
            }
            public static int operator -(Human h1, int x)
            {
                h1._salary -= x;
                return 0;
            }
            public static bool operator==(Human h1,Human h2)
            {
                return h1._salary== h2._salary;
            }
            public static bool operator !=(Human h1, Human h2)
            {
                return h1._salary != h2._salary;
            }
            public static bool operator<(Human h1,Human h2)
            {
                return h1._salary < h2._salary;
            }
            public static bool operator >(Human h1, Human h2)
            {
                return h1._salary < h2._salary;
            }
            public virtual void Zarp(Human h2)
            {
                if(_salary == h2._salary)
                {
                    Console.WriteLine(" Зарплаты равны ");return;
                }
                if (_salary < h2._salary)
                {
                    Console.WriteLine(" Зарплата меньше ");return;
                }
                if (_salary > h2._salary)
                {
                    Console.WriteLine(" Зарплата больше ");return;
                }
            }

        }
        class Builder : Human
        {
            public Builder(int haut, int ans, int gravity,int salary) : base(haut, ans, gravity,salary)
            {
            }

            public override void HHH()
            {
                Console.WriteLine(" Я строитель ");
            }
        }
        class Sailor : Human
        {
            public Sailor(int haut, int ans, int gravity,int salary) : base(haut, ans, gravity,salary)
            {
            }

            public override void HHH()
            {
                Console.WriteLine(" Я моряк ");
            }
        }
        class Pilot : Human
        {
            public Pilot(int haut, int ans, int gravity,int salary) : base(haut, ans, gravity,salary)
            {
            }

            public override void HHH()
            {
                Console.WriteLine(" Я пилот ");
            }
        }
        static void Main(string[] args)
        {
            Matrix mat1 = new Matrix(4, 4);
            Matrix mat2 = new Matrix(4, 4);
            mat1.Mostra();
            mat2.Mostra();
            Matrix mat3 = mat1 + mat2;
            mat3.Mostra();
            Matrix mat4= mat1 - mat2;   
            mat4.Mostra();

            Matrix mat5 = new Matrix(5, 5);
            Matrix mat6 = mat1 + mat5;


            Matrix mat7 = mat1 * 2;
            mat7.Mostra();
            Matrix mat8 = mat1 * mat2;
            mat8.Mostra();
            Matrix mat9 = new Matrix(4, 1);
            Matrix mat10 = mat1 * mat9;
            mat10.Mostra();

           

            Human builder = new Builder(170, 55, 70,80000);
            Human sailor = new Sailor(190, 70, 67,90000);
            Human pilot = new Pilot(185, 29, 78,70000);
            builder.HHH();
            builder.Mostra();
            sailor.HHH();
            sailor.Mostra();
            pilot.HHH();
            pilot.Mostra();
            builder.Zarp(sailor);
            int asd = builder + 10000;
            builder.Zarp(sailor);
            asd = builder - 10000;
            builder.Zarp(pilot);
        }
    }
}