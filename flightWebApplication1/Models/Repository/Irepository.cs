using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightWebApplication1.Models.Repository
{
    public interface Ifunction<T> where T : class
    {
        IEnumerable<T> GetModel();
        T GetModelbyID(int modelId);
        void InsertModel(T model);
        void UpdateModel(T model);
        void DeleteModel(int modelId);
    }
}
