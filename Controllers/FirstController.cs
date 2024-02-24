using ASP.NET_tut.Data;
using ASP.NET_tut.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_tut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // the [controller]  will be prefix of Controller in FirstController ==> First
    public class StudentController(ILogger<StudentController> Ilogger, CollegeDbContext dbContext, IMapper mapper) : ControllerBase
    {

        private readonly ILogger<StudentController> _Ilogger = Ilogger;
        private readonly CollegeDbContext _dbContext=dbContext;
        private readonly IMapper _mapper=mapper;

        [HttpGet]
        [Route("All", Name ="GetAllStudents")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<StudentDTO>>>GetStudentsAsync(){

            // for customization of records

            // var students=_dbContext.Students.Select(s=> new StudentDTO()
            // {
            //     Id=s.Id,
            //     Name =s.Name,
            //     Email=s.Email,
            //     Address=s.Address,
            //     DOB=s.DOB
            // }).ToList();
            
            // to fetch all
            var students= await _dbContext.Students.ToListAsync();
            var studentDTOdata= _mapper.Map<List<StudentDTO>>(students);

            _Ilogger.LogInformation("All data fetched");
            return Ok(studentDTOdata);
        }

        [HttpGet]
        [Route("{id:int}",Name ="GetStudentById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<StudentDTO>>GetStudentsbyIDAsync(int id){
            if(id<=0) return BadRequest($"{id} should be >=1");
            var student=await _dbContext.Students.Where(x=>x.Id==id).FirstOrDefaultAsync();  
            if(student==null){
                _Ilogger.LogError("Student with this Id does not found");
                return NotFound($"student with {id} does not found");
            }
            var studentDTO= _mapper.Map<StudentDTO>(student);
            // var studentDTO= new StudentDTO
            // {
            //     Id=student.Id,
            //     Name=student.Name,
            //     Email=student.Email,
            //     Address=student.Address,
            //     DOB=student.DOB
            // };
            return Ok(studentDTO);
        }

        [HttpGet("{name:alpha}",Name ="GetStudentsByName")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<StudentDTO>> GetStudentsbyNameAsync(string name){
            var student=await _dbContext.Students.Where(x=>x.Name==name).FirstOrDefaultAsync();
            if(student==null){
                return NotFound($"student with name {name} does not found");
            }
            // var studentDTO= new StudentDTO
            // {
            //     Id=student.Id,
            //     Name=student.Name,
            //     Email=student.Email,
            //     Address=student.Email,
            //     DOB=student.DOB
            // };
            var studentDTO= _mapper.Map<StudentDTO>(student);
            return Ok(studentDTO);
            
        }
        [HttpDelete("{id:int}", Name ="DeleteStudentByid")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteStudentByidAsync(int id){
            if(id<=0){
                return BadRequest($"{id} is negative");
            }
            var student= await _dbContext.Students.Where(x=>x.Id==id).FirstOrDefaultAsync();
            if(student==null)return NotFound($"student with {id} does not found");
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
            return Ok(true);
        }


        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<StudentDTO>> CreateStudentAsync([FromBody]StudentDTO dto)
        {   
            if(dto==null){
                return BadRequest();
            }
            // Students student= new()
            // {
            //     Name=model.Name,
            //     Email=model.Email,
            //     Address=model.Address,
            //     DOB=model.DOB
            // };
            var student= _mapper.Map<Students>(dto);
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            dto.Id=student.Id;
            return CreatedAtRoute("GetStudentById",new {id=dto.Id},dto);
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> UpdateStudentAsync([FromBody] StudentDTO dto)
        {
            if(dto==null || dto.Id<=0) {
                return BadRequest("cannot update student: try valid ID");
            }
            var existingStudent=await _dbContext.Students.AsNoTracking().Where(x=>x.Id==dto.Id).FirstOrDefaultAsync();
            if(existingStudent==null){
                return BadRequest();
            }

            // one way of updation

            // existingStudent.Id=model.Id;
            // existingStudent.Name=model.Name;
            // existingStudent.Address=model.Address;
            // existingStudent.Email=model.Email;
            // existingStudent.DOB=model.DOB;

            // using AsNOtracking

            // var newStudent= new Students {
            //     Id=existingStudent.Id,
            //     Name=model.Name,
            //     Address=model.Address,
            //     Email=model.Email,
            //     DOB=model.DOB
            // };
            var newStudent= _mapper.Map<Students>(dto);
            _dbContext.Update(newStudent);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}