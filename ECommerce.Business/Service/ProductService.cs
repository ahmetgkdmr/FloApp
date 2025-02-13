using ECommerce.Entity.Entities;
using ECommerce.Repository.Repository;

namespace ECommerce.Business.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public List<Product> GetAll() => _repository.GetAll().ToList();

        public Product GetById(int id) => _repository.GetById(id);

        public void Add(Product product) => _repository.Add(product);

        public void Update(Product product) => _repository.Update(product);

        public void Delete(int id)
        {
            var product = _repository.GetById(id);
            if (product != null)
                _repository.Delete(product);
        }
    }
}
