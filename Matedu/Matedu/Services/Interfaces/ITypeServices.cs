namespace Matedu.Services.Interfaces
{
    public interface ITypeServices
    {
        Task<List<TypeSimpleDTO>> GetAllAsync();
    }
}