using Freedom.BusinessLogic.Repositories;
using Freedom.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedom.BusinessLogic.Service
{
    public interface IQuestionService
    {
        Task<List<Questions>> GetQuestions();
        Task<Questions> CreateQuestion(Questions question);
        Task<Questions> GetQuestion(Guid id);
        Task<bool> QuestioModelExists(Guid id);
        Task UpdateQuestion(Questions question);
        Task DeleteQuestion(Guid id);
    }
    public class QuestionService(IQuestionRepository questionRepository) : IQuestionService
    {
        public Task<Questions> CreateQuestion(Questions question)
        {
            return questionRepository.CreateQuestion(question);
        }

        public Task DeleteQuestion(Guid id)
        {
            return questionRepository.DeleteQuestion(id);
        }

        public Task<Questions> GetQuestion(Guid id)
        {
            return questionRepository.GetQuestion(id);
        }

        public Task<List<Questions>> GetQuestions()
        {
            return questionRepository.GetQuestions();
        }

        public Task<bool> QuestioModelExists(Guid id)
        {
            return questionRepository.QuestioModelExists(id);
        }

        public Task UpdateQuestion(Questions question)
        {
            return questionRepository.UpdateQuestion(question);
        }
    }
}
