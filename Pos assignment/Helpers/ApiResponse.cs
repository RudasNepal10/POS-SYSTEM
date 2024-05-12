using Microsoft.AspNetCore.Mvc;

namespace SAIM_Alumni_APP.Helpers
{
    public  class ApiResponse
    {
        public static BadRequestObjectResult getErrorResponseJson(string message)
        {
            return new BadRequestObjectResult(new { success = false, responseText = message });
        }
    }
}
