using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Idioma;
using Api.Domain.Interface.Services.Idioma;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdiomasController : ControllerBase
    {

        private IIdiomaService _service;

        public IdiomasController(IIdiomaService service)
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
        [Route("{id}", Name = "GetIdiomaById")]
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
        public async Task<ActionResult> Post(IdiomaDtoCreate idiomaCreate){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try{

                var result = await _service.Post(idiomaCreate);

                if(result != null){
                    return Created(new Uri( Url.Link("GetIdiomaById", new {id = result.Id})), result);
                } else {
                    return BadRequest();
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

        [HttpPut]
        [Route("{IdiomaId}")]
        public async Task<ActionResult> Put(int IdiomaId, IdiomaDtoUpdate idiomaUpdate){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try{

                var result = await _service.Put(IdiomaId, idiomaUpdate);

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
