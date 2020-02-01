using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.MVC.LinkedIn.DbLayer.Enums
{
    public enum EmploymentType
    {
        FullTime = 1,
        PartTime = 2,
        SelfEmployed = 4,
        FreeLance = 8,
        Contract = 16,
        Internship = 32,
        apprenticeship = 64

    }
}
