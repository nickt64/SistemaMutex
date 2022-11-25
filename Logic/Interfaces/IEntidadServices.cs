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

        Task InsertEntidad(EntidadJsonDto nuevaEntidad, string repEntidad, bool decJurada);

        Task<EntidadJsonDto> BuscarEntidad(string cuit, int padron);

        Task<EntidadDto> GetById(long entidadId);
        
        Task ActualizarEntidad(EntidadDto entidadDto);

        Task EliminarEntidad(long id);

        //Task ReActivarEntidad(int id);
    }
}
