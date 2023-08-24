﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollExercise.Models.Messages.Response
{
    public class BaseResponse<T>
    {
        public T Data { get; set; }

        public string Message { get; set; } = string.Empty;

        public int StatusCode { get; set; }
    }
}
