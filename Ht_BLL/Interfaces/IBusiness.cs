using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_BLL.Interfaces
{
    public interface IBusiness<TEntity>
        where TEntity : new()
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Delete(int id);
        void Insert(TEntity t);
        void Update(TEntity t);
    }
}
