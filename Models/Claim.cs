using System;
using System.Threading;

namespace IMS_Assignment_1.Models
{
    class Claim
    {
        public int Id { get; set; }

        public DateTime Incured_Date { get; set; }

        public string Police_No { get; set; }

        public decimal Claimed_Amount { get; set; }

        static int lastId = 0;

        public int GenerateId()
        {
            return Interlocked.Increment(ref lastId);
        }


        public Claim(DateTime Incured_Date, string Police_No, decimal Claimed_Amount)
        {
            Id = GenerateId();
            this.Incured_Date = Incured_Date;
            this.Police_No = Police_No;
            this.Claimed_Amount = Claimed_Amount;



        }
    }
}
