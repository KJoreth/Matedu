namespace Matedu.Data.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        IMaterialRepository MaterialRepository { get; }
        IReviewRepository ReviewRepository { get; }
        ITypeRepository TypeRepository { get; }

        Task<int> CompleteUnitAsync();
    }
}