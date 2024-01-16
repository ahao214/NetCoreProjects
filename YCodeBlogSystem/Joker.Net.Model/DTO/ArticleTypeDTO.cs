﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joker.Net.Model.DTO
{
    public record ArticleTypeDTO
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; }
        public List<string> ArticleNames { get; set; } = new List<string>();
    }
}
