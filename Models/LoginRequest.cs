namespace Fullstack.SwaggerIntergration.Models
{
    public class LoginRequest
    {
        /// <summary>
        /// User login email.
        /// </summary>
        /// <example>admin@devstore.com</example>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// User password.
        /// </summary>
        /// <example>Admin@123</example>
        public string Password { get; set; } = string.Empty;
    }
}
