using JeBalanceDenonciation.Models;
using JeBalanceDenonciation.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JeBalanceDenonciation.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class DenonciationController : ControllerBase
    {
        private readonly IDenonciationRepository _repository;

        public DenonciationController(IDenonciationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("denonciations")]
        public IActionResult GetDenonciations()
        {
            return Ok(_repository.GetAll().Select(Convertir));
        }

        [HttpGet]
        [Route("denonciations/{id}")]
        public IActionResult GetDenonciation([FromRoute] string id)
        {

            var denonciation = _repository.GetById(id);

            if (denonciation == null)
            {
                return NotFound();
            }

            return Ok(Convertir(denonciation));
        }

        [HttpPost]
        [Route("denonciations")]
        public IActionResult CreateDenonciation([FromBody] DenonciationDtoInput dto)
        {
            Denonciation newDenonciation = new Denonciation(
                dto.Informateur,
                dto.Suspect,
                dto.Delit,
                dto.Pays
                );
            return Ok(_repository.Add(newDenonciation));
        }

        [HttpPut]
        [Route("denonciations/{id}")]
        public IActionResult UpdateDenonciation([FromRoute] string id, [FromBody] ReponseDtoInput dto)
        {
            Reponse reponse = new Reponse(
                retribution: dto.Retribution,
                typeReponse: dto.TypeReponse
                );
            return Ok(_repository.Update(id, reponse));
        }


        [HttpDelete]
        [Route("denonciations/{id}")]
        public IActionResult DeleteDenonciation([FromRoute] string id)
        {
            if (!_repository.DeleteById(id))
            {
                return NotFound();
            }
            return Ok();
        }

        private static DenonciationDto? Convertir(Denonciation? denonciation)
        {
            if (denonciation == null)
            {
                return null;
            }

            return new DenonciationDto
            {
                Id = denonciation.Id,
                Informateur = denonciation.Informateur,
                Suspect = denonciation.Suspect,
                Date = denonciation.Date,
                Delit = denonciation.Delit,
                Pays = denonciation.Pays,
                Reponse = denonciation.Reponse,
            };
        }
    }
}
