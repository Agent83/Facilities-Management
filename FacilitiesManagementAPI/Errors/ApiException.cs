namespace FacilitiesManagementAPI.Errors
{
    public class ApiException
    {
        public ApiException(int statuCode, string message = null, string detail = null)
        {
            StatuCode = statuCode;
            Message = message;
            Detail = detail;
        }

        public int StatuCode { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
    }
}