using System;
using AnotherNamespace;

namespace OOP
{
    class Point
    {
        public int x;
        public int y;
        private string color = "red";
        int z; // by default all fields are private

        public void Print()
        {
            Console.WriteLine($"Custom Print method of class Point: x = {x}, y = {y}");
        }

        public string GetColor()
        {
            return color;
        }
    }

    class Square
    {
        public Square() {} // empty parameters constructor
        
        public Square(int size) // constructor
        {
            this.size = size; // we can use this for example if we have name conflict to point out class field
            angles = 4;
        }
        
        public Square(int size, int angles) // we can overload constructor
        {
            this.size = size;
            this.angles = angles;
        }

        public Square(Square square) // another useful kind of constructor. We can use it for example when we want to copy one class exemplar to another
        {
            size = square.size;
            angles = square.angles;
            color = square.color;
        }
        
        // we can create chain of constructors to not duplicate code. In current constructor we call our second constructor with size and angles
        public Square(int size, int angles, string color) : this(size, angles)
        {
            this.color = color;
        }

        public int size;
        public int angles;
        public string color;

        private int price;
        
        // Property - special field of class with built-in getter and setter
        // property also can be virtual/abstract/protected

        public int PriceProperty // property to work with private field price, get and set - accessors
        {
            // we can remove one of the accessors if we want
            // accessors can be private - possibly used only inside class
            get
            {
                return price;
            }
            set
            {
                price = value; // value - argument of set accessor
            }
        }

        // the shortest way to declare property - auto property
        // work exactly in the same way as PriceProperty above but without separate private field
        public int ShortProperty { get; set; }
        
        // example with private set
        public int ShortPropertyPrivateSet { get; private set; }

        // array property with private set
        // !! BUT !! array - reference type, so when we get array value in main program we can change it DESPITE OF PRIVATE SET !!
        // for example remove values
        // so it's good practice to keep all reference type fields as private and create public getters for copy them by value
        // or just getByIndex method
        public int[] ArrayProperty { get; private set; } = { 1, 2, 3 };

        // with logic in getter we can transform property to something like computed in mobx
        public bool IsArray
        {
            get
            {
                return ArrayProperty.Length > 0;
            }
            // or new syntax
            // get => ArrayProperty.Length > 0;
        }

        // we have access to static fields from class, not from class exemplar.
        // Static fields are "shared" for all class exemplars and can be used for storing some shared information
        // or for creating util classes with some functionality (static class)
        public static int staticField = 10;

        public void SetStaticField(int staticField)
        {
            // if we have name conflict we can not use this as above, because this - reference to current class exemplar,
            // but static fields relate to class, not class exemplar
            Square.staticField = staticField;
            // staticField = funcArgument; // or we can just change the name of func argument
        }

        public void PrintStaticField()
        {
            Console.WriteLine($"Print static field: staticField = {staticField}");
            
            // non static methods can work with static fields and methods
            // staticField = 1; - WORKS
            // StaticPrint(); - WORKS
        }

        public static void StaticPrint()
        {
            // in static methods we can only work with static fields/methods
            // PrintStaticField(); // Error - Cannot access non-static method 'PrintStaticField' in static context
            // size = 1; // Error - Cannot access non-static field 'size' in static context
            Console.WriteLine($"Print static field by calling static method: {staticField}");
        }
        
        // property also can be static
        public static int StaticProperty { get; set; }

        // class may have static constructor. It may be needed to set up static fields, for example, by parsing config files
        // some rules:
        // 1. no access modificator (public/private)
        // 2. no arguments
        // 3. no overload
        // 4. static constructor calls only once - during very first interaction with class (new Class() - before main constructor, Class.StaticMethod - before StaticMethod etc)
        static Square()
        {
            
        }

        // const - we must assign a value to this field immediately and can never change it again
        // const fields are static by default
        public const string Error = "error";
        
        // readonly - we can assign a value to this immediately OR in constructor and can never change it again
        // readonly fields are NOT static by default, but can be transformed to it by "static" word
        public readonly string Success;

        // children can work with protected fields, but class exemplars can't
        protected int protectedField;
        
        // virtual - special modificator, child class can override only virtual methods
        public virtual void VirtualMethod() {}
    }

    // class also can be static. some rules:
    // 1. can't be used as type for variable
    // 2. can't be created as class exemplar using "new"
    // 3. can't contain non static fields/methods/constructors
    // 4. can't use word "this" (only for extensions)
    // 5. can't use inheritance (наследование)
    static class StaticClass { }
    
