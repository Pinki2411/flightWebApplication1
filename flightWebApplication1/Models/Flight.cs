using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace flightWebApplication1.Models
{

    [TableName("Flights")]
    public class Flight
    {
        
        [Key]
        [Column("FlightId")]
        public int Flight_Id { get; set; }

        [Column("Flight")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(30)]
        public string Name { get; set; }
        [Required(ErrorMessage = "To is Required")]
        [StringLength(50)]
        public string To { get; set; }
        [Required(ErrorMessage = "From is Required")]
        [StringLength(50)]
        public string From { get; set; }
        [Required(ErrorMessage = "Required to fill")]
        [Display(Name="Planned on")]
        //[DataType(DataType.Date)]
        //[Validation.GreaterDate(ErrorMessage="Date Must be greater than or equal to Todays Date")]
        public DateTime  DateAndTime { get; set; }
        [Required(ErrorMessage = "Require to Fill")]
        public float Fare { get; set; }
        [Required]
        public int seatAvailable { get; set; }
        //Navigation property
        [ForeignKey("Booking_id")]
        public virtual ICollection<Booking> Booking { get; set; }
       

    }
       public class Registration
        {
            [Required]
            [StringLength(40)]
        public string FullName { get; set; }
           [Key]
            [Display(Name = "Email")]
            [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }
            [Display(Name = "Password")]
            [DataType(DataType.Password)]
            [Required(ErrorMessage = "Password is Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string Password { get; set; }
        [NotMapped]
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        //Navigation property
        public virtual ICollection <Booking>Bookings { get; set; }  
        }
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Booking_id { get; set; }
        [Required]
        [StringLength(30)]
        public string Passenger_Name { get; set; }
        [Required]
        [StringLength(40)]
        public string City { get; set; }
        [Required]
        [StringLength(30)]
        public string Country { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "Passport_No Invalid")]
        public string Passport_No { get; set; }
        public string Gender { get; set; }
        [Required]

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "PhoneNumber Must be 10 Digit Only")]

        public string PhoneNumber { get; set; }
        
        [Required]
        [Range(1,120,ErrorMessage ="Age must be between 1-120 only")]
        public int Age { get; set; }
        [Required]
        public int ReferenceNo { get; set; }

        //Navigation Property
        [Required]
        public int Flight_Id { get; set; }
        [ForeignKey("Flight_Id")]
        public virtual Flight Flight { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [ForeignKey("Email")]
        public virtual Registration Registration { get; set; }
      
        public virtual CheckIn CheckIn { get; set; }
    }

public class CheckIn
    {
        
        [Column("CheckInId")]
        public int Check_Id { get; set; }
        [Required]
        [Display(Name = "Seatno.")]
        public int Seat_Allocation { get; set; }
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Booking_id { get; set; }
        [ForeignKey("Booking_id")]
        public virtual Booking Booking { get; set; }
        
    }

}
