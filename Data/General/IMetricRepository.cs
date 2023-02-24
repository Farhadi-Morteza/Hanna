
namespace Data.General
{
    public interface IMetricRepository : IRepositoryBase<Models.Metric>
    {
        Task<List<Models.Metric>> GetIndexAsync();
        Task<List<ViewModels.MetricSelectViewModel>> GetSelectAsync();
    }
}
