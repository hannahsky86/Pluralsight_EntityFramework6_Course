using NinjaDomain.Classes;
using System;
using System.ComponentModel.DataAnnotations;

namespace NinjaDomainClasses
{
    public class NinjaEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        [Required]
        public Ninja Ninja { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }
    }
}
