using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Response
{
    public class AppResponseCode
    {
        public const string Success = "00";
        public const string Failed = "01";
        public const string InvalidSignature = "02";
        public const string InternalError = "03";
        public const string UnAuthorized = "04";
        public const string RecordNotFound = "05";
        public const string DuplicateRecord = "06";
        public const string NewDeviceDetected = "07";
        public const string AccessDenied = "08";
    }

    public class HttpResponseCode
    {
        public const int Success = 200;
        public const int BadRequest = 400;
        public const int UnAuthorized = 401;
        public const int RecordNotFound = 404;
        public const int DuplicateRecord = 409;
        public const int InternalError = 500;
    }
}
