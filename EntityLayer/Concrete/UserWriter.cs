﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class UserWriter
    {
        [Key]
        public int UserWriterId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ImageURL { get; set; }
        public bool Status { get; set; }
        public List<UserMessage> UserMessages { get; set; }
    }
}
