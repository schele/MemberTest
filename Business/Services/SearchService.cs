using MembersTestUmbraco16.Business.Services.Interfaces;
using MembersTestUmbraco16.Models.Search;

namespace MembersTestUmbraco16.Business.Services
{
	public class SearchService : ISearchService
	{
		public List<SearchHit> Search(string query)
		{
			var hits = new List<SearchHit>();

			var hit1 = new SearchHit
			{
				Title = "Wilson Pro Staff 97 v14",
				Description = "Control & Precision",
				Price = 269.00,
				Image = "/img/03875000_000.webp"
			};

			var hit2 = new SearchHit
			{
				Title = "Wilson Blade 98 16x19 v8",
				Description = "Feel & Stability",
				Price = 259.00,
				Image = "/img/04142000_000.webp"
			};

			var hit3 = new SearchHit
			{
				Title = "Wilson Clash 100 v2",
				Description = "Comfort & Power",
				Price = 249.00,
				Image = "/img/04146000_000.webp"
			};

			hits.AddRange(hit1, hit2, hit3);

			return hits;
		}
	}
}