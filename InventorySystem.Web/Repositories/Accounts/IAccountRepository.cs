using InventorySystem.Web.ViewModels;

namespace InventorySystem.Web.Repositories.Accounts
{
    public interface IAccountRepository
    {
        Task<string> LoginUserAsync(LoginUserViewModel loginUser);
        Task<bool> SignUpUserAsync(RegisterUserViewModel registerUser);
    }
}