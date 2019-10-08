using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.WCF
{
    [ServiceContract]
   public interface ICompany
    {
        [OperationContract]
        void AddCompanyDescription(CompanyDescriptionPoco[] items);
        [OperationContract]
        void UpdateCompanyDescription(CompanyDescriptionPoco[] items);
        [OperationContract]
        void RemoveCompanyDescription(CompanyDescriptionPoco[] items);
        [OperationContract]
        CompanyDescriptionPoco GetSingleCompanyDescription(string Id);
        [OperationContract]
        List<CompanyDescriptionPoco> GetAllCompanyDescription();

        //cjd
        [OperationContract]
        void AddCompanyJobDescription(CompanyJobDescriptionPoco[] items);
        [OperationContract]
        void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] items);
        [OperationContract]
        void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] items);
        [OperationContract]
        CompanyJobDescriptionPoco GetSingleCompanyJobDescription(string Id);
        [OperationContract]
        List<CompanyJobDescriptionPoco> GetAllCompanyJobDescription();

        //cjE
        [OperationContract]
        void AddCompanyJobEducation(CompanyJobEducationPoco[] items);
        [OperationContract]
        void UpdateCompanyJobEducation(CompanyJobEducationPoco[] items);
        [OperationContract]
        void RemoveCompanyJobEducation(CompanyJobEducationPoco[] items);
        [OperationContract]
        CompanyJobEducationPoco GetSingleCompanyJobEducation(string Id);
        [OperationContract]
        List<CompanyJobEducationPoco> GetAllCompanyJobEducation();

        //cj
        [OperationContract]
        void AddCompanyJob(CompanyJobPoco[] items);
        [OperationContract]
        void UpdateCompanyJob(CompanyJobPoco[] items);
        [OperationContract]
        void RemoveCompanyJob(CompanyJobPoco[] items);
        [OperationContract]
        CompanyJobPoco GetSingleCompanyJob(string Id);
        [OperationContract]
        List<CompanyJobPoco> GetAllCompanyJob();

        //cjs
        [OperationContract]
        void AddCompanyJobSkill(CompanyJobSkillPoco[] items);
        [OperationContract]
        void UpdateCompanyJobSkill(CompanyJobSkillPoco[] items);
        [OperationContract]
        void RemoveCompanyJobSkill(CompanyJobSkillPoco[] items);
        [OperationContract]
        CompanyJobSkillPoco GetSingleCompanyJobSkill(string Id);
        [OperationContract]
        List<CompanyJobSkillPoco> GetAllCompanyJobSkill();

        //cl
        [OperationContract]
        void AddCompanyLocation(CompanyLocationPoco[] items);
        [OperationContract]
        void UpdateCompanyLocation(CompanyLocationPoco[] items);
        [OperationContract]
        void RemoveCompanyLocation(CompanyLocationPoco[] items);
        [OperationContract]
        CompanyLocationPoco GetSingleCompanyLocation(string Id);
        [OperationContract]
        List<CompanyLocationPoco> GetAllCompanyLocation();

        //cp
        [OperationContract]
        void AddCompanyProfile(CompanyProfilePoco[] items);
        [OperationContract]
        void UpdateCompanyProfile(CompanyProfilePoco[] items);
        [OperationContract]
        void RemoveCompanyProfile(CompanyProfilePoco[] items);
        [OperationContract]
        CompanyProfilePoco GetSingleCompanyProfile(string Id);
        [OperationContract]
        List<CompanyProfilePoco> GetAllCompanyProfile();
    }
}
