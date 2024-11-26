using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebCafeSmart.DataAccess;
using WebCafeSmart.DTOS;

namespace WebCafeSmart.Services
{
    public class TiposService
    {
        private readonly DBContext _db;
        private readonly IMapper _mapper;

        public TiposService(DBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoDTO>> GetTipos()
        {
            return await _db.Tipos
                .ProjectTo<TipoDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
