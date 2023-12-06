using Microsoft.AspNetCore.Mvc;
using RESTfull.API.DTO;
using RESTfull.Infrastructure;
using RESTfull.Infrastructure.Repository;

namespace RESTfull.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualController : ControllerBase
    {


            private readonly Context _context;
            private readonly IndividualRepository _individualRepository;
            public IndividualController(Context context)
            {
                _context = context;
                _individualRepository = new IndividualRepository(_context);
            }

            // GET: api/Individuals
            [HttpGet]
            public async Task<ActionResult<IEnumerable<IndividualDTO>>> GetPersons()
            {
                var individuals = await _individualRepository.GetAll();
                return IndividualDTOMapper.ToDto(individuals);
            }

            // GET: api/Individuals/5
            [HttpGet("{id}")]
            public async Task<ActionResult<IndividualDTO>> GetPerson(Guid id)
            {
                var individual = await _individualRepository.GetByID(id);
                if (individual == null)
                {
                    return NotFound();
                }
                var individualDTO = IndividualDTOMapper.ToDto(individual);
                return individualDTO;
            }

            // PUT: api/Individuals/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
            public async Task<IActionResult> PutPerson(Guid id, IndividualDTO individualDTO)
            {
                if (id != individualDTO.ID)
                {
                    return BadRequest();
                }

                var individual = IndividualDTOMapper.ToEntity(individualDTO);

                await _individualRepository.Update(individual);

                return NoContent();
            }

            // POST: api/Individuals
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            public async Task<ActionResult<IndividualDTO>> PostPerson(IndividualDTO individualDTO)
            {
                var person = IndividualDTOMapper.ToEntity(individualDTO);
                var person2 = await _individualRepository.Create(person);
                var personDto2 = IndividualDTOMapper.ToDto(person2);
                return CreatedAtAction("GetPerson", new { id = personDto2.ID }, personDto2);
            }

            // DELETE: api/Individuals/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePerson(Guid id)
            {
                var person = await _individualRepository.GetByID(id);
                if (person == null)
                {
                    return NotFound();
                }

                await _individualRepository.Delete(id);

                return NoContent();
            }

            private bool PersonExists(Guid id)
            {
                return _context.Individuals.Any(e => e.ID == id);
            }
        }
    }
