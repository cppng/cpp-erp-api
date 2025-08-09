using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Domain.Entities.User
{
    [Table("tbl_Users")]
    public class UserEntity : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Blocked { get; set; }
        public bool Active { get; set; }
    }
}
