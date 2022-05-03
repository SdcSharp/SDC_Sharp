using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SDC_Sharp.Types.Enums;
using SDC_Sharp.Types.Interfaces;

namespace SDC_Sharp.Types.Monitoring
{
    public class BaseGuild : IGuild
    {
        private string _tagsString = "";
        private GuildTags[] _tags = Array.Empty<GuildTags>();

        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Invite { get; set; }
        [JsonProperty("owner")]
        public string OwnerTag { get; set; }

        [JsonProperty("tags")]
        public string TagsString
        {
            get => _tagsString;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) return;
                
                _tagsString = value;
                
                var tagsArray = JsonConvert.SerializeObject(value.Split(","));
                _tags = JsonConvert.DeserializeObject<GuildTags[]>(tagsArray);
            }
        }

        [JsonIgnore]
        public IEnumerable<GuildTags> Tags => _tags;
        [JsonProperty("des")]
        public string Description { get; set; }
        
        public ulong Online { get; set; }
        public ulong Members { get; set; }
        [JsonProperty("upCount")]
        public ulong UpPoints { get; set; }
        
        [JsonProperty("bot")]
        public bool IsBotOnServer { get; set; }
        
        [JsonProperty("status")]
        public GuildBadges Badges { get; set; }
        public GuildBoostLevel Boost { get; set; }
        [JsonProperty("lang")]
        public GuildLanguages Language { get; set; }
    }
}