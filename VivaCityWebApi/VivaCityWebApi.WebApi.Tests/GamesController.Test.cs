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

		[Fact]
		public async void ShouldGet200_GET_AllGames() {
			var response = await client.GetAsync("/api/Games/");

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var data = JsonSerializer.Deserialize<IEnumerable<GameDto>>(
				await response.Content.ReadAsStringAsync(),
				jsonOptions
			);

			data.Should().NotBeEmpty();
		}

		[Theory]
		[InlineData("y", 0)]
		[InlineData("Zelda", 1)]
		public async Task ShouldGet200_GET_SearchByName(string name, int length) {
			var response = await client.GetAsync($"/api/Games/searchByName/{name}");

			response.StatusCode.Should().Be(HttpStatusCode.OK);

			var data = JsonSerializer.Deserialize<IEnumerable<GameDto>>(
				await response.Content.ReadAsStringAsync(),
				jsonOptions
			);

			data.Count().Should().Be(length);
		}

		[Fact]
		public async void ShouldGet400_GET_SearchByName() {
			var response = await client.GetAsync($"/api/Games/searchByName/");

			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
		}

		[Theory]
		[InlineData(1, HttpStatusCode.OK)]
		[InlineData(2, HttpStatusCode.NotFound)]
		public async void ShouldGetReleventHttpCode_GET_ById(int id, HttpStatusCode code) {
			var response = await client.GetAsync($"/api/Games/{id}");

			response.StatusCode.Should().Be(code);

			if (code == HttpStatusCode.OK) {
				var data = JsonSerializer.Deserialize<GameDto>(
					await response.Content.ReadAsStringAsync(),
					jsonOptions
				);

				data.Should().NotBeNull();
			}
		}

		private async Task<HttpResponseMessage> CreateGame(GameCreationRequest game) {
			var content = new StringContent(
				JsonSerializer.Serialize(game),
				Encoding.UTF8,
				"application/json"
			);

			return await client.PostAsync("/api/Games/", content);
		}

		[Fact]
		public async void ShouldGet201_POST_Create() {
			var game = new GameCreationRequest {
				Name = "test",
				Description = "test de description plutôt longue",
				Logo = "http://domain.tld/logo.png"
			};

			var response = await CreateGame(game);
			response.StatusCode.Should().Be(HttpStatusCode.Created);
		}

		[Fact]
		public async void Should_GameCreationProcess_Work() {
			await ShouldGet200_GET_SearchByName("test_de_creation", 0);

			var game = new GameCreationRequest {
				Name = "test_de_creation",
				Description = "test de description plutôt longue",
				Logo = "http://domain.tld/logo.png"
			};

			await CreateGame(game);

			await ShouldGet200_GET_SearchByName("test_de_creation", 1);
			await ShouldGet200_GET_SearchByName("a", 2); // Zelda + test_de_creation
		}

		public static IEnumerable<object[]> GetCreateSchemas() {
			var data = new List<object[]>();
			data.Add(new object[] {
				new GameCreationRequest {
						Name = "test",
						Description = "un",
						Logo = "http://domain.tld/logo.png"
				},
				"Erreur: Description doit être >= à 10 caracteres"
			});

			data.Add(new object[] {
				new GameCreationRequest {
						Name = "test",
						Description = " ",
						Logo = "http://domain.tld/logo.png"
				},
				"Erreur: Description vide"
			});

			return data;
		}

		[Theory]
		[MemberData(nameof(GetCreateSchemas))]
		public async void ShouldGet400_POST_Create(GameCreationRequest game, string error) {
			var response = await CreateGame(game);
			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
			(await response.Content.ReadAsStringAsync()).Should().Be(error);
		}

		private async Task<HttpResponseMessage> UpdateGame(GameUpdateRequest game) {
			var content = new StringContent(
				JsonSerializer.Serialize(game),
				Encoding.UTF8,
				"application/json"
			);

			return await client.PostAsync("/api/Games/update", content);
		}

		public static IEnumerable<object[]> GetUpdateSchemas() {
			var data = new List<object[]>();
			data.Add(new object[] {
				new GameUpdateRequest {
						Id = 42,
						Description = "un",
						Logo = "http://domain.tld/logo.png"
				},
				"Erreur: jeu inexistant!"
			});

			data.Add(new object[] {
				new GameUpdateRequest {
						Id = 1,
						Description = " ",
						Logo = "http://domain.tld/logo.png"
				},
				"Erreur: Description vide"
			});

			return data;
		}

		[Theory]
		[MemberData(nameof(GetUpdateSchemas))]
		public async void ShouldGet400_POST_Update(GameUpdateRequest game, string error) {
			var response = await UpdateGame(game);
			response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
			(await response.Content.ReadAsStringAsync()).Should().Be(error);
		}

		[Fact]
		public async void ShouldGet200_POST_Update() {
			var game = new GameUpdateRequest {
				Id = 1,
				Description = "Une description suffisament longue",
				Logo = "http://domain.tld/logo.png"
			};

			var response = await UpdateGame(game);
			response.StatusCode.Should().Be(HttpStatusCode.OK);
		}

		[Fact]
		public async void ShouldGet200_POST_Delete() {
			var game = new GameCreationRequest {
				Name = "test_de_creation_25",
				Description = "test de description plutôt longue",
				Logo = "http://domain.tld/logo.png"
			};

			await CreateGame(game);

			var id = 2;
			var response = await client.PostAsync($"/api/Games/delete/{id}", new StringContent(""));
			response.StatusCode.Should().Be(HttpStatusCode.NoContent);
		}
	}
}
