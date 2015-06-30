namespace Asn2_GoodSam.Migrations.ClientMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbuserRelationships",
                c => new
                    {
                        AbuserRelationshipId = c.Int(nullable: false, identity: true),
                        AbuserRelationshipName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.AbuserRelationshipId);
            
            CreateTable(
                "dbo.Ages",
                c => new
                    {
                        AgeId = c.Int(nullable: false, identity: true),
                        AgeName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.AgeId);
            
            CreateTable(
                "dbo.AssignedWorkers",
                c => new
                    {
                        AssignedWorkerId = c.Int(nullable: false, identity: true),
                        AssignedWorkerName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.AssignedWorkerId);
            
            CreateTable(
                "dbo.BadDateReports",
                c => new
                    {
                        BadDateReportId = c.Int(nullable: false, identity: true),
                        BadDateReportName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.BadDateReportId);
            
            CreateTable(
                "dbo.CityOfAssaults",
                c => new
                    {
                        CityOfAssaultId = c.Int(nullable: false, identity: true),
                        CityOfAssaultName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.CityOfAssaultId);
            
            CreateTable(
                "dbo.CityOfResidences",
                c => new
                    {
                        CityOfResidenceId = c.Int(nullable: false, identity: true),
                        CityOfResidenceName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.CityOfResidenceId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        FirstName = c.String(),
                        ChildrenZeroToSix = c.Int(nullable: false),
                        ChildrenSevenToTwelve = c.Int(nullable: false),
                        ChildrenThirteenToEighteen = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        PoliceFileNumber = c.String(),
                        CourtFileNumber = c.Int(nullable: false),
                        SWCFileNumber = c.Int(nullable: false),
                        RiskAssessmentAssignedTo = c.String(),
                        AbuserName = c.String(),
                        EthnicityId = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                        AgeId = c.Int(nullable: false),
                        FiscalYearId = c.Int(nullable: false),
                        RiskLevelId = c.Int(nullable: false),
                        CrisisId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        ProgramId = c.Int(nullable: false),
                        AssignedWorkerId = c.Int(nullable: false),
                        ReferralSourceId = c.Int(nullable: false),
                        ReferralContactId = c.Int(nullable: false),
                        IncidentId = c.Int(nullable: false),
                        AbuserRelationshipId = c.Int(nullable: false),
                        VictimOfIncidentId = c.Int(nullable: false),
                        FamilyViolenceFileId = c.Int(nullable: false),
                        DuplicateFileId = c.Int(nullable: false),
                        RepeatClientId = c.Int(nullable: false),
                        StatusOfFileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.AbuserRelationships", t => t.AbuserRelationshipId, cascadeDelete: true)
                .ForeignKey("dbo.Ages", t => t.AgeId, cascadeDelete: true)
                .ForeignKey("dbo.AssignedWorkers", t => t.AssignedWorkerId, cascadeDelete: true)
                .ForeignKey("dbo.Crises", t => t.CrisisId, cascadeDelete: true)
                .ForeignKey("dbo.DuplicateFiles", t => t.DuplicateFileId, cascadeDelete: true)
                .ForeignKey("dbo.Ethnicities", t => t.EthnicityId, cascadeDelete: true)
                .ForeignKey("dbo.FamilyViolenceFiles", t => t.FamilyViolenceFileId, cascadeDelete: true)
                .ForeignKey("dbo.FiscalYears", t => t.FiscalYearId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .ForeignKey("dbo.Incidents", t => t.IncidentId, cascadeDelete: true)
                .ForeignKey("dbo.Programs", t => t.ProgramId, cascadeDelete: true)
                .ForeignKey("dbo.ReferralContacts", t => t.ReferralContactId, cascadeDelete: true)
                .ForeignKey("dbo.ReferralSources", t => t.ReferralSourceId, cascadeDelete: true)
                .ForeignKey("dbo.RepeatClients", t => t.RepeatClientId, cascadeDelete: true)
                .ForeignKey("dbo.RiskLevels", t => t.RiskLevelId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .ForeignKey("dbo.StatusOfFiles", t => t.StatusOfFileId, cascadeDelete: true)
                .ForeignKey("dbo.VictimOfIncidents", t => t.VictimOfIncidentId, cascadeDelete: true)
                .Index(t => t.EthnicityId)
                .Index(t => t.GenderId)
                .Index(t => t.AgeId)
                .Index(t => t.FiscalYearId)
                .Index(t => t.RiskLevelId)
                .Index(t => t.CrisisId)
                .Index(t => t.ServiceId)
                .Index(t => t.ProgramId)
                .Index(t => t.AssignedWorkerId)
                .Index(t => t.ReferralSourceId)
                .Index(t => t.ReferralContactId)
                .Index(t => t.IncidentId)
                .Index(t => t.AbuserRelationshipId)
                .Index(t => t.VictimOfIncidentId)
                .Index(t => t.FamilyViolenceFileId)
                .Index(t => t.DuplicateFileId)
                .Index(t => t.RepeatClientId)
                .Index(t => t.StatusOfFileId);
            
            CreateTable(
                "dbo.Crises",
                c => new
                    {
                        CrisisId = c.Int(nullable: false, identity: true),
                        CrisisName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.CrisisId);
            
            CreateTable(
                "dbo.DuplicateFiles",
                c => new
                    {
                        DuplicateFileId = c.Int(nullable: false, identity: true),
                        DuplicateFileName = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.DuplicateFileId);
            
            CreateTable(
                "dbo.Ethnicities",
                c => new
                    {
                        EthnicityId = c.Int(nullable: false, identity: true),
                        EthnicityName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.EthnicityId);
            
            CreateTable(
                "dbo.FamilyViolenceFiles",
                c => new
                    {
                        FamilyViolenceFileId = c.Int(nullable: false, identity: true),
                        FamilyViolenceFileName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.FamilyViolenceFileId);
            
            CreateTable(
                "dbo.FiscalYears",
                c => new
                    {
                        FiscalYearId = c.Int(nullable: false, identity: true),
                        FiscalYearName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.FiscalYearId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        GenderName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.Incidents",
                c => new
                    {
                        IncidentId = c.Int(nullable: false, identity: true),
                        IncidentName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.IncidentId);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        ProgramId = c.Int(nullable: false, identity: true),
                        ProgramName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.ProgramId);
            
            CreateTable(
                "dbo.ReferralContacts",
                c => new
                    {
                        ReferralContactId = c.Int(nullable: false, identity: true),
                        ReferralContactName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.ReferralContactId);
            
            CreateTable(
                "dbo.ReferralSources",
                c => new
                    {
                        ReferralSourceId = c.Int(nullable: false, identity: true),
                        ReferralSourceName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.ReferralSourceId);
            
            CreateTable(
                "dbo.RepeatClients",
                c => new
                    {
                        RepeatClientId = c.Int(nullable: false, identity: true),
                        RepeatClientName = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.RepeatClientId);
            
            CreateTable(
                "dbo.RiskLevels",
                c => new
                    {
                        RiskLevelId = c.Int(nullable: false, identity: true),
                        RiskLevelName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.RiskLevelId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.ServiceId);
            
            CreateTable(
                "dbo.Smarts",
                c => new
                    {
                        ClientID = c.Int(nullable: false),
                        AccompanimentMinutes = c.Int(nullable: false),
                        NumberTransportsProvided = c.Int(nullable: false),
                        RefferedToNursePractitioner = c.Boolean(nullable: false),
                        SexWorkId = c.Int(nullable: false),
                        MultiplePerpetratorsId = c.Int(nullable: false),
                        DrugFacilitatedAssaultId = c.Int(nullable: false),
                        CityOfAssaultId = c.Int(nullable: false),
                        CityOfResidenceId = c.Int(nullable: false),
                        ReferringHospitalId = c.Int(nullable: false),
                        HospitalAttendedId = c.Int(nullable: false),
                        SocialWorkAttendanceId = c.Int(nullable: false),
                        PoliceAttendanceId = c.Int(nullable: false),
                        VictimServicesAttendanceId = c.Int(nullable: false),
                        MedicalOnlyId = c.Int(nullable: false),
                        EvidenceStoredId = c.Int(nullable: false),
                        HIVMedsId = c.Int(nullable: false),
                        ReferredToCBVSId = c.Int(nullable: false),
                        PoliceReportedId = c.Int(nullable: false),
                        ThirdPartyReportId = c.Int(nullable: false),
                        BadDateReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.BadDateReports", t => t.BadDateReportId, cascadeDelete: true)
                .ForeignKey("dbo.CityOfAssaults", t => t.CityOfAssaultId, cascadeDelete: true)
                .ForeignKey("dbo.CityOfResidences", t => t.CityOfResidenceId, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .ForeignKey("dbo.DrugFacilitatedAssaults", t => t.DrugFacilitatedAssaultId, cascadeDelete: true)
                .ForeignKey("dbo.EvidenceStoreds", t => t.EvidenceStoredId, cascadeDelete: true)
                .ForeignKey("dbo.HIVMeds", t => t.HIVMedsId, cascadeDelete: true)
                .ForeignKey("dbo.HospitalAttendeds", t => t.HospitalAttendedId, cascadeDelete: true)
                .ForeignKey("dbo.MedicalOnlies", t => t.MedicalOnlyId, cascadeDelete: true)
                .ForeignKey("dbo.MultiplePerpetrators", t => t.MultiplePerpetratorsId, cascadeDelete: true)
                .ForeignKey("dbo.PoliceAttendances", t => t.PoliceAttendanceId, cascadeDelete: true)
                .ForeignKey("dbo.PoliceReporteds", t => t.PoliceReportedId, cascadeDelete: true)
                .ForeignKey("dbo.ReferredToCBVS", t => t.ReferredToCBVSId, cascadeDelete: true)
                .ForeignKey("dbo.ReferringHospitals", t => t.ReferringHospitalId, cascadeDelete: true)
                .ForeignKey("dbo.SexWorks", t => t.SexWorkId, cascadeDelete: true)
                .ForeignKey("dbo.SocialWorkAttendances", t => t.SocialWorkAttendanceId, cascadeDelete: true)
                .ForeignKey("dbo.ThirdPartyReports", t => t.ThirdPartyReportId, cascadeDelete: true)
                .ForeignKey("dbo.VictimServicesAttendances", t => t.VictimServicesAttendanceId, cascadeDelete: true)
                .Index(t => t.ClientID)
                .Index(t => t.SexWorkId)
                .Index(t => t.MultiplePerpetratorsId)
                .Index(t => t.DrugFacilitatedAssaultId)
                .Index(t => t.CityOfAssaultId)
                .Index(t => t.CityOfResidenceId)
                .Index(t => t.ReferringHospitalId)
                .Index(t => t.HospitalAttendedId)
                .Index(t => t.SocialWorkAttendanceId)
                .Index(t => t.PoliceAttendanceId)
                .Index(t => t.VictimServicesAttendanceId)
                .Index(t => t.MedicalOnlyId)
                .Index(t => t.EvidenceStoredId)
                .Index(t => t.HIVMedsId)
                .Index(t => t.ReferredToCBVSId)
                .Index(t => t.PoliceReportedId)
                .Index(t => t.ThirdPartyReportId)
                .Index(t => t.BadDateReportId);
            
            CreateTable(
                "dbo.DrugFacilitatedAssaults",
                c => new
                    {
                        DrugFacilitatedAssaultId = c.Int(nullable: false, identity: true),
                        DrugFacilitatedAssaultName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.DrugFacilitatedAssaultId);
            
            CreateTable(
                "dbo.EvidenceStoreds",
                c => new
                    {
                        EvidenceStoredId = c.Int(nullable: false, identity: true),
                        EvidenceStoredName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.EvidenceStoredId);
            
            CreateTable(
                "dbo.HIVMeds",
                c => new
                    {
                        HIVMedsId = c.Int(nullable: false, identity: true),
                        HIVMedsName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.HIVMedsId);
            
            CreateTable(
                "dbo.HospitalAttendeds",
                c => new
                    {
                        HospitalAttendedId = c.Int(nullable: false, identity: true),
                        HospitalAttendedName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.HospitalAttendedId);
            
            CreateTable(
                "dbo.MedicalOnlies",
                c => new
                    {
                        MedicalOnlyId = c.Int(nullable: false, identity: true),
                        MedicalOnlyName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.MedicalOnlyId);
            
            CreateTable(
                "dbo.MultiplePerpetrators",
                c => new
                    {
                        MultiplePerpetratorsId = c.Int(nullable: false, identity: true),
                        MultiplePerpetratorsName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.MultiplePerpetratorsId);
            
            CreateTable(
                "dbo.PoliceAttendances",
                c => new
                    {
                        PoliceAttendanceId = c.Int(nullable: false, identity: true),
                        PoliceAttendanceName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.PoliceAttendanceId);
            
            CreateTable(
                "dbo.PoliceReporteds",
                c => new
                    {
                        PoliceReportedId = c.Int(nullable: false, identity: true),
                        PoliceReportedName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.PoliceReportedId);
            
            CreateTable(
                "dbo.ReferredToCBVS",
                c => new
                    {
                        ReferredToCBVSId = c.Int(nullable: false, identity: true),
                        ReferredToCBVSName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.ReferredToCBVSId);
            
            CreateTable(
                "dbo.ReferringHospitals",
                c => new
                    {
                        ReferringHospitalId = c.Int(nullable: false, identity: true),
                        ReferringHospitalName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.ReferringHospitalId);
            
            CreateTable(
                "dbo.SexWorks",
                c => new
                    {
                        SexWorkId = c.Int(nullable: false, identity: true),
                        SexWorkName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.SexWorkId);
            
            CreateTable(
                "dbo.SocialWorkAttendances",
                c => new
                    {
                        SocialWorkAttendanceId = c.Int(nullable: false, identity: true),
                        SocialWorkAttendanceName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.SocialWorkAttendanceId);
            
            CreateTable(
                "dbo.ThirdPartyReports",
                c => new
                    {
                        ThirdPartyReportId = c.Int(nullable: false, identity: true),
                        ThirdPartyReportName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.ThirdPartyReportId);
            
            CreateTable(
                "dbo.VictimServicesAttendances",
                c => new
                    {
                        VictimServicesAttendanceId = c.Int(nullable: false, identity: true),
                        VictimServicesAttendanceName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.VictimServicesAttendanceId);
            
            CreateTable(
                "dbo.StatusOfFiles",
                c => new
                    {
                        StatusOfFileId = c.Int(nullable: false, identity: true),
                        StatusOfFileName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.StatusOfFileId);
            
            CreateTable(
                "dbo.VictimOfIncidents",
                c => new
                    {
                        VictimOfIncidentId = c.Int(nullable: false, identity: true),
                        VictimOfIncidentName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.VictimOfIncidentId);
            
            CreateTable(
                "dbo.RiskStatus",
                c => new
                    {
                        RiskStatusId = c.Int(nullable: false, identity: true),
                        RiskStatusName = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.RiskStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "VictimOfIncidentId", "dbo.VictimOfIncidents");
            DropForeignKey("dbo.Clients", "StatusOfFileId", "dbo.StatusOfFiles");
            DropForeignKey("dbo.Smarts", "VictimServicesAttendanceId", "dbo.VictimServicesAttendances");
            DropForeignKey("dbo.Smarts", "ThirdPartyReportId", "dbo.ThirdPartyReports");
            DropForeignKey("dbo.Smarts", "SocialWorkAttendanceId", "dbo.SocialWorkAttendances");
            DropForeignKey("dbo.Smarts", "SexWorkId", "dbo.SexWorks");
            DropForeignKey("dbo.Smarts", "ReferringHospitalId", "dbo.ReferringHospitals");
            DropForeignKey("dbo.Smarts", "ReferredToCBVSId", "dbo.ReferredToCBVS");
            DropForeignKey("dbo.Smarts", "PoliceReportedId", "dbo.PoliceReporteds");
            DropForeignKey("dbo.Smarts", "PoliceAttendanceId", "dbo.PoliceAttendances");
            DropForeignKey("dbo.Smarts", "MultiplePerpetratorsId", "dbo.MultiplePerpetrators");
            DropForeignKey("dbo.Smarts", "MedicalOnlyId", "dbo.MedicalOnlies");
            DropForeignKey("dbo.Smarts", "HospitalAttendedId", "dbo.HospitalAttendeds");
            DropForeignKey("dbo.Smarts", "HIVMedsId", "dbo.HIVMeds");
            DropForeignKey("dbo.Smarts", "EvidenceStoredId", "dbo.EvidenceStoreds");
            DropForeignKey("dbo.Smarts", "DrugFacilitatedAssaultId", "dbo.DrugFacilitatedAssaults");
            DropForeignKey("dbo.Smarts", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Smarts", "CityOfResidenceId", "dbo.CityOfResidences");
            DropForeignKey("dbo.Smarts", "CityOfAssaultId", "dbo.CityOfAssaults");
            DropForeignKey("dbo.Smarts", "BadDateReportId", "dbo.BadDateReports");
            DropForeignKey("dbo.Clients", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.Clients", "RiskLevelId", "dbo.RiskLevels");
            DropForeignKey("dbo.Clients", "RepeatClientId", "dbo.RepeatClients");
            DropForeignKey("dbo.Clients", "ReferralSourceId", "dbo.ReferralSources");
            DropForeignKey("dbo.Clients", "ReferralContactId", "dbo.ReferralContacts");
            DropForeignKey("dbo.Clients", "ProgramId", "dbo.Programs");
            DropForeignKey("dbo.Clients", "IncidentId", "dbo.Incidents");
            DropForeignKey("dbo.Clients", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.Clients", "FiscalYearId", "dbo.FiscalYears");
            DropForeignKey("dbo.Clients", "FamilyViolenceFileId", "dbo.FamilyViolenceFiles");
            DropForeignKey("dbo.Clients", "EthnicityId", "dbo.Ethnicities");
            DropForeignKey("dbo.Clients", "DuplicateFileId", "dbo.DuplicateFiles");
            DropForeignKey("dbo.Clients", "CrisisId", "dbo.Crises");
            DropForeignKey("dbo.Clients", "AssignedWorkerId", "dbo.AssignedWorkers");
            DropForeignKey("dbo.Clients", "AgeId", "dbo.Ages");
            DropForeignKey("dbo.Clients", "AbuserRelationshipId", "dbo.AbuserRelationships");
            DropIndex("dbo.Smarts", new[] { "BadDateReportId" });
            DropIndex("dbo.Smarts", new[] { "ThirdPartyReportId" });
            DropIndex("dbo.Smarts", new[] { "PoliceReportedId" });
            DropIndex("dbo.Smarts", new[] { "ReferredToCBVSId" });
            DropIndex("dbo.Smarts", new[] { "HIVMedsId" });
            DropIndex("dbo.Smarts", new[] { "EvidenceStoredId" });
            DropIndex("dbo.Smarts", new[] { "MedicalOnlyId" });
            DropIndex("dbo.Smarts", new[] { "VictimServicesAttendanceId" });
            DropIndex("dbo.Smarts", new[] { "PoliceAttendanceId" });
            DropIndex("dbo.Smarts", new[] { "SocialWorkAttendanceId" });
            DropIndex("dbo.Smarts", new[] { "HospitalAttendedId" });
            DropIndex("dbo.Smarts", new[] { "ReferringHospitalId" });
            DropIndex("dbo.Smarts", new[] { "CityOfResidenceId" });
            DropIndex("dbo.Smarts", new[] { "CityOfAssaultId" });
            DropIndex("dbo.Smarts", new[] { "DrugFacilitatedAssaultId" });
            DropIndex("dbo.Smarts", new[] { "MultiplePerpetratorsId" });
            DropIndex("dbo.Smarts", new[] { "SexWorkId" });
            DropIndex("dbo.Smarts", new[] { "ClientID" });
            DropIndex("dbo.Clients", new[] { "StatusOfFileId" });
            DropIndex("dbo.Clients", new[] { "RepeatClientId" });
            DropIndex("dbo.Clients", new[] { "DuplicateFileId" });
            DropIndex("dbo.Clients", new[] { "FamilyViolenceFileId" });
            DropIndex("dbo.Clients", new[] { "VictimOfIncidentId" });
            DropIndex("dbo.Clients", new[] { "AbuserRelationshipId" });
            DropIndex("dbo.Clients", new[] { "IncidentId" });
            DropIndex("dbo.Clients", new[] { "ReferralContactId" });
            DropIndex("dbo.Clients", new[] { "ReferralSourceId" });
            DropIndex("dbo.Clients", new[] { "AssignedWorkerId" });
            DropIndex("dbo.Clients", new[] { "ProgramId" });
            DropIndex("dbo.Clients", new[] { "ServiceId" });
            DropIndex("dbo.Clients", new[] { "CrisisId" });
            DropIndex("dbo.Clients", new[] { "RiskLevelId" });
            DropIndex("dbo.Clients", new[] { "FiscalYearId" });
            DropIndex("dbo.Clients", new[] { "AgeId" });
            DropIndex("dbo.Clients", new[] { "GenderId" });
            DropIndex("dbo.Clients", new[] { "EthnicityId" });
            DropTable("dbo.RiskStatus");
            DropTable("dbo.VictimOfIncidents");
            DropTable("dbo.StatusOfFiles");
            DropTable("dbo.VictimServicesAttendances");
            DropTable("dbo.ThirdPartyReports");
            DropTable("dbo.SocialWorkAttendances");
            DropTable("dbo.SexWorks");
            DropTable("dbo.ReferringHospitals");
            DropTable("dbo.ReferredToCBVS");
            DropTable("dbo.PoliceReporteds");
            DropTable("dbo.PoliceAttendances");
            DropTable("dbo.MultiplePerpetrators");
            DropTable("dbo.MedicalOnlies");
            DropTable("dbo.HospitalAttendeds");
            DropTable("dbo.HIVMeds");
            DropTable("dbo.EvidenceStoreds");
            DropTable("dbo.DrugFacilitatedAssaults");
            DropTable("dbo.Smarts");
            DropTable("dbo.Services");
            DropTable("dbo.RiskLevels");
            DropTable("dbo.RepeatClients");
            DropTable("dbo.ReferralSources");
            DropTable("dbo.ReferralContacts");
            DropTable("dbo.Programs");
            DropTable("dbo.Incidents");
            DropTable("dbo.Genders");
            DropTable("dbo.FiscalYears");
            DropTable("dbo.FamilyViolenceFiles");
            DropTable("dbo.Ethnicities");
            DropTable("dbo.DuplicateFiles");
            DropTable("dbo.Crises");
            DropTable("dbo.Clients");
            DropTable("dbo.CityOfResidences");
            DropTable("dbo.CityOfAssaults");
            DropTable("dbo.BadDateReports");
            DropTable("dbo.AssignedWorkers");
            DropTable("dbo.Ages");
            DropTable("dbo.AbuserRelationships");
        }
    }
}
