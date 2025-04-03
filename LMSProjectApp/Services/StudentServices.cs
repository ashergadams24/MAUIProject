using LearningManagementSystem;
using System;
using System.Collections.ObjectModel;

public class StudentServices
{
    public ObservableCollection<Student> Students { get; private set; } = new ObservableCollection<Student>();

    private static StudentServices? _instance;

    public void Add(Student student)
    {
        BackDatabase.Student.Add(student);
        Students.Add(student); 
    }

    public static StudentServices Current
    {
        get
        {
            if (_instance == null)
            {
                _instance = new StudentServices();
            }
            return _instance;
        }
    }

    public Student? GetById(int id)
    {
        return BackDatabase.People.FirstOrDefault(p => p.studentId == id);
    }

    public void Remove(Student student)
    {
        BackDatabase.Student.Remove(student);
        Students.Remove(student);
    }


}
