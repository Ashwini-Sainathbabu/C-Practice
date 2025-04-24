using System;

class Student
{
    public string Name { get; set; }
    public int Marks { get; set; }
}

class LinQ
{
    public static void Main()
    {
        var names = new string[] { "Mark", "John", "Roger", "Michael", "Jackson" };
        System.Console.WriteLine("---Fluent Syntax---");
        foreach (var item in names)
        {
            System.Console.WriteLine(item);
        }

        System.Console.WriteLine("---Query Syntax---");
        var longNames = names.Where(x => x.Length > 4);
        foreach (var item in longNames)
        {
            System.Console.WriteLine(item);
        }

        System.Console.WriteLine("---Method Chaning Using Fluent Syntax---");
        var upperNamesFluent = names.Where(x => x.Length > 4).Select(y => y.ToUpper()).OrderBy(z => z);
        foreach (var item in upperNamesFluent)
        {
            System.Console.WriteLine(item);
        }

        System.Console.WriteLine("---Method Chaning Using Query Syntax---");
        var upperNamesQuery = from name in names
        where name.Length > 4
        let upperName = name.ToUpper()
        orderby upperName
        select upperName;

        foreach (var item in upperNamesQuery)
        {
            System.Console.WriteLine(item);
        }

        System.Console.WriteLine("----Fluent Syntax first value returning----");
        var firstName=  names.Where(x=>x.Length>4).OrderBy(x=>x).First();
        System.Console.WriteLine(firstName);

        System.Console.WriteLine("----Query Syntax first value returning mixed with fluent syntax----");
        var sortedNameFirst = (from name in names where name.Length >4 orderby name select name).First();
        System.Console.WriteLine(sortedNameFirst);

      // 3. Various LINQ methods
        System.Console.WriteLine("---Fluent syntax difference methods---");
        var seq=new int[]{3,4,6,5,7};

        var first = seq.First();
        Console.WriteLine(first);  // Output: 3

        var first1 = seq.FirstOrDefault();
        Console.WriteLine(first1);  // Output: 3

        var last = seq.Last();
        Console.WriteLine(last);  // Output: 7

        var last1 = seq.LastOrDefault();
        Console.WriteLine(last1);  // Output: 7

        Console.WriteLine($"Count the elements: {seq.Count()}");  // Output: 5
        Console.WriteLine($"Minimum element: {seq.Min()}");       // Output: 3
        Console.WriteLine($"Maximum  element: {seq.Max()}");      // Output: 7

        // Skip first 2 elements
        var skip = seq.Skip(2);
        Console.WriteLine("Elements after skipping first 2:");
        foreach (var item in skip)
        {
            Console.Write(item + " ");  // Output: 6 5 7
        }

        var take =seq.Take(2);
        Console.WriteLine("Elements taking last 2:");
        foreach (var item in take)
        {
            Console.Write(item + " ");  // Output: 3 4
        }
        

        System.Console.WriteLine("Return bool whether it exist or not");
        var exist =seq.Any(x=>x%2 ==0);
        System.Console.WriteLine(exist);  //Output: true

        System.Console.WriteLine("Concatenation");
        var seq1=new int[]{2,7,9,0};
        var seq3=seq1.Concat(seq);
        foreach (var item in seq3)
        {
            Console.Write(item + " ");  // Output: 2 7 9 0 3 4 6 5 7
        }

        // Progressive Query Construction
        var query=names.Where(x=>x.Length >4);
        query=query.OrderBy(x=>x);
        query =query.Select(x=>x.ToUpper());
        foreach (var item in query)
        {
            Console.Write(item + " ");  // Output:  JACKSON MICHAEL ROGER
        }
       
       //Using INTO keyword
        var filterName = from name in names
                         select name.Split(" ").First()
                         into firstName1
                         where firstName1.Length > 4
                         select firstName1;

        foreach (var item in filterName)
        {
            Console.Write(item + " ");  // Output:  Roger Michael Jackson
        }

        var nested =from name in names select name.Split(" ").First();
        var wrappingNested= from name in nested where name.Length >4 select name;
        var fluent =nested.Where(x=>x.Length >4);
        foreach (var item in wrappingNested)
        {
            Console.Write( "\n "+ item );  // Output:  Roger Michael Jackson
        }

        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Marks = 95 },
            new Student { Name = "Bob", Marks = 78 },
            new Student { Name = "Charlie", Marks = 88 },
            new Student { Name = "David", Marks = 60 },
            new Student { Name = "Eva", Marks = 82 }
        };

        // LINQ query using object initializer
        var result = from s in students
                     where s.Marks > 80
                     select new Student { Name = s.Name, Marks = s.Marks };

        // Display the result
        Console.WriteLine("\nName\tMarks");
        foreach (var student in result)
        {
            Console.WriteLine($"{student.Name}\t{student.Marks}");
        }
    }

}