using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.Ator;
using Api.Domain.Dtos.Filme;
using Api.Domain.Dtos.FilmeAtor;
using Api.Domain.Dtos.Idioma;
using Api.Domain.Enum;
using Bogus;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Filme
{
    public class QuandoRequisitarFilme : BaseIntegration
    {

        [Fact]
        public async Task CRUD_Filme(){

            #region Configurando Faker
            var filmes = new [] {"Pantera Negra", "Vingadores: Ultimato", "Nós", "Toy Story 4", "Lady Bird - A Hora de Voar", "Missão Impossível Efeito Fallout"};

            var fakerIdioma = new Faker<IdiomaDto>()
                .RuleFor(i => i.Id, a => 1);
            
            
            var fakerAtor = new Faker<AtorDto>()
                .RuleFor(a => a.PrimeiroNome, n => n.Name.FirstName())
                .RuleFor(a => a.UltimoNome, n => n.Name.LastName());

            var fakerFilmeCreate = new Faker<FilmeDtoCreate>("pt_BR")
                .RuleFor(f => f.Titulo, a => a.PickRandom(filmes))
                .RuleFor(f => f.Duracao, a => Convert.ToInt16(a.Random.Number(240)))
                .RuleFor(f => f.Descricao, a => a.Lorem.Sentence(250))
                .RuleFor(f => f.AnoLancamento, a => a.Random.Number(2021).ToString());

            // Configurando faker para criar gerar FilmeDtoUpdate
            var fakerFilmeUpdate = new Faker<FilmeDtoUpdate>("pt_BR")
                .RuleFor(f => f.Titulo, a => a.PickRandom(filmes))
                .RuleFor(f => f.Duracao, a => Convert.ToInt16(a.Random.Number(240)))
                .RuleFor(f => f.Descricao, a => a.Lorem.Sentence(250))
                .RuleFor(f => f.AnoLancamento, a => a.Random.Number(2021).ToString())
                .RuleFor(f => f.Classificacao, a => a.PickRandom<ClassificacaoIndicativa>());
        #endregion
            
            #region Post Adicionar Filme
            //Post
            var filmeDtoCreate = fakerFilmeCreate.Generate();

            filmeDtoCreate.Atores = fakerAtor.Generate(2);
            filmeDtoCreate.IdiomaFalado = fakerIdioma.Generate();
            filmeDtoCreate.Classificacao = ClassificacaoIndicativa.G;

            // É preciso colocar o Id 0 pois se não o Id é criado com 1.
            filmeDtoCreate.IdiomaFalado.Id = 0;
            filmeDtoCreate.IdiomaFalado.Nome = "Alemao";

            var response = await PostJsonAsync(filmeDtoCreate, $"{hostApi}/Filmes", client);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<FilmeDto>(postResult);

            Assert.Equal(filmeDtoCreate.Titulo, registroPost.Titulo);
            Assert.Equal(filmeDtoCreate.AnoLancamento, registroPost.AnoLancamento);
            Assert.Equal(filmeDtoCreate.Classificacao, registroPost.Classificacao);
            Assert.Equal(filmeDtoCreate.Descricao, registroPost.Descricao);
            Assert.Equal(filmeDtoCreate.Duracao, registroPost.Duracao);
            Assert.NotNull(registroPost.Id);
        #endregion

            #region Get All
            //Get
            response = await client.GetAsync($"{hostApi}/Filmes");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<FilmeDto>>(jsonResult);
            Assert.True(listaFromJson.Count() > 2);
            Assert.True(listaFromJson.Where(u => u.Id.Equals(registroPost.Id)).Count() == 1);
        #endregion

            #region Put Alterar Filme
            //PUT
            var filmeDtoUpdate = fakerFilmeUpdate.Generate();

            filmeDtoUpdate.Titulo = "Procurando Nemo";

            filmeDtoUpdate.Id = registroPost.Id;

            filmeDtoUpdate.IdiomaFalado = fakerIdioma.Generate();
            filmeDtoUpdate.IdiomaOriginal = fakerIdioma.Generate();

            filmeDtoUpdate.IdiomaFalado.Id = 2;
            filmeDtoUpdate.IdiomaOriginal.Id = 2;
            filmeDtoUpdate.Classificacao = ClassificacaoIndicativa.PG;

            
            var stringContent = new StringContent(JsonConvert.SerializeObject(filmeDtoUpdate), Encoding.UTF8, "application/json");
            
            response = await client.PutAsync($"{hostApi}/Filmes/{filmeDtoUpdate.Id}", stringContent);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            

            var registroAtualizado = JsonConvert.DeserializeObject<FilmeDto>(jsonResult);

            Assert.NotEqual(registroAtualizado.AnoLancamento, registroPost.AnoLancamento);
            Assert.NotEqual(registroAtualizado.Classificacao, registroPost.Classificacao);
            Assert.NotEqual(registroAtualizado.Descricao, registroPost.Descricao);
            Assert.NotEqual(registroAtualizado.Duracao, registroPost.Duracao);
            Assert.NotEqual(registroAtualizado.Titulo, registroPost.Titulo);
        #endregion

            #region Get Complete
            //GET Complete
            response = await client.GetAsync($"{hostApi}/Filmes/Complete/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            var registroCompleto = JsonConvert.DeserializeObject<FilmeDtoCompleto>(jsonResult);

            Assert.Equal(registroCompleto.Id, registroAtualizado.Id);
            Assert.Equal(registroCompleto.AnoLancamento, registroAtualizado.AnoLancamento);
            Assert.Equal(registroCompleto.Classificacao, registroAtualizado.Classificacao);
            Assert.Equal(registroCompleto.Descricao, registroAtualizado.Descricao);
            Assert.Equal(registroCompleto.Duracao, registroAtualizado.Duracao);
            Assert.Equal(registroCompleto.Titulo, registroAtualizado.Titulo);
            Assert.Equal(registroCompleto.IdiomaFalado.Id, 2);
            Assert.Equal(registroCompleto.IdiomaOriginal.Id, 2);
            
            Assert.True(registroCompleto.Atores.Count() == 2);
            foreach(var ator in registroCompleto.Atores){
                Assert.NotNull(filmeDtoCreate.Atores.Select(a => a.PrimeiroNome == ator.PrimeiroNome));
                Assert.NotNull(filmeDtoCreate.Atores.Select(a => a.UltimoNome == ator.UltimoNome));
            }
        #endregion

            #region Get Id
            //GET Id
            response = await client.GetAsync($"{hostApi}/Filmes/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<FilmeDto>(jsonResult);

            Assert.Equal(registroSelecionado.Id, registroAtualizado.Id);
            Assert.Equal(registroSelecionado.AnoLancamento, registroAtualizado.AnoLancamento);
            Assert.Equal(registroSelecionado.Classificacao, registroAtualizado.Classificacao);
            Assert.Equal(registroSelecionado.Descricao, registroAtualizado.Descricao);
            Assert.Equal(registroSelecionado.Duracao, registroAtualizado.Duracao);
            Assert.Equal(registroSelecionado.Titulo, registroAtualizado.Titulo);
        #endregion

            #region Adicionar Ator Filme
            //Post
            var AddAtorFilmeDto = new AddAtorFilmeDto{AtorId = 1, FilmeId = filmeDtoUpdate.Id};

            response = await PostJsonAsync(AddAtorFilmeDto, $"{hostApi}/Filmes/FilmeAtor/Add", client);
            postResult = await response.Content.ReadAsStringAsync();
            registroCompleto = JsonConvert.DeserializeObject<FilmeDtoCompleto>(postResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(registroCompleto.Atores.Select(a => a.Id == 1));
        #endregion

            #region Remover Ator Filme
            //Post
            response = await PostJsonAsync(AddAtorFilmeDto, $"{hostApi}/Filmes/FilmeAtor/Remove", client);
             postResult = await response.Content.ReadAsStringAsync();
            registroCompleto = JsonConvert.DeserializeObject<FilmeDtoCompleto>(postResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Null(registroCompleto.Atores.SingleOrDefault(a => a.Id == 1));
        #endregion

            #region Delete

            //DELETE
            response = await client.DeleteAsync($"{hostApi}/Filmes/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            foreach(var ator in registroCompleto.Atores){
                response = await client.DeleteAsync($"{hostApi}/Atores/{ator.Id}");
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                response = await client.GetAsync($"{hostApi}/Atores/{ator.Id}");
                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }

            response = await client.GetAsync($"{hostApi}/Filmes/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        #endregion
        
            #region Post Erro Create
            //Post Erro Create
            filmeDtoCreate.AnoLancamento = "99999";

            response = await PostJsonAsync(filmeDtoCreate, $"{hostApi}/Filmes", client);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            filmeDtoCreate.AnoLancamento = "2020";
            filmeDtoCreate.Duracao = 501;
            response = await PostJsonAsync(filmeDtoCreate, $"{hostApi}/Filmes", client);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            filmeDtoCreate.Duracao = 120;
            filmeDtoCreate.IdiomaFalado = null;
            response = await PostJsonAsync(filmeDtoCreate, $"{hostApi}/Filmes", client);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            filmeDtoCreate.IdiomaFalado = fakerIdioma.Generate();
            filmeDtoCreate.Descricao = null;
            response = await PostJsonAsync(filmeDtoCreate, $"{hostApi}/Filmes", client);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            filmeDtoCreate.Descricao = "teste";
            filmeDtoCreate.Titulo = new Faker().Lorem.Sentence(256);
            response = await PostJsonAsync(filmeDtoCreate, $"{hostApi}/Filmes", client);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        #endregion

            #region Put Erro Update
            //Post Erro Update
            filmeDtoUpdate.AnoLancamento = "99999";

            stringContent = new StringContent(JsonConvert.SerializeObject(filmeDtoUpdate), Encoding.UTF8, "application/json");

            response = await client.PutAsync($"{hostApi}/Filmes/{filmeDtoUpdate.Id}", stringContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            filmeDtoUpdate.AnoLancamento = "2020";
            filmeDtoUpdate.Duracao = 501;
            
            stringContent = new StringContent(JsonConvert.SerializeObject(filmeDtoUpdate), Encoding.UTF8, "application/json");

            response = await client.PutAsync($"{hostApi}/Filmes/{filmeDtoUpdate.Id}", stringContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            filmeDtoUpdate.IdiomaFalado = null;
            filmeDtoUpdate.Duracao = 120;

            stringContent = new StringContent(JsonConvert.SerializeObject(filmeDtoUpdate), Encoding.UTF8, "application/json");
            
            response = await client.PutAsync($"{hostApi}/Filmes/{filmeDtoUpdate.Id}", stringContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            filmeDtoUpdate.Descricao = null;
            filmeDtoUpdate.IdiomaFalado = fakerIdioma.Generate();

            stringContent = new StringContent(JsonConvert.SerializeObject(filmeDtoUpdate), Encoding.UTF8, "application/json");
            
            response = await client.PutAsync($"{hostApi}/Filmes/{filmeDtoUpdate.Id}", stringContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            filmeDtoUpdate.Descricao = "teste";
            stringContent = new StringContent(JsonConvert.SerializeObject(filmeDtoUpdate), Encoding.UTF8, "application/json");
            
            filmeDtoUpdate.Titulo = new Faker().Lorem.Sentence(256);
            stringContent = new StringContent(JsonConvert.SerializeObject(filmeDtoUpdate), Encoding.UTF8, "application/json");
            
            response = await client.PutAsync($"{hostApi}/Filmes/{filmeDtoUpdate.Id}", stringContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        #endregion
        }
    }
}