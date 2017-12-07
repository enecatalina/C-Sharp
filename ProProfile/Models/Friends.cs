using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProProfile.Models;

namespace ProProfile.Models
{
    public class Friends : BaseEntity
    {
        [Key]
        public int idFriends { get; set; }
        public int idUser { get; set; }
        public Users Friend { get; set; }
    }
}