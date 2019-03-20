using System;
using csharpDemo.ADT;

namespace csharpDemo.ADTImplement
{
    public class CourseList :LinkList<StudentList,string>, INode<string>
    {
        public INode<string> Next { get; set; } = null;
        public string Value { get => Name; set => Name = value; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public StudentList Student{get;set;} = null;
        public override String ToString(){
            return "name:"+Name+",teacher:"+Teacher;
        }
        public StudentList Enroll(StudentList student){
            this.Append(student);
            student.Append(this);
            return student;
        }
    }
}
