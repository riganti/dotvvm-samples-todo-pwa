using AutoMapper;
using Newtonsoft.Json;

namespace TodoPwa.BL.Models
{
    public class PushNotificationModel
    {
        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("collapse_key")]
        public string CollapseKey { get; set; }

        [JsonProperty("notification")]
        public PushNotificationContentModel PushNotificationContent { get; set; }
    }

    public class PushNotificationModelMapperProfile : Profile
    {
        public PushNotificationModelMapperProfile()
        {
            CreateMap<TodoItemNotificationModel, PushNotificationModel>()
                .ForMember(dst => dst.PushNotificationContent, option => option.MapFrom(src => src))
                .ForMember(dst => dst.To, option => option.Ignore())
                .ForMember(dst => dst.CollapseKey, option => option.Ignore());
        }
    }
}