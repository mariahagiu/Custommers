﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manager.DataContracts;
using System.ServiceModel;

namespace Manager.ServiceContracts
{
    [ServiceContract]
    public interface ICustommerService
    {
        [OperationContract] 
        Custommer[] GetCustommers();

        [OperationContract]
        Custommer GetCustommerByID(Guid ID);

        [OperationContract]
        Manager.DataContracts.Error[] AddCustommer(Custommer custommer);
    }
}
    
