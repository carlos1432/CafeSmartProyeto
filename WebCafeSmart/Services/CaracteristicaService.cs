using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebCafeSmart.DataAccess;
using WebCafeSmart.DTOS;

namespace WebCafeSmart.Services
{
    public class CaracteristicaService
    {
        private readonly DBContext _db;
        private readonly IMapper _mapper;

        public CaracteristicaService(DBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CaracteristicaDTO>> GetCaracteristicas()
        {
            return await _db.Caracteristicas
                .ProjectTo<CaracteristicaDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
