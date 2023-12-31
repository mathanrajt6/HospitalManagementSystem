﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HMSUserAPI.Models
{
    public class Patient : IEntity
    {
        [Key]
        public int PatientID { get; set; }
        [ForeignKey("PatientID")]
        [JsonIgnore]
        public UserDetail? UserDetail { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Emergency COntact name Group should be less than 50 characters")]
        public string? EmergencyContactName { get; set; }
        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Emergency Contact Phone Number should have only 10 digits")]
        public string? EmergencyContactPhone { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Emergency Contact Relation should be less than 50 characters")]
        public string? BloodGroup { get; set; }


    }
}
