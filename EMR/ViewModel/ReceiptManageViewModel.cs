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
using System.Windows.Data;
using System.Globalization;

namespace EMR.ViewModel
{
    public class ReceiptManageViewModel : ViewModelBase
    {
        IPatientInfoService ObjPatientInfoService;
        IReceiptInfoService ObjRececiptInfoService;


        public RelayCommand OnclickSearchCommand { get; set; }
        public RelayCommand OnclickNewCommand { get; set; }
        public RelayCommand OnclickSaveCommand { get; set; }
        public RelayCommand OnclickModifyCommand { get; set; }
        public RelayCommand OnclickDeleteCommand { get; set; }
        public RelayCommand OnclickReceiptCommand { get; set; }
        public RelayCommand OnclickReceiptModifyCommand { get; set; }
        public RelayCommand OnclickReceiptReservationCommand { get; set; }
        private PatientInfoModel patientInfo;
        private ReceiptInfoModel receiptInfo;
        private List<ReceiptInfoModel> receipted;
        string[] insurance = { "실비보험", "생명보험", "상해보험" };
        string[] relation = { "부", "모", "본인", "기타" };
        string[] discount_percent = { "10", "20", "30", "40", "50", "60", "70", "80", "90", "100" };
        string[] discount_reason = { "임직원가족", "저소득층", "장애인의료비지원", };
        string[] in_chage_name = { "안재홍", "이병원", "김머핀" };
        string[] patient_classification = { "내과", "외과", "소아과", "성형외과" };
        string[] doctor_in_charge = { "김사부","허준" };
        string[] series = { "null","null" };
        string[] diagnostic_experience = {"초진","재진"};
         

        bool checkedVar = false;

        public ReceiptManageViewModel()
        {
            ObjPatientInfoService = new PatientInfoService();
            ObjRececiptInfoService = new ReceiptInfoService();
            OnclickSearchCommand = new RelayCommand(OnclickSearchCommend, null);
            OnclickNewCommand = new RelayCommand(OnclickNewCommend, null);
            OnclickSaveCommand = new RelayCommand(OnclickSaveCommend, null);
            OnclickModifyCommand = new RelayCommand(OnclickModifyCommend, null);
            OnclickDeleteCommand = new RelayCommand(OnclickDeleteCommend, null);

            OnclickReceiptCommand = new RelayCommand(OnclickReceiptCommend, null);
            OnclickReceiptModifyCommand = new RelayCommand(OnclickReceiptModifyCommend, null);
            OnclickReceiptReservationCommand = new RelayCommand(OnclickReceiptReservationCommend, null);
            PatientInfo = new PatientInfoModel();
            ReceiptInfo = new ReceiptInfoModel();
            Receipted = new List<ReceiptInfoModel>();
            ReadOn = true;
            Comboclick = false;
            Receipted = ObjRececiptInfoService.GetList();




        }


        public bool CheckedVar
        {
            get {  return checkedVar;  }
            set { checkedVar = value; }
        }

        private bool readOn;

        public bool ReadOn
        {
            get { return readOn; }
            set { readOn = value; RaisePropertyChanged(() => ReadOn); }
        }
        private bool comboclick;

        public bool Comboclick
        {
            get { return comboclick; }
            set { comboclick = value; RaisePropertyChanged(() => Comboclick); }
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
        public string[] Patient_classification
        {
            get { return patient_classification; }
            set { patient_classification = value; }
        }
        public string[] Doctor_in_charge
        {
            get { return doctor_in_charge; }
            set { doctor_in_charge = value; }
        }
        public string[] Series
        {
            get { return series; }
            set { series = value; }
        }
        public string[] Diagnostic_experience
        {
            get { return diagnostic_experience; }
            set { diagnostic_experience = value; }
        }

        public PatientInfoModel PatientInfo
        {
            get { return patientInfo; }
            set{  patientInfo = value; RaisePropertyChanged(() => PatientInfo); }


        }
        public ReceiptInfoModel ReceiptInfo
        {
            get { return receiptInfo; }
            set { receiptInfo = value; RaisePropertyChanged(() => ReceiptInfo); }


        }
        public List<ReceiptInfoModel> Receipted
        {
            get { return receipted; }
            set { receipted = value; RaisePropertyChanged(() => Receipted); }


        }



        private void OnclickSearchCommend()
        {
            PatientInfo = ObjPatientInfoService.Search(PatientInfo.name, PatientInfo.rrnumber);
            ReadOn = false;
            Comboclick = true;
        }
        private void OnclickNewCommend()
        {
            PatientInfo = new PatientInfoModel();
            MessageBox.Show("환자정보를 입력해주세요");
            ReadOn = false;
            Comboclick = true;

        }
        private void OnclickSaveCommend()
        {
            if (ObjPatientInfoService.Insert(PatientInfo))
            {
                ReadOn = true;
                Comboclick = false;
                PatientInfo = ObjPatientInfoService.Search(PatientInfo.name, PatientInfo.rrnumber);
            }
            
        }
        private void OnclickModifyCommend()
        {
       
            ObjPatientInfoService.Update(PatientInfo);
        }
        private void OnclickDeleteCommend()
        {
            ObjPatientInfoService.Delete(PatientInfo.id);
            PatientInfo = new PatientInfoModel();
        }
        private void OnclickReceiptReservationCommend()
        {
            throw new NotImplementedException();
        }

        private void OnclickReceiptModifyCommend()
        {
            throw new NotImplementedException();
        }

        private void OnclickReceiptCommend()
        {
            ReceiptInfo.patient_id = PatientInfo.id;
            if (ObjRececiptInfoService.Insert(ReceiptInfo))
            {
                MessageBox.Show("접수되었습니다.");
                Receipted = ObjRececiptInfoService.GetList();
                ReceiptInfo = new ReceiptInfoModel();
            }
            else
                MessageBox.Show("입력정보를 확인해주세요");
        }

    }
   
}
