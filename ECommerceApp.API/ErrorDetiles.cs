using Newtonsoft.Json;

namespace ECommerceApp.API
{
    public class ErrorDetiles
    {
        public int StutsCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
