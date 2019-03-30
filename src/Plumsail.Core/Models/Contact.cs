using System;

namespace Plumsail.Core.Models
{
    public class Contact
    {
        public int Id { get; internal set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
