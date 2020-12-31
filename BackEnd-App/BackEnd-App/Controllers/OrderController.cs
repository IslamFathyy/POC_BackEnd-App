using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd_App.Data;
using BackEnd_App.Dto;
using BackEnd_App.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd_App.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public OrderController(AppDbContext appDbContext )
        {
            _appDbContext = appDbContext;  
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<ViewModelDTO> Get()
        {
            List<ViewModelDTO> list = new List<ViewModelDTO>();
            var users = _appDbContext.UserInformation.Select(e => e).ToList();
            foreach (var user in users)
            {
                var userFlight = _appDbContext.Flight.FirstOrDefault(e => e.UserId == user.Id);
                var userPayment = _appDbContext.Payments.FirstOrDefault(e => e.UserId == user.Id);

                var userView = new ViewModelDTO { FirstName = user.FirstName, LastName = user.LastName, FlightDate = userFlight.FlightDate, FlightLevel = userFlight.FlightLevel.Name, PaymentMethod = userPayment.PaymentMethod.Name, Mobile = user.Mobile };
                list.Add(userView);
            }

            return list;
        }


        // POST api/<OrderController>
        [HttpPost]
        public bool Post([FromBody] CollectingDataDTO value)
        {
            var userInfo = value.registerationInfo;
            var flightInfo = value.flightInfo;
            var paymentInfo = value.paymentMethodInfo;

            User user = new User { FirstName = userInfo.FirstName, LastName = userInfo.LastName, Email = userInfo.Email, Mobile = userInfo.Mobile, BirthDate = userInfo.BirthDate };
            _appDbContext.UserInformation.Add(user);

            Flight flight = new Flight { FlightDate = flightInfo.FlightDate, FlightLevelId = flightInfo.FlightLevelId, User = user };
            _appDbContext.Flight.Add(flight);

            Payment payment = new Payment { PaymentMethodId = paymentInfo.PaymentMethodId, CreditCardNumber = paymentInfo.CreditCardNumber, Address = paymentInfo.Address ,User = user };
            _appDbContext.Payments.Add(payment);

            int count = _appDbContext.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

    }
}
