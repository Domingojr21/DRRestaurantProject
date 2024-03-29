using DRRestaurant.Core.Application.Dtos.Account;
using DRRestaurant.Core.Application.Dtos.User;
using DRRestaurant.Core.Application.ViewModels.User;

namespace DRRestaurant.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<string> ConfirmAccountAsync(string userId, string token);
        Task<UserDTO> GetUserByUserName(string UserName);
        Task<bool> IsaValidUser(string UserName);
        Task<RegisterResponse> RegisterUserAsync(RegisterRequest request, string origin,string role);
        Task SignOutAsync();
        Task UpdateUser(SaveUserViewModel user);
    }
}