using Shared.Dtos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IEntidadServices
    {
        Task<List<EntidadDto>> GetEntidades();

        //Task<NuevaEntidadDto> Detalle(int entidadId);

        Task InsertEntidad(EntidadJSON nuevaEntidad, string repEntidad, bool decJurada);

        Task<List<EntidadJSON>> BuscarEntidad(string cuit, int padron);

        //Task<Entidad> GetById(int entidadId);
        
        

        //Task UpdateUsuario(NuevaEntidadDto   usuario);

        //Task Delete(int id);

        //Task ReActivar(int id);
    }
}
