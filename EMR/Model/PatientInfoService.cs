using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EMR.Model
{
    class PatientInfoService : IPatientInfoService
    {
      
        OracleConnection conn;
        public PatientInfoService()
        {
        }
        public bool Insert(PatientInfoModel objNewPatienInfo)
        {
            DbConnect_init();
            String sql = "INSERT INTO patientInfo (rrnumber, Insurance, insuredperson_name, card_number, Relationship, Combination, name, cellphone, phone, post_number, adrress, mail, " +
                "patient_memo, discount_percent, discount_reason, in_charge_name, birthday, calender) VALUES ('"+objNewPatienInfo.rrnumber+"','"+objNewPatienInfo.Insurance + "','"+objNewPatienInfo.insuredperson_name + 
                "','"+objNewPatienInfo.card_number+"','"+ objNewPatienInfo.Relationship + "','" + objNewPatienInfo.Combination + "','" + objNewPatienInfo.name + "','"+ objNewPatienInfo.cellphone + 
                "','" + objNewPatienInfo.phone + "','" + objNewPatienInfo.post_number + "','" + objNewPatienInfo.adrress + "','" + objNewPatienInfo.mail + "','" + objNewPatienInfo .patient_memo+ "','" + objNewPatienInfo.discount_percent
                + "','" + objNewPatienInfo.discount_reason + "','" + objNewPatienInfo .in_charge_name+ "','" + objNewPatienInfo.birthday + "','" + objNewPatienInfo.calender +"') ";
           

            OracleCommand comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = sql;
            
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("올바른 환자 정보를 입력하세요");
                conn.Close();
                return false;
            }
            conn.Close();
            MessageBox.Show("저장되었습니다.");
            return true;
            
        }
        public bool Delete(int id)
        {
            DbConnect_init();
            String sql = "Delete From patientinfo WHERE id = '" + id + "'";
            OracleCommand comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = sql;

            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("삭제할 값이 없습니다.");
                conn.Close();
                return false;
            }
            conn.Close();
            MessageBox.Show("삭제되었습니다.");
            return true;
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
        public PatientInfoModel Search(String name, String rrnumber)
        {
            DbConnect_init();
            string sql = "select * from patientinfo where name= '"+name+"' AND rrnumber ='"+rrnumber+"'";
            OracleCommand comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = sql;
            OracleDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection);
            PatientInfoModel patientInfoModels = new PatientInfoModel();
           
            if (reader.Read())
            {
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
                patientInfoModels.birthday = reader.GetString(reader.GetOrdinal("birthday"));
                
                if (reader.GetString(reader.GetOrdinal("calender")) == "lunar")
                    patientInfoModels.calender = true;
                else patientInfoModels.calender = false;              
            }
            else if (name == null || rrnumber == null)
            {
                MessageBox.Show("이름과 주민번호를 모두 입력해주세요.");
            }
            else
                MessageBox.Show("환자가 존재하지 않습니다.");
            reader.Close();
            return patientInfoModels;
        }


        public bool Update(PatientInfoModel objNewPatienInfo)
        {
            DbConnect_init();
            String sql = "UPDATE patientinfo " +
                "SET " +
                "Insurance = '" + objNewPatienInfo.Insurance + "'," +
                " insuredperson_name = '" + objNewPatienInfo.insuredperson_name + "'," +
                " card_number = '" + objNewPatienInfo.card_number + "'," +
                " Relationship = '" + objNewPatienInfo.Relationship + "'," +
                " Combination = ' " + objNewPatienInfo.Combination + "'," +
                " cellphone = '" + objNewPatienInfo.cellphone + "'," +
                " phone = '" + objNewPatienInfo.phone + "'," +
                " post_number = '" + objNewPatienInfo.post_number + "'," +
                " adrress = '" + objNewPatienInfo.adrress + "'," +
                " mail= '" + objNewPatienInfo.mail + "', " +
                "patient_memo = '" + objNewPatienInfo.patient_memo + "'," +
                " discount_percent = '" + objNewPatienInfo.discount_percent + "'," +
                " discount_reason = '" + objNewPatienInfo.discount_reason + "'," +
                " in_charge_name = '" + objNewPatienInfo.in_charge_name + "'," +
                " birthday = '" + objNewPatienInfo.birthday + "'," +
                " calender = '" + objNewPatienInfo.calender + "'" +
                "WHERE id = '" + objNewPatienInfo.id+"'";

            OracleCommand comm = new OracleCommand();
            comm.Connection = conn;
            comm.CommandText = sql;

            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("올바른 환자 정보를 입력하세요");
                conn.Close();
                return false;
            }
            conn.Close();
            MessageBox.Show("수정되었습니다.");
            return true;
        }

       
    }
}
