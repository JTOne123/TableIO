﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableIO.ModelValidators
{
    public interface IModelValidator
    {
        ErrorDetail[] Validate(object model);
    }
}