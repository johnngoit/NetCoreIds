﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ids.Common.Interfaces
{
    public interface IPortScanAnalysis
    {
        bool CheckForVerticalScan(int threshold, int analysisWindow);
    }
}