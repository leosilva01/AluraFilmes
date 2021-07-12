using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Ator;
using Api.Domain.Interface.Services.Ator;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtoresController : ControllerBase
    {
        IAtorService _service;
        public AtoresController(IAtorService service)
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
        [Route("{id}", Name = "GetAtorById")]
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
        [Route("Filmografia/{id}")]
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

        [HttpGet]
        [Route("PorCategoria/{categoria}")]

        public async Task<ActionResult> PorCategoria(string categoria)
        {

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try {

                var result = await _service.PorCategoria(categoria);

                if(result == null){
                    return NotFound();
                }
               
                return Ok(result);

            } catch(ArgumentException e) {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);

            }    
        }

        [HttpGet]
        [Route("top5")]
        public async Task<ActionResult> MaisAtuantes()
        {
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try {

                var result = await _service.Top5();

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
        public async Task<ActionResult> Post(AtorDtoCreate atorCreate){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try{

                var result = await _service.Post(atorCreate);

                if(result != null){
                    return Created(new Uri( Url.Link("GetAtorById", new {id = result.Id})), result);
                } else {
                    return BadRequest();
                }

            }catch(Exception e){
                return StatusCode((int) HttpStatusCode.InternalServerError, e.InnerException.Message);
            }
        }

        [HttpPut("{atorId}")]
        public async Task<ActionResult> Put(int atorId, AtorDtoUpdate atorUpdate){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try{

                var result = await _service.Put(atorId, atorUpdate);

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
    }
}
