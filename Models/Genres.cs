using Humanizer.Bytes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netcore5CRUD.Models
{
    public class Genres
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public byte generesId { get; set; }

        [Required, MaxLength(100)]
        public string Name  { get; set; }


    }
}
