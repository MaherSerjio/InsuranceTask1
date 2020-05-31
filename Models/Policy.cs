using IMS_Assignment_1.Models.enums;
using System;
using System.Threading;

namespace IMS_Assignment_1.Models
{
    class Policy
    {

        public int Id;

        public PolicyType PolicyType { get; set; }

        public DateTime Effective { get; set; }


        public DateTime Expiry { get; set; }

        public string Police_No { get; set; }


        public decimal Premium { get; set; }

        public bool IsValid { get; set; }

        public void PolicyCreationSuccessMessage()
        {
            Console.WriteLine(" Policy " + Police_No + " was added Successfully! ");
        }
        public void PolicyCreationErrorMessage()
        {
            Console.WriteLine(" Cannot add policy because it is invalid. ");
        }
        public void DisplayPolicyTemplate()
        {
            Console.WriteLine("Id: " + Id + "\n" + "Effective: " + Effective.ToShortDateString()
             + "\n" + "Expiry: " + Expiry.ToShortDateString()
             + "\n" + "Police_No: " + Police_No + "\n" + "Premium: " + Premium + "\n"
             + "IsValid: " + IsValid);

        }
        public void DisplayPoliciesWherePremiumBetweenFiveHundredAndTwoThousand()
        {
            if ((Premium >= 500) && (Premium <= 2000))
            {
                DisplayPolicyTemplate();

            }
        }

        public void EffectiveGreaterThanExpiry()
        {
            Console.WriteLine("Effective date must be less than expiry date");
        }

        static int lastId = 0;

        public int GenerateId()
        {
            return Interlocked.Increment(ref lastId);
        }
        public bool IsEffectiveLessThanExpiry()
        {
            if (DateTime.Compare(Effective, Expiry) < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }


}
