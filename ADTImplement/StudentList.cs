using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class StudentList : LinkList<CourseList, string>, INode<string>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public INode<string> Next { get; set; } = null;
        public string Value { get => Name; set => Name = value; }

        public override String ToString()
        {
            return "name:" + Name + ",Age:" + Age;
        }

        public CourseList Enroll(CourseList course)
        {
            this.Append(course);
            course.Append(this);
            return course;
        }
    }
}
