using LearningManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static LearningManagementSystem.Student;

namespace MAUIProject1.ViewModels
{
    public class StudentOptionsViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string ClassificationString { get; set; }

        public int Id { get; set; }

        public StudentOptionsViewModel(int Id = 0) { 
            if (Id > 0)
            {
                LoadById(Id);
            }
        }

        public void AddPerson()
        {

            if (Id <= 0)
            {
                StudentServices.Current.Add(new Student { studentName = Name, Classification = StringToClass(ClassificationString) });
            }
            else
            {
                var refToUpdate = StudentServices.Current.GetById(Id) as Student;
                refToUpdate.studentName = Name;
                refToUpdate.Classification = StringToClass(ClassificationString);
            }
            Shell.Current.GoToAsync("//Instructor");
        }


        public void LoadById(int id)
        {
            if (id == 0) { return; }
            var person = StudentServices.Current.GetById(id) as Student;
            if (person != null)
            {
                Name = person.studentName;
                Id = person.studentId;
                ClassificationString = ClassToString(person.Classification);
            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(ClassificationString));

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private PersonClassification StringToClass(string s)
        {
            PersonClassification classification;
            switch (s)
            {
                case "S":
                    classification = PersonClassification.Senior;
                    break;
                case "J":
                    classification = PersonClassification.Junior;
                    break;
                case "O":
                    classification = PersonClassification.Sophomore;
                    break;
                case "F":
                default:
                    classification = PersonClassification.Freshman;
                    break;
            }

            return classification;
        }

        private string ClassToString(PersonClassification pc)
        {
            var classificationString = string.Empty;
            switch (pc)
            {
                case PersonClassification.Senior:
                    classificationString = "S";
                    break;
                case PersonClassification.Junior:
                    classificationString = "J";
                    break;
                case PersonClassification.Sophomore:
                    classificationString = "O";
                    break;
                case PersonClassification.Freshman:
                default:
                    classificationString = "F";
                    break;
            }
            return classificationString;
        }
    }
}
