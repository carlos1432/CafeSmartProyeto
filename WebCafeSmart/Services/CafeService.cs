using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebCafeSmart.DataAccess;
using WebCafeSmart.DTOS;

namespace WebCafeSmart.Services
{
    public class CafeService
    {
        private readonly DBContext _db;
        private readonly IMapper _mapper;

        public CafeService(DBContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<CafeDTO>> GetAll()
        {
            var query = from cafe in _db.Caves  // Asegúrate de usar _db en lugar de context
                        join tipo in _db.Tipos on cafe.IdTipo equals tipo.IdTipo into tipoJoin
                        from tipo in tipoJoin.DefaultIfEmpty()  // Left join
                        join cc in _db.CafeCaracteristicas on cafe.IdCafe equals cc.IdCafe into cafeCaracteristicasJoin
                        from cafeCaracteristica in cafeCaracteristicasJoin.DefaultIfEmpty()  // Left join
                        join caracteristica in _db.Caracteristicas on cafeCaracteristica.IdCaracteristica equals caracteristica.IdCaracteristica into caracteristicaJoin
                        from caracteristica in caracteristicaJoin.DefaultIfEmpty()  // Left join
                        group new { cafe, tipo, cafeCaracteristica, caracteristica } by new
                        {
                            cafe.IdCafe,
                            cafe.Nombre,
                            cafe.Descripcion,
                            cafe.Precio,
                            tipo.NombreTipo,
                            tipo.DescripcionTipo
                        } into g
                        select new CafeDTO
                        {
                            IdCafe = g.Key.IdCafe,
                            CafeNombre = g.Key.Nombre,
                            CafeDescripcion = g.Key.Descripcion,
                            PrecioBase = g.Key.Precio,
                            Tipo = g.Key.NombreTipo,
                            Caracteristicas = string.Join(", ", g.Select(x => x.caracteristica.Nombre)),  // Concatenar características
                            PrecioAjusteCaracteristica = g.Sum(x => x.cafeCaracteristica.PrecioAjuste ?? 0),
                            DescripcionTipo = g.Key.DescripcionTipo,
                            PrecioFinal = g.Key.Precio + g.Sum(x => x.cafeCaracteristica.PrecioAjuste ?? 0)
                        };

            // Ejecutar la consulta de manera asíncrona y devolver el resultado como una lista
            return await query.ToListAsync();  // ToListAsync es una función de Entity Framework que realiza la consulta de manera asíncrona
        }

    }
}
