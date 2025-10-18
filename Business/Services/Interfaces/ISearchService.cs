using MembersTestUmbraco16.Models.Search;

namespace MembersTestUmbraco16.Business.Services.Interfaces
{
	public interface ISearchService
	{

		List<SearchHit> Search(string query);
	}
}
