using Cars.Api.ViewModels;

namespace Cars.Api.Mappers
{
    public class UserToUserViewModelMapper
    {
        public static UserViewModel UserToUserViewModel(Domain.User.User user)
        {
            var userViewModel = new UserViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                RegistrationDate = user.CreationDate,
                AdsCount = user.AdsCount,
            };
            return userViewModel;
        }
    }
}