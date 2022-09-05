using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace IfrsDocs.API.Extensions
{
    public static class PaginationExtension
    {
        public static void AddPagination(this HttpResponse response,
            int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            response.Headers.Add("Pagination", JsonSerializer.Serialize(
                new { currentPage = currentPage, itemsPerPage = itemsPerPage}, options));

            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
