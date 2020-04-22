using AutoMapper;
using Newtonsoft.Json;

namespace TodoPwa.BL.Models
{
    public class PushNotificationContentModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("click_action")]
        public string ClickAction { get; set; }
    }

    public class PushNotificationContentModelMapperProfile : Profile
    {
        public PushNotificationContentModelMapperProfile()
        {
            CreateMap<TodoItemNotificationModel, PushNotificationContentModel>()
                .ForMember(dst => dst.Title, option => option.MapFrom(src => src.Title))
                .ForMember(dst => dst.Body, option => option.MapFrom(src => ""))
                .ForMember(dst => dst.ClickAction, option => option.MapFrom(src => ""));
        }
    }
}