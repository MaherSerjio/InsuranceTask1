using IMS_Assignment_1.Models.enums;
using System;

namespace IMS_Assignment_1.Models
{
    class Travel : Policy
    {
        public string Departure { get; set; }

        public string Destination { get; set; }

        public bool Family { get; set; }

        public int Number_Of_Days_Travelled { get; set; }


        public Travel(DateTime Effective, DateTime Expiry, string Departure,
            string Destination, bool Family, int Number_Of_Days_Travelled)
        {

            this.Effective = Effective;
            this.Expiry = Expiry;
            this.Number_Of_Days_Travelled = Number_Of_Days_Travelled;

            if (IsEffectiveLessThanExpiry() && !IsNumberOfTravelDaysExceeded())
            {
                Id = GenerateId();
                PolicyType = PolicyType.Travel;
                this.Destination = Destination;
                this.Departure = Departure;
                this.Family = Family;

                IsValid = true;
                Police_No = "" + DateTime.Now.Date.Year + "-" + this.PolicyType + "-" + this.Id;

                if (Family) Premium = Number_Of_Days_Travelled * 10;
                else Premium = Number_Of_Days_Travelled * 5;

                PolicyCreationSuccessMessage();
            }


            else
                PolicyCreationErrorMessage();



        }

        public bool IsNumberOfTravelDaysExceeded()
        {
            if ((Number_Of_Days_Travelled > 30) || (Number_Of_Days_Travelled <= 0)) return true;

            return false;
        }

        public void DisplayTravelPolicyTemplate()
        {

            if (Id == 0)
            {
                Console.Write("");

            }
            else
            {
                DisplayPolicyTemplate();
                Console.Write("Family: " + Family + "\n" + "Number_Of_Days_Travelled: " + Number_Of_Days_Travelled
                 + "\n" + "Departure: " + Departure + "\n" + "Destination: " + Destination
                 + "\n---------------------------------\n");
            }



            //if (IsNumberOfTravelDaysExceeded())
            //  {
            //  Console.WriteLine("Number of days travelled cannot exceed 30");
            //  }

        }

    }

}



