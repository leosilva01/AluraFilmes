using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Filme;
using Api.Domain.Dtos.FilmeAtor;
using Api.Domain.Interface.Services.Filme;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private IFilmeService _service;

        public FilmesController(IFilmeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            try{

                return Ok(await _service.GetAll());

            }catch(ArgumentException e){
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetById")]
        public async Task<ActionResult> Get(int id) {

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try {
               
                var result = await _service.Get(id);

                if(result == null){
                    return NotFound();
                }

                return Ok(result);

            } catch(ArgumentException e) {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);

            }
        }

        [HttpGet]
        [Route("Complete/{id}")]
        public async Task<ActionResult> GetCompleteById(int id) {

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try {

                var result = await _service.GetCompleto(id);

                if(result == null){
                    return NotFound();
                }
               
                return Ok(result);

            } catch(ArgumentException e) {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);

            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Post(FilmeDtoCreate filmeCreate){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try{

                var result = await _service.Post(filmeCreate);

                if(result != null){
                    return Created(new Uri( Url.Link("GetById", new {id = result.Id})), result);
                } else {
                    return BadRequest();
                }

            }catch(Exception e){
                return StatusCode((int) HttpStatusCode.InternalServerError, e.InnerException.Message);
            }
        }

        [HttpPut]
        [Route("{FilmeId}")]
        public async Task<ActionResult> Put(int FilmeId, FilmeDtoUpdate filmeUpdate){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try{

                var result = await _service.Put(FilmeId, filmeUpdate);

                if(result != null){
                    return Ok(result);
                } else {
                    return NoContent();
                }

            }catch(Exception e){
                return StatusCode((int) HttpStatusCode.InternalServerError, e.InnerException.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try{

                var result = await _service.Delete(id);

                if(result){
                    return Ok(result);
                } else {
                    return NoContent();
                }

            }catch(Exception e){
                return StatusCode((int) HttpStatusCode.InternalServerError, e.InnerException.Message);
            }
        }

        [HttpPost]
        [Route("FilmeAtor/Add")]
        public async Task<ActionResult> AdicionarFilmeAtor(AddAtorFilmeDto atorFilme){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try{

                var result = await _service.AdicionarAtorFilme(atorFilme);

                if(result != null){
                    return Ok(result);
                } else {
                    return NoContent();
                }

            }catch(Exception e){
                return StatusCode((int) HttpStatusCode.InternalServerError, e.InnerException.Message);
            }
        }

        [HttpPost]
        [Route("FilmeAtor/Remove")]
        public async Task<ActionResult> RemoverFilmeAtor(AddAtorFilmeDto atorFilme){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try{

                var result = await _service.RemoverAtorFilme(atorFilme);

                if(result != null){
                    return Ok(result);
                } else {
                    return NoContent();
                }

            }catch(Exception e){
                return StatusCode((int) HttpStatusCode.InternalServerError, e.InnerException.Message);
            }
        }
    }
}