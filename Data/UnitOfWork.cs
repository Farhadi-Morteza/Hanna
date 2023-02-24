

using Data.General;

namespace Data
{
    public class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        public UnitOfWork(Tools.Options options) : base(options)
        {
        }

        private Authentications.IUserRepository _userRepository;
        public Authentications.IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    
                    _userRepository = 
                        new Authentications.UserRepository(DatabaseContext);
                }

                return _userRepository;
            }
        }
        // **************************************************
        private Products.IPrincipalBusinessRepository _principalBusinessRepository;
        public Products.IPrincipalBusinessRepository PrincipalBusinessRepository
        {
            get
            {
                if (_principalBusinessRepository == null)
                {
                    _principalBusinessRepository =
                        new Products.PrincipalBusinessRepository(DatabaseContext);
                }

                return _principalBusinessRepository;
            }
        }
        // **************************************************
        // **************************************************
        private Products.IBusinessRepository _businessRepository;
        public Products.IBusinessRepository BusinessRepository
        {
            get
            {
                if (_businessRepository == null)
                {
                    _businessRepository =
                        new Products.BusinessRepository(DatabaseContext);
                }

                return _businessRepository;
            }
        }
        // **************************************************
        // **************************************************
        private Products.IBusinessTypeRepository _businessTypeRepository;
        public Products.IBusinessTypeRepository BusinessTypeRepository
        {
            get
            {
                if (_businessTypeRepository == null)
                {
                    _businessTypeRepository =
                        new Products.BusinessTypeRepository(DatabaseContext);
                }

                return _businessTypeRepository;
            }
        }
        // **************************************************

        private Products.IActivityRepository _activityRepository;
        public Products.IActivityRepository ActivityRepository
        {
            get
            {
                if (_activityRepository == null)
                {
                    _activityRepository =
                        new Products.AcitvityRepository(DatabaseContext);
                }

                return _activityRepository;
            }
        }
        // **************************************************
        // **************************************************

        private Products.IActivityIndicatorRepository _activityIndicatorRepository;
        public Products.IActivityIndicatorRepository ActivityIndicatorRepository
        {
            get
            {
                if (_activityIndicatorRepository == null)
                {
                    _activityIndicatorRepository =
                        new Products.ActivityIndicatorRepository(DatabaseContext);
                }

                return _activityIndicatorRepository;
            }
        }
        // **************************************************
        // **************************************************

        private Products.IProductRepository _productRepository;
        public Products.IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository =
                        new Products.ProductRepository(DatabaseContext);
                }

                return _productRepository;
            }
        }
        // **************************************************
        // **************************************************

        private Products.IProductIndicatorRepository _productIndicatorRepository;
        public Products.IProductIndicatorRepository ProductIndicatorRepository
        {
            get
            {
                if (_productIndicatorRepository == null)
                {
                    _productIndicatorRepository =
                        new Products.ProductIndicatorRepository(DatabaseContext);
                }

                return _productIndicatorRepository;
            }
        }
        // **************************************************
        // **************************************************

        private Products.IProductTypeRepository _productTypeRepository;
        public Products.IProductTypeRepository ProductTypeRepository
        {
            get
            {
                if (_productTypeRepository == null)
                {
                    _productTypeRepository =
                        new Products.ProductTypeRepository(DatabaseContext);
                }

                return _productTypeRepository;
            }
        }
        // **************************************************
        // **************************************************

        private General.IMetricRepository _metricRepository;
        public General.IMetricRepository MetricRepository
        {
            get
            {
                if (_metricRepository == null)
                {
                    _metricRepository =
                        new General.MetricRepository(DatabaseContext);
                }

                return _metricRepository;
            }
        }
        // **************************************************
        // **************************************************

        private General.IEmployeeRepository _employeeRepository;
        public General.IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository =
                        new General.EmployeeRepository(DatabaseContext);
                }

                return _employeeRepository;
            }
        }
        // **************************************************
        // **************************************************

        private General.IYearRepository _yearRepository;
        public General.IYearRepository YearRepository
        {
            get
            {
                if (_yearRepository == null)
                {
                    _yearRepository =
                        new General.YearRepository(DatabaseContext);
                }

                return _yearRepository;
            }
        }
        // **************************************************
        // **************************************************

        private Companies.ICompanyCategoryRepository _companyCategoryRepository;
        public Companies.ICompanyCategoryRepository CompanyCategoryRepository
        {
            get
            {
                if (_companyCategoryRepository == null)
                {
                    _companyCategoryRepository =
                        new Companies.CompanyCategoryRepository(DatabaseContext);
                }

                return _companyCategoryRepository;
            }
        }
        // **************************************************
        // **************************************************

        private Companies.ICompanyRepository _companyRepository;
        public Companies.ICompanyRepository CompanyRepository
        {
            get
            {
                if (_companyRepository == null)
                {
                    _companyRepository =
                        new Companies.CompanyRepository(DatabaseContext);
                }

                return _companyRepository;
            }
        }
        // **************************************************
        // **************************************************

        private General.IChatMessageRepository _chatMessageRepository;
        public General.IChatMessageRepository ChatMessageRepository
        {
            get
            {
                if (_chatMessageRepository == null)
                {
                    _chatMessageRepository =
                        new General.ChatMessageRepository(DatabaseContext);
                }

                return _chatMessageRepository;
            }
        }
        // **************************************************

        #region Schedules
        // **************************************************

        private Schedules.IPlanRepository _planRepository;
        public Schedules.IPlanRepository PlanRepository
        {
            get
            {
                if (_planRepository == null)
                {
                    _planRepository =
                        new Schedules.PlanRepository(DatabaseContext);
                }

                return _planRepository;
            }
        }
        // **************************************************
        // **************************************************

        private Schedules.IActivityPlanRepository _activityPlanRepository;
        public Schedules.IActivityPlanRepository ActivityPlanRepository
        {
            get
            {
                if (_activityPlanRepository == null)
                {
                    _activityPlanRepository =
                        new Schedules.ActivityPlanRepository(DatabaseContext);
                }

                return _activityPlanRepository;
            }
        }
        // **************************************************
        // **************************************************

        private Schedules.IProductActivityPlanRepository _productActivityPlanRepository;
        public Schedules.IProductActivityPlanRepository ProductActivityPlanRepository
        {
            get
            {
                if (_productActivityPlanRepository == null)
                {
                    _productActivityPlanRepository =
                        new Schedules.ProductActivityPlanRepository(DatabaseContext);
                }

                return _productActivityPlanRepository;
            }
        }
        // **************************************************
        #endregion

    }
}
