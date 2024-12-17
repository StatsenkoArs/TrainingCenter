using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class GroupSchedule
    {
        public GroupSchedule(int id, Course course, DateTime startDate, Teacher teacher, int seatsAvailable, CourseCost courseCost)
        {
            Id = id;
            Course = course;
            StartDate = startDate;
            Teacher = teacher;
            SeatsAvailable = seatsAvailable;
            CourseCost = courseCost;
        }

        public int Id { get; }
        public Course Course { get; set; }
        public DateTime StartDate { get; set; }
        public Teacher Teacher { get; set; }
        public int SeatsAvailable { get; set; }
        public CourseCost CourseCost { get; set; }
    }
}
