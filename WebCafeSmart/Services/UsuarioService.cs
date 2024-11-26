using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebCafeSmart.DataAccess;
using WebCafeSmart.DTOS;

namespace WebCafeSmart.Services
{
    public class UsuarioService
    {
        private readonly DBContext _db;
        private readonly IMapper _mapper;

        public UsuarioService(DBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsuarios()
        {
            return await _db.Usuarios
                .ProjectTo<UsuarioDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
