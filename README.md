# Srinadimpalli.UltimateAspnetCoreApi




# Purpose
The purpose of this Complete ASP.NET Core Web API solution to use .NET Core and Web API features to develop loosely coupled and maintable and modular API endpoints.
# Usage


This solution covres the following  features:
* Configuration and Logging service
* EF Core Database, migrations, Repository pattern
* Handling and Creating HTTP GET,POST,PUT,DELETE,PATCH
* Content Negotiation, Implementing Custom Formatter (CSV)
#
(under construction)
#
* Validation 
* How to add Async code to Controllers
* Action Filters
* Paging,Sorting, Searching, Data Shaping
* Supporting HATEOAS
* Caching, Vesioning APIs
* Rate Limit and Throttling
* JWT and Identity
* Documenting API with Swagger
* Deployment to IIS, Cloud
* 
Configuration using C# Extension methods (ServiceExtensions.cs)
```cs

public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
```

Configure Logging using NLog:

```cs
public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

public class LoggerManager : ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public LoggerManager() { }
        public void LogDebug(string message) {logger.Debug(message);}
        public void LogError(string message) {logger.Error(message);}
        public void LogInfo(string message)  {logger.Info(message);}
        public void LogWarn(string message)  {logger.Warn(message);}
    }
```
Database and Repository pattern
```cs

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private RepositoryContext RepositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public void Create(T entity) =>
            RepositoryContext.Set<T>().Add(entity);
        
        public void Delete(T entity) =>
            RepositoryContext.Set<T>().Update(entity);
        
        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges? RepositoryContext.Set<T>().AsNoTracking()
                                    :RepositoryContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ? RepositoryContext.Set<T>().Where(expression).AsNoTracking()
                        : RepositoryContext.Set<T>().Where(expression);
        }

        public void Update(T entity) =>
            RepositoryContext.Set<T>().Update(entity);
    }
    It is quite common for the API to return a response that consists of data from multiple resources, with that in mind, used a pattern called Repository Manager,it is a
    wrapper class,which will create instances of repository classes for us and then register it inside teh dependency injection container.
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public ICompanyRepository Company
        {
            get
            {
                if(_companyRepository == null)
                    _companyRepository = new CompanyRepository(_repositoryContext);
                return _companyRepository;
            }
        }
        public IEmployeeRepository Employee
        {
            get
            {
                if(_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_repositoryContext);
                return _employeeRepository;
            }
        }
        public void Save() =>
            _repositoryContext.SaveChanges();
        
    }
```
Global Exception Handling:
```cs

  Extracting all the exception handling logic into a single centralized place, we can make sure or actions cleaner, more readable and the error processing more maintainable.
   app.ConfigureExceptionHandler(logger);
  [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _repository.Company.GetAllCompanies(trackChanges: false);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return Ok(companiesDto);
            
        }
```
