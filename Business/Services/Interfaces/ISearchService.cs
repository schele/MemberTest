using MembersTestUmbraco16.Models;

namespace MembersTestUmbraco16.Business.Services.Interfaces
{
	public interface ISearchService
	{
		List<Product> Search(string query);
	}
}