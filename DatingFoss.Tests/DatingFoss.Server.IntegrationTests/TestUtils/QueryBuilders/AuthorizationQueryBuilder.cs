using DatingFoss.Server.Controllers.Authorization.Queries;
using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.IntegrationTests.TestUtils.QueryBuilders
{
    public static class AuthorizationQueryBuilder
    {
        public static SignUpQuery GetSignUpQuery(string username)
        {
            var (modulus, exponent) = GetRsaKeyData();

            var publicKey = new RSAPublicKeyDTO
            {
                Exponent = exponent,
                Modulus = modulus
            };

            var signUpQuery = new SignUpQuery
            {
                PublicKey = publicKey,
                Username = username
            };

            return signUpQuery;
        }


        public static (string modulus, string exponent) GetRsaKeyData()
        {
            var modulusBase64 = "ltDexlcJC6btMxYeEmarCra1058+puTBILG3s9bVbavvEVEtFo1BPjkM9YRXbHPg36aWh6Y308gPTyE91Z/yvDMrPxIrGdIcDF9kTlPBq206V9Sw6nXuLS9bPvA6zAZbD5HCpHD50nfiWRunycvNcEp64aFCSSvRPT6XqVlW9ivjq6jlrPVA9uj1LwGRFjeZVTF8kypz1TulZb6J0jy3sovYBqHgN+ynVY5gOpIV4NJBnAx+N/y0jm/UMTpQg9uADJKi8diY4N2OrnDC85sSvNwUNvHK/Gv5dxku5SERUhkUro3cxMd+wo/ZlldgTWFYPTQlzY6fnKKx1dA1f7vjJw==";        
            var exponentBase64 = "AQAB";
            return (modulusBase64, exponentBase64);
        }
    }
}
