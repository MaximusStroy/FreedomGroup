using Freedom.Database.Data;
using Freedom.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedom.BusinessLogic.Repositories
{
    public interface IQuestionRepository
    {
        Task<List<Questions>> GetQuestions();
        Task<Questions> CreateQuestion(Questions question);
        Task<Questions> GetQuestion(Guid id);
        Task<bool> QuestioModelExists(Guid id);
        Task UpdateQuestion(Questions question);
        Task DeleteQuestion(Guid id);
    }

    public class QuestionRepository(AppDbContext dbContext) : IQuestionRepository
    {
        public async Task<Questions> CreateQuestion(Questions question)
        {
            dbContext.Questions.Add(question); 
            await dbContext.SaveChangesAsync();
            return question;
        }

        public async Task DeleteQuestion(Guid id)
        {
            var question = dbContext.Questions.FirstOrDefault(q => q.id == id);
            dbContext.Questions.Remove(question);
            await dbContext.SaveChangesAsync();
        }

        public Task<Questions> GetQuestion(Guid id)
        {
            return dbContext.Questions.FirstOrDefaultAsync(q => q.id == id);
        }

        public async Task<List<Questions>> GetQuestions()
        {
            return await dbContext.Questions.OrderByDescending(q => q.created_at).ToListAsync();
        }

        public Task<bool> QuestioModelExists(Guid id)
        {
            return dbContext.Questions.AnyAsync(q => q.id == id);
        }

        public async Task UpdateQuestion(Questions question)
        {
            dbContext.Entry(question).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