    // Extensions - we can modify and supplement class with some methods/behavior using extensions. It can be only static class
    // in this example we want to add method print to struct DateTime
    static class ExtensionPrint
    {
        public static void Print(this DateTime dateTime)
        {
            Console.WriteLine($"Extension Print works: dateTime = {dateTime}");
        }
        
        // first argument - always struct/class for modifying, and then other arguments
        public static void PrintWithArguments(this DateTime dateTime, int day)
        {
            Console.WriteLine($"Extension PrintWithArguments works: dateTime = {dateTime}, day = {day}");
        }
    }
    
    // Inheritance
    // parent constructor calls before child constructor
    class SquareChild : Square
    {
        // implementation of method with the same name as inside parent class - overriding
        public override void VirtualMethod()
        {
            // base.VirtualMethod();
            int a = 5;
        }

        public void PrintThatIsChild()
        {
            Console.WriteLine("Hi, I am a child of Square class! Inheritance works!");
            // children can work with protected fields, but class exemplars can't
            int a = protectedField;
        }
    }
    
    // Inheritance
    // base - call of parent constructor. With base we can call specific overloaded constructor of parent class
    class SquareChild2 : Square
    {
        public SquareChild2(int s, int a) : base(s, a)
        {
            base.PrintStaticField(); // also we can use base as reference to parent class, but it is unnecessary
            PrintStaticField(); // it also works
        }
        
        public void test() {}
    }

    // abstract classes can't be created as class exemplars (new Class()), and can be only inherited
    // such classes is used for describing some idea, some interface, some base for other classes
    abstract class AbstractWeapon
    {
        // abstract method - can be placed only inside abstract class, can't have any logic, just modificators and arguments
        // any child of abstract class MUST implement all abstract methods, so they used as agreement, contract
        public abstract void Fire(int bullets);

        // but abstract class can also contain regular, non abstract methods
        public void Reload()
        {
            // get a type of child
            Console.WriteLine($"{GetType().Name} - Reloaded");
        }
    }

    class LaserGun : AbstractWeapon
    {
        // child of abstract class overrides abstract method
        public override void Fire(int bullets)
        {
            Console.WriteLine($"Laser Gun: {bullets}");
        }
    }
    
    class PlasmaGun : AbstractWeapon
    {
        // child of abstract class overrides abstract method
        public override void Fire(int bullets)
        {
            Console.WriteLine($"Plasma Gun: {bullets}");
        }
    }

    class Player
    {
        // so now Player can shoot from ANY weapon, that is inherited from AbstractWeapon, because all of them
        // have method Fire()
        public void Shoot(AbstractWeapon weapon)
        {
            weapon.Fire(5);
        }
    }
    
    // ********** Interfaces **********
    // like an abstract classes, interfaces are used to describe ideas, contract, type (like interfaces in type script)
    // BUT, the main difference from abstract class is: they can use multiple inheritance, and classes can use
    // inheritance from multiple interfaces
    // interfaces can't have constructor or realization of methods or fields. Only their contract

    interface IDataProvider
    {
        // int a; // error - Interface cannot contain instance fields. So interface can contain only methods and properties (!!)

        // all interface methods are public by default, because the idea of interface - describe public contract
        string GetData();
    }

    interface IDataProcessor
    {
        void ProcessData(IDataProvider dataProvider);
    }

    // class implements interface
    class DataProcessor : IDataProcessor
    {
        public void ProcessData(IDataProvider dataProvider)
        {
            Console.WriteLine($"Data processor - log data: {dataProvider.GetData()}");
        }
    }

    class DbDataProvider : IDataProvider
    {
        public string GetData()
        {
            return "Data from Data base";
        }
    }
    
    class FileDataProvider : IDataProvider
    {
        public string GetData()
        {
            return "Data from File";
        }
    }
    
    class HttpDataProvider : IDataProvider
    {
        public string GetData()
        {
            return "Data from HTTP";
        }
    }
    
    // multiple implementation of interfaces
    class DataProcessorProvider : IDataProcessor, IDataProvider
    {
        public void ProcessData(IDataProvider dataProvider)
        {
            throw new NotImplementedException();
        }

        public string GetData()
        {
            throw new NotImplementedException();
        }
    }

    // interface can inherit one or more other interfaces
    interface IChildOfOthers : IDataProcessor, IDataProvider
    {
        
    }

    internal class Program
    {
        static Point GetPoint()
        {
            Point point = new Point();
            point.x = 5;
            point.y = 1;

            return point;
        }

        static void PrintPoint(Point point)
        {
            Console.WriteLine($"Point: x = {point.x}, y = {point.y}");
        }
        
