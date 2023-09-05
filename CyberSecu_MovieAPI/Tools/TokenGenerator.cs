using Microsoft.IdentityModel.Tokens;
using MovieAPI_DAL.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CyberSecu_MovieAPI.Tools
{
    public class TokenGenerator
    {
        public static string secretKey = "µpiçaezjrkuyjfgk:ghmkjghmiugl:hjfvtFSDMOifnZAE MOVjkµ$)'éàipornjfd ù)'$piç";

        public string GenerateToken(User u) 
        {
            //Générer la clé de signature du token

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //Création du payload (Donnée contenues dans le token)

            Claim[] userInfo = new[] 
            { 
                new Claim(ClaimTypes.Role, 
                        (u.RoleId == 3 ? "Admin" : u.RoleId == 2 ? "Modo" : "User")),
                new Claim(ClaimTypes.Sid, u.Id.ToString()),
                new Claim(ClaimTypes.Email, u.Email)
            };

            JwtSecurityToken jwt = new JwtSecurityToken(
                claims : userInfo,
                signingCredentials: credentials,
                expires : DateTime.Now.AddDays(1)
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(jwt);
        }
    }
}
