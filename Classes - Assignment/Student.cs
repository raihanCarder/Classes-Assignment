using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Making_a_Class
{
    class Student: IComparable<Student>
    {
        private static Random generator = new Random();
        private string _firstName;
        private string _lastName;
        private string _email;
        private int _studentId;
        private int _age;

        // Constructor

        public Student(string firstName, string lastName)
        {
            this._firstName = firstName.ToUpper();
            this._lastName = lastName.ToUpper();
            this._studentId = generator.Next(100, 1000) + 555000;
            this._age = generator.Next(14, 19);
            GenerateEmail();
        }

        // Getters, Setters

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                this._firstName = value;
                GenerateEmail();

            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                this._email = value;
                GenerateEmail();

            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set // Makes it so user can change value
            {
                this._lastName = value;
                GenerateEmail();
            }
        }
        public int StudentNumber
        {
            get // makes it so you cannot change value
            { 
                return _studentId;
            }

        }
        public int StudentAge
        {
            get // makes it so you cannot change value
            {
                return _age;
            }

        }
        
        // Methods

        public override string ToString()
        {
            return _firstName + " " + _lastName;
        }

        public void ResetStudentNumber()
        {
            this._studentId = 555000 + generator.Next(100, 1000);
            GenerateEmail();
        }

        private void GenerateEmail()
        {
            string first, last;

            if (_firstName.Length <= 3)
                first = _firstName;
            else
                first = _firstName.Substring(0, 3);

            if (_lastName.Length <= 3)
                last = _lastName;
            else
                last = _lastName.Substring(0, 3);

            _email = first + last + (_studentId + "").Substring(3) + "@ICS4U.com";

        }

        public override bool Equals(object obj)
        {
            Student student = obj as Student; //cast obj to Student
            if (student == null) //protects us in case obj is null
                return false;
            return this.FirstName == student.FirstName && this.LastName == student.LastName && this.StudentNumber == student.StudentNumber;

        }

        public int CompareTo(Student that) // Sort()
        {
            if (this.LastName.CompareTo(that.LastName) == 0) //If last names are equal, compares first names
                return this.FirstName.CompareTo(that.FirstName);

            return this.LastName.CompareTo(that.LastName);  //Otherwise compares last names
        }
    }
}
