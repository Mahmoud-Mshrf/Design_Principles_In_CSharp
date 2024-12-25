namespace Aggregation
{
    // Aggregation is a special form of association. It is a relationship between two classes like association, however, it is a directional association, which means it is strictly a one-way association.
    // It represents a "whole-part" relationship.
    // In Aggregation, the child class can exist independently of the parent class.
    // Aggregation is represented by an empty diamond.
    // Aggregation is a weak relationship.
    // Aggregation is a relationship where the child can exist independently of the parent.
    // Let's take an example of a class and students. A class can have multiple students, but a student can only belong to one class.
    // If a class is deleted, the students will not be deleted.
    // The class and students are independent entities.
    // The class can exist without students and students can exist without a class.
    // The class is not responsible for the creation and destruction of students.
    // The class and students have their own lifecycle.
    // The class can have a reference to students.
    // The student can have a reference to the class.
    // The class and students are not strongly dependent on each other.
    // The class and students can be created and deleted independently.
    // Bidirectional references can lead to circular dependencies, which may complicate memory management and debugging. Use them only when necessary and avoid them in scenarios where simpler unidirectional relationships suffice.
    // in this example, the student has a reference to the class room just to make the student aware of the class room he belongs to it.
    // aggregation is unidirectional relationship by default, but you can make it bidirectional by adding a reference to the parent class in the child class but it may lead to circular dependencies, which may complicate memory management and debugging but in this example, it's not a problem and we add it just to make the student aware of the class room he belongs to it.
    internal class Program
    {
        static void Main(string[] args)
        {
            var classRoom = new ClassRoom("ClassRoom1");
            var student1 = new Student("Student1");
            var student2 = new Student("Student2");
            var student3 = new Student("Student3");
            var students = new List<Student> { student2, student3 };
            classRoom.AddStudent(student1);
            classRoom.AddStudents(students);
            foreach (var student in classRoom.Students)
            {
                Console.WriteLine($"{student.Name} belongs to {student.ClassRoom.Name}");
            }
            Console.ReadKey();
        }
    }
    class ClassRoom
    {
        public string Name { get; set; }

        public ClassRoom(string name)
        {
            Name = name;
        }

        public List<Student> Students { get; set; } = new List<Student>();
        public void AddStudent(Student student)
        {
            Students.Add(student);
            student.ClassRoom = this;
        }
        public void AddStudents(List<Student> students)
        {
            Students.AddRange(students);
            foreach (var student in students)
            {
                student.ClassRoom = this;
            }
        }

    }
    class Student
    {
        public string Name { get; private set; }
        public ClassRoom ClassRoom { get;  set; }// just to make the student aware of the class room he belongs to it, but it may lead to circular dependencies, which may complicate memory management and debugging so it not preferred to make it bidirectional
        public Student(string name)
        {
            Name = name;
        }
    }

}
