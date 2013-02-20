using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denolk.XchangeWrapper.Model
{
    public class Person
    {
        public Person(Contact c)
        {
            this.Company = c.CompanyName;
            this.Department = c.Department;
            this.DisplayName = c.DisplayName;
            this.Name = c.GivenName;
            this.Surname = c.Surname;
            this.Email = c.EmailAddresses[0].ToString();
            this.Id = c.Id.UniqueId;
            this.MobilePhone = c.PhoneNumbers[PhoneNumberKey.MobilePhone] ?? string.Empty;
            this.DeskPhone= c.PhoneNumbers[PhoneNumberKey.BusinessPhone]??string.Empty;
        }

        public Person(Attendee a)
        {
            this.Email = a.Address;
            this.Name = a.Name;
            this.Id = a.Id != null ? a.Id.UniqueId : a.Address;
        }

        public Person() { }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string MobilePhone { get; set; }
        public string DeskPhone { get; set; }
    }
}
