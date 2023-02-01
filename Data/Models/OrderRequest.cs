﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class OrderRequest
    {
        public int? OrderRequestId { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public bool? IsApprove { get; set; }
        public int? ServiceId { get; set; }
        public int? PakageId { get; set; }
        public string? RequestIntro { get; set; }
    }
}
