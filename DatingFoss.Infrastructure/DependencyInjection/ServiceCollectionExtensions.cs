using DatingFoss.Application.Authorization;
using DatingFoss.Application.Authorization.Abstractions;
using DatingFoss.Application.Discover.Abstractions;
using DatingFoss.Application.Encryption.Abstractions;
using DatingFoss.Application.Messages.Abstractions;
using DatingFoss.Application.Notifications.Abstractions;
using DatingFoss.Application.Repositories.Abstractions;
using DatingFoss.Domain;
using DatingFoss.Infrastructure.Authorization;
using DatingFoss.Infrastructure.Discover;
using DatingFoss.Infrastructure.Encryption;
using DatingFoss.Infrastructure.Notifications;
using DatingFoss.Infrastructure.Repositories;
using DatingFoss.Infrastructure.Repositories.Mocks;
using Microsoft.Extensions.DependencyInjection;

namespace DatingFoss.Infrastructure.DependencyInjection;
public static class ServiceCollectionExtensions
{
    public static void UseDatingFossInfrastructure(this IServiceCollection @this)
    {
        @this.AddUsersServices();
        @this.AddMessagesServices();


        @this.AddSingleton<IServerCredentials, MockServerCredentials>();
        @this.AddSingleton<IEncryptionService, EncryptionService>();
        @this.AddSingleton<IAuthorizationService, AuthorizationService>();
        @this.AddSingleton<IServerCredentials, MockServerCredentials>();
        @this.AddSingleton<IDiscoverService, DiscoverService>();
        @this.AddSingleton<INotificationService, InMemoryNotificationService>();
        @this.AddSingleton(new AuthorizationConfiguration { ShouldVerifyClientSignature = true });
    }

    private static void AddUsersServices(this IServiceCollection @this)
    {
        @this.AddSingleton<IQueryableCrud<User>, MockUserCrud>();
        @this.AddSingleton<ICrud<User>>(provider => provider.GetService<IQueryableCrud<User>>()!);
        @this.AddSingleton<IQueryable<User>>(provider => provider.GetService<IQueryableCrud<User>>()!.Entities);
        @this.AddSingleton<IUsersService, UsersService>();
    }

    private static void AddMessagesServices(this IServiceCollection @this)
    {
        @this.AddSingleton<IQueryableCrud<Message>>(new MockCrud<Message>());
        @this.AddSingleton<ICrud<Message>>(provider => provider.GetService<IQueryableCrud<Message>>()!);
        @this.AddSingleton<IQueryable<Message>>(provider => provider.GetService<IQueryableCrud<Message>>()!.Entities);
        @this.AddSingleton<IMessagesService, MessagesService>();
    }
    
}
