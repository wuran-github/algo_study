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
        public void CopyProperty(StudentList student){
            this.Age = student.Age;
        }
        public CourseList Enroll(CourseList course)
        {
            CourseList individualCourse = null;
            //不存在才插入
            if(this.Find(course.Value) == null){
                individualCourse = this.Append(course.Value);
                individualCourse.CopyProperty(course);
                var individualStudent = course.Append(this.Value);
                individualStudent.CopyProperty(this);
            }
            return individualCourse;
        }
    }
}
