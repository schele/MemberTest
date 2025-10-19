using MembersTestUmbraco16.Models;
using MembersTestUmbraco16.Models.Search;

namespace MembersTestUmbraco16.Business.Services.Interfaces
{
	public interface ICartService
	{
		event Action? OnChange;

		IReadOnlyList<Product> Items { get; }

		void AddToCart(Product product);

		void RemoveFromCart(Product product);
		
		void Clear();
		
		int Count { get; }
	}
}