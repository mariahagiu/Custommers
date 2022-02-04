﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Resource.DataContracts
{
    [DataContract]
    public class Custommer
    {
        [DataMember] 
        public Guid IDCustommer { get; set; }
        [DataMember] 
        public string Name { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Position { get; set; }
        [DataMember] 
        public string Description { get; set; }
        [DataMember]
        public string Resume { get; set; }
    }
}
