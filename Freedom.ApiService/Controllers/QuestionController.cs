using Freedom.BusinessLogic.Service;
using Freedom.Model.Entities;
using Freedom.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Freedom.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController(IQuestionService questionService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<BaseResponseModel>> GetQuestions()
        {
            var questions = await questionService.GetQuestions();
            return Ok(new BaseResponseModel { Success = true, Data = questions });
        }

        [HttpPost]
        public async Task<ActionResult<Questions>> CreateQuestion(Questions question)
        {
            await questionService.CreateQuestion(question);
            return Ok(new BaseResponseModel { Success = true });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponseModel>> GetQuestion(Guid id)
        {
            var question = await questionService.GetQuestion(id);
            if (question == null)
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = $"Объект (id:{id}) не найден" });
            }
            return Ok(new BaseResponseModel { Success = true, Data = question });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(Guid id, Questions question)
        {
            if (id != question.id || !await questionService.QuestioModelExists(id))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Bad request" });
            }
            await questionService.UpdateQuestion(question);
            return Ok(new BaseResponseModel {Success = true});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(Guid id)
        {
            if (!await questionService.QuestioModelExists(id))
            {
                return Ok(new BaseResponseModel { Success = false, ErrorMessage = "Not Found" });
            }
            await questionService.DeleteQuestion(id);
            return Ok(new BaseResponseModel { Success = true });
        }
    }
}

