
namespace CommonServices
{
    public class ConvertLog
    {
        public string ReturnLog(string controller, string exception, string ipAddress)
        {
            var date = DateTime.Now;
            return 
            (
                                $@"*------ StartRequest ------*" + "\r\r" +
                                $@"      Controller : {controller}      " + "\r" +
                                $@"      Thông báo: {exception}      " + "\r" +
                                $@"      Thời gian: {date.ToString("dd-MM-yyyy HH:mm:ss")}" + "\r" +
                                $@"      Địa chỉ IP: {ipAddress}" + "\r\r" +
                                $@"*------ EndRequest ------*" + "\r\r\r\r"
            );
        }
    }
}
