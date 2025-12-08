using System.Numerics;

namespace AoC.Shared.ValueObjects;

public record Position3D<T>(T X, T Y, T Z) where T : INumber<T>
{

}
