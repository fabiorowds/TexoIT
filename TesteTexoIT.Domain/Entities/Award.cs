using System;
using System.Collections.Generic;
using System.Text;

namespace TesteTexoIT.Domain.Entities
{
    public class Award
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string Studios { get; set; }
        public string Producers { get; set; }
        public bool Winner { get; set; }
    }
}
