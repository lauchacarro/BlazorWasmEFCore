using Aqua.Dynamic;

using BlazorWasmEFCore.Shared;

using Remote.Linq;
using Remote.Linq.Expressions;
using Remote.Linq.Text.Json;

using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorWasmEFCore.Client.Data
{
    public class RemoteLinqContext
    {
        private readonly HttpClient _httpClient;
        private readonly Func<Expression, CancellationToken, ValueTask<DynamicObject>> _asyncDataProvider;

        public RemoteLinqContext(HttpClient httpClient)
        {
            _httpClient = httpClient;

            _asyncDataProvider = DataProvider;
        }


        public IQueryable<WeatherForecast> WeatherForecasts => RemoteQueryable.Factory.CreateAsyncQueryable<WeatherForecast>(_asyncDataProvider);


        private async ValueTask<DynamicObject> DataProvider(Expression expression, CancellationToken cancellationToken = default)
        {
            JsonSerializerOptions options = new JsonSerializerOptions().ConfigureRemoteLinq();


            RemoteQuery query = new RemoteQuery { Expression = expression };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/query", query, options, cancellationToken);

            response.EnsureSuccessStatusCode();

            DynamicObject? result = await response.Content.ReadFromJsonAsync<DynamicObject>(options, cancellationToken);

            return result!;
        }
    }
}
