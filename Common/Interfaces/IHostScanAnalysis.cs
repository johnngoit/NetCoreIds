﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IHostScanAnalysis
    {
        bool CheckForHorizontalScan(string connectionString, int threshold, int? analysisWindow);
    }
}
