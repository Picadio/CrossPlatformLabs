using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Lab6.Services;

public class GoogleOpenIdService
{
    public static async Task<List<JsonWebKey>> GetPublicKeysFromGoogle(string googlePublicKeysUrl)
    {
        using (var httpClient = new HttpClient())
        {
            // Получаем ключи из Google
            var response = await httpClient.GetStringAsync(googlePublicKeysUrl);
            var jsonResponse = JObject.Parse(response);
            var keys = jsonResponse["keys"].ToObject<List<JsonWebKey>>();
            return keys;
        }
    }
}