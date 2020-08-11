
using GalaSoft.MvvmLight;

public class ReceiptInfoModel : ObservableObject
{
    public int patient_id
    {
        get { return _patient_id; }
        set { _patient_id = value; RaisePropertyChanged("patient_id"); }
    }
    int _patient_id;

    public string patient_name
    {
        get { return _patient_name; }
        set { _patient_name = value; RaisePropertyChanged("patient_name"); }
    }
    string _patient_name;

    public string patient_classification
    {
        get { return _patient_classification; }
        set { _patient_classification = value; RaisePropertyChanged("patient_classification"); }
    }
    string _patient_classification;

    public string doctor_in_charge
    {
        get { return _doctor_in_charge; }
        set { _doctor_in_charge = value; RaisePropertyChanged("doctor_in_charge"); }
    }
    string _doctor_in_charge;

    public string series
    {
        get { return _series; }
        set { _series = value; RaisePropertyChanged("series"); }
    }
    string _series;

    public string diagnostic_experience
    {
        get { return _diagnostic_experience; }
        set { _diagnostic_experience = value; RaisePropertyChanged("diagnostic_experience"); }
    }
    string _diagnostic_experience;

    public string last_visit
    {
        get { return _last_visit; }
        set { _last_visit = value; RaisePropertyChanged("last_visit"); }
    }
    string _last_visit;

    public string receipt_memo
    {
        get { return _receipt_memo; }
        set { _receipt_memo = value; RaisePropertyChanged("receipt_memo"); }
    }
    string _receipt_memo;

    public string reservation_time
    {
        get { return _reservation_time; }
        set { _reservation_time = value; RaisePropertyChanged("reservation_time"); }
    }
    string _reservation_time;

    // receiptInfo 모델 복사
    public void CopyData(ReceiptInfoModel param)
    {
        this.patient_id = param.patient_id;
        this.patient_classification = param.patient_classification;
        this.doctor_in_charge = param.doctor_in_charge;
        this.series = param.series;
        this.diagnostic_experience = param.diagnostic_experience;
        this.last_visit = param.last_visit;
        this.receipt_memo = param.receipt_memo;
        this.reservation_time = param.reservation_time;
    }
}