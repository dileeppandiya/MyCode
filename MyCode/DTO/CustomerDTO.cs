﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCode.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CustomerExtendedDTO : CustomerDTO
    {
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
    }
         
}