using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CareerCloud.EntityFrameworkDataAccess
{
    class CareerCloudContext : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyDescriptions)
                .WithRequired(p => p.CompanyProfiles)
                .HasForeignKey(p => p.Company)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyLocations)
                .WithRequired(p => p.CompanyProfiles)
                .HasForeignKey(p => p.Company)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SystemLanguageCodePoco>()
                .HasMany(c => c.CompanyDescriptions)
                .WithRequired(l => l.SystemLanguageCodes)
                .HasForeignKey(l => l.LanguageId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyProfilePoco>()
                .HasMany(c => c.CompanyJobs)
                .WithRequired(p => p.CompanyProfiles)
                .HasForeignKey(p => p.Company)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(c => c.CompanyJobSkills)
                .WithRequired(j => j.CompanyJobs)
                .HasForeignKey(j => j.Job)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(c => c.CompanyJobEducations)
                .WithRequired(j => j.CompanyJobs)
                .HasForeignKey(j => j.Job)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(c => c.CompanyJobDescriptions)
                .WithRequired(j => j.CompanyJobs)
                .HasForeignKey(j => j.Job)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(a => a.ApplicantJobApplications)
                .WithRequired(j => j.CompanyJobs)
                .HasForeignKey(j => j.Job)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantJobApplications)
                .WithRequired(p => p.ApplicantProfiles)
                .HasForeignKey(p => p.Applicant)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantEducations)
                .WithRequired(p => p.ApplicantProfiles)
                .HasForeignKey(p => p.Applicant)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantResumes)
                .WithRequired(p => p.ApplicantProfiles)
                .HasForeignKey(p => p.Applicant)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantSkills)
                .WithRequired(p => p.ApplicantProfiles)
                .HasForeignKey(p => p.Applicant)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantWorkHistories)
                .WithRequired(p => p.ApplicantProfiles)
                .HasForeignKey(p => p.Applicant)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(a => a.ApplicantWorkHistories)
                .WithRequired(c => c.SystemCountryCodes)
                .HasForeignKey(c => c.CountryCode)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(a => a.ApplicantProfiles)
                .WithRequired(c => c.SystemCountryCodes)
                .HasForeignKey(c => c.Country)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(a => a.ApplicantProfiles)
                .WithRequired(s => s.SecurityLogins)
                .HasForeignKey(s => s.Login)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(a => a.SecurityLoginsLogs)
                .WithRequired(s => s.SecurityLogins)
                .HasForeignKey(s => s.Login)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(a => a.SecurityLoginsRoles)
                .WithRequired(s => s.SecurityLogins)
                .HasForeignKey(s => s.Login)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SecurityRolePoco>()
                .HasMany(a => a.SecurityLoginsRoles)
                .WithRequired(s => s.SecurityRoles)
                .HasForeignKey(s => s.Role)
                .WillCascadeOnDelete(true);


            base.OnModelCreating(modelBuilder);
        }

        public CareerCloudContext() : 
            base(ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString)
        {
        }

        DbSet<ApplicantEducationPoco> applicantEducations { get; set; }
        DbSet<ApplicantJobApplicationPoco> applicantJobApplications { get; set; }
        DbSet<ApplicantProfilePoco> applicantProfiles { get; set; }
        DbSet<ApplicantResumePoco> applicantResumes { get; set; }
        DbSet<ApplicantSkillPoco> applicantSkills { get; set; }
        DbSet<ApplicantWorkHistoryPoco> applicantWorkHistories { get; set; }

        DbSet<CompanyDescriptionPoco> companyDescriptions { get; set; }
        DbSet<CompanyJobDescriptionPoco> companyJobDescriptions { get; set; }
        DbSet<CompanyJobEducationPoco> companyJobEducations { get; set; }
        DbSet<CompanyJobPoco> companyJobs { get; set; }
        DbSet<CompanyJobSkillPoco> companyJobSkills { get; set; }
        DbSet<CompanyLocationPoco> companyLocations { get; set; }
        DbSet<CompanyProfilePoco> companyProfiles { get; set; }

        DbSet<SecurityLoginPoco> securityLogins { get; set; }
        DbSet<SecurityLoginsLogPoco> securityLoginsLogs { get; set; }
        DbSet<SecurityLoginsRolePoco> securityLoginsRoles { get; set; }
        DbSet<SecurityRolePoco> securityRoles { get; set; }

        DbSet<SystemCountryCodePoco> systemCountryCodes { get; set; }
        DbSet<SystemLanguageCodePoco> systemLanguageCodes { get; set; }
     
    }
}
