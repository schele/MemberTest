using MembersTestUmbraco16.Business.Services.Interfaces;
using MembersTestUmbraco16.Models;

namespace MembersTestUmbraco16.Business.Services
{
	public class SearchService : ISearchService
	{
		public List<Product> Search(string query)
		{
			var hits = new List<Product>();

			var hit1 = new Product
			{
				Name = "Wilson Pro Staff 97 v14",
				Description = "Control & Precision",
				Price = 269m,
				Image = "/img/03875000_000.webp"
			};

			var hit2 = new Product
			{
				Name = "Wilson Blade 98 16x19 v8",
				Description = "Feel & Stability",
				Price = 259m,
				Image = "/img/04142000_000.webp"
			};

			var hit3 = new Product
			{
				Name = "Wilson Clash 100 v2",
				Description = "Comfort & Power",
				Price = 249m,
				Image = "/img/04146000_000.webp"
			};

			hits.AddRange(hit1, hit2, hit3);

			return hits;
		}
	}
}