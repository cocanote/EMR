using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EMR.Model
{
    class PatientInfoService : IPatientInfoService
    {
        private static List<PatientInfoModel> objpatientInfoModels;
        OracleConnection conn;
        public PatientInfoService()
        {
            
        }

       

        public List<PatientInfoModel> GetAll()
        {
            return objpatientInfoModels;
        }

        public bool Insert(PatientInfoModel objNewPatienInfo)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PatientInfoModel Search(String name, String rrnumber)
        {
            try
            {
                string strCon = "Data Source=orcl;User Id=c##scott;Password=tiger;";
                conn = new OracleConnection(strCon);
                conn.Open();
                MessageBox.Show("DB Connection OK!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            string sql = "select * from patientinfo ";

            OracleCommand comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = sql;

            OracleDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection);

            PatientInfoModel patientInfoModels = new PatientInfoModel();
            while (reader.Read())
            {
                System.Diagnostics.Trace.WriteLine(reader.GetString(reader.GetOrdinal("name")));
                patientInfoModels.id = reader.GetInt32(reader.GetOrdinal("id"));
                patientInfoModels.name = reader.GetString(reader.GetOrdinal("name"));
                patientInfoModels.rrnumber =  reader.GetString(reader.GetOrdinal("rrnumber"));
                patientInfoModels.Insurance = reader.GetString(reader.GetOrdinal("Insurance"));
                patientInfoModels.insuredperson_name = reader.GetString(reader.GetOrdinal("insuredperson_name"));
                patientInfoModels.card_number =  reader.GetString(reader.GetOrdinal("card_number"));
                patientInfoModels.Relationship = reader.GetString(reader.GetOrdinal("Relationship"));
                patientInfoModels.Combination =  reader.GetString(reader.GetOrdinal("Combination"));
                patientInfoModels.cellphone =  reader.GetString(reader.GetOrdinal("cellphone"));
                patientInfoModels.phone =  reader.GetString(reader.GetOrdinal("phone"));
                patientInfoModels.adrress =  reader.GetString(reader.GetOrdinal("adrress"));
                patientInfoModels.mail =  reader.GetString(reader.GetOrdinal("mail"));
                patientInfoModels.post_number = reader.GetInt32(reader.GetOrdinal("post_number"));
                patientInfoModels.patient_memo = reader.GetString(reader.GetOrdinal("patient_memo"));
                patientInfoModels.discount_percent =  reader.GetString(reader.GetOrdinal("discount_percent"));
                patientInfoModels.discount_reason =  reader.GetString(reader.GetOrdinal("discount_reason"));
                patientInfoModels.in_charge_name = reader.GetString(reader.GetOrdinal("in_charge_name"));
                patientInfoModels.insuredperson_name = reader.GetString(reader.GetOrdinal("insuredperson_name"));
                patientInfoModels.birthday = reader.GetDateTime(reader.GetOrdinal("birthday"));
                if (reader.GetString(reader.GetOrdinal("calender")) == "lunar")
                    patientInfoModels.calender = true;
                else patientInfoModels.calender = false;


            }   
            reader.Close();
            return patientInfoModels;
        }

        public bool Update(PatientInfoModel objNewPatienInfo)
        {
            throw new NotImplementedException();
        }
    }
}
