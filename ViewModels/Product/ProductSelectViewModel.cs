using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ProductSelectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ProductIndicatorSelectViewModel ProductIndicatorSelectViewModel { get; set; } =
            new ProductIndicatorSelectViewModel();

        public MetricSelectViewModel MetricSelectViewModel { get; set; } =
            new MetricSelectViewModel();

        public ProductTypeSelectViewModel ProductTypeSelectViewModel { get; set; } =
            new ProductTypeSelectViewModel();
    }
}
