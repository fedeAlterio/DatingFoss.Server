using AutoMapper;
using DatingFoss.Domain;
using DatingFoss.Server.DTOs;

namespace DatingFoss.Server.Mapping;

public class ValueRangeMap : Profile
{
    public ValueRangeMap()
    {
        CreateMap<ValueRange<double>, ValueRangeDTO<double>>();
        CreateMap<ValueRangeDTO<double>, ValueRange<double>>();
    }
}
