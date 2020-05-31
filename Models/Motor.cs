using IMS_Assignment_1.Models.enums;
using System;

namespace IMS_Assignment_1.Models
{

    class Motor : Policy
    {
        public decimal VehiclePrice { get; set; }


        public Motor(DateTime Effective, DateTime Expiry, decimal VehiclePrice)
        {

            this.Effective = Effective;
            this.Expiry = Expiry;


            if (IsEffectiveLessThanExpiry())
            {
                Id = GenerateId();
                PolicyType = PolicyType.Motor;
                this.VehiclePrice = VehiclePrice;
                Premium = VehiclePrice * (decimal)0.2;
                IsValid = true;
                Police_No = "" + DateTime.Now.Date.Year + "-" + this.PolicyType + "-" + this.Id;
                PolicyCreationSuccessMessage();
            }


            else PolicyCreationErrorMessage();


        }

        public void DisplayMotorPolicyTemplate()
        {

            if (Id == 0)
            {
                Console.Write("");
            }
            else
            {
                DisplayPolicyTemplate();
                Console.Write("VehiclePrice: " + VehiclePrice + "\n---------------------------------\n");

            }

        }




    }
}
