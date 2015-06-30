using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asn2_GoodSam.Models.Client
{
    public class Smart
    {
        [Key]
        [ForeignKey("Client")]
        public int ClientID { get; set; }

        public int AccompanimentMinutes { get; set; }
        public int NumberTransportsProvided { get; set; }
        public bool RefferedToNursePractitioner { get; set; }
        
        public int SexWorkId { get; set; } 
        public int MultiplePerpetratorsId { get; set; }
        public int DrugFacilitatedAssaultId { get; set; }
        public int CityOfAssaultId { get; set; }
        public int CityOfResidenceId { get; set; }
        public int ReferringHospitalId { get; set; }
        public int HospitalAttendedId { get; set; }
        public int SocialWorkAttendanceId { get; set; }
        public int PoliceAttendanceId { get; set; }
        public int VictimServicesAttendanceId { get; set; }
        public int MedicalOnlyId { get; set; }
        public int EvidenceStoredId { get; set; }
        public int HIVMedsId { get; set; }
        public int ReferredToCBVSId { get; set; }
        public int PoliceReportedId { get; set; }
        public int ThirdPartyReportId { get; set; }
        public int BadDateReportId { get; set; }

        public SexWork SexWork { get; set; }
        public MultiplePerpetrators MultiplePerpetrators { get; set; }
         public DrugFacilitatedAssault DrugFacilitatedAssault { get; set; }
         public CityOfAssault CityOfAssault { get; set; }
         public CityOfResidence CityOfResidence { get; set; }
         public ReferringHospital ReferringHospital { get; set; }
         public HospitalAttended HospitalAttended { get; set; }
         public SocialWorkAttendance SocialWorkAttendance { get; set; }
         public PoliceAttendance PoliceAttendance { get; set; }
         public VictimServicesAttendance VictimServicesAttendance { get; set; }
         public MedicalOnly MedicalOnly { get; set; }
         public EvidenceStored EvidenceStored { get; set; }
         public HIVMeds HIVMeds { get; set; }
         public ReferredToCBVS ReferredToCBVS { get; set; }
         public PoliceReported PoliceReported { get; set; }
         public ThirdPartyReport ThirdPartyReport { get; set; }
         public BadDateReport BadDateReport { get; set; }

        public virtual Client Client { get; set; }

    }


}