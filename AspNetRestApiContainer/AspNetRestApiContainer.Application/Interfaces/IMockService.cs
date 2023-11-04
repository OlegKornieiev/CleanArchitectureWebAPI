using AspNetRestApiContainer.Domain.Entities;
using System.Collections.Generic;

namespace AspNetRestApiContainer.Application.Interfaces
{
    public interface IMockService
    {
        List<Rectangle> SeedRectangles(int rowCount);
        List<User> SeedUsers(int rowCount);      
    }
}