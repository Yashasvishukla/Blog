using Microsoft.AspNetCore.Http;

namespace ToDo.API.Helper
{
    public static class Extension
    {
        public static void AddApplicationError(this HttpResponse response,string message){
            response.Headers.Add("Application-Error",message);
            response.Headers.Add("Access-Control-Expose-Headers","Application-Error");
        }
    }
}