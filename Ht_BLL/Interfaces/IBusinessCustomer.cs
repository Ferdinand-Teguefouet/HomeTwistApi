using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT_BLL.Interfaces
{
    public interface IBusinessCustomer<TEntity> : IBusiness<TEntity>
        where TEntity : new()
    {
        TEntity GetByEmail(string email);
    }
}
