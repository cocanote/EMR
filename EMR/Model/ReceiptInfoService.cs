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
    class ReceiptInfoService : IReceiptInfoService
    {
        private OracleConnection conn;

        public bool Insert(ReceiptInfoModel objNewreceiptInfo)
        {
            if (objNewreceiptInfo.patient_id == 0)
            {
                return false;
            }
            DbConnect_init();
            String sql =
                "INSERT INTO receiptInfo" +
"(patient_id, patient_classification, doctor_in_charge, series, diagnostic_experience, last_visit, receipt_memo, reservation_time) VALUES "+
"('"+objNewreceiptInfo.patient_id+ "', '" + objNewreceiptInfo.patient_classification + "', '" + objNewreceiptInfo.doctor_in_charge + "', '" + objNewreceiptInfo.series + "'," +
" '" + objNewreceiptInfo.diagnostic_experience + "', '" + objNewreceiptInfo.last_visit + "', '" + objNewreceiptInfo.receipt_memo + "', '" + objNewreceiptInfo.reservation_time + "')";


            OracleCommand comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = sql;

            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return true;
        }

        public bool InsertToReserve(PatientInfoModel objNewreceiptInfo)
        {
            throw new NotImplementedException();
        }

        public bool Update(PatientInfoModel objNewreceiptInfo)
        {
            throw new NotImplementedException();
        }
        public void DbConnect_init()
        {
            try
            {
                string strCon = "Data Source=orcl;User Id=c##scott;Password=tiger;";
                conn = new OracleConnection(strCon);
                conn.Open();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        public List<ReceiptInfoModel> GetList()
        {
            DbConnect_init();
            string sql = "select patient_id,name ,patient_classification,doctor_in_charge,diagnostic_experience "+
                         "from RECEIPTINFO inner join PATIENTINFO On patient_id = id ";

            OracleCommand comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = sql;

            OracleDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
            List<ReceiptInfoModel> receiptInfoModels = new List<ReceiptInfoModel>();


            while (reader.Read())
            {
                ReceiptInfoModel receiptInfoModel = new ReceiptInfoModel();
                receiptInfoModel.patient_name = reader.GetString(reader.GetOrdinal("name"));
                receiptInfoModel.patient_id = reader.GetInt32(reader.GetOrdinal("patient_id"));
                receiptInfoModel.patient_classification = reader.GetString(reader.GetOrdinal("patient_classification"));
                receiptInfoModel.doctor_in_charge = reader.GetString(reader.GetOrdinal("doctor_in_charge"));
                receiptInfoModel.diagnostic_experience = reader.GetString(reader.GetOrdinal("diagnostic_experience"));

                receiptInfoModels.Add(receiptInfoModel);
            }
            reader.Close();
            return receiptInfoModels;
        }
    }
}
