using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Model
{
    interface IPatientInfoService
    {
        List<PatientInfoModel> GetAll();
        bool Insert(PatientInfoModel objNewPatienInfo);
        bool Update(PatientInfoModel objNewPatienInfo);
        bool Delete(int id);
        PatientInfoModel Search(String name, String rrnumber);
    }
}
