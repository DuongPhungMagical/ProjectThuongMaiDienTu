using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModel
{
    public class BrandModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Không được để trống tên Brand")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Không được để trống tên mô tả")]
        public string Description { get; set; }
        [Required]
        public string Slug { get; set; }
        public int Status { get; set; }
    }
}
