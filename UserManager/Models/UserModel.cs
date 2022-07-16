using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Newtonsoft.Json;

namespace UserManager.Models
{
    public class UserModel
    {
        // Fields
        private string id;
        private string name;
        private string email;

        // Properties - Validations
        [JsonProperty("id")]
        [DisplayName("User ID")]
        public string Id { get => id; set => id = value; }

        [JsonProperty("name")]
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, ErrorMessage = "Name max length 20 char")]
        public string Name { get => name; set => name = value; }

        [JsonProperty("email")]
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(20, ErrorMessage = "Email max length 20 char")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email invalidate")]
        [EmailAddress]
        public string Email { get => email; set => email = value; }
    }
}
