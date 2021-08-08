using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.BaseOperations;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICountryService:ICrudOperationService<Country>
    {
    }
}
