using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EMR
{
    /// <summary>
    /// Receipt_management.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Receipt_management : Window
    {
        public Receipt_management()
        {
            InitializeComponent();
        }
        OracleConnection conn;
        String name2;



       
        /* public String CurrentTime
         {
             get { return currentTime; }
             set { currentTime = value; RaisePropertyChanged(() => CurrentTime); }
         }


        */
       
        private void Select_Emp(object sender, RoutedEventArgs e)
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
            string sql = "select id, name, rrnumber from patientinfo ";

            OracleCommand comm = new OracleCommand();         
            comm.Connection = conn;
            comm.CommandText = sql;

            OracleDataReader reader = comm.ExecuteReader(CommandBehavior.CloseConnection);

            List<PatientInfoModel> emps = new List<PatientInfoModel>();
            while (reader.Read())
            {
                System.Diagnostics.Trace.WriteLine(reader.GetString(reader.GetOrdinal("name")));
                emps.Add(new PatientInfoModel()
                {
                    id = reader.GetInt32(reader.GetOrdinal("id")),
                    name = reader.GetString(reader.GetOrdinal("name")),
                   rrnumber  = reader.GetString(reader.GetOrdinal("rrnumber"))

                  
            });
            }
            



            reader.Close();
        }
    }
}
