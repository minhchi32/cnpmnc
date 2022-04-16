using System;
using System.Collections.Generic;

#nullable disable

namespace cnpmnc.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
