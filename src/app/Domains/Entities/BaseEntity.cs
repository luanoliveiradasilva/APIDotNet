using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.app.Domains.Entities
{
    public class BaseEntity
    {

        [Key]
        public Guid Id { get; set; }

        private DateTime? createAt;
        public DateTime? CreateAt
        {
            get => createAt;
            set => createAt = value == null ? DateTime.UtcNow : value;
        }

        public DateTime? UpdateAt { get; set; }

    }
}