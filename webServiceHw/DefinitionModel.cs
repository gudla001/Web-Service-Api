
using System;
using System.Collections.Generic;


using Newtonsoft.Json;
using Newtonsoft.Json.Linq;





namespace webServiceHw
{
    public class DefinitionModel
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("definition")]
        public string Definition { get; set; }

        [JsonProperty("example")]
        public string Example { get; set; }

    }

}