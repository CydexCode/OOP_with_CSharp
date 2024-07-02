using System;
using System.Collections.Generic;

namespace OOP_with_CSharp
{
    class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }

        public Person(string name, string id)
        {
            Name = name;
            ID = id;
        }
    }

    class Student : Person
    {
        public int GradeLevel { get; set; }
        private List<string> courses;

        public Student(string name, string id, int gradeLevel) : base(name, id)
        {
            GradeLevel = gradeLevel;
            courses = new List<string>();
        }

        public void EnrollInCourse(string course)
        {
            courses.Add(course);
        }

        public void DisplayCourses()
        {
            Console.WriteLine($"{Name} is enrolled in the following courses:");
            foreach (var course in courses)
            {
                Console.WriteLine(course);
            }
        }
    }

    abstract class Course
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }

        public Course(string courseName, string courseCode)
        {
            CourseName = courseName;
            CourseCode = courseCode;
        }

        public abstract void DisplayCourse();
    }

    class OnlineCourse : Course
    {
        public string Platform { get; set; }

        public OnlineCourse(string courseName, string courseCode, string platform) : base(courseName, courseCode)
        {
            Platform = platform;
        }

        public override void DisplayCourse()
        {
            Console.WriteLine($"Online Course: {CourseName}, Code: {CourseCode}, Platform: {Platform}");
           
        }
        
    }

    class OfflineCourse : Course
    {
        public string Location { get; set; }

        public OfflineCourse(string courseName, string courseCode, string location) : base(courseName, courseCode)
        {
            Location = location;
        }

        public override void DisplayCourse()
        {
            Console.WriteLine($"Offline Course: {CourseName}, Code: {CourseCode}, Location: {Location}");
        }
    }

    class StudentManagementSystem
    {
        private List<Student> students;
        private List<Course> courses;

        public StudentManagementSystem()
        {
            students = new List<Student>();
            courses = new List<Course>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public void EnrollStudentInCourse(string studentId, string courseCode)
        {
            Student student = students.Find(s => s.ID == studentId);
            Course course = courses.Find(c => c.CourseCode == courseCode);

            if (student != null && course != null)
            {
                student.EnrollInCourse(course.CourseName);
                Console.WriteLine($"{student.Name} has been enrolled in {course.CourseName}");
            }
            else
            {
                Console.WriteLine("Student or course not found.");
            }
        }

        public void DisplayStudents()
        {
            Console.WriteLine("");
            Console.WriteLine("Students:");
            foreach (var student in students)
            {
                Console.WriteLine("");
                Console.WriteLine($"Name: {student.Name}, ID: {student.ID}, Grade Level: {student.GradeLevel}");

                student.DisplayCourses();
            }
        }

        public void DisplayCourses()
        {
            Console.WriteLine("");
            Console.WriteLine("Courses:");
            foreach (var course in courses)
            {
                course.DisplayCourse();

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StudentManagementSystem sms = new StudentManagementSystem();

            Student student1 = new Student("Alice", "S001", 10);
            Student student2 = new Student("Bob", "S002", 11);


            sms.AddStudent(student1);
            sms.AddStudent(student2);


            Course onlineCourse = new OnlineCourse("Introduction to Programming", "C101", "Udemy");
            Course offlineCourse = new OfflineCourse("Advanced Mathematics", "C102", "Room 301");

            sms.AddCourse(onlineCourse);
            sms.AddCourse(offlineCourse);


            sms.EnrollStudentInCourse("S001", "C101");
            sms.EnrollStudentInCourse("S002", "C102");

            Console.WriteLine("");

            sms.DisplayStudents();
            sms.DisplayCourses();

            Console.ReadKey();
        }
    }
}
