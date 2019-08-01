using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
    class CareerCloudContext:DbContext
    {
        public CareerCloudContext() : 
            base(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)
        {



        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyProfilePoco>().Ignore(s => s.TimeStamp);
            modelBuilder.Entity<ApplicantEducationPoco>().Ignore(s => s.TimeStamp);
            modelBuilder.Entity<ApplicantJobApplicationPoco>().Ignore(s => s.TimeStamp);
            modelBuilder.Entity<ApplicantProfilePoco>().Ignore(s => s.TimeStamp);
            modelBuilder.Entity<ApplicantSkillPoco>().Ignore(s => s.TimeStamp);
            modelBuilder.Entity<CompanyDescriptionPoco>().Ignore(s => s.TimeStamp);
            modelBuilder.Entity<CompanyJobDescriptionPoco>().Ignore(s => s.TimeStamp);
            modelBuilder.Entity<CompanyJobPoco>().Ignore(s => s.TimeStamp);
            modelBuilder.Entity<CompanyJobSkillPoco>().Ignore(s => s.TimeStamp);
            modelBuilder.Entity<CompanyLocationPoco>().Ignore(s => s.TimeStamp);
            modelBuilder.Entity<CompanyJobEducationPoco>().Ignore(s => s.TimeStamp);
            modelBuilder.Entity<ApplicantWorkHistoryPoco>().Ignore(s => s.TimeStamp);
            modelBuilder.Entity<ApplicantProfilePoco>().Ignore(s => s.TimeStamp);
            modelBuilder.Entity<SecurityLoginPoco>().Ignore(s => s.TimeStamp);
            modelBuilder.Entity<SecurityLoginsRolePoco>().Ignore(s => s.TimeStamp);


            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyDescriptions)
                .WithRequired(d => d.CompanyProfile)
                .HasForeignKey(c => c.Company)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(cl => cl.CompanyLocations)
                .WithRequired(cp => cp.CompanyProfiles)
                .HasForeignKey(s => s.Company)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SystemLanguageCodePoco>()
                .HasMany(c => c.CompanyDescriptions)
                .WithRequired(d => d.SystemLanguageCode)
                .HasForeignKey(s => s.LanguageId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyJobs)
                .WithRequired(d => d.CompanyProfiles)
                .HasForeignKey(s => s.Company)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(c => c.CompanyJobSkills)
                .WithRequired(d => d.CompanyJob)
                .HasForeignKey(s => s.Job)
                .WillCascadeOnDelete(true);
           

            modelBuilder.Entity<CompanyJobPoco>()
               .HasMany(c => c.CompanyJobDescriptions)
               .WithRequired(d => d.CompanyJob)
               .HasForeignKey(s => s.Job)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyJobPoco>()
              .HasMany(c => c.CompanyJobEducations)
              .WithRequired(d => d.CompanyJob)
              .HasForeignKey(s => s.Job)
              .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyJobPoco>()
               .HasMany(c => c.ApplicantJobApplications)
               .WithRequired(d => d.CompanyJob)
               .HasForeignKey(s => s.Job)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(c => c.ApplicantJobApplications)
               .WithRequired(d => d.ApplicantProfile)
               .HasForeignKey(s => s.Applicant)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(c => c.ApplicantSkills)
               .WithRequired(d => d.ApplicantProfile)
               .HasForeignKey(s => s.Applicant)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(c => c.ApplicantResumes)
               .WithRequired(d => d.ApplicantProfile)
               .HasForeignKey(s => s.Applicant)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<SecurityLoginPoco>()
               .HasMany(c => c.ApplicantProfiles)
               .WithRequired(d => d.SecurityLogin)
               .HasForeignKey(s => s.Login)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(ae => ae.ApplicantEducations)
               .WithRequired(ap => ap.ApplicantProfile)
               .HasForeignKey(ap => ap.Applicant)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<SecurityLoginPoco>()
               .HasMany(c => c.SecurityLoginsLogs)
               .WithRequired(d => d.SecurityLogin)
               .HasForeignKey(s => s.Login)
               .WillCascadeOnDelete(true);

            modelBuilder.Entity<SecurityLoginPoco>()
              .HasMany(c => c.SecurityLoginsRoles)
              .WithRequired(d => d.SecurityLogin)
              .HasForeignKey(s => s.Login)
              .WillCascadeOnDelete(true);

            modelBuilder.Entity<SecurityRolePoco>()
              .HasMany(c => c.SecurityLoginsRoles)
              .WithRequired(d => d.SecurityRole)
              .HasForeignKey(s => s.Role)
              .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicantProfilePoco>()
             .HasMany(c => c.ApplicantWorkHistories)
             .WithRequired(d => d.ApplicantProfile)
             .HasForeignKey(s => s.Applicant)
             .WillCascadeOnDelete(true);

            modelBuilder.Entity<SystemCountryCodePoco>()
             .HasMany(c => c.ApplicantWorkHistories)
             .WithRequired(d => d.SystemCountryCode)
             .HasForeignKey(s => s.CountryCode)
             .WillCascadeOnDelete(true);

            modelBuilder.Entity<SystemCountryCodePoco>()
             .HasMany(c => c.ApplicantProfiles)
             .WithRequired(d => d.SystemCountryCodes)
             .HasForeignKey(s => s.Country)
             .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
        DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        DbSet<ApplicantEducationPoco> applicantEducations { get; set; }
        DbSet<ApplicantProfilePoco> applicantProfiles { get; set; }
        DbSet<ApplicantResumePoco> applicantResumes { get; set; }
        DbSet<ApplicantSkillPoco> applicantSkills { get; set; }
        DbSet<ApplicantWorkHistoryPoco> applicantWorkHistories{ get; set; }
        DbSet<ApplicantJobApplicationPoco> applicantJobApplications { get; set; }
        DbSet<CompanyJobDescriptionPoco> companyJobDescriptions { get; set; }
        DbSet<CompanyJobPoco> companyJobs { get; set; }
        DbSet<CompanyJobSkillPoco> companyJobSkills { get; set; }
        DbSet<CompanyLocationPoco> companyLocations { get; set; }
        DbSet<CompanyJobEducationPoco> companyJobEducations { get; set; }

        DbSet<SecurityLoginPoco> securityLogins { get; set; }
        DbSet<SecurityLoginsLogPoco> securityLoginsLogs { get; set; }
        DbSet<SecurityLoginsRolePoco> securityLoginsRoles { get; set; }
        DbSet<SecurityRolePoco> securityRoles { get; set; }
        DbSet<SystemCountryCodePoco> systemCountryCodes { get; set; }
        DbSet<SystemLanguageCodePoco> systemLanguageCodes { get; set; }
        DbSet<CompanyProfilePoco> companyProfiles { get; set; }



        


    }
}
