using Newtonsoft.Json;

namespace CarAssistance.Extensions.StringExtensions
{
    public static class StringExtension
    {
        public static T GetDto<T>(this string jsonDto) 
        {
            return JsonConvert.DeserializeObject<T>(jsonDto);
        }
    }
}
