using Practice_12_1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Practice_12_1.Models
{
    internal class Client
    {
        public event EventHandler<LogInfoEventArgs> AccountUpdate;

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string MiddleName { get; set; }
        public string PassportNumber { get; set; }

        public DepositAccount DepositAccount { get; set; }
        public NonDepositAccount NonDepositAccount { get; set; }

        public void UpdateInfo(string firstName, 
                               string secondName, 
                               string middleName, 
                               string passportNumber)
        {
            if(int.TryParse(passportNumber, out int number))
            {
                FirstName = firstName;
                SecondName = secondName;
                MiddleName = middleName;
                PassportNumber = passportNumber;

                LogInfoEventArgs logInfo = new LogInfoEventArgs()
                {
                    Time = DateTime.Now,
                    AuthorName = "Manager",
                    TransactionType = "Updating client information",
                    TransactionSum = 0
                };

                AccountUpdate(this, logInfo);
            }
            else
            {
                throw new InputDataExceptions("Номер паспорта должен быть числом");
            }
        }
    }
}
