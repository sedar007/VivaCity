﻿using FluentAssertions;
using VivaCityWebApi.Common.DTO;
using VivaCityWebApi.Common.Requests;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Text;
using System.Text.Json;

namespace VivaCityWebApi.WebApi.Tests {
	public class GamesControllerTest {
		public HttpClient client { get; }
		public TestServer server { get; }

		private readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions() {
			PropertyNameCaseInsensitive = true,
		};

		public GamesControllerTest() {
			var webApplicationFactory = new WebApplicationFactory<WebAPI.Program>();
			client = webApplicationFactory.CreateClient();
		}

		/*[Fact]
		public async void ShouldGet200_GET_AllGames() {
			var response = await client.GetAsync("/api/Games/");

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var data = JsonSerializer.Deserialize<IEnumerable<GameDto>>(
				await response.Content.ReadAsStringAsync(),
				jsonOptions
			);

			data.Should().NotBeEmpty();
		} */


	}
}
