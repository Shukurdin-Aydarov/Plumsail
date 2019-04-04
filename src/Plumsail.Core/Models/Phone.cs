using System;

namespace Plumsail.Core.Models
{
    public class Phone
    {
        public int Id { get; internal set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public DateTime ProductionDate { get; set; }
        public string Color { get; set; }
        public int Memory { get; set; }
        public bool Nfc { get; set; }
    }
}
