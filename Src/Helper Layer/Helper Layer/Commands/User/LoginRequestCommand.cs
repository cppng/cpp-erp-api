using Erp.Helper.Dto.Response.User;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Commands.User
{
    public class LoginRequestCommand: Command<LoginBaseResponseDto>
    {
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecrete { get; set; } = string.Empty;
        public string DeviceId { get; set; } = string.Empty;
        public string DeviceModel { get; set; } = string.Empty;
        public string DeviceOs { get; set; } = string.Empty;
        public string DeviceName { get; set; } = string.Empty;
        public string DeviceType { get; set; } = string.Empty;
    }
}
