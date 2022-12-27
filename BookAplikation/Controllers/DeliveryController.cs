using BookAplikation.Models.DTO.Delivery;
using BookAplikation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAplikation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryService _deliveryService;
        private readonly ILogger<DeliveryController> _logger;

        public DeliveryController(IDeliveryService deliveryService, ILogger<DeliveryController> logger)
        {
            _deliveryService = deliveryService;
            _logger = logger;
        }

        /// <summary>
        /// Count how much it will cost to deliver to your desired city.
        /// </summary>
        /// <param name="city">City name you want to deliver to</param>
        /// <returns></returns>
        [HttpGet("GetDeliveryPrice")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeliveryDataDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeliveryDataDto>> GetDeliveryPriceToEnteredCity([FromQuery] string city)
        {
            try
            {
                var deliveryCoordinates = await _deliveryService.GetCityLocation(city);
                if (deliveryCoordinates == "")
                {
                    _logger.LogInformation("City ({0}) entered by user not found!", city);
                    return NotFound();
                }

                var distanceInKm = await _deliveryService.GetDistanceForDelivery(deliveryCoordinates);
                if (distanceInKm == null)
                {
                    _logger.LogInformation("Distance calculation is not posible with coordinates - {0}", deliveryCoordinates);
                    return NotFound();
                }

                var deliveryPrice = _deliveryService.CalculateDeliveryPrice(distanceInKm);
                if (deliveryPrice == null)
                {
                    _logger.LogInformation("Del atstumo ({0}km) iki pasirinkto miesto, pristatymas negalimas", distanceInKm);
                    return NotFound();
                }

                DeliveryDataDto deliveryDataDto = _deliveryService.BuildDeliveryInfo(city, deliveryCoordinates, distanceInKm, deliveryPrice);
                if (deliveryDataDto == null)
                {
                    _logger.LogInformation("DeliveryDto sukurti nepavyko");
                    return NotFound();
                }

                return Ok(deliveryDataDto.Price);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ivyko kazkas blogo");
                throw;
            }
        }
    }
}
