using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Beryllium_Back.Models
{
    public class FirstSlider
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
