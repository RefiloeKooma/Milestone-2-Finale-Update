using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MileStone2
{
    class DataHandler
    {


        int modulecode;
        string modulename;
        string moduledescription;
        string moduleresource;
        SqlCommand cmd;
        DataHandler myDataHandler = new DataHandler();
        private object searchValue;
        string connect = "Data Source=.; Initial Catalog=StudentInformationMilestone1; Integrated Security = SSPI";

        SqlConnection conn = new SqlConnection("Server=.;Initial Catalog=StudentInformationMilestone1;Integrated security=SSPI");
        public DataHandler() { }

        public DataHandler(int modulecode, string modulename, string moduledescription, string moduleresource)
        {
            this.modulecode = modulecode;
            this.modulename = modulename;
            this.moduledescription = moduledescription;
            this.moduleresource = moduleresource;
        }

        public DataHandler(int modulecode, string modulename, string moduledescription)
        {
            this.modulecode = modulecode;
            this.modulename = modulename;
            this.moduledescription = moduledescription;
        }
        public void updateName(int modulecode_, string modulename_)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("up1valname", conn);
            cmd.Parameters.AddWithValue("@id", modulecode_);
            cmd.Parameters.AddWithValue("@name", modulename_);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void updateSurname(int modulecode_, string moduledescription_)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("up1valSurname", conn);
            cmd.Parameters.AddWithValue("@id", modulecode_);
            cmd.Parameters.AddWithValue("@surname", moduledescription_);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void updateAll(int modulecode_, string modulename_, string moduledescription_, string moduleresource_)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("up1valall", conn);
            cmd.Parameters.AddWithValue("@id", modulecode_);
            cmd.Parameters.AddWithValue("@name", modulename_);
            cmd.Parameters.AddWithValue("@surname", moduledescription_);
            cmd.Parameters.AddWithValue("@surname", moduleresource_);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DBAccess()
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=.;Initial Catalog=StudentInformationMilestone1;Integrated security=SSPI");

            }
            catch (Exception)
            {

                MessageBox.Show("was not connected", "Connection Problem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public DataTable ReadData()
        {

            DataTable dt = new DataTable();
            try
            {

                conn.Open();
                SqlDataAdapter SDA = new SqlDataAdapter("ViewAll", conn);
                SDA.SelectCommand.CommandType = CommandType.StoredProcedure;
                SDA.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return dt;
            }
        }

        internal void updateAll(int v, string text1, string text2)
        {
            throw new NotImplementedException();
        }

        public void InsertData(int modulecode, string modulename, string moduledescription, string moduleresource)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Inserted", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", modulename);
                cmd.Parameters.AddWithValue("@surname", moduledescription);
                cmd.Parameters.AddWithValue("@gender", moduleresource);
                cmd.Parameters.AddWithValue("@IDNumber", modulecode);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public DataTable ReadUsermod(int number)
        {
            DataTable tb = new DataTable();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("readmod", conn);
                cmd.Parameters.AddWithValue("ids", number);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SDA = new SqlDataAdapter();
                SDA.SelectCommand = cmd;

                SDA.Fill(tb);
                conn.Close();
                return tb;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return tb;
            }
        }

        public string DeleteData(string num)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("deleteid", conn);
                cmd.Parameters.AddWithValue("@idNumber", num);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                conn.Close();
                return "record deleted";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public void Storemod(int modulecode, string modulename, string moduledescription, string moduleresource) //, int userid
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insertmod", conn);
                cmd.Parameters.AddWithValue("@name", modulename);
                cmd.Parameters.AddWithValue("@type", moduledescription);
                cmd.Parameters.AddWithValue("@age", moduleresource);
                // cmd.Parameters.AddWithValue("@user", userid);
                conn.Close();
                MessageBox.Show("record inserted");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        #region Save
        public void Add(int StudentID, string Name, string Surname, int DateOfBirth, string Gender, int Phone, int Address, int Fees, double Payment, string ModuleCode)
        {
            try
            {

                string query = @"INSERT INTO tblStudent VALUES(" + StudentID + " ,'" + Name + "' ,'" + Surname + "','" + Gender + "'," + DateOfBirth + "'," + Phone + "'," + Address + "' ,'" + ModuleCode + "')";

                conn = new SqlConnection(connect);
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Details Added Successfully.");
            }
            catch (Exception)
            {

                MessageBox.Show("Details not Added");

            }

        }

        #endregion


        #region Update
        public void Update(int StudentID, string Name, string Surname, int DateOfBirth, string Gender, int Phone, int Address, int Fees, double Payment, string ModuleCode)
        {
            try
            {
                string query = @"UPDATE tblStudent VALUES(" + StudentID + " ,'" + Name + "' ,'" + Surname + "','" + Gender + "'," + DateOfBirth + ")";
                conn = new SqlConnection(connect);
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Details Successfully Updated");


            }
            catch (Exception ex)
            {

                MessageBox.Show("Details not saved!..");
            }
        }

        #endregion



        #region deleteStudent

        public void DeleteStudent(int StudentID)
        {
            try
            {
                string query = @"DELETE FROM tblStudent WHERE StudentID = ('" + StudentID + " ')";
                conn = new SqlConnection(connect);
                conn.Open();
                cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted the details of student with ID number of :{0},StudentID");
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error!!!" + ex.Message);
            }

        }

        #endregion

        #region ViewAll


        private void btnShowAll(int StudentID)
        {
            try
            {
                string connect = @"DataSource=.;Initial Catalog=StudentInformationMilestone1;Integrated Security=SSPI";
                SqlConnection conn = new SqlConnection(connect);
                conn.Open();
                string query = @"Select * from tbl Student";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudentRecords.DataSource = dt;
                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        #endregion

        #region Search


        private void btnSearch_Click(int StudentID)
        {
            try
            {
                foreach (DataGridViewRow row in dgvStudentRecords.Rows)
                {
                    if (row.Cells[2].Value.ToString().Equals(searchValue))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        #endregion








    }
}
