using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        // private readonly RepositoryContext _context;   //Satışta olmayan ama database üzerinde bulunan verileri de getirir onun için kullanımı çok sağlıklı değil

        private readonly IServiceManager _manager;
        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.ProductService.GetAllProducts(false).Count().ToString();
        }

    }
}