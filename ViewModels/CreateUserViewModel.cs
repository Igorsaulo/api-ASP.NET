using Flunt.Notifications;
using Flunt.Validations;
using FirstApp.HashedPassword;

namespace FirstApp.ViewModels
{
    public class CreateUserViewModel : Notifiable<Notification>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }  
        public string Email { get; set; }
        public string Password { get; set; }
        public User UserDTO()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(FirstName, nameof(FirstName), "O nome é obrigatório")
                .IsNotNullOrEmpty(LastName, nameof(LastName), "O sobrenome é obrigatório")
                .IsEmail(Email, nameof(Email), "O e-mail é obrigatório")
                .IsNotNullOrEmpty(Password, nameof(Password), "A senha é obrigatória");

            AddNotifications(contract);

            return new User(FirstName, LastName, Email, new Hashed().HashPassword(Password) );
        }
    }
}