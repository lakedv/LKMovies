using LKMovies.Models;
using LKMovies.Repositories;
using LKMovies.Repositories.Interfaces;
using LKMovies.Services.Interfaces;

namespace LKMovies.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
        }
        public async Task<Genre> Add(Genre genre)
        {
            if (genre == null) throw new ArgumentNullException(nameof(genre));
            if (string.IsNullOrWhiteSpace(genre.Name))
                throw new ArgumentException("Name can not be empty", nameof(genre.Name));
            return await _genreRepository.Add(genre);
        }

        public async Task<bool> Delete(int id)
        {
            return await _genreRepository.Delete(id);
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _genreRepository.GetAll();
        }

        public async Task<Genre> GetById(int id)
        {
            return await _genreRepository.GetById(id);
        }

        public async Task<Genre> Update(int id, Genre genre)
        {
            return await _genreRepository.Update(id, genre);
        }
    }
}
