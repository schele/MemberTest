using MembersTestUmbraco16.Business.Services.Interfaces;
using MembersTestUmbraco16.Models;

namespace MembersTestUmbraco16.Business.Services
{	
	public class CartService : ICartService
	{
		private readonly List<Product> _items = new();

		public event Action? OnChange;

		public IReadOnlyList<Product> Items => _items;

		public void AddToCart(Product product)
		{
			_items.Add(product);

			NotifyStateChanged();
		}

		public void RemoveFromCart(Product product)
		{
			_items.Remove(product);

			NotifyStateChanged();
		}

		public int Count => _items.Count;

		private void NotifyStateChanged() => OnChange?.Invoke();

		public void Clear()
		{
		}
	}
}