using mvc_in_memory_data_store.Data;
using System;

namespace mvc_in_memory_data_store.Models
{
    public class ProductRepository : IProductRepository
    {
        //private static int IdCounter = 1;
        private static List<Product> _products = new List<Product>();

        

        public List<Product> findAll()
        {
            return ProductRepository._products;
            
        }

        public Product find(int id)
        {
            return ProductRepository._products.First(product => product.Id == id);
        }

        public bool Add(Product product)
        {
            if (product != null)
            {
                product.Id = _products.Count == 0 ? 1 : _products.Max(p => p.Id) + 1; //ProductRepository.IdCounter++;
                //ProductRepository._products.Add(product);
                //product.Id = productRepository.idcounter++;
                _products.Add(product);
                return true;
            }
            return false;
        }

        public bool Update(int id, Product newProduct)
        {
            var updatedProduct = _products.Where(p => p.Id == id).FirstOrDefault();
            if (updatedProduct == null)
            {
                return false;
            }


            updatedProduct.Name = !string.IsNullOrEmpty(newProduct.Name) ? newProduct.Name : updatedProduct.Name;
            updatedProduct.Category = !string.IsNullOrEmpty(newProduct.Category) ? newProduct.Category : updatedProduct.Category;
            updatedProduct.Price = (newProduct.Price != 0) ? newProduct.Price : updatedProduct.Price;

            return true;


            //if (updatedProduct == null) 
            //{
            //    return false;
            //  }
            //    updatedProduct.Name = string.IsNullOrEmpty(newProduct.Name) ? updatedProduct.Name : newProduct.Name;
            //    updatedProduct.Price = string.IsNullOrEmpty(newProduct.Price) ? updatedProduct.Price : newProduct.Price;
            //    updatedProduct.Category = string.IsNullOrEmpty(newProduct.Category) ? updatedProduct.Category : newProduct.Category;
            //if (updatedProduct == null)
            //{
            //    return false; 
            //}


            //if (!string.IsNullOrEmpty(newProduct.Name))
            //{
            //    updatedProduct.Name = newProduct.Name;
            //}
            //if (!string.IsNullOrEmpty(newProduct.Category))
            //{
            //    updatedProduct.Category = newProduct.Category;
            //}
            //if (newProduct.Price != 0) 
            //{
            //    updatedProduct.Price = newProduct.Price;
            //}

            //return true;






        }

        public bool Delete(int id)
        {
            var product = _products.Where(p =>p.Id == id).FirstOrDefault();
            if (product!= null)
            {
                _products.Remove(product);
                return true;
            }
            return false;
            
        }
    }
}
