using System;

namespace Assignment4
{
    // ==========================================
    //  (Enums & Structs)
    // ==========================================

    class MyClass { public int Value; }

    enum WeekDays { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    struct Person
    {
        public string Name;
        public int Age;
    }

    enum Season { Spring, Summer, Autumn, Winter }

    [Flags]
    enum Permissions
    {
        None = 0, Read = 1, Write = 2, Delete = 4, Execute = 8
    }

    enum Colors { Red, Green, Blue }

    struct Point
    {
        public double X;
        public double Y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Assignment 4 Solutions ===");

            // 1 & 2. Value vs Reference types passing
            Console.WriteLine("\n--- 1 & 2. Passing by Value vs Reference ---");
            int val = 10;
            PassByValue(val);
            Console.WriteLine($"After PassByValue: {val}"); // 10
            PassByReference(ref val);
            Console.WriteLine($"After PassByReference: {val}"); // 100

            MyClass obj = new MyClass { Value = 10 };
            RefTypeByValue(obj);
            Console.WriteLine($"After RefTypeByValue: {obj.Value}"); // 5
            RefTypeByRef(ref obj);
            Console.WriteLine($"After RefTypeByRef: {obj.Value}"); // 20

            // 3. Sum and Subtract Output Parameters
            Console.WriteLine("\n--- 3. Sum and Subtract ---");
            SumAndSubtract(10, 5, out int sum, out int sub);
            Console.WriteLine($"10 + 5 = {sum}, 10 - 5 = {sub}");

            // 4. Sum of Digits
            Console.WriteLine("\n--- 4. Sum of Digits ---");
            Console.Write("Enter a number: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                Console.WriteLine($"The sum of the digits of the number {num} is: {SumOfDigits(num)}");
            }

            // 5. IsPrime
            Console.WriteLine("\n--- 5. IsPrime ---");
            Console.WriteLine($"Is 7 Prime? {IsPrime(7)}");
            Console.WriteLine($"Is 10 Prime? {IsPrime(10)}");

            // 6. MinMaxArray
            Console.WriteLine("\n--- 6. MinMaxArray ---");
            int[] arr = { 5, 2, 9, 1, 7 };
            int min = 0, max = 0;
            MinMaxArray(arr, ref min, ref max);
            Console.WriteLine($"Array: [5, 2, 9, 1, 7] -> Min: {min}, Max: {max}");

            // 7. Factorial (Iterative)
            Console.WriteLine("\n--- 7. Factorial ---");
            Console.WriteLine($"Factorial of 5 is: {Factorial(5)}");

            // 8. ChangeChar
            Console.WriteLine("\n--- 8. ChangeChar ---");
            Console.WriteLine($"Change char at index 1 in 'Hello' to 'a': {ChangeChar("Hello", 1, 'a')}");

            // ==========================================
            // Enums and Structs Tests
            // ==========================================

            // 1. WeekDays Enum
            Console.WriteLine("\n--- Enum 1: WeekDays ---");
            foreach (string day in Enum.GetNames(typeof(WeekDays)))
            {
                Console.WriteLine(day);
            }

            // 2. Person Struct Array
            Console.WriteLine("\n--- Struct 2: Person Array ---");
            Person[] people = new Person[3]
            {
                new Person { Name = "Ahmed", Age = 25 },
                new Person { Name = "Mona", Age = 30 },
                new Person { Name = "Ali", Age = 22 }
            };
            foreach (var p in people)
            {
                Console.WriteLine($"Name: {p.Name}, Age: {p.Age}");
            }

            // 3. Season Enum
            Console.WriteLine("\n--- Enum 3: Seasons ---");
            Console.Write("Enter a season (Spring, Summer, Autumn, Winter): ");
            string seasonInput = Console.ReadLine();
            if (Enum.TryParse(seasonInput, true, out Season season))
            {
                switch (season)
                {
                    case Season.Spring: Console.WriteLine("Spring: March to May"); break;
                    case Season.Summer: Console.WriteLine("Summer: June to August"); break;
                    case Season.Autumn: Console.WriteLine("Autumn: September to November"); break;
                    case Season.Winter: Console.WriteLine("Winter: December to February"); break;
                }
            }
            else { Console.WriteLine("Invalid Season."); }

            // 4. Permissions Enum
            Console.WriteLine("\n--- Enum 4: Permissions ---");
            Permissions myPerm = Permissions.Read; // Initial permission
            myPerm |= Permissions.Write; // Add Write
            Console.WriteLine($"Permissions after adding Write: {myPerm}");
            myPerm &= ~Permissions.Write; // Remove Write
            Console.WriteLine($"Permissions after removing Write: {myPerm}");
            bool hasRead = (myPerm & Permissions.Read) == Permissions.Read;
            Console.WriteLine($"Has Read permission? {hasRead}");

            // 5. Colors Enum
            Console.WriteLine("\n--- Enum 5: Colors ---");
            Console.Write("Enter a primary color (Red, Green, Blue): ");
            string colorInput = Console.ReadLine();
            if (Enum.TryParse(colorInput, true, out Colors color))
            {
                Console.WriteLine($"{color} is a primary color!");
            }
            else { Console.WriteLine($"{colorInput} is not defined in our primary colors enum."); }

            // 6. Distance between Points
            Console.WriteLine("\n--- Struct 6: Distance Between Points ---");
            Point p1 = new Point { X = 0, Y = 0 };
            Point p2 = new Point { X = 3, Y = 4 };
            Console.WriteLine($"Distance between (0,0) and (3,4) is: {CalculateDistance(p1, p2)}");

            // 7. Oldest Person
            Console.WriteLine("\n--- Struct 7: Oldest Person ---");
            Person[] userPeople = new Person[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter Name for person {i + 1}: ");
                userPeople[i].Name = Console.ReadLine();
                Console.Write($"Enter Age for person {i + 1}: ");
                int.TryParse(Console.ReadLine(), out userPeople[i].Age);
            }

            Person oldest = userPeople[0];
            foreach (var p in userPeople)
            {
                if (p.Age > oldest.Age) oldest = p;
            }
            Console.WriteLine($"The oldest person is {oldest.Name} with age {oldest.Age}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // ==========================================
        // (Methods)
        // ==========================================

        static void PassByValue(int x) { x = 100; }

        static void PassByReference(ref int x) { x = 100; }

        static void RefTypeByValue(MyClass obj) { obj.Value = 5; }

        static void RefTypeByRef(ref MyClass obj) { obj = new MyClass { Value = 20 }; }

        static void SumAndSubtract(int a, int b, out int sum, out int sub)
        {
            sum = a + b;
            sub = a - b;
        }

        static int SumOfDigits(int number)
        {
            int sum = 0;
            number = Math.Abs(number);
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        static void MinMaxArray(int[] arr, ref int min, ref int max)
        {
            if (arr == null || arr.Length == 0) return;
            min = arr[0];
            max = arr[0];
            foreach (int num in arr)
            {
                if (num < min) min = num;
                if (num > max) max = num;
            }
        }

        static long Factorial(int n)
        {
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        static string ChangeChar(string text, int position, char newLetter)
        {
            if (position < 0 || position >= text.Length) return text;
            char[] chars = text.ToCharArray();
            chars[position] = newLetter;
            return new string(chars);
        }

        static double CalculateDistance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
    }
}