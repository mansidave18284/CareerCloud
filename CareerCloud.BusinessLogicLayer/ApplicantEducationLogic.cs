﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
    
    public class ApplicantEducationLogic : BaseLogic<ApplicantEducationPoco>
    {
       // private const int saltLengthLimit = 10;

        public ApplicantEducationLogic(IDataRepository<ApplicantEducationPoco> repository) : base(repository)
        {
        }

        public override void Add(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            //foreach (ApplicantEducationPoco poco in pocos)
           // {
                //poco.Password = ComputeHash(poco.Password, new byte[saltLengthLimit]);
                //poco.Created = DateTime.Now.ToUniversalTime();
                //poco.IsLocked = false;
                //poco.IsInactive = false;
                //poco.ForceChangePassword = true;
                //poco.PasswordUpdate = poco.Created.AddDays(30);
           // }
            base.Add(pocos);
        }

        public override void Update(ApplicantEducationPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }

        protected override void Verify(ApplicantEducationPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
           // string[] requiredExtendedPasswordChars = new string[] { "$", "*", "#", "_", "@" };

            foreach (var poco in pocos)
            {
                if (string.IsNullOrEmpty(poco.Major))
                {
                    exceptions.Add(new ValidationException(107, $"Major for ApplicationEducation {poco.Id} cannot be empty"));
                }
                else if (poco.Major.Length <= 3)
                {
                    exceptions.Add(new ValidationException(107, $"Major for ApplicationEducation {poco.Id} must be at least 3 characters."));
                }
               
                if (poco.StartDate != null)
                {
                    if(poco.StartDate > DateTime.Now)
                    {
                        exceptions.Add(new ValidationException(108, $"StartDate for ApplicationEducation {poco.Id} cannot be greater than today"));
                    }                    
                }

                if (poco.CompletionDate != null)
                {
                    if (poco.CompletionDate < poco.StartDate)
                    {
                        exceptions.Add(new ValidationException(109, $"CompletionDate for ApplicationEducation {poco.Id} cannot be earlier than StartDate"));
                    }
                }

            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException(exceptions);
            }
        }

        
    }
}
