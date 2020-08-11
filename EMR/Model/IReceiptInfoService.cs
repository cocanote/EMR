using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Model
{
    interface IReceiptInfoService
    {
        bool Insert(ReceiptInfoModel objNewreceiptInfo);
        bool InsertToReserve(PatientInfoModel objNewreceiptInfo);
        bool Update(PatientInfoModel objNewreceiptInfo);
        List<ReceiptInfoModel> GetList();
    }
}
