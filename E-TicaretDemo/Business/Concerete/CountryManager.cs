using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concerete
{
    public class CountryManager : ICountryService
    {
        private ICountryDal _countryDal;
        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public IResult Add(Country entity)
        {
            _countryDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Country entity)
        {
            _countryDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Country>> GetAll()
        {
            return new SuccessDataResult<List<Country>>(_countryDal.GetAll());
        }

        public IResult Update(Country entity)
        {
            _countryDal.Update(entity);
            return new SuccessResult();
        }
    }
}
