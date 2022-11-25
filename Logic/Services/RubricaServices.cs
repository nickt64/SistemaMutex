using Data.Interfaces;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class RubricaServices : IRubricaServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RubricaServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


    }
}
