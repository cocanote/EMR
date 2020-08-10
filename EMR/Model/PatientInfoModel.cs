 using GalaSoft.MvvmLight;
using System;

public class PatientInfoModel : ObservableObject 
{
    public int id
    {
        get { return _id; }
        set { _id = value; RaisePropertyChanged("id"); }
    }
    int _id;

    public string rrnumber
    {
        get { return _rrnumber; }
        set { _rrnumber = value; RaisePropertyChanged("rrnumber"); }
    }
    string _rrnumber;

    public string Insurance
    {
        get { return _insurance; }
        set { _insurance = value; RaisePropertyChanged("Insurance"); }
    }
    string _insurance;

    public string insuredperson_name
    {
        get { return _insuredperson_name; }
        set { _insuredperson_name = value; RaisePropertyChanged("insuredperson_name"); }
    }
    string _insuredperson_name;

    public string card_number
    {
        get { return _card_number; }
        set { _card_number = value; RaisePropertyChanged("card_number"); }
    }
    string _card_number;

    public string Relationship
    {
        get { return _relationship; }
        set { _relationship = value; RaisePropertyChanged("Relationship"); }
    }
    string _relationship;

    public string Combination
    {
        get { return _combination; }
        set { _combination = value; RaisePropertyChanged("Combination"); }
    }
    string _combination;

    public string name
    {
        get { return _name; }
        set { _name = value; RaisePropertyChanged("name"); }
    }
    string _name;

    public string cellphone
    {
        get { return _cellphone; }
        set { _cellphone = value; RaisePropertyChanged("cellphone"); }
    }
    string _cellphone;

    public string phone
    {
        get { return _phone; }
        set { _phone = value; RaisePropertyChanged("phone"); }
    }
    string _phone;

    public int? post_number
    {
        get { return _post_number; }
        set { _post_number = value; RaisePropertyChanged("post_number"); }
    }
    int? _post_number;

    public string adrress
    {
        get { return _adrress; }
        set { _adrress = value; RaisePropertyChanged("adrress"); }
    }
    string _adrress;

    public string mail
    {
        get { return _mail; }
        set { _mail = value; RaisePropertyChanged("mail"); }
    }
    string _mail;

    public string patient_memo
    {
        get { return _patient_memo; }
        set { _patient_memo = value; RaisePropertyChanged("patient_memo"); }
    }
    string _patient_memo;

    public string discount_percent
    {
        get { return _discount_percent; }
        set { _discount_percent = value; RaisePropertyChanged("discount_percent"); }
    }
    string _discount_percent;

    public string discount_reason
    {
        get { return _discount_reason; }
        set { _discount_reason = value; RaisePropertyChanged("discount_reason"); }
    }
    string _discount_reason;

    public string in_charge_name
    {
        get { return _in_charge_name; }
        set { _in_charge_name = value; RaisePropertyChanged("in_charge_name"); }
    }
    string _in_charge_name;

    public String birthday
    {
        get { return _birthday; }
        set { _birthday = value; RaisePropertyChanged("birthday"); }
    }
    String _birthday;

    public bool calender
    {
        get { return _calender; }
        set { _calender = value; RaisePropertyChanged("calender"); }
    }
    bool _calender;

    // patientInfo 모델 복사
    public void CopyData(PatientInfoModel param)
    {
        this.id = param.id;
        this.rrnumber = param.rrnumber;
        this.Insurance = param.Insurance;
        this.insuredperson_name = param.insuredperson_name;
        this.card_number = param.card_number;
        this.Relationship = param.Relationship;
        this.Combination = param.Combination;
        this.name = param.name;
        this.cellphone = param.cellphone;
        this.phone = param.phone;
        this.post_number = param.post_number;
        this.adrress = param.adrress;
        this.mail = param.mail;
        this.patient_memo = param.patient_memo;
        this.discount_percent = param.discount_percent;
        this.discount_reason = param.discount_reason;
        this.in_charge_name = param.in_charge_name;
        this.birthday = param.birthday;
        this.calender = param.calender;
    }
}