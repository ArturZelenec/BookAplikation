using BookAplikation.Models.DTO.Delivery;

namespace BookAplikation.Services
{
    public interface IDeliveryService
    {
        DeliveryDataDto BuildDeliveryInfo(string city, string deliveryCoordinates, double? distanceInKm, int? deliveryPrice);
        int? CalculateDeliveryPrice(double? distance);
        Task<string> GetCityLocation(string city);
        Task<double?> GetDistanceForDelivery(string deliveryCoordinates);
    }
}
