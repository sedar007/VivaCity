using FluentAssertions;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Text;
using System.Text.Json;

namespace VivaCityWebApi.WebApi.Tests {
	public class RessourceItemsControllerTest {
		public HttpClient client { get; }
		public TestServer server { get; }

		private readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions() {
			PropertyNameCaseInsensitive = true,
		};

		public RessourceItemsControllerTest() {
			var webApplicationFactory = new WebApplicationFactory<WebAPI.Program>();
			client = webApplicationFactory.CreateClient();
		}

		[Fact]
		public async void ShouldGet200_GET_AllRessourceItems() {
			var response = await client.GetAsync("/api/RessourceItems/");

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var data = JsonSerializer.Deserialize<IEnumerable<RessourceItemDto>>(
				await response.Content.ReadAsStringAsync(),
				jsonOptions
			);

			data.Should().NotBeEmpty();
		}

		[Theory]
		[InlineData("y", 0)]
		[InlineData("coin", 1)]
		public async Task ShouldGet200_GET_SearchByName(string name, int length) {
			var response = await client.GetAsync($"/api/RessourceItems/searchByName/{name}");

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var data = JsonSerializer.Deserialize<IEnumerable<RessourceItemDto>>(
				await response.Content.ReadAsStringAsync(),
				jsonOptions
			);

			data.Count().Should().Be(length);
		}

		[Fact]
		public async void ShouldGet400_GET_SearchByName() {
			var response = await client.GetAsync($"/api/RessourceItems/searchByName/");

			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
		}

		[Theory]
		[InlineData(1, HttpStatusCode.OK)]
		[InlineData(200, HttpStatusCode.NotFound)]
		public async void ShouldGetReleventHttpCode_GET_ById(int id, HttpStatusCode code) {
			var response = await client.GetAsync($"/api/RessourceItems/{id}");

			response.StatusCode.Should().Be(code);

			if (code == HttpStatusCode.OK) {
				var data = JsonSerializer.Deserialize<RessourceItemDto>(
					await response.Content.ReadAsStringAsync(),
					jsonOptions
				);

				data.Should().NotBeNull();
			}
		}
	}
}