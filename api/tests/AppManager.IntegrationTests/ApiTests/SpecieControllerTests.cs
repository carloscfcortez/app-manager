using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AppManager.Application.DTO;
using AppManager.Application.Interfaces;
using AppManager.Domain.Entities;
using AppManager.Services.Api;
using AppManager.Services.Api.Controllers;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Xunit;

namespace AppManager.IntegrationTests.ApiTests
{
    public class SpecieControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAll_WithoutParams_ReturnAll()
        {
            // Act
            var response = await Client.GetAsync("api/specie");

            var result = response.Content.ReadAsStringAsync();
            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.ReadAsAsync<List<TreeDTO>>().Should().NotBeNull();

        }
    }
}
