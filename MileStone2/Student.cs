using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MileStone2
{
   abstract class Student
    {
        #region Fields
        int StudentID;
        string Name;
        string Surname;
        int DateOfBirth;
        string Gender;
        int Phone;
        int Address;
        int Fees;
        double Payment;
        string ModuleCode;
        #endregion


        #region Properties
        public int StudentID1 { get => StudentID; set => StudentID = value; }
        public string Name1 { get => Name; set => Name = value; }
        public string Surname1 { get => Surname; set => Surname = value; }
        public int DateOfBirth1 { get => DateOfBirth; set => DateOfBirth = value; }
        public string Gender1 { get => Gender; set => Gender = value; }
        public int Phone1 { get => Phone; set => Phone = value; }
        public int Address1 { get => Address; set => Address = value; }
        public int Fees1 { get => Fees; set => Fees = value; }
        public double Payment1 { get => Payment; set => Payment = value; }
        public string ModuleCode1 { get => ModuleCode; set => ModuleCode = value; }
       
 


        #endregion


        #region parameterless constructor
        public Student()
        { }
        #endregion

        #region Constructor

        public Student(int StudentID,string Name,string Surname,int DateOfBirth,string Gender,int Phone,int Address,int Fees,double Payment,string ModuleCode)
        {
            this.StudentID = StudentID1;
            this.Name = Name;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender1;
            this.Phone = Phone1;
            this.Address = Address;
            this.Fees = Fees;
            this.Payment = Payment1;
            this.ModuleCode =ModuleCode1;
            
        }
        #endregion

        #region Method
        public abstract double CalculatePayment();
        #endregion

        #region tostring
        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}", StudentID1,ModuleCode, Name);
        }
        #endregion
    }
}
