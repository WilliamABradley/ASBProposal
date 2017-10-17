using System;

namespace ASBDemo.Models
{
    public class AccountHolder
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public DateTimeOffset? LastLogin { get; set; }
        public DateTimeOffset? LastPasswordChange { get; set; }
    }
}