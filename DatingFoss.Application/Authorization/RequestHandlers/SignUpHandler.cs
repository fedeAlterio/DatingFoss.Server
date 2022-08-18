using DatingFoss.Application.Authorization.Requests;
using DatingFoss.Application.Authorization.Responses;
using DatingFoss.Application.Encryption.Abstractions;
using DatingFoss.Application.Exceptions;
using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Domain;
using MediatR;

namespace DatingFoss.Application.Authorization.RequestHandlers
{
    public class SignUpHandler : IRequestHandler<SignUpRequest, SignupResponse>
    {
        // Private fields
        private readonly IUsersService _usersService;
        private readonly IEncryptionService _encryptionService;
        private readonly ICrud<User> _usersCrud;



        // Initialization
        public SignUpHandler(IUsersService usersService, IEncryptionService encryptionService, ICrud<User> usersCrud)
        {
            _usersService = usersService;
            _encryptionService = encryptionService;
            _usersCrud = usersCrud;
        }



        // Public
        public async Task<SignupResponse> Handle(SignUpRequest request, CancellationToken cancellationToken)
        {
            if (await _usersService.Exists(request.Username, cancellationToken))
                throw new UserAlreadyRegisteredException(request.Username);

            var user = NewUser(request.Username!, request.PublicKey!);
            _ = _encryptionService.RSAParametersFromExponentAndModulus(user.PublicKey!.Exponent!, user.PublicKey!.Modulus!);
            var respositoryUser = await _usersCrud.Add(user, cancellationToken);
            return new SignupResponse { User = respositoryUser };
        }


        private User NewUser(string username, RSAPublicKey publicKey) => new()
        {
            Username = username,
            PublicKey = publicKey
        };
    }
}
