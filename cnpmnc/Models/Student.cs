﻿using System;
using System.Collections.Generic;

#nullable disable

namespace cnpmnc.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int? FacultyId { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}
