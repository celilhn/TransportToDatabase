using Application.ViewModels;

namespace Application.Interfaces
{
    public interface ICastService
    {
        CastDto SaveCast(CastDto cast);
        CastDto GetCast(int ID);
    }
}
