using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitPatterns.SOLID
{
    static class LiskovSubstitutionProblem_Rectangle
    {
        public static void Display()
        {
            Rectangle rect = new Square();
            try
            {
                TestRectangleArea(rect);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                TestRectangleArea2(rect);            
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
}

        static void TestRectangleArea(Rectangle rect)
        {
            rect.Height = 5;
            rect.Width = 10;
            if (rect.GetArea() != 50)
                throw new Exception("Некорректная площадь!");
        }

        static void TestRectangleArea2(Rectangle rect)
        {
            if (rect is Square)
            {
                rect.Height = 5;
                if (rect.GetArea() != 25)
                    throw new Exception("Неправильная площадь!");
            }
            else if (rect is Rectangle)
            {
                rect.Height = 5;
                rect.Width = 10;
                if (rect.GetArea() != 50)
                    throw new Exception("Неправильная площадь!");
            }
        }

        class Rectangle
        {
            public virtual int Width { get; set; }
            public virtual int Height { get; set; }

            public int GetArea()
            {
                return Width * Height;
            }
        }

        class Square : Rectangle
        {
            public override int Width
            {
                get
                {
                    return base.Width;
                }

                set
                {
                    base.Width = value;
                    base.Height = value;
                }
            }

            public override int Height
            {
                get
                {
                    return base.Height;
                }

                set
                {
                    base.Height = value;
                    base.Width = value;
                }
            }
        }
    }

    static class LiskovSubstitutionProblem_Precondition
    {
        public static void Display()
        {
            Account acc = new MicroAccount();
            try
            {
                InitializeAccount(acc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void InitializeAccount(Account account)
        {
            account.SetCapital(200);
            Console.WriteLine(account.Capital);
        }

        class Account
        {
            public int Capital { get; protected set; }

            public virtual void SetCapital(int money)
            {
                if (money < 0)
                    throw new Exception("Нельзя положить на счет меньше 0");
                this.Capital = money;
            }
        }

        class MicroAccount : Account
        {
            public override void SetCapital(int money)
            {
                if (money < 0)
                    throw new Exception("Нельзя положить на счет меньше 0");

                if (money > 100)
                    throw new Exception("Нельзя положить на счет больше 100");

                this.Capital = money;
            }
        }
    }

    static class LiskovSubstitutionProblem_Postcondition
    {
        public static void Display()
        {
            Account acc = new MicroAccount();
            try
            {
                CalculateInterest(acc); // получаем 1100 без бонуса 100
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CalculateInterest(Account account)
        {
            decimal sum = account.GetInterest(1000, 1, 10); // 1000 + 1000 * 10 / 100 + 100 (бонус)
            if (sum != 1200) // ожидаем 1200
            {
                throw new Exception("Неожиданная сумма при вычислениях");
            }
        }

        class Account
        {
            public virtual decimal GetInterest(decimal sum, int month, int rate)
            {
                // предусловие
                if (sum < 0 || month > 12 || month < 1 || rate < 0)
                    throw new Exception("Некорректные данные");

                decimal result = sum;
                for (int i = 0; i < month; i++)
                    result += result * rate / 100;

                // постусловие
                if (sum >= 1000)
                    result += 100; // добавляем бонус

                return result;
            }
        }

        class MicroAccount : Account
        {
            public override decimal GetInterest(decimal sum, int month, int rate)
            {
                if (sum < 0 || month > 12 || month < 1 || rate < 0)
                    throw new Exception("Некорректные данные");

                decimal result = sum;
                for (int i = 0; i < month; i++)
                    result += result * rate / 100;

                return result;
            }
        }
    }

    static class LiskovSubstitutionProblem_Invariant
    {
        public static void Display()
        {
            try
            {
                Account acc = new Account(1000);
                acc.Capital = 10;
                acc = new MicroAccount(1000);
                acc.Capital = 10;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        class Account
        {
            protected int capital;
            public Account(int sum)
            {
                if (sum < 100)
                    throw new Exception("Некорректная сумма");
                this.capital = sum;
            }

            public virtual int Capital
            {
                get { return capital; }
                set
                {
                    if (value < 100)
                        throw new Exception("Некорректная сумма");
                    capital = value;
                }
            }
        }

        class MicroAccount : Account
        {
            public MicroAccount(int sum) : base(sum)
            {
            }

            public override int Capital
            {
                get { return capital; }
                set
                {
                    capital = value;
                }
            }
        }
    }
}
