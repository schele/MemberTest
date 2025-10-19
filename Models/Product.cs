namespace MembersTestUmbraco16.Models
{
	public class Product
	{
		public string Name { get; set; } = string.Empty;		

		public string Description { get; set; } = string.Empty;

		public decimal Price { get; set; }
		
		public string Image { get; set; } = string.Empty;

		public Product() { }

		public Product(string name, decimal price, string image, string description)
		{
			Name = name;
			Price = price;
			Image = image;
			Description = description;
		}
	}
}