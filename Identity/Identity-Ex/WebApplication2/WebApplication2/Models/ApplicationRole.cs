﻿using Microsoft.AspNetCore.Identity;

namespace WebApplication2.Models
{
    public class ApplicationRole: IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
