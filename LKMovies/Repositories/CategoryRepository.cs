using LKMovies.Data;
using LKMovies.Models;
using LKMovies.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LKMovies.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LKMoviesContext _db;
        public CategoryRepository(LKMoviesContext db)
        {
            _db = db;
        }

        public async Task<Category> Add(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return false;
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
           return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> Update(int id, Category category)
        {
            if (await _db.Categories.Where(c => c.Id == id).AsNoTracking().FirstOrDefaultAsync() == null)
            {
                throw new Exception("Category not Found.");
            }
            
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();
            return category;
        }
    }
}
