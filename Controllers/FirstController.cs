using ASP.NET_tut.Models;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_tut.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // the [controller]  will be prefix of Controller in FirstController ==> First
    public class StudentController(ILogger<StudentController> Ilogger) : ControllerBase
    {

        private readonly ILogger<StudentController> _Ilogger = Ilogger;

        [HttpGet]
        [Route("All", Name ="GetAllStudents")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<StudentDTO>>GetStudents(){
            var students=CollegeRepository.Students.Select(s=> new StudentDTO()
            {
                Id=s.Id,
                Name =s.Name,
                Email=s.Email,
                Address=s.Address
            });
            _Ilogger.LogInformation("All data fetched");
            return Ok(students);
        }

        [HttpGet]
        [Route("{id:int}",Name ="GetStudentById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO>GetStudentsbyID(int id){
            if(id<=0) return BadRequest($"{id} should be >=1");
            var student= CollegeRepository.Students.Where(x=>x.Id==id).FirstOrDefault();  
            if(student==null){
                _Ilogger.LogError("Student with this Id does not found");
                return NotFound($"student with {id} does not found");
            }
            var studentDTO= new StudentDTO
            {
                Id=student.Id,
                Name=student.Name,
                Email=student.Email,
                Address=student.Email
            };
            return Ok(studentDTO);
        }

        [HttpGet("{name:alpha}",Name ="GetStudentsByName")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> GetStudentsbyName(string name){
            var student= CollegeRepository.Students.Where(x=>x.Name==name).FirstOrDefault();
            if(student==null){
                return NotFound($"student with name {name} does not found");
            }
            var studentDTO= new StudentDTO
            {
                Id=student.Id,
                Name=student.Name,
                Email=student.Email,
                Address=student.Email
            };
            return Ok(studentDTO);
            
        }
        [HttpDelete("{id:int}", Name ="DeleteStudentByid")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteStudentByid(int id){
            if(id<=0){
                return BadRequest($"{id} is negative");
            }
            var student=CollegeRepository.Students.Where(x=>x.Id==id).FirstOrDefault();
            if(student==null)return NotFound($"student with {id} does not found");
            CollegeRepository.Students.Remove(student);
            return Ok(true);
        }


        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<StudentDTO> CreateStudent([FromBody]StudentDTO model)
        {   
            if(model==null){
                return BadRequest();
            }

            // if(model.AdmissionDate < DateTime.Now){
            //     ModelState.AddModelError("Admission Error",  
            //     "Admission date must be greater than or equal to current date");
            //     return BadRequest(ModelState);
            // }

            int newID= CollegeRepository.Students.LastOrDefault().Id+1;
            Student student= new Student{
                Id=newID,
                Name=model.Name,
                Email=model.Email,
                Address=model.Address
            };
            CollegeRepository.Students.Add(student);
            model.Id=newID;
            return CreatedAtRoute("GetStudentById",new {id=model.Id},model);
        }
    }
}