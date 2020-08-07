using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using EMR.Model;

namespace EMR.ViewModel
{
    public class ReceiptManageViewModel : ViewModelBase
    {
        IPatientInfoService ObjPatientInfoService;

        public RelayCommand OnclickSearchCommand { get; set; }
        private PatientInfoModel patientInfo;
        string[] insurance = {"실비보험","생명보험","상해보험"};
        string[] relation = { "부", "모", "본인","기타" };
        string[] discount_percent = { "10", "20", "30","40","50","60","70","80","90","100" };
        string[] discount_reason = { "임직원가족", "저소득층", "장애인의료비지원", };
        string[] in_chage_name = { "안재홍", "이병원", "김머핀" };
        bool checkedVar = false;

        public bool CheckedVar
        {
            get { System.Diagnostics.Trace.WriteLine(checkedVar+"1"); return checkedVar;  }
            set { System.Diagnostics.Trace.WriteLine(checkedVar); checkedVar = value; }
        }

        public string[] Insurance
        {
            get { return insurance; }
            set { insurance = value; }
        }
        public string[] Relation
        {
            get { return relation; }
            set { relation = value; }
        }
        public string[] Discount_percent
        {
            get { return discount_percent; }
            set { discount_percent = value; }
        }
        public string[] Discount_reason
        {
            get { return discount_reason; }
            set { discount_reason = value; }
        }
        public string[] In_chage_name
        {
            get { return in_chage_name; }
            set { in_chage_name = value; }
        }

        public PatientInfoModel PatientInfo
        {
            get { return patientInfo; }
            set{  patientInfo = value; RaisePropertyChanged(() => PatientInfo); }

        }

         public ReceiptManageViewModel()
         {
            ObjPatientInfoService = new PatientInfoService();
            OnclickSearchCommand = new RelayCommand(OnclickSearchCommend, null);


         }
        
       
        private void OnclickSearchCommend()
        {
           
            PatientInfo = ObjPatientInfoService.Search(patientInfo.name,patientInfo.rrnumber);

            System.Diagnostics.Trace.WriteLine(patientInfo.name);
        

        }
    }
}
