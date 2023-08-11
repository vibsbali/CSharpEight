using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;

namespace CSharpEight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BlogPost post = null;
            PrintPostInfo(post);
        }

        static void PrintPostInfo(BlogPost post)
        {
            Console.WriteLine($"{post.Title} ({post.Title.Length})");

            foreach (var comment in post.Comments)
            {
                var preview = comment.Body.Length > 10 ? $"{comment.Body.Substring(0, 10)}..." : comment.Body;

                Console.WriteLine($"{comment.PostedBy.Name} ({comment.PostedBy.Email}");
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Teacher HomeRoomTeacher { get; set; }
        public int GradeLevel { get; set; }

        public Student(string firstName, string lastName, Teacher homeRoomTeacher, int gradeLevel)
        {
            FirstName = firstName;
            LastName = lastName;
            HomeRoomTeacher = homeRoomTeacher;
            GradeLevel = gradeLevel;
        }

        public void Deconstruct(out string firstName, out string lastName, out Teacher homeRoomTeacher, out int gradeLevel)
        {
            firstName = FirstName;
            lastName = LastName;
            homeRoomTeacher = HomeRoomTeacher;
            gradeLevel = GradeLevel;
        }

    }

    public class Teacher
    {
        public Teacher(string firstName, string lastName, string subject)
        {
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public void Deconstruct(out string firstName, out string lastName, out string subject)
        {
            firstName = FirstName;
            lastName = LastName;
            subject = Subject;
        }
    }

    public static class PositionalPatternSample
    {
        //useful for recursive
        public static bool IsInSeventhGradeMath(Student s)
        {
            return s is (_, _, (_, _, "Math"), 7);
        }
    }


    class BlogPost
    {
        public BlogPost(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
        public List<Comment> Comments { get; } = new List<Comment>();
    }

    internal class Comment  
    {
        public Comment(string body, Author postedBy)
        {
            Body = body;
            PostedBy = postedBy;
        }

        public string Body { get; set; }
        public Author PostedBy { get; set; }
    }

    internal class Author   
    {
        public Author(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}