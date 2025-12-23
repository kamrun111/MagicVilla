using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MagicVilla_API.Logging;
using Microsoft.EntityFrameworkCore;


namespace MagicVilla_API.Controllers
{
    //[Route("api/[Controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public VillaAPIController(ApplicationDbContext db)
        {
            _db = db; 
        }

        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {

            return Ok(_db.Villas.ToList());
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
             
                return BadRequest();
            }
            var villa = _db.Villas.FirstOrDefault(v => v.VillaId == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);


        }
        [HttpPost]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            if (_db.Villas.FirstOrDefault(v => v.VillaName.ToLower() == villaDTO.VillaName.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa already exists!");
                return BadRequest(ModelState);
            }
            Villa mode = new()
            {
                VillaName = villaDTO.VillaName,
                Details = villaDTO.Details,
                VillaId = villaDTO.VillaId,
                Sqft = villaDTO.Sqft,
                Rate = villaDTO.Rate,
                Occupancy = villaDTO.Occupancy,
                ImageUrl=villaDTO.ImageUrl,
                Amenity = villaDTO.Amenity
            };
            _db.Villas.Add(mode);
            _db.SaveChanges();
            return CreatedAtRoute("GetVilla", new { id = villaDTO.VillaId }, villaDTO);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = _db.Villas.FirstOrDefault(v => v.VillaId == id);
            if (villa == null)
            {
                return NotFound();
            }
            _db.Villas.Remove(villa);
            _db.SaveChanges();
            return NoContent();
        }
        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
        {
            if (villaDTO == null || id != villaDTO.VillaId)
            {
                return BadRequest();
            }
            Villa model = new()
            {
                VillaName = villaDTO.VillaName,
                Details = villaDTO.Details,
                VillaId = villaDTO.VillaId,
                Sqft = villaDTO.Sqft,
                Rate = villaDTO.Rate,
                Occupancy = villaDTO.Occupancy,
                ImageUrl=villaDTO.ImageUrl,
                Amenity= villaDTO.Amenity
            };
            _db.Villas.Update(model);
            _db.SaveChanges();

            return NoContent();
        }
        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        public IActionResult UpdatePartialVilla(int id, [FromBody] JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var villa = _db.Villas.AsNoTracking().FirstOrDefault(v => v.VillaId == id);
            VillaDTO villaDTO = new()
            {
                VillaName = villa.VillaName,
                Details = villa.Details,
                VillaId = villa.VillaId,
                Sqft = villa.Sqft,
                Rate = villa.Rate,
                Occupancy = villa.Occupancy,
                ImageUrl=villa.ImageUrl,
                Amenity=villa.Amenity
            };
            if (villa == null)
            {
                return NotFound();
            }

            patchDTO.ApplyTo(villaDTO, ModelState);
            Villa model = new()
            {
                VillaName = villaDTO.VillaName,
                Details = villaDTO.Details,
                VillaId = villaDTO.VillaId,
                Sqft = villaDTO.Sqft,
                Rate = villaDTO.Rate,
                Occupancy = villaDTO.Occupancy,
                ImageUrl = villaDTO.ImageUrl,
                Amenity = villaDTO.Amenity
            };
            _db.Villas.Update(model);
            _db.SaveChanges();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
