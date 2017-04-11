﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bluebox.Models;

namespace Bluebox.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public string Title
        {
            get
            {
                if (Customer.Id != 0)
                    return "Edit Customer";

                return "New Customer";
            }
        }
    }
}