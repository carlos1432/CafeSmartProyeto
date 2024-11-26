using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebCafeSmart.DataAccess;
using WebCafeSmart.DTOS;

namespace WebCafeSmart.Services
{
    public class RolService
    {
        private readonly DBContext _db;
        private readonly IMapper _mapper;

        public RolService(DBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RolDTO>> GetRoles()
        {
            return await _db.Rols
                .ProjectTo<RolDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
