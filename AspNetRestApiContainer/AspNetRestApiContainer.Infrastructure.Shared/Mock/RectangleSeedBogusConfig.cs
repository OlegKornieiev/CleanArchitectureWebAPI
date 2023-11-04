using AspNetRestApiContainer.Domain.Entities;
using AutoBogus;
using Bogus;
using System;

namespace AspNetRestApiContainer.Infrastructure.Shared.Mock
{
    public class RectangleSeedBogusConfig : AutoFaker<Rectangle>
    {
        public RectangleSeedBogusConfig()
        {
            Randomizer.Seed = new Random(8675309);
            RuleFor(m => m.Id, f => Guid.NewGuid());
            RuleFor(o => o.X, f => f.Random.Double(0, 1000));
            RuleFor(o => o.Y, f => f.Random.Double(0, 1000));
            RuleFor(o => o.Width, f => f.Random.Double(1, 100));
            RuleFor(o => o.Height, f => f.Random.Double(1, 100));
        }
    }
}