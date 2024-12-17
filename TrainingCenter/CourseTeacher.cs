using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CourseTeacher
    {
        public int Id { get; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }

        public CourseTeacher(Teacher teacher, Course course)
        {
            this.Teacher = teacher;
            this.Course = course;
        }
    }
}