        public static void Main(string[] args)
        {
            // !!! All functions in C# are methods, because they can not exist outside of a class
            
            Point point = new Point();
            point.x = 4;
            point.y = 6;
            
            // as class is reference type, we can set its value as null
            point = null;

            Point point1 = GetPoint();
            PrintPoint(point1);
            point1.Print();

            // !!! class Person is placed in separate file, but in the same namespace, so we can simply use it here without import
            Person person = new Person();
            
            // !!! class is placed in separate file and in another namespace, so we use import - "using AnotherNamespace;"
            AnotherNamespaceClass another = new AnotherNamespaceClass();

            Square square = new Square(5);
            Square square1 = new Square(5, 10); // overloaded constructor

            square.PriceProperty = 10; // call of set method
            int price = square.PriceProperty; // call of get method

            // we don't need to create class exemplar to access to static field
            int staticVar = Square.staticField;
            
            square.SetStaticField(5); // set static field from one class exemplar
            square1.PrintStaticField(); // 5 - print from another, static field is shared because relates to class
            
            // call static method from class, not class exemplar
            Square.StaticPrint();
            
            DateTime date = DateTime.Now;
            date.Print(); // our extension works for every vars with type DateTime
            DateTime.Now.Print();
            DateTime.Now.PrintWithArguments(23);

            // partial class works in the same way like regular class
            Partial partial = new Partial();
            partial.PrintA();
            
            // special syntax to initialize class exemplar and its public fields
            Point specialPoint = new Point
            {
                x = 5,
                y = 8,
            };

            // with this syntax we also can use non default constructors with arguments
            Square squareSpecial = new Square(8, 4)
            {
                color = "blue",
            };
            
            // inheritance
            SquareChild squareChild = new SquareChild();
            squareChild.PrintThatIsChild(); // child method
            squareChild.PrintStaticField(); // parent method
            // squareChild.protectedField; // error - Cannot access protected field 'protectedField' here

            // Upcasting - assign child class to variable with parent class type
            Square baseSquare = new SquareChild(); // it also works, because SquareChild is the Square class too, but: ↓
            // baseSquare.PrintThatIsChild(); // error - baseSquare contains only fields and methods of Square, not SquareChild
            // it can be useful, for example, if method works with parent class, then it will work with child class
            
            // Dawncasting - assign parent class to variable with child class type
            SquareChild squareChildDown = (SquareChild)baseSquare; // don't work without explicit casting
            // BUT, child class must be assigned before Dawncasting to parent class variable through the Upcasting
            // otherwise, we will have bugs when we will try to get fields of child class which don't exist in parent

            // as object is the base parent class for all other data types, we can assign any class to it,
            // but such a class will have only base methods for object
            object objectSquare = new SquareChild();
            
            // we can do explicit type cast and return SquareChild functionality to squareSquareChild
            SquareChild squareSquareChild = (SquareChild)objectSquare;
            
            // ********** AS and IS operators **********
            
            // BUT !! it is unsafe casting, because it can be any data type inside objectSquare, for example:
            // object objectSquare = "test string";
            // SquareChild squareSquareChild = (SquareChild)objectSquare; <- error - can't resolve types
            
            SquareChild squareSquareChild2 = objectSquare as SquareChild;

            // as returns null if it can't do type casting
            if (squareSquareChild2 != null)
            {
                squareSquareChild2.PrintThatIsChild();
            }
            
            // is operator allow us to check type casting success and assign transformed class to new variable at the same time
            if (objectSquare is SquareChild newSquareChild)
            {
                newSquareChild.PrintThatIsChild();
            }
            
            // or just check without assign to new variable
            if (objectSquare is SquareChild)
            {
                SquareChild squareSquareChild3 = (SquareChild)objectSquare; // now it is safe
            }
            
            // or we can use switch case if we have different possible results
            switch (objectSquare)
            {
                case SquareChild sqChild:
                    sqChild.PrintThatIsChild();
                    break;
            }
            
            
            // ********** Abstract classes **********
            // we create array of all weapons with type AbstractWeapon
            AbstractWeapon[] inventory = new AbstractWeapon[] { new LaserGun(), new PlasmaGun() };
            Player player = new Player();

            // and then player can shoot from any weapon because they all are inherited from base abstract class
            foreach (var weapon in inventory)
            {
                player.Shoot(weapon);
                weapon.Reload(); // LaserGun - Reloaded // PlasmaGun - Reloaded
            }
            
            
            // ********** Interfaces **********
            IDataProcessor dataProcessor = new DataProcessor();
            
            // so now we can use any class which implements interface IDataProvider
            dataProcessor.ProcessData(new DbDataProvider());
            dataProcessor.ProcessData(new FileDataProvider());
            dataProcessor.ProcessData(new HttpDataProvider());

            var explicitInterfaceImplementation = new ExplicitInterfaceImplementation();
        }
    }
}