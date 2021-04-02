using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Touriss.Models;
using Type = Touriss.Models.Type;

namespace Touriss.Dtos
{
    public class CityToReturnDto
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        public virtual string Photos { get; set; }

    }
}
