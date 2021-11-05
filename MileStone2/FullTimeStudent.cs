using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MileStone2
{
    class FullTimeStudent:Student
    {


        public FullTimeStudent(int StudentID, string Name, string Surname, int DateOfBirth, string Gender, int Phone, int Address, int Fees,double Payment,string ModuleCode):base (StudentID,Name,Surname,DateOfBirth,Gender,Phone,Address,Fees,Payment,ModuleCode)
        {

            this.Payment1 = CalculatePayment();
        }

        public override double CalculatePayment()
        {
            return this.Fees1 * 0.10;
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}", StudentID1, ModuleCode1, Name1);
        }

    }
}
