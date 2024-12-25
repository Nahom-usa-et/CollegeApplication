using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CollegeApplication.Models;
using CollegeApplication.Data.DTOs;
using CollegeApplication.CustomValidations;
using Microsoft.AspNetCore.JsonPatch;
using System.Numerics;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using CollegeApplication.Interfaces___Implimentaions;
using CollegeApplication.Data.Repositories.onmemoryrepository;


namespace CollegeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {    

        [HttpGet]
        [Route("All", Name = "getallreords")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<StudentDtos>> getallstudents()
        {
            // creating  a lsit is that contains student dto object (1st method)
            //var students = new List<StudentDtos>();
            //foreach (var item in StudentRepository.Students)
            //{
            //    StudentDtos obj = new StudentDtos()
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        Email = item.Email,
            //        phone = item.phone
            //    };
            //    students.Add(obj);
            //}

            //    if (students.Count > 0)
            //    {
            //        return Ok(students);
            //    }

            //    return NotFound();

            var students = StudentRepository.Students.Select(s => new StudentDtos


            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                phone = s.phone
            }
            );
            return Ok(students);

        }

        [HttpGet]
        [Route("{id:int}", Name = "getsudentbyid")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public ActionResult<StudentDtos> getstudentbyid(int id)
        {
            //if(id <=0)
            //{
            //    return BadRequest($"The Id entered has wrong value of {id}");
            //}
            //var result = StudentRepository.Students.Where(n =>n.Id == id).FirstOrDefault();
            //if(result == null)
            //{
            // return NoContent ();
            //}
            //return Ok(result);  
            if (id <= 0)
            {
                return BadRequest();
            }
            if (!StudentRepository.Students.Any(s => s.Id == id))
            {
                return NotFound();
            }

            var student = StudentRepository.Students.Where(s => s.Id == id).FirstOrDefault();

            var studentdto = new StudentDtos()
            {

                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                phone = student.phone

            };



            if (student == null)
            {
                return NotFound();
            }


            return Ok(studentdto);

        }


        [HttpGet]
        [Route("{name:alpha}", Name = "getstudentbyname")]
        public ActionResult<Student?> getallstudentbyname(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Value for name is not entered");
            }
            var result = StudentRepository.Students.Where(s => s.Name == name).FirstOrDefault();
            if (result == null)
            {
                return NotFound($"No record is found for the name entered which is {name}");
            }
            return Ok(result);
        }



        [HttpDelete]
        [Route("{id:int}", Name = "Deletestudentbyid")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public bool Deletestudent(int id)
        {
            var DeleteItem = StudentRepository.Students.Where(s => s.Id == id).FirstOrDefault();
            StudentRepository.Students.Remove(DeleteItem);
            return true;
        }



        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]

        public ActionResult<Student> Createnewstudentobject([FromBody] Student studentmodel)
        {
            int? newid = StudentRepository.Students.LastOrDefault().Id + 1;

            Student student = new Student()
            {
                Id = newid.Value,
                Name = studentmodel.Name,
                Email = studentmodel.Email,
                phone = studentmodel.phone,
                password = studentmodel.password,
                ConfirmPassword = studentmodel.ConfirmPassword,
            };

            StudentRepository.Students.Add(student);
            newid = student.Id;
            return Ok(student);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public ActionResult<Student> updatestudent([FromBody] Student studentmodel)
        {
            if (studentmodel == null || studentmodel.Id <= 0)

            {
                return BadRequest();
            }

            var student = StudentRepository.Students.Where(s => s.Id == studentmodel.Id).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }

            else
            {
                student.Name = studentmodel.Name;
                student.Email = studentmodel.Email;
                student.phone = studentmodel.phone;
                student.password = studentmodel.password;
                student.ConfirmPassword = studentmodel.ConfirmPassword;
                student.addmisiondate = studentmodel.addmisiondate;
            }

            return NoContent();

        }
        //Define Attribute Route 

        [HttpPatch]
        [Route("{id:int}/patch")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult updatepartial(int id, [FromBody] JsonPatchDocument<Student> patchmodel)
        {
            if (patchmodel == null || id <= 0)
            {
                return BadRequest();
            }

            var existedrecord = StudentRepository.Students.Where(s => s.Id == id).FirstOrDefault();

            if (existedrecord == null)
            {
               
                return NotFound();
            }
           



            Student stu = new Student()
            {
                Id = existedrecord.Id,
                Name = existedrecord.Name,
                Email = existedrecord.Email,
                phone = existedrecord.phone,
                password = existedrecord.password,
                ConfirmPassword = existedrecord.ConfirmPassword,
                addmisiondate = existedrecord.addmisiondate,
            };

            patchmodel.ApplyTo(stu, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            existedrecord.Id = stu.Id;
            existedrecord.Name = stu.Name;
            existedrecord.phone = stu.phone;
            existedrecord.password = stu.password;
            existedrecord.ConfirmPassword = stu.ConfirmPassword;
            existedrecord.addmisiondate = stu.addmisiondate;
            return NoContent();
        }


        [HttpDelete]
        [Route ("{id:int}/deleterecord")]
        [ProducesResponseType (StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult deletebyid(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            var existed = StudentRepository.Students.Where(s=>s.Id == id ).FirstOrDefault();

            if(existed == null)
            {
             return NotFound(); 
            }

          
            StudentRepository.Students.Remove(existed);
            
            return NoContent();
        }

    }
}
