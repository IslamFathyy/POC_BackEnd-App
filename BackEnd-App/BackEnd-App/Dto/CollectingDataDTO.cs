using BackEnd_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_App.Dto
{
    public class CollectingDataDTO
    {
        public User registerationInfo { get; set; }
        public Flight flightInfo { get; set; }
        public Payment paymentMethodInfo { get; set; }
    }
}
