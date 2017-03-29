using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLogistics.Models
{
    public class EmployeeDocuments
    {

        public int Id { get; set; }
        public bool CV { get; set; }
        public bool DocumentCopy { get; set; }
        public bool Photos { get; set; }
        public bool MilitaryIdCopy { get; set; }
        public bool LaborCertification { get; set; }
        public bool PersonalReference { get; set; }
        public bool DisciplinaryBackground { get; set; }
        public bool KnowledgeTest { get; set; }
        public bool AdmissionTest { get; set; }
        public bool Contract { get; set; }
        public bool InternalRegulations { get; set; }
        public bool EndownmentLetter { get; set; }
        public bool CriticalPosition { get; set; }

    }
}