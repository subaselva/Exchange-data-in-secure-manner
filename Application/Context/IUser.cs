using Application.DTDs;


namespace Application.Context

{
    public interface IUser
    {
        Task<RegistrationResponse> RegisterUserAsync(RegisterUserDTO registerUserDTO);
        Task<LoginResponce> LoginUserAsync(LoginDTO loginDTO);
        
    }
}
