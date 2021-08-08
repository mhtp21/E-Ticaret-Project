using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concerete
{
    public class CityManager : ICityService
    {
        private ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("ICityService.Get")]
        [ValidationAspect(typeof(CityValidator))]
        public IResult Add(City entity)
        {
            _cityDal.Add(entity);
            return new SuccessResult();
        }
        [SecuredOperation("admin,user")]
        public IResult Delete(City entity)
        {
            _cityDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll());
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("ICityService.Get")]
        [ValidationAspect(typeof(CityValidator))]
        public IResult Update(City entity)
        {
            _cityDal.Update(entity);
            return new SuccessResult();
        }
    }
}
