using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AppManager.Application.DTO;
using Xunit;

namespace AppManager.IntegrationTests.ApiTests
{
    [Collection(nameof(FixtureCollection))]
    public class SpecieTests
    {
        private readonly Fixture<StartupApiTests> _fixture;
        public SpecieTests(Fixture<StartupApiTests> fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "Get All species")]
        public async Task GetAllSpecies()
        {
            var req = await _fixture.client.GetAsync($"/api/specie");
            var resp =  await req.Content.ReadAsStringAsync();

            Assert.True(req.IsSuccessStatusCode);
            Assert.IsType<List<SpecieDTO>>( JsonSerializer.Deserialize<SpecieDTO>(resp));
        }
    }
}
