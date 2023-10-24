using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BackEnd.Areas.Identity.Data;

// Add profile data for application users by adding properties to the UGymUser class
public class UGymUser : IdentityUser
{
    public string? Gender { get; set; } = null;
    public string? Cedula { get; set; } = null;
    public string? Name { get; set; } = null;
    public DateTime? Birthday { get; set; } = null;
    public string? Ocupation { get; set; } = null;
    public string? KnowGym { get; set; } = null;
    public string? Motivation { get; set; } = null;
    public string? Address { get; set; } = null;
    public int? EmergencyContactId { get; set; }
    public int? UserFileId { get; set; } = null;
    public int? QrcodeId { get; set; } = null;

    public virtual Qrcode Qrcode { get; set; } = null!;
}