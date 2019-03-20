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
        public void CopyProperty(CourseList course){
            this.Teacher = course.Teacher;
        }
        ///暂时通过每个课程克隆传入对象来实现了
        public StudentList Enroll(StudentList student){
            StudentList individualStudent = null;
            //不存在才插入
            if(this.Find(student.Value) == null){
                individualStudent = this.Append(student.Value);
                individualStudent.CopyProperty(student);
                var individualCourse = student.Append(this.Value);
                individualCourse.CopyProperty(this);
            }
            return individualStudent;
        }
    }
}
