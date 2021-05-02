using System;
using travel.Enums;

namespace travel.DTO
{
    public class Passenger : BaseIdentityModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Gender { get; set; }
        public string DocumentNo { get; set; }
        public DocumentType DocumentType { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
