using System;
using System.Collections.Generic;

namespace Tendo.Models
{
    public abstract class NamedEntity
    {
        public Guid Id { get; set; }
        public string Family { get; set; }
        public string Name { get; set; }
        public List<string> Given { get; set; }
        public string FirstName() => Given?[0];
    }
}
