using BLL.Interfaces;
namespace UI.Controllers
{
    public class PseudoController
    {
        private ICategoryService _categoryService;
        private IProductService _productService;
        private ISupplierService _supplierService;
        public  PseudoController
            (ICategoryService categoryService,
            IProductService productService,
            ISupplierService supplierService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _supplierService = supplierService;
        }
    }
}