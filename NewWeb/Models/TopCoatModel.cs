﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewWeb.Models
{
    public class TopCoatModel
    {
#nullable enable
        [Key]
        public int? ID { get; set; }
        public string? DateTopCoat { get; set; }
    }
}
