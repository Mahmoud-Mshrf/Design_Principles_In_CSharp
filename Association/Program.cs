namespace Association
{
    // Association is a relationship between two separate classes that establishes through their objects.
    // In association, an object of one class can have a reference to an object of another class.
    // It can be one-to-one, one-to-many, many-to-one, many-to-many.
    // It can be unidirectional or bidirectional.
    // Association is the general relationship between objects.
    // Aggregation and Composition are the specific forms of association.
    // Association is represented by a solid line.
    // Association is a weak relationship.
    // Association is a relationship where all objects have their own lifecycle and there is no owner.
    // Let's take an example of a teacher and a student. Multiple students can associate with a single teacher and a single student can associate with multiple teachers.
    // The teacher and student are independent entities.
    // Both can be created and deleted independently.
    // Both can exist without each other.
    // The student can exist without a teacher and a teacher can exist without a student.

    internal class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher1 = new Teacher("Teacher1");
            Teacher teacher2 = new Teacher("Teacher2");

            Student student1 = new Student("Student1");
            Student student2 = new Student("Student2");

            teacher1.AddStudent(student1);
            teacher1.AddStudent(student2);

            teacher2.AddStudent(student1);

            student1.AddTeacher(teacher1);
            student1.AddTeacher(teacher2);

            student2.AddTeacher(teacher1);

            Console.WriteLine($"Students of {teacher1.Name} :");
            foreach (var student in teacher1.students)
            {
                Console.WriteLine($"  {student.Name}");
            }

            Console.WriteLine($"Students of {teacher2.Name} :");
            foreach (var student in teacher2.students)
            {
                Console.WriteLine($"  {student.Name}");
            }
            Console.WriteLine($"Teachers of {student1.Name} :");
            foreach (var teacher in student1.teachers)
            {
                Console.WriteLine($"  {teacher.Name}");
            }
            Console.WriteLine($"Teachers of {student2.Name} :");
            foreach (var teacher in student2.teachers)
            {
                Console.WriteLine($"  {teacher.Name}");
            }
        }
    }
    class Teacher 
    {
        public string Name { get; private set; }
        public List<Student> students { get; set; } = new List<Student>();
        public Teacher(string name)
        {
            Name = name;
        }
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
    }
    class Student
    {
        public string Name { get; private set; }
        public List<Teacher> teachers { get; set;} = new List<Teacher>();
        public Student(string name)
        {
            Name = name;
        }
        public void AddTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
        }
    }
}
