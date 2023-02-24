using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Data.Products
{
    public interface IActivityRepository : IRepositoryBase<Models.Activity>
    {
        Task<List<Models.Activity>> GetIndexAsync();
        Task<ViewModels.ActivityViewModel> GetIndexByIdAsync(Guid id);
        Task<Activity> GetMyIndexAsync(Guid id);
        Task<List<ViewModels.ActivitySelectViewModel>> GetSelectAsync();

    }
}
