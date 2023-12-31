using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTO;
using Entities.DTO.Post.Otp;

namespace Business.Abstract
{
    public interface IOtpService
    {
        IDataResult<User> CheckOtp(CheckOtpDto checkOtpDto);
        IResult SendOtp(SendOtpDto sendOtpDto);
        IDataResult<string> GenerateOtp();
    }
}