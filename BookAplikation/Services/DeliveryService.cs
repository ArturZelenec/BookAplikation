using BookAplikation.Models.DTO.Delivery;

namespace BookAplikation.Services
{
    public class DeliveryService : IDeliveryService
    {
        private readonly string _api_key = "5b3ce3597851110001cf62482920470c35d14362a9757510cb6a82e9"; 
        private readonly string _vilnius_warehouse = "25.251531,54.700902";
        private readonly IHttpClientFactory _httpClientFactory;
        public DeliveryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetCityLocation(string city)
        {
            var httpClient = _httpClientFactory.CreateClient("OpenRouteServiceApi");
            var endpoint = "geocode/search";

            var reponse = await httpClient.GetAsync(endpoint + "?api_key=" + _api_key + "&text=" + city);
            if (reponse.IsSuccessStatusCode)
            {
                var content = await reponse.Content.ReadAsStringAsync();
                return GetCoordinatesFromResponseString(content);
            }
            return "";
        }

        private string GetCoordinatesFromResponseString(string content)
        {
            string text = "type\":\"Point\",\"coordinates\":[";
            var start = content.IndexOf(text) + text.Length;
            var end = content.IndexOf("]", start);
            return content.Substring(start, end - start);
        }

        public async Task<double?> GetDistanceForDelivery(string deliveryCoordinates)
        {
            var httpClient = _httpClientFactory.CreateClient("OpenRouteServiceApi");
            var endpoint = "v2/directions/driving-car";

            var reponse = await httpClient.GetAsync(endpoint + "?api_key=" + _api_key + "&start=" + _vilnius_warehouse + "&end=" + deliveryCoordinates);
            if (reponse.IsSuccessStatusCode)
            {
                var content = await reponse.Content.ReadAsStringAsync();
                var distanceInKm = GetDistanceInMetersFromResponseString(content) / 1000;
                return distanceInKm;
            }
            return null;
        }

        private double GetDistanceInMetersFromResponseString(string content)
        {
            string text = "summary\":{\"distance\":";
            var start = content.IndexOf(text) + text.Length;
            var end = content.IndexOf(",\"duration\"", start);
            var distanceInMeters = Convert.ToDouble(content.Substring(start, end - start));
            return distanceInMeters;
        }

        public int? CalculateDeliveryPrice(double? distance)
        {
            var basePrice = 5;
            if (distance == null) return null;
            if (distance <= 50) return basePrice - 2;
            if (distance > 50 && distance <= 150) return basePrice;
            if (distance > 150 && distance <= 300) return basePrice + 2;
            if (distance > 300) return null;
            return null;
        }

        public DeliveryDataDto BuildDeliveryInfo(string city, string deliveryCoordinates, double? distanceInKm, int? deliveryPrice)
        {
            return new DeliveryDataDto()
            {
                ShippingToCity = city,
                ShippingToCoordinates = deliveryCoordinates,
                Distance = distanceInKm.Value,
                Price = deliveryPrice.Value
            };
        }

    }
}
