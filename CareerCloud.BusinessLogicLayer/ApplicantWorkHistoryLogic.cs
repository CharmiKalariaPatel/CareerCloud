﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    public class ApplicantWorkHistoryLogic: BaseLogic<ApplicantWorkHistoryPoco>
    {

    public ApplicantWorkHistoryLogic(IDataRepository<ApplicantWorkHistoryPoco> repository) : base(repository)
    {
    }

    public override void Add(ApplicantWorkHistoryPoco[] pocos)
    {
        Verify(pocos);
        base.Add(pocos);
    }
    public override void Update(ApplicantWorkHistoryPoco[] pocos)
    {
        Verify(pocos);
        base.Update(pocos);
    }
        protected override void Verify(ApplicantWorkHistoryPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.CompanyName))
                {
                    exceptions.Add(new ValidationException(105, $"companyname for applicantworkhistory {poco.Id} cannot be null"));
                }
                else if (poco.CompanyName.Length <= 2)
                {
                    exceptions.Add(new ValidationException(105, $"companyname for applicantworkhistory {poco.Id} must be grater than ."));

                }

            }
            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}