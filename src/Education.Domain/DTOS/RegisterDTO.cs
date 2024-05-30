﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain.DTOS
{
    public class RegisterDTO
    {
        public string FullName {  get; set; }
        public string Username { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
} 
