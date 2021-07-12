using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.Ator;
using Api.Domain.Dtos.FilmeAtor;
using Bogus;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Ator
{
    public class QuandoRequisitarAtor : BaseIntegration
    {

        [Fact]
        public async Task CRUD_Ator(){

            #region Configurando Faker
            var fakerAtorCreate = new Faker<AtorDtoCreate>()
                .RuleFor(a => a.PrimeiroNome, n => n.Name.FirstName())
                .RuleFor(a => a.UltimoNome, n => n.Name.LastName());

                var fakerAtorUpdate = new Faker<AtorDtoUpdate>("pt_BR")
                .RuleFor(a => a.PrimeiroNome, n => n.Name.FirstName())
                .RuleFor(a => a.UltimoNome, n => n.Name.LastName());

        #endregion
            
            #region Post Adicionar Filme
            //Post
            var atorDtoCreate = fakerAtorCreate.Generate();

            var response = await PostJsonAsync(atorDtoCreate, $"{hostApi}/Atores", client);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<AtorDto>(postResult);

            Assert.NotNull(registroPost.Id);
            Assert.Equal(atorDtoCreate.PrimeiroNome, registroPost.PrimeiroNome);
            Assert.Equal(atorDtoCreate.UltimoNome, registroPost.UltimoNome);

            var addAtorFilme = new AddAtorFilmeDto{AtorId = registroPost.Id, FilmeId = 1};

            response = await PostJsonAsync(addAtorFilme, $"{hostApi}/Filmes/FilmeAtor/Add", client);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        #endregion

            #region Get All
            //Get
            response = await client.GetAsync($"{hostApi}/Atores");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<AtorDto>>(jsonResult);
            Assert.True(listaFromJson.Count() == 3);
            Assert.True(listaFromJson.Where(u => u.Id.Equals(registroPost.Id)).Count() == 1);
        #endregion

            #region Put Alterar Ator
            //PUT
            var atorDtoUpdate = fakerAtorUpdate.Generate();

            atorDtoUpdate.Id = registroPost.Id;

            var stringContent = new StringContent(JsonConvert.SerializeObject(atorDtoUpdate), Encoding.UTF8, "application/json");
            
            response = await client.PutAsync($"{hostApi}/Atores/{atorDtoUpdate.Id}", stringContent);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            

            var registroAtualizado = JsonConvert.DeserializeObject<AtorDto>(jsonResult);

            Assert.NotEqual(registroAtualizado.PrimeiroNome, registroPost.PrimeiroNome);
            Assert.NotEqual(registroAtualizado.UltimoNome, registroPost.UltimoNome);
        #endregion

            #region Get Complete
            //GET Complete
            response = await client.GetAsync($"{hostApi}/Atores/Filmografia/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            var registroCompleto = JsonConvert.DeserializeObject<AtorDtoCompleto>(jsonResult);

            Assert.Equal(registroCompleto.Id, registroAtualizado.Id);
            Assert.Equal(registroCompleto.PrimeiroNome, registroAtualizado.PrimeiroNome);
            Assert.Equal(registroCompleto.UltimoNome, registroAtualizado.UltimoNome);
            Assert.True(registroCompleto.Filmes.Count() == 1);
        #endregion

            #region Get Id
            //GET Id
            response = await client.GetAsync($"{hostApi}/Atores/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<AtorDto>(jsonResult);

            Assert.Equal(registroSelecionado.Id, registroAtualizado.Id);
            Assert.Equal(registroSelecionado.PrimeiroNome, registroAtualizado.PrimeiroNome);
            Assert.Equal(registroSelecionado.UltimoNome, registroAtualizado.UltimoNome);
        #endregion

            #region Delete

            //DELETE
            response = await client.DeleteAsync($"{hostApi}/Atores/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            response = await client.GetAsync($"{hostApi}/Atores/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            #endregion
        
            #region Post Erro Create
            //Post Erro Create
            atorDtoCreate.PrimeiroNome = new Faker().Lorem.Sentence(46);
            response = await PostJsonAsync(atorDtoCreate, $"{hostApi}/Atores", client);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);


            atorDtoCreate.UltimoNome = new Faker().Lorem.Sentence(46);
            response = await PostJsonAsync(atorDtoCreate, $"{hostApi}/Atores", client);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        #endregion

            #region Put Erro Update
            atorDtoUpdate.PrimeiroNome = new Faker().Lorem.Sentence(46);
            stringContent = new StringContent(JsonConvert.SerializeObject(atorDtoUpdate), Encoding.UTF8, "application/json");

            response = await client.PutAsync($"{hostApi}/Atores/{atorDtoUpdate.Id}", stringContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            atorDtoUpdate.PrimeiroNome = "teste";
            atorDtoUpdate.UltimoNome = new Faker().Lorem.Sentence(46);
            stringContent = new StringContent(JsonConvert.SerializeObject(atorDtoUpdate), Encoding.UTF8, "application/json");

            response = await client.PutAsync($"{hostApi}/Atores/{atorDtoUpdate.Id}", stringContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        #endregion
        }
    }
}