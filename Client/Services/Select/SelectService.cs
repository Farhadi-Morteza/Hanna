namespace Client.Services
{
    public class SelectService : ServiceBase
    {
        public SelectService(HttpClient http, int type) : base(http)
        {
            Type = type;
        }

        public int Type { get; set; }
        protected override string GetApiUrl()
        {
            switch (Type)
            {
                case 1:
                    {
                        return "Metric";
                        
                    }
                default:
                    return "Metric";
                    
            }

        }

        public async Task<T> GetSelectAsync<T>()
        {
            string query = $"Select";
            T result =
                await ServiceBaseGetAsync<T>(query: query);

            return result;
        }
    }
}
