using Microsoft.AspNetCore.Mvc;
using RESTfull.API.DTO;
using RESTfull.Infrastructure;
using RESTfull.Infrastructure.Repository;

namespace RESTfull.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly Context _context;
        private readonly InfoRepository _informationRepository;
        public InfoController(Context context)
        {
            _context = context;
            _informationRepository = new InfoRepository(_context);
        }

        // GET: api/Infos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfoDTO>>> GetInfos()
        {
            var info = await _informationRepository.GetAll();
            return InformationDTOMapper.ToDto(info);
        }

        // GET: api/Infos/id
        [HttpGet("{id}")]
        public async Task<ActionResult<InfoDTO>> GetInfo(Guid id)
        {
            var info = await _informationRepository.GetByID(id);
            if (info == null)
            {
                return NotFound();
            }
            var individualDTO = InformationDTOMapper.ToDto(info);
            return individualDTO;
        }

        // GET: /name/name
        [HttpGet("name/{name}")]
        public async Task<ActionResult<InfoDTO>> GetInfoByName(string name)
        {
            var info = await _informationRepository.GetByName(name);
            if (info == null)
            {
                return NotFound();
            }
            var individualDTO = InformationDTOMapper.ToDto(info);
            return individualDTO;
        }

        // PUT: api/Infos/id
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInfo(Guid id, InfoDTO individualDTO)
        {
            if (id != individualDTO.ID)
            {
                return BadRequest();
            }

            var info = InformationDTOMapper.ToEntity(individualDTO);

            await _informationRepository.Update(info);

            return NoContent();
        }

        // POST: api/Infos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InfoDTO>> PostInfo(InfoDTO infoDto)
        {
            var info = InformationDTOMapper.ToEntity(infoDto);
            var info2 = await _informationRepository.Create(info);
            var infoDto2 = InformationDTOMapper.ToDto(info2);
            return CreatedAtAction("GetPerson", new { id = infoDto2.ID }, infoDto2);
        }

        // DELETE: api/Infos/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInfo(Guid id)
        {
            var person = await _informationRepository.GetByID(id);
            if (person == null)
            {
                return NotFound();
            }

            await _informationRepository.Delete(id);

            return NoContent();
        }

        private bool InfoExists(Guid id)
        {
            return _context.Infos.Any(e => e.ID == id);
        }
    }
}
