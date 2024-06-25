using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Application.DTDs;

public class AuthenticationService
{
    private readonly HttpClient _httpClient;

    public AuthenticationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResponce> LoginAsync(LoginDTO loginDTO)
    {
        var response = await _httpClient.PostAsJsonAsync("api/user/login", loginDTO);
        return await response.Content.ReadFromJsonAsync<LoginResponce>();
    }

    public async Task<RegistrationResponse> RegisterAsync(RegisterUserDTO registerUserDTO)
    {
        var response = await _httpClient.PostAsJsonAsync("api/user/register", registerUserDTO);
        return await response.Content.ReadFromJsonAsync<RegistrationResponse>();
    }
}
