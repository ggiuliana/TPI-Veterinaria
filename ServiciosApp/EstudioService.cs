using Data;
using DTOs;
using ModeloDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosApp
{
    public class EstudioService : IEstudioService
    {
        private readonly IEstudioRepository repo;

        public EstudioService(IEstudioRepository repo)
        {
            this.repo = repo;
        }
        public async Task<EstudioDTO> AddAsync(EstudioDTO dto) {
            Estudio estudio = new Estudio(0, dto.NombreEstudio, dto.DescripcionEstudio);
            await repo.AddAsync(estudio);
            dto.IdEstudio = estudio.IdEstudio;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id) {
            return await repo.DeleteAsync(id);
        }
        public async Task<EstudioDTO?> GetAsync(int id) {
            Estudio? estudio = await repo.GetAsync(id);
            if (estudio == null)
            {
                return null;
            }
            return new EstudioDTO
            {
                IdEstudio = estudio.IdEstudio,
                NombreEstudio = estudio.NombreEstudio,
                DescripcionEstudio = estudio.DescripcionEstudio
            };
        }
        public async Task<IEnumerable<EstudioDTO>> GetAllAsync() {
            IEnumerable<Estudio> estudios = await repo.GetAllAsync();
            return estudios.Select(estudio => new EstudioDTO
            {
                IdEstudio = estudio.IdEstudio,
                NombreEstudio = estudio.NombreEstudio,
                DescripcionEstudio = estudio.DescripcionEstudio
            }).ToList();
        }
        public async Task<bool> UpdateAsync(EstudioDTO dto) {
            Estudio estudio = new Estudio(dto.IdEstudio, dto.NombreEstudio, dto.DescripcionEstudio);
            return await repo.UpdateAsync(estudio);
        }
    }
}
