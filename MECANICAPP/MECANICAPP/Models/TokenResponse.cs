using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MECANICAPP.Models
{
    public class TokenResponse
    {

      [JsonProperty(PropertyName = "access_token")]
        public string Access_token { get; set; }


        [JsonProperty(PropertyName = "token_type")]
        public string Token_type { get; set; }


        [JsonProperty(PropertyName = "expires_in")]
        public int Expires_in { get; set; }


        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }


        [JsonProperty(PropertyName = ".issued")]
        public string Issued { get; set; }


        [JsonProperty(PropertyName = ".expires")]
        public string Expires { get; set; }


        [JsonProperty(PropertyName = "error_description")]
        public string ErrorDescription { get; set; }



    }
}
