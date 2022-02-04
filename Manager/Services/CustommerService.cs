﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.DataContracts;
using Manager.ServiceContracts;
using Utilities;

namespace Manager.Services
{
    public class CustommerService : ICustommerService
    {
        private readonly CustommerResource.ICustommerResource custommerResource;
        private readonly CustommerValidation.ICustommerValidationService custommerValidationService;
        public CustommerService()
        {
            this.custommerResource = new CustommerResource.CustommerResourceClient();
            this.custommerValidationService = new CustommerValidation.CustommerValidationServiceClient();
        }
        public Manager.DataContracts.Custommer[] GetCustommers()
        {
            CustommerResource.Custommer[] custommers = custommerResource.GetAllCustommers();
            List<Custommer> custommerList = new List<Custommer>();
            foreach (CustommerResource.Custommer custommer in custommers) custommerList.Add(custommer.MapObject<Manager.DataContracts.Custommer>());
            return custommerList.ToArray();
        }
        public Manager.DataContracts.Custommer GetCustommerByID(Guid ID)
        {
            CustommerResource.Custommer custommer = custommerResource.GetCustommerByID(ID);
            return custommer.MapObject<Manager.DataContracts.Custommer>();
        }
        public Manager.DataContracts.Error[] AddCustommer(Custommer custommer)
        {
            
            CustommerResource.Custommer newCustommer = custommer.MapObject<CustommerResource.Custommer>();
            CustommerValidation.CustommerName custommerName = new CustommerValidation.CustommerName
         
                { Name = newCustommer.Name };
            List<CustommerValidation.Error> errors = new List<CustommerValidation.Error>();
            errors.AddRange(custommerValidationService.ValidateName(custommerName)); 
            errors.AddRange(custommerValidationService.Validate(newCustommer.MapObject<CustommerValidation.Custommer>()));
            if (!errors.Any()) custommerResource.InsertCustommer(newCustommer);
            List<Manager.DataContracts.Error> returnedErrors = new List<Manager.DataContracts.Error>();
            foreach (CustommerValidation.Error error in errors)
            returnedErrors.Add(error.MapObject<Manager.DataContracts.Error>());
            return returnedErrors.ToArray();
        }

        }
    }

