
using ViewModels;

namespace Data.General
{
    public interface IYearRepository : IRepositoryBase<Models.Year>
    {
        Task<List<YearSelectViewModel>> GetSelectAsync();
        Task<YearViewModel?> GetYearByYearName(int yearName);
    }
}
