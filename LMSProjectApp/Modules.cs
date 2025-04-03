using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem
{
    public class Modules
    {
        private string? moduleName;
        private string? moduleDescription;
        public string? GetName
        {
            get { return moduleName; }
            set { moduleName = value; }
        }

        public string? GetDescription
        {
            get { return moduleDescription; }
            set { moduleDescription = value; }
        }

        public void CreateModule()
        {
            Console.WriteLine("Enter Module Name: ");
            moduleName = Console.ReadLine();

            Console.WriteLine("Enter Module Description: ");
            moduleDescription = Console.ReadLine();
        }
    }
}
