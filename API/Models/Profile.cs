using System;
using System.Globalization;

namespace API.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string Nickname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Town { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public string Self
        {
            get
            {
                return string.Format(CultureInfo.CurrentCulture,
               "api/profiles/{0}", this.ProfileId);
            }
            set { }
        }
    }
}