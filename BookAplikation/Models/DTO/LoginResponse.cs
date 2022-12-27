namespace BookAplikation.Models.DTO
{
    public class LoginResponse
    {
        public RegistrationResponse? User { get; set; }

        public string Token { get; set; }
    }
}
