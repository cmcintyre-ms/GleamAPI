using GleamAPI.Data;
using GleamAPI.Entities.Venue;
using GleamAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GleamAPI.Repositories
{
    public class GleamVenueRepository : IGleamVenueRepository
    {
        private readonly DataContext _dbContext;

        public GleamVenueRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GleamVenue>> GetGleamVenues()
        {
            return await _dbContext!.GleamVenues!.Include(v => v.Reviews).ToListAsync();
        }

        public async Task<GleamVenue?> GetGleamVenueById(Guid id)
        {
            return await _dbContext!.GleamVenues!.Include(v => v.Reviews).FirstOrDefaultAsync(x => x.Id == id);
            
            //return await _dbContext!.GleamVenues!.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<GleamVenue> CreateGleamVenue(GleamVenue gleamvenue)
        {
            await _dbContext!.GleamVenues!.AddAsync(gleamvenue);

            try
            {
                await _dbContext!.SaveChangesAsync();
            }
            catch(Exception e)
            {
                int a = 1;
            }
            return gleamvenue;
        }

        public async Task<bool> DeleteGleamVenue(Guid id)
        {
            var gleamVenueToRemove = await GetGleamVenueById(id);

            if (gleamVenueToRemove == null)
                throw new Exception($"Entity {id} cannot be found");

            _dbContext!.GleamVenues!.Remove(gleamVenueToRemove);

            var result = await _dbContext.SaveChangesAsync();

            return result == 1;
        }

        public async Task<IEnumerable<GleamVenue>> GetVenuesByCity(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return new List<GleamVenue>();
            }

            return await _dbContext.GleamVenues.Where(v => v.Address.City.ToLower() == city.ToLower()).ToListAsync();  
        }


        #region Original
        //private readonly DataContext _dataContext;

        //public GleamVenueRepository(DataContext dataContext)
        //{
        //    _dataContext = dataContext;
        //    //checks, don't pass in null
        //}
        //public async Task<string> AddGleamVenue(GleamVenue gleamVenueToBeAdded)
        //{
        //    await _dataContext!.GleamVenues.AddAsync(gleamVenueToBeAdded);

        //    await _dataContext!.SaveChangesAsync();

        //    return gleamVenueToBeAdded.VenueName;
        //}

        //public async Task<GleamVenue> GetGleamVenue(Guid id)
        //{
        //    //checks for null
        //    //nuget package
        //    return await _dataContext.GleamVenues.FindAsync(id);
        //}

        //public async Task<List<GleamVenue>> GetGleamVenues()
        //{
        //    return await _dataContext.GleamVenues.ToListAsync();

        //}

        //public Task<List<GleamVenue>> GetGleamVenuesByName(string venueName)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion
    }
}
