using Core.Security.Authorization;
using Dtos.Auth;
using Entities.Concretes;

namespace Business.Abstracts;

public interface IAuthService
{
    public User Register(RegisterDto registerDto);
    public User Login(LoginDto loginDto);
    public User ForgotPassword(ForgetPasswordDto forgetPasswordDto);
    public AccessToken CreateAccessToken(User user); 
}