using Microsoft.AspNetCore.Mvc;
using MyDiary.Contexts;
using MyDiary.Models.DTOs.RequestDtos;
using MyDiary.Models.DTOs.ResponseDtos;
using MyDiary.Models.ORMs;
using System.Diagnostics.Metrics;

namespace MyDiary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DiaryController : Controller
    {

        myDiaryContext context = new myDiaryContext();

        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllDiariesResponseDto> result = context.diaries.Select(d => new GetAllDiariesResponseDto()
            {
                Id=d.Id,
                Title = d.Title,
                Body = d.Body
            }).ToList();

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No Diary Recorded Yet!");
            }
                
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Diary diary = context.diaries.FirstOrDefault(d => d.Id == id);
            if (diary == null)
            {
                return BadRequest("There is no Diary in database with id: " + id);
            }
            else
            {
                return Ok(new GetDiaryByIdResponseDto()
                {
                    Title = diary.Title,
                    Body = diary.Body
                });
            }
        }

        [HttpPost("create")]
        public IActionResult Create(CreateDiaryRequestDto request)
        {
            Diary diary = new Diary()
            {
                Title = request.Title.Trim(),
                Body = request.Body.Trim(),
                

            };
            context.diaries.Add(diary);
            context.SaveChanges();
            return Ok(request);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            Diary diary = context.diaries.FirstOrDefault(x => x.Id == id);
            if (diary == null)
            {
                return BadRequest("There is no Diary in database with id: " + id);
            }
            else
            {
                context.diaries.Remove(diary);
                context.SaveChanges();
                return Ok("Diary Deleted");
            }
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdateDiaryRequestDto request)
        {
            Diary diary = context.diaries.FirstOrDefault(x => x.Id == id);
            if (diary == null)
            {
                return BadRequest("There is no Diary in database with id: " + id);
            }
            else
            {
                diary.Title = request.Title.Trim();
                diary.Body = request.Body.Trim();
                context.SaveChanges();
                return Ok(new UpdateDiaryResponseDto()
                {
                    Title = request.Title.Trim(),
                    Body = request.Body.Trim()

                
                });
            }
        }

    }
}