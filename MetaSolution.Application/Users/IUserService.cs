using MetaSolution.ViewModels.Common;
using MetaSolution.ViewModels.Users;

namespace MetaSolution.Application.Users
{
    public interface IUserService
    {
        Task<ApiResult<string>> Login(LoginRequest request);
        Task<ApiResult<bool>> Register(RegisterRequest request);
    }
}
