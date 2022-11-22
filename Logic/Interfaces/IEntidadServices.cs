using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IEntidadServices
    {
        //Task<IEnumerable<EntidadDto>> GetUsuarios(bool? estado);

        //Task<NuevaEntidadDto> Detalle(int entidadId);

        Task InsertEntidad(NuevaEntidadDto entidad);

        Task<List<NuevaEntidadDto>> BuscarEntidad(string cuit, int padron);


        //Task UpdateUsuario(NuevaEntidadDto   usuario);

        //Task Delete(int id);

        //Task ReActivar(int id);
    }
}
