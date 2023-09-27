using mvc_in_memory_data_store.Models;

namespace mvc_in_memory_data_store.Data
{
    public interface IProductRepository
    {
       
        List<Product> findAll();     
        Product find(int id);
        bool Add(Product product);
        bool Update(int id, Product product);

        bool Delete(int id);
    }
}
