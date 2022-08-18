using AutoMapper;
using DatingFoss.Server.DTOs;
using NetTopologySuite.Geometries;

namespace DatingFoss.Server.Mapping;

public class PointMap : Profile
{
    public PointMap()
    {
        CreateMap<Point?, PointDTO?>()
            .ConvertUsing(point => point != null
                        ? new PointDTO { Latitude = point.X, Longitude = point.Y }
                        : null);

        CreateMap<PointDTO?, Point?>()
            .ConvertUsing(pointVm => pointVm != null
                    ? new Point(pointVm.Latitude, pointVm.Longitude)
                    : null);
    }
}
