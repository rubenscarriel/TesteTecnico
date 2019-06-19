using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Model
{
    [Table("TB_USER")]
    public class User
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Column("LOGIN")]
        public string Login { get; set; }
        [Column("PASSWORD")]
        public string Password { get; set; }
        [Column("EMAIL")]
        public string Email { get; set; }
    }
}
