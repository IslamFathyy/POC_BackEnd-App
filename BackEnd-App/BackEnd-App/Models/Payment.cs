using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_App.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PaymentMethodId { get; set; }
        public string Address { get; set; }
        public string CreditCardNumber { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public User User { get; set; }

    }
}
