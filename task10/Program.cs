using System;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentSolutions
{
    #region Part 01 Solutions

    #region Problem 1: Generic Sorting for Employee Objects
    public class Employee : IComparable<Employee>, ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public Employee() { }

        public Employee(int id, string name, decimal salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public int CompareTo(Employee other)
        {
            if (other == null) return 1;
            return this.Salary.CompareTo(other.Salary);
        }

        public object Clone()
        {
            return new Employee(this.Id, this.Name, this.Salary);
        }

        public override string ToString() => $"[ID: {Id}, Name: {Name}, Salary: {Salary:C}]";
    }

    public static class SortingAlgorithm<T> where T : IComparable<T>, ICloneable
    {
        public static void Sort(T[] array)
        {
            if (array == null) return;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }

        public static void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        internal static void Swap<T>(ref T a, ref T b)
        {
            
        
            T temp = a;
            a = b;
            b = temp;
        
    }
    }

    /*
     * Question: What are the benefits of using a generic sorting algorithm over a non-generic one?
     * Answer: 
     * Generic sorting algorithms provide compile-time type safety, eliminate boxing and unboxing overhead 
     * for value types, and allow code reusability across any object type without writing type-specific logic.
     */
    #endregion

    #region Problem 2: Dynamic Sorting with Lambda Expressions
    public static class SortingTwo
    {
        public static void Sort<T>(T[] array, Func<T, T, int> comparer)
        {
            if (array == null || comparer == null) return;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (comparer(array[j], array[j + 1]) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }

    /*
     * Question: How do lambda expressions improve the readability and flexibility of sorting methods?
     * Answer: 
     * Lambda expressions allow developers to specify custom sorting strategies inline directly at the call site, 
     * avoiding the clutter of creating separate named comparison methods while keeping code concise and expressive.
     */
    #endregion

    #region Problem 3: String Length Sorting with Comparer
    /*
     * Question: Why is it important to use a dynamic comparer function when sorting objects of various data types?
     * Answer: 
     * A dynamic comparer decouples the sorting algorithm from the object's core definition, enabling custom or multi-attribute 
     * sorting criteria (such as string length or dynamic properties) without modifying the original class structure.
     */
    #endregion

    #region Problem 4: Manager Inheritance and IComparable
    public class Manager : Employee
    {
        public string Department { get; set; }

        public Manager(int id, string name, decimal salary, string department)
            : base(id, name, salary)
        {
            Department = department;
        }

        public override string ToString() => $"Manager [ID: {Id}, Name: {Name}, Salary: {Salary:C}, Dept: {Department}]";
    }

    /*
     * Question: How does implementing IComparable in derived classes enable custom sorting?
     * Answer: 
     * Implementing IComparable establishes a natural ordering contract (`CompareTo`) for derived instances. 
     * Generic sort algorithms rely on this contract to order objects polymorphically in collections.
     */
    #endregion

    #region Problem 5: Func Delegate for Sorting by Name Length
    /*
     * Question: What is the advantage of using built-in delegates like Func in generic programming?
     * Answer: 
     * Built-in delegates like `Func` and `Action` standardize functional signatures across the .NET ecosystem, 
     * reducing custom delegate boilerplate, enhancing API readability, and improving compatibility with LINQ.
     */
    #endregion

    #region Problem 6: Anonymous Functions vs Lambda Expressions
    /*
     * Question: How does the usage of anonymous functions differ from lambda expressions in terms of readability and efficiency?
     * Answer: 
     * Both compile to similar IL code with equivalent performance. However, lambda expressions feature far superior syntax 
     * readability (`(x, y) => ...` vs `delegate(int x, int y) { ... }`), making them the standard choice in modern C#.
     */
    #endregion

    #region Problem 7: Standalone Generic Swap Method
    /*
     * Question: Why is the use of generic methods beneficial when creating utility functions like Swap?
     * Answer: 
     * Generic methods allow utility operations to work across any data type without duplicating code or incurring performance 
     * hits from object boxing when dealing with value types.
     */
    #endregion

    #region Problem 8: Multi-Criteria Sorting Logic
    /*
     * Question: What are the challenges and benefits of implementing multi-criteria sorting logic in generic methods?
     * Answer: 
     * Benefits include fine-grained tie-breaking logic (e.g., sort by Salary then Name). 
     * Challenges involve managing complex nested conditionals and ensuring consistent comparison results.
     */
    #endregion

    #region Problem 9: Handling Default Values with default(T)
    public static class DefaultUtility
    {
        public static T GetDefault<T>()
        {
            return default(T);
        }
    }

    /*
     * Question: Why is the default(T) keyword crucial in generic programming, and how does it handle value and reference types differently?
     * Answer: 
     * `default(T)` provides a type-safe way to initialize generic variables. It returns `null` for reference types, 
     * `0` for numeric value types, `false` for booleans, and zero-initialized memory structures for structs.
     */
    #endregion

    #region Problem 10: Generic Constraints with ICloneable
    /*
     * Question: How do constraints in generic programming ensure type safety and improve the reliability of generic methods?
     * Answer: 
     * Constraints enforce compile-time rules on type parameters, ensuring that passed types support required operations 
     * (like cloning or comparison) and catching invalid type usage during compilation rather than runtime.
     */
    #endregion

    #region Problem 11: Delegate for String Transformations
    public delegate string StringTransformer(string input);

    public static class StringUtility
    {
        public static List<string> TransformStrings(List<string> list, StringTransformer transformer)
        {
            List<string> result = new List<string>();
            foreach (var item in list)
            {
                result.Add(transformer(item));
            }
            return result;
        }
    }

    /*
     * Question: What are the benefits of using delegates for string transformations in a functional programming style?
     * Answer: 
     * Delegates enable higher-order functions that accept transformation behavior as arguments, promoting modularity, 
     * immutability, and seamless behavior swapping without mutating the original input data.
     */
    #endregion

    #region Problem 12: Math Operations using Custom Delegates
    public delegate int MathOperation(int a, int b);

    public static class MathUtility
    {
        public static int ExecuteOperation(int a, int b, MathOperation operation)
        {
            return operation(a, b);
        }
    }

    /*
     * Question: How does the use of delegates promote code reusability and flexibility in implementing mathematical operations?
     * Answer: 
     * Delegates separate mathematical calculation workflows from concrete execution logic, allowing a single execution pipeline 
     * to perform dynamic operations (addition, subtraction, multiplication) dynamically.
     */
    #endregion

    #region Problem 13: Generic Transformation Delegate
    public delegate R GenericTransformer<T, R>(T input);

    public static class TransformUtility
    {
        public static List<R> Map<T, R>(List<T> list, GenericTransformer<T, R> transformer)
        {
            List<R> result = new List<R>();
            foreach (var item in list)
            {
                result.Add(transformer(item));
            }
            return result;
        }
    }

    /*
     * Question: What are the advantages of using generic delegates in transforming data structures?
     * Answer: 
     * Generic delegates allow type projection (e.g., mapping `int` to `string`), supporting type-safe operations 
     * across different collection models.
     */
    #endregion

    #region Problem 14: Func Delegate Usage
    /*
     * Question: How does Func simplify the creation and usage of delegates in C#?
     * Answer: 
     * `Func` eliminates the manual definition of custom delegate types by providing built-in generic signatures 
     * that support up to 16 input parameters and a return value.
     */
    #endregion

    #region Problem 15: Action Delegate Usage
    /*
     * Question: Why is Action preferred for operations that do not return values?
     * Answer: 
     * `Action` explicitly signals side-effecting void operations (e.g., logging, printing, writing to files), 
     * offering clean intent in method declarations.
     */
    #endregion

    #region Problem 16: Predicate Delegate and Filtering
    /*
     * Question: What role do predicates play in functional programming, and how do they enhance code clarity?
     * Answer: 
     * Predicates represent boolean conditions (`T -> bool`). They provide clean, readable criteria definitions 
     * for filtering and querying collections.
     */
    #endregion

    #region Problem 17: Anonymous Functions for Filtering
    /*
     * Question: How do anonymous functions improve code modularity and customization?
     * Answer: 
     * Anonymous functions allow logic to be defined inline where needed, reducing class-level method clutter 
     * for single-use operations.
     */
    #endregion

    #region Problem 18: Anonymous Functions for Math
    /*
     * Question: When should you prefer anonymous functions over named methods in implementing mathematical operations?
     * Answer: 
     * Anonymous functions are ideal for quick, localized calculations passed to higher-order functions that won't be reused elsewhere.
     */
    #endregion

    #region Problem 19: Lambda Expressions for String Filtering
    /*
     * Question: What makes lambda expressions an essential feature in modern C# programming?
     * Answer: 
     * Lambda expressions provide compact syntax for writing inline delegates, forming the foundation of LINQ 
     * and functional C# paradigms.
     */
    #endregion

    #region Problem 20: Lambda Expressions for Double Math Operations
    /*
     * Question: How do lambda expressions enhance the expressiveness of mathematical computations in C#?
     * Answer: 
     * They allow complex math formulas to be written declaratively, making algorithms look close to mathematical notation.
     */
    #endregion

    #endregion

    #region Part 02 Solutions

    

    #region Topic Search Summaries
    /*
     * TECHNICAL TOPIC OVERVIEWS
     * ---------------------------------------------------------------------------------------------------------
     * 1. Parallel Programming & Concurrency:
     *    - Leverages multi-core processors via Task Parallel Library (TPL) and Parallel.ForEach to execute tasks concurrently.
     *    - Manages race conditions using locking mechanisms (lock, SemaphoreSlim, Monitor) and thread-safe collections.
     * 
     * 2. Unit Testing & Test-Driven Development (TDD):
     *    - TDD Workflow: Red (write failing test) -> Green (write minimal code to pass) -> Refactor.
     *    - Uses frameworks like xUnit or NUnit along with mocking libraries (Moq) to test isolated units of code.
     * 
     * 3. Asynchronous Programming with async/await:
     *    - Enables non-blocking I/O operations by yielding control back to the caller while awaiting background tasks.
     *    - Prevents UI freezing and optimizes server throughput in backend ASP.NET Core applications.
     */
    #endregion

    #endregion

    #region Part 03 Solutions (Bonus)

    #region Report 1: Self-Study Technical Report
    /*
     * SELF-STUDY REPORT: Advanced C# Functional and Asynchronous Design
     * ---------------------------------------------------------------------------------------------------------
     * Overview:
     * Modern .NET combines object-oriented architecture with functional paradigms and asynchronous pipelines.
     * Combining delegates, lambdas, generics, and async/await enables clean, testable, and high-performance backend systems.
     */
    #endregion

    #region Report 2: What is Asynchronous Programming?
    /*
     * ASYNCHRONOUS PROGRAMMING IN C#
     * ---------------------------------------------------------------------------------------------------------
     * Asynchronous programming is a non-blocking execution model that allows an application to initiate I/O-bound 
     * or network-bound operations without stalling the executing thread.
     * 
     * Key Benefits:
     * - Responsiveness: Keeps UI applications responsive during background operations.
     * - Scalability: Frees up ASP.NET Core request threads to handle high concurrent traffic.
     */
    #endregion

    #endregion

    #region Program Execution Entry Point
    public class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("=== PART 01 DEMO ===\n");


            // Problem 1: Generic Sorting for Employees
            Employee[] employees = new Employee[]
            {
                new Employee(1, "Alice", 75000m),
                new Employee(2, "Bob", 50000m),
                new Employee(3, "Charlie", 90000m)
            };
            SortingAlgorithm<Employee>.Sort(employees);
            Console.WriteLine("Problem 1 - Sorted Employees by Salary (Ascending):");
            foreach (var emp in employees) Console.WriteLine($"  {emp}");

            // Problem 2 & 3: Dynamic Sorting & Lambda
            int[] numbers = { 5, 2, 8, 1, 9 };
            SortingTwo.Sort(numbers, (a, b) => b.CompareTo(a)); // Descending
            Console.WriteLine($"\nProblem 2 - Dynamic Lambda Sort (Descending): [{string.Join(", ", numbers)}]");

            string[] names = { "Alexander", "Bob", "Charlotte", "Dan" };
            SortingTwo.Sort(names, (a, b) => a.Length.CompareTo(b.Length));
            Console.WriteLine($"Problem 3 - Sort Strings by Length: [{string.Join(", ", names)}]");

            // Problem 4: Manager Inheritance
            Manager[] managers = new Manager[]
            {
                new Manager(1, "Dave", 120000m, "IT"),
                new Manager(2, "Eve", 95000m, "HR")
            };
            SortingAlgorithm<Manager>.Sort(managers);
            Console.WriteLine("\nProblem 4 - Sorted Managers:");
            foreach (var m in managers) Console.WriteLine($"  {m}");

            // Problem 5: Func Delegate for Name Length
            Func<Employee, Employee, int> nameLengthComparer = (e1, e2) => e1.Name.Length.CompareTo(e2.Name.Length);
            SortingTwo.Sort(employees, nameLengthComparer);
            Console.WriteLine("\nProblem 5 - Sorted Employees by Name Length:");
            foreach (var emp in employees) Console.WriteLine($"  {emp}");

            // Problem 6: Anonymous Function vs Lambda
            int[] numbers2 = { 4, 1, 3, 2 };
            SortingTwo.Sort(numbers2, delegate (int a, int b) { return a.CompareTo(b); });
            Console.WriteLine($"\nProblem 6 - Anonymous Function Sort: [{string.Join(", ", numbers2)}]");

            // Problem 7: Generic Swap
            int[] swapArr = { 10, 20 };
            SortingAlgorithm<Employee>.Swap(ref swapArr[0], ref swapArr[1]);
            Console.WriteLine($"\nProblem 7 - Generic Swap Result: [{string.Join(", ", swapArr)}]");



            // Problem 8: Multi-Criteria Sorting
            Employee[] multiList = new Employee[]
            {
                new Employee(1, "Zara", 60000m),
                new Employee(2, "Adam", 60000m),
                new Employee(3, "Bob", 80000m)
            };
            SortingTwo.Sort(multiList, (e1, e2) =>
            {
                int salaryComp = e1.Salary.CompareTo(e2.Salary);
                return salaryComp != 0 ? salaryComp : e1.Name.CompareTo(e2.Name);
            });
            Console.WriteLine("\nProblem 8 - Multi-Criteria Sorted Employees:");
            foreach (var emp in multiList) Console.WriteLine($"  {emp}");

            // Problem 9: default(T)
            Console.WriteLine($"\nProblem 9 - Default Values: Int={DefaultUtility.GetDefault<int>()}, String={DefaultUtility.GetDefault<string>() ?? "null"}");

            // Problem 10: Array Cloning and Sorting
            Employee[] clonedEmployees = (Employee[])employees.Clone();
            SortingAlgorithm<Employee>.Sort(clonedEmployees);
            Console.WriteLine($"\nProblem 10 - Cloned Array Sorted Successfully (Length: {clonedEmployees.Length})");

            // Problem 11: String Transformations
            List<string> words = new List<string> { "hello", "world" };
            List<string> upperWords = StringUtility.TransformStrings(words, s => s.ToUpper());
            Console.WriteLine($"\nProblem 11 - Transformed Uppercase: [{string.Join(", ", upperWords)}]");

            // Problem 12: Math Operations via Delegate
            int mathResult = MathUtility.ExecuteOperation(10, 5, (a, b) => a * b);
            Console.WriteLine($"\nProblem 12 - Delegate Math Operation (10 * 5): {mathResult}");

            // Problem 13: Generic Transformer
            List<int> intList = new List<int> { 10, 20, 30 };
            List<string> strList = TransformUtility.Map(intList, i => $"Val_{i}");
            Console.WriteLine($"\nProblem 13 - Generic Mapping (int -> string): [{string.Join(", ", strList)}]");

            // Problem 14: Func Square
            Func<int, int> squareFunc = x => x * x;
            List<int> squares = intList.Select(squareFunc).ToList();
            Console.WriteLine($"\nProblem 14 - Func Square Results: [{string.Join(", ", squares)}]");

            // Problem 15: Action Printing
            Action<string> printAction = s => Console.WriteLine($"  [Action Output]: {s}");
            Console.WriteLine("\nProblem 15 - Action Delegate Execution:");
            words.ForEach(printAction);

            // Problem 16: Predicate Filtering
            Predicate<int> isEven = x => x % 2 == 0;
            List<int> evens = intList.Where(x => isEven(x)).ToList();
            Console.WriteLine($"\nProblem 16 - Predicate Filtered Evens: [{string.Join(", ", evens)}]");

            // Problem 17 & 19: Filtering with Anonymous Functions & Lambdas
            List<string> sampleStrings = new List<string> { "apple", "cat", "elephant", "dog" };
            List<string> filteredLambdas = sampleStrings.Where(s => s.Length > 3 || s.Contains("e")).ToList();
            Console.WriteLine($"\nProblem 19 - Lambda Filtered Strings: [{string.Join(", ", filteredLambdas)}]");

            // Problem 20: Lambda Double Operations
            Func<double, double, double> exponentiate = (b, exp) => Math.Pow(b, exp);
            Console.WriteLine($"\nProblem 20 - Lambda Exponentiation (2^8): {exponentiate(2, 8)}");

            Console.WriteLine("\n=== PART 02 & PART 03 DEMO ===");
            Console.WriteLine("Refer to corresponding Regions in the source code comments above for full articles & reports.");
        }
       
    }
    #endregion
}