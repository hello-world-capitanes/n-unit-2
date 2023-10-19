﻿using Scoring.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoring.Core.Interfaces.CalculatePreScoring
{
    public interface INegationRule
    {
        bool Check(Solicitud solicitud);
    }
}
