﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Database
{
    public interface ITestStatsRepository
    {
        void Add(Run run);
    }
}
