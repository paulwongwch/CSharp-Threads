using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpThreadTutorial
{
    class BankAcct
    {
        private Object acctLock = new object();
        double Balance { get; set; }

        public BankAcct(double bal)
        {
            this.Balance = bal;
        }

        public void Withdraw(double amt)
        {
            if ((Balance - amt) < 0)
            {
                Console.WriteLine($"Sorry ${Balance} in Account");

            }
            lock (acctLock)
            {
                if (Balance >= amt)
                {
                    Console.WriteLine("Removed {0} and {1} left in account", amt, (Balance - amt));
                    Balance -= amt;
                }
            }
        }

        public void IssueWithThread()
        {
            Withdraw(1);
        }
    }
}
