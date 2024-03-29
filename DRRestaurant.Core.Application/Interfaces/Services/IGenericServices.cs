using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRestaurant.Core.Application.Interfaces.Services
{
        public interface IGenericService<SVModel, VModel, Model>
         where SVModel : class
         where VModel : class
         where Model : class
        {
            Task Update(SVModel vm, int id);

            Task<SVModel> Add(SVModel vm);

            Task Delete(int id);

            Task<SVModel> GetByIdSaveViewModel(int id);

            Task<List<VModel>> GetAllViewModel();
        }
    
}
