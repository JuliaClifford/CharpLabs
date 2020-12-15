namespace L11
{
    public class Student
    {
        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public delegate bool StudentPredicateDelegate(Student student);
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public static bool IsEighteen(Student student) => student.Age >= 18;
        public static bool NameStartsWithA(Student student) => student.FirstName?[0] == 'A';
        public static bool SurnameLongerThanThree(Student student) => student.LastName?.Length > 3;
        
        public override string ToString()
        {
            return $"First name: {FirstName}\n" +
                   $"Last Name: {LastName}\n" +
                   $"Age: {Age}\n";
        }
    }
}