using Humanizer.Localisation;
using LKMovies.Models;
using LKMovies.Repositories;
using LKMovies.Repositories.Interfaces;
using LKMovies.Services.Interfaces;

namespace LKMovies.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository ?? throw new ArgumentNullException(nameof(directorRepository));
        }
        public async Task<Director> Add(Director director)
        {
            if (director == null) throw new ArgumentNullException(nameof(director));
            if (string.IsNullOrWhiteSpace(director.FirstName))
                throw new ArgumentException("Name can not be empty", nameof(director.FirstName));
            if (string.IsNullOrWhiteSpace(director.LastName))
                throw new ArgumentException("Surname can not be empty", nameof(director.LastName));
            return await _directorRepository.Add(director);
        }

        public async Task<bool> Delete(int id)
        {
            return await _directorRepository.Delete(id);
        }

        public async Task<IEnumerable<Director>> GetAll()
        {
            return await _directorRepository.GetAll();
        }

        public async Task<Director> GetById(int id)
        {
            return await _directorRepository.GetById(id);
        }

        public async Task<Director> GetByLastName(string LastName)
        {
            return await _directorRepository.GetByLastName(LastName);
        }

        public async Task<Director> GetByName(string FirstName)
        {
            return await _directorRepository.GetByName(FirstName);
        }

        public async Task<Director> Update(int id, Director director)
        {
            return await _directorRepository.Update(id, director);
        }
    }
}
