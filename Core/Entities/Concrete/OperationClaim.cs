﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public Guid OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }
    }
}
