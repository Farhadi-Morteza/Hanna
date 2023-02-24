using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ActivitySelectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ActivityIndicatorSelectViewModel ActivityIndicatorSelectViewModel{ get; set; }
        public MetricSelectViewModel MetricSelectViewModel { get; set; }
    }
}
