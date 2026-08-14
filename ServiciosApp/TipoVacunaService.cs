using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using DTOs;
using ModeloDominio;

namespace ServiciosApp
{
    public class TipoVacunaService : ITipoVacunaService
    {
        private readonly ITipoVacunaRepository repo;

        public TipoVacunaService(ITipoVacunaRepository repo)
        {
            this.repo = repo;
        }

        public async Task<TipoVacunaDTO> AddAsync(TipoVacunaDTO dto) {
            TipoVacuna tipovacuna = new TipoVacuna(0, dto.NombreTipoVacuna, dto.DescripcionTipoVacuna);
            await repo.AddAsync(tipovacuna);
            dto.IdTipoVacuna = tipovacuna.IdTipoVacuna;
            return dto;
        }
        public async Task<bool> DeleteAsync(int id) { 
            return await repo.DeleteAsync(id);
        }
        public async Task<TipoVacunaDTO> GetAsync(int id) {
            TipoVacuna? tipovac = await repo.GetAsync(id);
            if (tipovac == null)
            {
                return null;
            }
            return new TipoVacunaDTO
            {
                IdTipoVacuna = tipovac.IdTipoVacuna,
                NombreTipoVacuna = tipovac.NombreTipoVacuna,
                DescripcionTipoVacuna = tipovac.DescripcionTipoVacuna
            };
        }
        public async Task<IEnumerable<TipoVacunaDTO>> GetAllAsync() {
            IEnumerable<TipoVacuna> tipovacs = await repo.GetAllAsync();
            return tipovacs.Select(t => new TipoVacunaDTO
            {
                IdTipoVacuna = t.IdTipoVacuna,
                NombreTipoVacuna = t.NombreTipoVacuna,
                DescripcionTipoVacuna = t.DescripcionTipoVacuna
            }).ToList();
        }
        public async Task<bool> UpdateAsync(TipoVacunaDTO dto) {
            var tipovac = await repo.GetAsync(dto.IdTipoVacuna);
            if (tipovac == null) {
                return false;
            }
            TipoVacuna tpv = new TipoVacuna(dto.IdTipoVacuna, dto.NombreTipoVacuna, dto.DescripcionTipoVacuna);
            await repo.UpdateAsync(tpv);
            return true;
        }
    }
}
