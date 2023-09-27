namespace mvc_in_memory_data_store.Models
{
    public class Product
    {
        //private int id;
        //private string type;
        //private int price;

        //public Product(int id, string type, int price)
        //{
        //    this.id = id;
        //    this.type = type;
        //    this.price = price;
        //}

        //public int getId()
        //{
        //    return this.id;
        //}

        //public string getType()
        //{
        //    return this.type;
        //}

        //public int getPrice()
        //{
        //    return this.price;
        //}

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

    }
}
