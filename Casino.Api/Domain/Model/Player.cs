using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
    public class Player : BaseEntity
    {
        public decimal amount { get; set; }
        public string fullName { get; set; }
        public bool isActive { get; set; }
    }
}
