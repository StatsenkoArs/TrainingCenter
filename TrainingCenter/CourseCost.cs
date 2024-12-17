using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public enum CourseType
    {
        online,
        offline
    }
    public class CourseCost
    {
        public int Id { get; }
        public CourseType TrainingType { get; set; }
        public double Cost;

        public CourseCost(int id, CourseType trainingType, double cost)
        {
            this.Id = id;
            this.TrainingType = trainingType;
            this.Cost = cost;
        }
    }
}
