using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankApp.MvcUI.ModelView
{
    public class HavaleViewModel
    {
        public int Id { get; set; }
        public int Gonderen { get; set; }
        public string Alici { get; set; }
        public decimal Bakiye { get; set; }
    }
}