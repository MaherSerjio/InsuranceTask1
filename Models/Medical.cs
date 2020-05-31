using IMS_Assignment_1.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMS_Assignment_1.Models
{
    class Medical : Policy
    {
        public List<Beneficiary> Beneficiaries { get; set; }

        public Medical(DateTime Effective, DateTime Expiry, List<Beneficiary> beneficiaries)
        {


            this.Effective = Effective;
            this.Expiry = Expiry;
            Beneficiaries = beneficiaries;

            if (IsEffectiveLessThanExpiry() && Beneficiaries.Count > 0 && !IsAnySelfRelationshipDuplicate())
            {
                Id = GenerateId();
                PolicyType = PolicyType.Medical;
                IsValid = true;
                Police_No = "" + DateTime.Now.Date.Year + "-" + this.PolicyType + "-" + this.Id;


                CalculatePremium();
                PolicyCreationSuccessMessage();
            }

            else
                PolicyCreationErrorMessage();


        }

        public bool IsAnySelfRelationshipDuplicate()
        {
            var dup = Beneficiaries
                .Where(b => b.Relationship == Relationship.Self);

            if (dup.Count() > 1)
                return true;


            return false;


        }

        public void CalculatePremium()
        {
            int Sum_Of_Beneficiaire_Premium = 0;

            foreach (var beneficiarie in Beneficiaries)
            {
                if (beneficiarie.Age < 10)
                {
                    Sum_Of_Beneficiaire_Premium += 10;
                }
                else if (beneficiarie.Age <= 11 && beneficiarie.Age >= 45)
                {
                    Sum_Of_Beneficiaire_Premium += 30;
                }
                else
                {
                    Sum_Of_Beneficiaire_Premium += 63;
                }
            }

            Premium = Sum_Of_Beneficiaire_Premium / Beneficiaries.Count;
        }

        public void DisplayMedicalPolicyTemplate()
        {
            if (Id == 0)
            {
                Console.Write("");
            }
            else
            {
                DisplayPolicyTemplate();
                Console.Write("Number of beneficiaries: " + Beneficiaries.Where(b => b.Relationship != Relationship.Self).Count());
                Console.Write("\n---------------------------------\n");

            }



        }

    }
}
