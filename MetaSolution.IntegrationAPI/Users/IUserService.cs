using MetaSolution.ViewModels.Common;
using MetaSolution.ViewModels.Users;

namespace MetaSolution.IntegrationAPI.Users
{
	public interface IUserService
	{
        Task<ApiResult<string>> Login(LoginRequest request);
    }
}
