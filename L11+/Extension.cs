using System.Collections.Generic;

namespace L11
{
    static class Extension
    {
        public static List<Student> FindStudents(this List<Student> students, Student.StudentPredicateDelegate findPredicate)
        {
            List<Student> result = new List<Student>();

            foreach (var student in students)
            {
                if (findPredicate(student))
                {
                    result.Add(student);
                }
            }

            return result;
        }
    }
}