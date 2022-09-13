using IfrsDocs.Domain.Dto;

namespace IfrsDocs.Domain.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(UserDto userUpdateDto);
    }
}
