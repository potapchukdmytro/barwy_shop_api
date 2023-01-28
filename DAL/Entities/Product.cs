﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Product : BaseEntity<Guid>
    {
        [Required, StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [StringLength(20)]
        public string Article { get; set; }
        public decimal Price { get; set; }
        [StringLength(20)]
        public string Size { get; set; }

        public virtual ICollection<CategoryProduct> CategoryProduct { get; set; }
    }
}
