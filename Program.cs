using IMS_Assignment_1.Models;
using IMS_Assignment_1.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMS_Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(" Console app Start: \n");

            ////////////////////////////////////////////////////
            // 1 (a + b) + 3
            ////////////////////////////////////////////////////
            Motor motorP1 = new Motor(new DateTime(2020, 1, 21),
            new DateTime(2020, 5, 21), 3600);

            Travel travelP1 = new Travel(new DateTime(2020, 2, 21),
             new DateTime(2020, 6, 21), "Kief", "Belarus", true, 20);

            List<Beneficiary> beneficiaryList1 = new List<Beneficiary>();

            beneficiaryList1.Add(new Beneficiary(Gender.Male, Relationship.Son, "Maher",
                 new DateTime(1993, 8, 8)));

            beneficiaryList1.Add(new Beneficiary(Gender.Female, Relationship.Daughter, "Maya",
                new DateTime(1993, 10, 10)));


            Medical medicalP1 = new Medical(new DateTime(2020, 2, 21),
             new DateTime(2020, 6, 21), beneficiaryList1);


            Console.WriteLine();
            ////////////////////////////////////////////////////
            // 2 
            ////////////////////////////////////////////////////



            Motor motorP2 = new Motor(new DateTime(2020, 2, 21),
            new DateTime(2020, 10, 21), 500);

            Motor motorP3 = new Motor(new DateTime(2020, 3, 21),
            new DateTime(2020, 11, 21), 1500);

            Travel travelP2 = new Travel(new DateTime(2020, 2, 21),
            new DateTime(2020, 10, 21), "Beirut", "London", false, 1);

            Travel travelP3 = new Travel(new DateTime(2020, 10, 21),
            new DateTime(2020, 10, 21), "Cuba", "Portugal", true, 2);

            Medical medicalP2 = new Medical(new DateTime(2020, 3, 21),
            new DateTime(2020, 2, 21), beneficiaryList1);


            Console.WriteLine();
            ////////////////////////////////////////////////////
            // 4
            ////////////////////////////////////////////////////

            Console.WriteLine(" All available policies following the Display Template.\n");

            motorP1.DisplayMotorPolicyTemplate();
            motorP2.DisplayMotorPolicyTemplate();
            motorP3.DisplayMotorPolicyTemplate();

            travelP1.DisplayTravelPolicyTemplate();
            travelP2.DisplayTravelPolicyTemplate();
            travelP3.DisplayTravelPolicyTemplate();

            medicalP1.DisplayMedicalPolicyTemplate();
            medicalP2.DisplayMedicalPolicyTemplate();


            Console.WriteLine();
            ////////////////////////////////////////////////////
            // 5
            ////////////////////////////////////////////////////
            Console.WriteLine(" All policies whose premium is between 500 USD and 2000 USD.\n");

            List<Policy> policyList = new List<Policy>();

            policyList.Add(motorP1);
            policyList.Add(motorP2);
            policyList.Add(motorP3);

            policyList.Add(travelP1);
            policyList.Add(travelP2);
            policyList.Add(travelP3);

            policyList.Add(medicalP1);
            policyList.Add(medicalP2);

            foreach (var policy in policyList)
            {
                policy.DisplayPoliciesWherePremiumBetweenFiveHundredAndTwoThousand();
            }



            Console.WriteLine();
            ////////////////////////////////////////////////////
            // 6 a + b 
            ////////////////////////////////////////////////////

            motorP2.IsValid = false;

            List<Claim> ClaimList = new List<Claim>();

            Claim claim1 = new Claim(new DateTime(2020, 1, 1), "asdads", 200);
            Claim claim2 = new Claim(new DateTime(2020, 2, 2), motorP1.Police_No, 100);
            Claim claim3 = new Claim(new DateTime(2020, 3, 3), motorP3.Police_No, 300);
            Claim claim4 = new Claim(new DateTime(2020, 4, 4), travelP1.Police_No, 400);
            Claim claim5 = new Claim(new DateTime(2020, 5, 5), travelP2.Police_No, 500);
            Claim claim6 = new Claim(new DateTime(2020, 6, 6), travelP3.Police_No, 600);
            Claim claim7 = new Claim(new DateTime(2020, 7, 7), medicalP1.Police_No, 700);
            Claim claim8 = new Claim(new DateTime(2020, 8, 8), medicalP2.Police_No, 800);
            Claim claim9 = new Claim(new DateTime(2020, 9, 9), travelP1.Police_No, 900);
            Claim claim10 = new Claim(new DateTime(2020, 10, 10), travelP2.Police_No, 1000);
            Claim claim11 = new Claim(new DateTime(2020, 11, 11), travelP3.Police_No, 1100);
            Claim claim12 = new Claim(new DateTime(2020, 12, 12), motorP1.Police_No, 1200);
            Claim claim13 = new Claim(new DateTime(2020, 1, 13), medicalP1.Police_No, 1300);
            Claim claim14 = new Claim(new DateTime(2020, 2, 14), motorP3.Police_No, 1400);
            Claim claim15 = new Claim(new DateTime(2020, 3, 15), motorP2.Police_No, 1500);

            ClaimList.Add(claim1);
            ClaimList.Add(claim2);
            ClaimList.Add(claim3);
            ClaimList.Add(claim4);
            ClaimList.Add(claim5);
            ClaimList.Add(claim6);
            ClaimList.Add(claim7);
            ClaimList.Add(claim8);
            ClaimList.Add(claim9);
            ClaimList.Add(claim10);
            ClaimList.Add(claim11);
            ClaimList.Add(claim12);
            ClaimList.Add(claim13);
            ClaimList.Add(claim14);
            ClaimList.Add(claim15);

            // we tend to not do nested loops due to time complexity => performance issues.

            // 6a
            foreach (var claim in ClaimList)
            {
                if (!policyList.Exists(p => p.Police_No == claim.Police_No))
                {
                    Console.WriteLine(" Cannot submit a claim for " +
                     "Policy# " + claim.Police_No + " because it does not exist");
                }
            }


            Console.WriteLine();

            // 6b
            foreach (var claim in ClaimList)
            {
                if (claim.Police_No != null)
                {

                    var validPolicies = policyList.FirstOrDefault((p => p.Effective <= claim.Incured_Date
                       && claim.Incured_Date < p.Expiry));

                    if (validPolicies == null)
                    {
                        Console.WriteLine(" Claim is rejected because Policy# "
                            + claim.Police_No + " is inactive or expired");
                    }

                }

            }




            Console.WriteLine();
            ////////////////////////////////////////////////////
            // 7 a + b + c 
            ////////////////////////////////////////////////////



            foreach (var police in policyList)
            {
                if (police.Police_No != null)
                {
                    var Submitted_Claims = ClaimList
                      .FindAll(c => c.Police_No == police.Police_No);

                    var Claim_Sum_Ammount = Submitted_Claims.Sum(c => c.Claimed_Amount);



                    var policyMaxClaimedAmount = Submitted_Claims.Max(c => c.Claimed_Amount);
                    var policyMinClaimedAmount = Submitted_Claims.Min(c => c.Claimed_Amount);

                    Console.WriteLine(" Police# " + police.Police_No + " has "
                        + Submitted_Claims.Count() + " claims with max: " + policyMaxClaimedAmount
                        + " and min: " + policyMinClaimedAmount + " and sum: " + Claim_Sum_Ammount
                        );



                }
            }

            Console.WriteLine("\n Console app Finish: \n");


        }
    }
}
