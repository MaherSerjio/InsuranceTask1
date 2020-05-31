using IMS_Assignment_1.Models.enums;
using System;

namespace IMS_Assignment_1.Models
{

    class Beneficiary
    {
        public Gender Gender;

        public Relationship Relationship;

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Date_Of_Birth { get; set; }

        public Beneficiary(Gender gender, Relationship relationship,
            string name, DateTime date_Of_Birth)
        {
            Gender = gender;
            Relationship = relationship;
            Name = name;
            Age = DateTime.Now.Year - date_Of_Birth.Year;
            Date_Of_Birth = date_Of_Birth;
        }
    }
}
