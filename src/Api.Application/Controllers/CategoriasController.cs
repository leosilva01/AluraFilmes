using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Categoria;
using Api.Domain.Dtos.FilmeCategoria;
using Api.Domain.Interface.Services.Categoria;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        ICategoriaService _service;
        
        public CategoriasController(ICategoriaService service)
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
        [Route("{id}", Name = "GetCategoriaById")]
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
        public async Task<ActionResult> Post(CategoriaDtoCreate categoria){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try{

                var result = await _service.Post(categoria);

                if(result != null){
                    return Created(new Uri( Url.Link("GetCategoriaById", new {id = result.Id})), result);
                } else {
                    return BadRequest();
                }

            }catch(Exception e){
                return StatusCode((int) HttpStatusCode.InternalServerError, e.InnerException.Message);
            }
        }

        [HttpPut("{categoriaId}")]
        public async Task<ActionResult> Put(int categoriaId, CategoriaDtoUpdate categoria){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try{

                var result = await _service.Put(categoriaId, categoria);

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
        [Route("CategoriaFilme/Add")]
        public async Task<ActionResult> AdicionarFilmeCategoria(FilmeCategoriaDto categoriaFilme){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try{

                var result = await _service.AdicionarFilmeCategoria(categoriaFilme);

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
        [Route("CategoriaFilme/Remove")]
        public async Task<ActionResult> RemoverFilmeCategoria(FilmeCategoriaDto categoriaFilme){
            
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            try{

                var result = await _service.RemoverFilmeCategoria(categoriaFilme);

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