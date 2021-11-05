using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MileStone2;

namespace MileStone2
{
    class Module : Student
    {
        string ModuleName;

        public Module(string moduleName)
        {
            ModuleName = moduleName;
        }

        public Module(int StudentID, string Name, string Surname, int DateOfBirth, string Gender, int Phone, int Address, int Fees, double Payment, string ModuleCode) : base(StudentID, Name, Surname, DateOfBirth, Gender, Phone, Address, Fees, Payment, ModuleCode)
        {

        }

        public override double CalculatePayment()
        {
            throw new NotImplementedException();
        }
    }
}
class mod
{
    int modulecode;
    string modulename;
    string moduledes;
    string moduleres;

    public mod() { }

    public mod(int modulecode, string modulename, string moduledes, string moduleres)
    {
        this.modulecode = modulecode;
        this.modulename = modulename;
        this.moduledes = moduledes;
        this.moduleres = moduleres;
    }

    public int Modulecode { get => modulecode; set => modulecode = value; }
    public string Modulename { get => modulename; set => modulename = value; }
    public string Moduledes { get => moduledes; set => moduledes = value; }
    public string Moduleres { get => moduleres; set => moduleres = value; }

    public List<mod> GetPets(int number)
    {
        List<mod> myMods = new List<mod>();
        try
        {
            DataHandler dh = new DataHandler();
            foreach (DataRow item in dh.ReadUsermod(number).Rows)
            {
                mod p = new mod(Convert.ToInt32(item[3].ToString()), (item[0].ToString()), item[1].ToString(), item[2].ToString());
                myMods.Add(p);
            }
            return myMods;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return myMods;

        }
    }
}

