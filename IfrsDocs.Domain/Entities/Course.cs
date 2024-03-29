﻿using System;
using System.Collections.Generic;

namespace IfrsDocs.Domain
{
    public partial class Course
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public List<Form> Forms { get; set; }
    }
}
