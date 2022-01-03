﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taurus.Entities
{
    public interface IEntity
    {
        public Guid Id { get; }

        public string Name { get; }
    }
}
