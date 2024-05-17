using Newtonsoft.Json;

namespace DotNetTask.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("currentResidence")]
        public string CurrentResidence { get; set; }

        [JsonProperty("idNumber")]
        public string IdNumber { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }


    }
}
