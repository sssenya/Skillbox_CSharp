using System;

namespace Practice_12_1.Models
{
    internal interface IBankAccount
    {
        string Name { get; }
        double Balance { get; set; }
        double Percent { get; set; }
        DateTime OpeningDate { get; set; }

        void AddMoney(double sum);

        bool RemoveMoney(double sum);
    }
}
