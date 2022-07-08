using Microsoft.AspNetCore.Mvc;
using Ulbraflix.domain.DTOs_e_VOs;
using Ulbraflix.domain.entities;
using Ulbraflix.services.interfaces;

namespace Ulbraflix.controllers
{


[ApiController]
[Route("[controller]")]
public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        
        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
          Subscription Subscription=_subscriptionService.GetById(id);
          SubscriptionRecord SubscriptionRecord = new SubscriptionRecord(
              Subscription.SubscriptionType, 
              Subscription.IsActive, 
              Subscription.PaymentMethod,
              Subscription.Id,
              Subscription.User,
              Subscription.UsersProfiles
          );
          return Ok(SubscriptionRecord);
        }


        [HttpGet("/async/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Subscription Subscription=await _subscriptionService.GetByIdAsync(id);
            SubscriptionRecord SubscriptionRecordVo = new SubscriptionRecord(
                Subscription.SubscriptionType, 
                Subscription.IsActive, 
                Subscription.PaymentMethod,
                Subscription.Id,
                Subscription.User,
                Subscription.UsersProfiles
            );
            return Ok(SubscriptionRecordVo);
        }
        
        
        [HttpGet("/async/")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Subscription> Subscriptions = new List<Subscription>();
            Subscriptions.AddRange(await _subscriptionService.GetAllAsync());
            List<SubscriptionRecord> SubscriptionRecords = new List<SubscriptionRecord>();
            Subscriptions.ForEach(Subscription =>
            {
                SubscriptionRecord SubscriptionRecordVo = new SubscriptionRecord(
                    Subscription.SubscriptionType, 
                    Subscription.IsActive, 
                    Subscription.PaymentMethod,
                    Subscription.PaymentValue,
                    Subscription.User,
                    Subscription.UsersProfiles
                    );
                SubscriptionRecords.Add(SubscriptionRecordVo);
            });
            return Ok(SubscriptionRecords);
        }
        
        [HttpGet]
        public  IActionResult GetAll()
        {
            List<Subscription> Subscriptions = new List<Subscription>();
            Subscriptions.AddRange(_subscriptionService.GetAll());
            List<SubscriptionRecord> SubscriptionRecords = new List<SubscriptionRecord>();
            Subscriptions.ForEach(Subscription =>
            {
                SubscriptionRecord SubscriptionRecord = new SubscriptionRecord(
                    Subscription.SubscriptionType, 
                    Subscription.IsActive, 
                    Subscription.PaymentMethod,
                    Subscription.PaymentValue,
                    Subscription.User,
                    Subscription.UsersProfiles);
                SubscriptionRecords.Add(SubscriptionRecord);
            });
            return Ok(SubscriptionRecords);
        }

        [HttpPost ("/insert")]
        public IActionResult InsertSubscription([FromBody] SubscriptionRecord SubscriptionRecord)
        {
            if (SubscriptionRecord.Equals(null))
            return new BadRequestResult();
            
            Subscription Subscription = new Subscription();
            Subscription.SubscriptionType = SubscriptionRecord.SubscriptionEnum;
            Subscription.IsActive = SubscriptionRecord.IsActive;
            Subscription.PaymentMethod = SubscriptionRecord.PaymentMethod;
            Subscription.PaymentValue = SubscriptionRecord.PaymentValue;
            Subscription.User = SubscriptionRecord.User;
            Subscription.UsersProfiles = SubscriptionRecord.UserProfiles;
            try
            {
                if (_subscriptionService.Insert(Subscription))
                {
                    return Ok("Successfully deleted");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            return BadRequest();
        }
        
        [HttpPut("/update")]
        public IActionResult UpdateSubscription([FromBody] SubscriptionRecord SubscriptionRecord)
        {
            if (SubscriptionRecord.Equals(null))
                return new BadRequestResult();
            
            Subscription Subscription = new Subscription();
            Subscription.SubscriptionType = SubscriptionRecord.SubscriptionEnum;
            Subscription.IsActive = SubscriptionRecord.IsActive;
            Subscription.PaymentMethod = SubscriptionRecord.PaymentMethod;
            Subscription.PaymentValue = SubscriptionRecord.PaymentValue;
            Subscription.User = SubscriptionRecord.User;
            Subscription.UsersProfiles = SubscriptionRecord.UserProfiles;
            try
            {
                if (_subscriptionService.Update(Subscription))
                {
                    return Ok("Successfully deleted");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            return BadRequest();
        }
        
        [HttpDelete("/delete/{id}")]
        public IActionResult DeleteSubscription(int id)
        {
            try
            {
                if (_subscriptionService.Delete(id))
                {
                    return Ok("Successfully deleted");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            return BadRequest();
        }
    }
}