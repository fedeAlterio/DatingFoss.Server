using AutoMapper;
using AutoMapper.Internal;
using Castle.Core.Internal;
using DatingFoss.Application.Notifications.Abstractions;
using DatingFoss.Domain;
using DatingFoss.Server.Controllers.Notifications.Attributes;
using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Controllers.Notifications.Mapping.ValueResolvers;

public class NotificationContentResolver : IValueResolver<INotification, NotificationDTO, object?>
{
    private readonly IMapper _mapper;
    private readonly Dictionary<Type, Type> _contentDTODictionary = new();

    public NotificationContentResolver(IMapper mapper)
    {
        _mapper = mapper;
        _contentDTODictionary = _mapper.ConfigurationProvider
            .Internal()
            .GetAllTypeMaps()
            .Where(typeMap => typeMap.DestinationType.CustomAttributes.Any(x => x.AttributeType == typeof(NotificationContentDTOAttribute)))
            .ToDictionary(typeMap => typeMap.SourceType, typeMap => typeMap.DestinationType);
    }

    public object? Resolve(INotification source, NotificationDTO destination, object? destMember, ResolutionContext context)
    {
        if (source.Content is null)
            return null;

        var sourceContentType = source.Content.GetType();
        if (!_contentDTODictionary.TryGetValue(sourceContentType, out var destinationType))
        {
            destinationType = _mapper.ConfigurationProvider
                    .Internal()
                    .GetAllTypeMaps()
                    .FirstOrDefault(typeMap => typeMap.SourceType == sourceContentType)
                    ?.DestinationType
                    ?? throw new InvalidOperationException($"Type {sourceContentType} not mapped to any type (Automapper)");
            _contentDTODictionary[sourceContentType] = destinationType;
        }


        return _mapper.Map(source.Content, sourceContentType, destinationType);
    }
}
