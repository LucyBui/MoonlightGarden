namespace MoonlightGarden.Framework.Utils
{
    public class ApiResponse
    {
        public bool success { get; set; }
        public object data { get; set; }
        public ApiResponse(object data)
        {
            this.success = data != null;
            this.data = data;
        }
    }
}