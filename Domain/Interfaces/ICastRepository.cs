using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICastRepository
    {
        Cast AddCast(Cast cast);
        Cast GetCast(int ID);
        Cast UpdateCast(Cast cast);
    }
}
