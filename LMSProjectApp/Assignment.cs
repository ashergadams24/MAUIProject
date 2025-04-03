using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem
{
    public class Assignment
    {
        private string? assignmentName;
        private string? assignmentDescription;
        private string? totalAvaialablePoints;
        private string? dueDate;

        public string? GetAssgnName
        {
            get { return assignmentName; }
            set { assignmentName = value; }
        }

        public string? GetAssgnDescription
        {
            get { return assignmentDescription; }
            set { assignmentDescription = value; }
        }

        public string? GetTAP
        {
            get { return totalAvaialablePoints; }
            set { totalAvaialablePoints = value; }
        }

        public string? GetDueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public void CreateAssignment()
        {
            Console.WriteLine("Enter Assignment Name: ");
            assignmentName = Console.ReadLine();

            Console.WriteLine("Enter Assignment Description: ");
            assignmentDescription = Console.ReadLine();

            Console.WriteLine("Enter Total Available Points for Assignment: ");
            totalAvaialablePoints = Console.ReadLine();

            Console.WriteLine("Enter Due Date: ");
            dueDate = Console.ReadLine();
        }
    }
}
