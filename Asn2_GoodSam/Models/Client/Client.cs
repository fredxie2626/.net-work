using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Asn2_GoodSam.Models.Client
{
    public class Client
    {
        [Key]
        [DisplayName("Client Id")]
        public int ClientId { get; set; }
        [DisplayName("Last Name")]
        public string Surname { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }


        [DisplayName("Children: 0-6 years")]
        [RegularExpression("[0-9]*")]
        public int ChildrenZeroToSix { get; set; }
        [DisplayName("Children: 7-12 years")]
        [RegularExpression("[0-9]*")]
        public int ChildrenSevenToTwelve { get; set; }
        [DisplayName("Children: 13-18 years")]
        [RegularExpression("[0-9]*")]
        public int ChildrenThirteenToEighteen { get; set; }

        //[Range(1,12)]
        [DisplayName("Month")]
        public int Month { get; set; }
        [DisplayName("Day")]
        //[Range(1, 31)]
        public int Day { get; set; }
        [RegularExpression("[0-9][0-9][-][0-9][0-9][0-9][0-9][0-9]")]
        [DisplayName("Police File Number")]
        public string PoliceFileNumber { get; set; }
        [DisplayName("Court File Number")]
        public int CourtFileNumber { get; set; }
        [DisplayName("SWC File Number")]
        public int SWCFileNumber { get; set; }
        [DisplayName("Risk Assessment Assigned To")]
        public string RiskAssessmentAssignedTo { get; set; }
        [RegularExpression("^[A-z]+[,][A-z]+")]
        [DisplayName("Abuser Name")]
        public string AbuserName { get; set; }
        /*public DateTime DateLastTransfered { get; set; }
        public DateTime DateClosed { get; set; }
        public DateTime DateReopened { get; set; }*/

        //DropDown Lists
        public int EthnicityId { get; set; }
        public int GenderId { get; set; }
        public int AgeId { get; set; }
        [DisplayName("Fiscal Year")]
        public int FiscalYearId { get; set; }
        public int RiskLevelId { get; set; }
        public int CrisisId { get; set; }
        public int ServiceId { get; set; }
        public int ProgramId { get; set; }
        public int AssignedWorkerId { get; set; }
        public int ReferralSourceId { get; set; }
        public int ReferralContactId { get; set; }
        public int IncidentId { get; set; }
        public int AbuserRelationshipId { get; set; }
        public int VictimOfIncidentId { get; set; }
        public int FamilyViolenceFileId { get; set; }
        public int DuplicateFileId { get; set; }
        public int RepeatClientId { get; set; }
        public int StatusOfFileId { get; set; }

        [DisplayName("Ethnicity")]
        public virtual Ethnicity Ethnicity { get; set; }
        [DisplayName("Gender")]
        public virtual Gender Gender { get; set; }
        [DisplayName("Age")]
        public virtual Age Age { get; set; }
        [DisplayName("Fiscal Year")]
        public virtual FiscalYear FiscalYear { get; set; }
        [DisplayName("Risk Level")]
        public virtual RiskLevel RiskLevel { get; set; }
        [DisplayName("Crisis")]
        public virtual Crisis Crisis { get; set; }
        [DisplayName("Service")]
        public virtual Service Service { get; set; }
        [DisplayName("Program")]
        public virtual Program Program { get; set; }
        [DisplayName("Assigned Worker")]
        public virtual AssignedWorker AssignedWorker { get; set; }
        [DisplayName("Referral Source")]
        public virtual ReferralSource ReferralSource { get; set; }
        [DisplayName("Referral Contact")]
        public virtual ReferralContact ReferralContact { get; set; }
        [DisplayName("Incident")]
        public virtual Incident Incident { get; set; }
        [DisplayName("Abuser Relationship")]
        public virtual AbuserRelationship AbuserRelationship { get; set; }
        [DisplayName("Victim Of Incident")]
        public virtual VictimOfIncident VictimOfIncident { get; set; }
        [DisplayName("Family Violence File")]
        public virtual FamilyViolenceFile FamilyViolenceFile { get; set; }
        [DisplayName("Duplicate File")]
        public virtual DuplicateFile DuplicateFile { get; set; }
        [DisplayName("Repeat Client")]
        public virtual RepeatClient RepeatClient { get; set; }
        [DisplayName("Status Of File")]
        public virtual StatusOfFile StatusOfFile { get; set; }
       public virtual Smart Smart { get; set; }

    }

}