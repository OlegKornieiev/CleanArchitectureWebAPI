using AspNetRestApiContainer.Domain.Common;

namespace AspNetRestApiContainer.Domain.Entities
{
    public class Rectangle : AuditableBaseEntity
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}