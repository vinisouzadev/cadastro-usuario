﻿using Bogus;
using eSistem.Dev.Estagio.Core;
using eSistem.Dev.Estagio.Core.Models.Account;
using eSistem.Dev.Estagio.Core.Responses;
using FluentAssertions;
using Microsoft.AspNetCore.ResponseCompression;
using System.Diagnostics.CodeAnalysis;

namespace eSistem.Dev.Estagio.CoreTestes.Tests.Responses
{
    [Trait("Category", "Response")]
    public class ResponseTestes
    {
        private readonly Faker _faker = new("pt_BR");

        [Fact]
        public void ConstrutorDataCodeMessage_DadoInstanciaComTodosOsValores_EntaoDeveSetarValoresCorretamente()
        {
            Usuario usuario = new();
            string expectedUsername = _faker.Person.FullName;
            string expectedMessage = _faker.Lorem.Paragraph();
            int expectedCode = _faker.Random.Int(100,599);
            
            usuario.UserName = expectedUsername;
            Response<Usuario> response = new(usuario, expectedCode, expectedMessage);

            response.Data.Should().NotBeNull();
            response.Data!.UserName.Should().Be(expectedUsername);
            response.StatusCode.Should().Be(expectedCode);
            response.Message.Should().Be(expectedMessage);
        }

        [Fact]
        public void ConstrutorDataCodeMessage_DadoInstanciaComParametroData_EntaoDeveSetarPropriedadesDefaultEDataCorretamente()
        {
            Usuario usuario = new();
            string expectedUsername = _faker.Person.FirstName;
            usuario.UserName= expectedUsername;
            Response<Usuario> response = new(usuario);

            response.Data.Should().NotBeNull();
            response.Data!.UserName.Should().Be(expectedUsername);
            response.StatusCode.Should().Be(Configuration.DefaultStatusCode);
            response.Message.Should().BeNull();
        }

        [Fact]
        public void Construtor_DadoInstanciaSemValores_EntaoDeveSetarStatusCodeDefault()
        {
            Response<Usuario> response = new();

            response.Data.Should().BeNull();
            response.StatusCode.Should().Be(Configuration.DefaultStatusCode);
            response.Message.Should().BeNull();
        }

        [Fact]
        public void IsSuccess_DadoValorDeSucessoParaStatusCode_EntaoDeveRetornarTrue()
        {

            int successStatusCode = _faker.Random.Int(200, 299); 

            Response<string> response = new("", successStatusCode);

            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void IsSuccess_DadoValorDiferenteDeSucessoParaStatusCode_EntaoDeveRetornarFalse()
        {

            int successStatusCode = _faker.Random.Int(300, 599);

            Response<string> response = new("", successStatusCode);

            response.IsSuccess.Should().BeFalse();
        }
    }
}
