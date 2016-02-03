using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    class Program
    {
        static void Main(string[] argv)
        {
            Foo x = new Foo();

            // "set" will be written to the console
            x.Bar = 5;

            // "get" will be written to the console
            int y = x.Bar;

            // Foo.Bar reflects the changes Foo.Baz makes
            x.Baz = 5;
            Console.WriteLine(x.Bar);

            // Foo.Baz ignores changes made by Foo.Bar
            x.Bar = 5;
            Console.WriteLine(x.Baz);

            Fizz z = new Fizz();

            // Nothing is written to the console
            z.Bizz = 5;
            y = z.Bizz;

            // illegal statement, Fizz.Dizz is readonly
            //z.Dizz = 5;

            // z.Dizz is null, with no way to initialize it
            y = z.Dizz;

            Jim j = new Jim();

            // Likewise, nothing is written to the console
            // z.Bizz and j.jam behave identically
            j.jam = 5;
            y = j.jam;

            // same problem as Fizz.Dizz
            //j.flam = 5;
            y = j.flam;

            // demonstrating different methods for handling a Person's age
            Person bob = new Person();
            bob.SetAge(years: 23);
            Console.WriteLine("Bob's age in years: " + bob.Age);
            Console.WriteLine("Bob's age in months: " + bob.AgeMonths);
            bob.AgeYears = 24;
            Console.WriteLine("Bob's new age: " + bob.Age);
            bob.AgeMonths = 300;
            Console.WriteLine("Bob's new age: " + bob.Age);
            

            Person baby = new Person();
            baby.SetAge(months: 2);
            Console.WriteLine("Baby's age: " + baby.Age);
            baby.AgeMonths = 3;
            Console.WriteLine("Baby's new age:" + baby.Age);
            Console.WriteLine("Baby's age in years: " + baby.AgeYears);

            // pause
            Console.ReadLine();
        }
    }

    class Foo
    {
        private int _bar;
        public int Bar
        {
            get
            {
                Console.WriteLine("Foo.Bar get");
                return _bar;
            }

            set
            {
                Console.WriteLine("Foo.Bar set");
                _bar = value;
            }
        }

        public int Baz
        {
            get
            {
                Console.WriteLine("hope you like 4");
                return 4;
            }

            set
            {
                Console.WriteLine("that looks like a 4");
                _bar = 4;
            }
        }
    }

    class Fizz
    {
        public int Bizz { get; set; }
        public int Dizz { get; }
    }

    class Jim
    {
        public int jam;

        // The compiler should yell about this
        public readonly int flam;
    }

    class Person
    {
        // Holds a person's age in months
        private uint _age;

        public string Age
        {
            get
            {
                if (_age < 12)
                {
                    return _age.ToString() + " month(s)";
                }
                else
                {
                    return (_age / 12).ToString() + " year(s)";
                }
            }
        }

        public void SetAge(uint years = 0, uint months = 0)
        {
            if (years == 0 && months == 0)
            {
                throw new ArgumentException("Must specify at least a number of months or a number of years.");
            }
            else
            {
                _age = (years * 12) + months;
            }
        }

        public uint AgeMonths
        {
            get
            {
                return _age;
            }

            set
            {
                _age = value;
            }
        }

        public uint AgeYears
        {
            get
            {
                return _age / 12;
            }

            set
            {
                _age = value * 12;
            }
        }
    }
}
