using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concerete
{
    public class UserCommentManager : IUserCommentService
    {
        private IUserCommentDal _userCommentDal;
        public UserCommentManager(IUserCommentDal userCommentDal)
        {
            _userCommentDal = userCommentDal;
        }
        [ValidationAspect(typeof(UserCommentValidator))]
        public IResult Add(UserComment entity)
        {
            _userCommentDal.Add(entity);
            return new SuccessResult(Messages.AddedComment);
        }

        public IResult Delete(UserComment entity)
        {
            _userCommentDal.Delete(entity);
            return new SuccessResult(Messages.DeletedComment);
        }
        [CacheAspect]
        public IDataResult<List<UserComment>> GetAll()
        {
            return new SuccessDataResult<List<UserComment>>(_userCommentDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<UserComment>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<UserComment>>(_userCommentDal.GetAll(i => i.UserId == userId));
        }
        [ValidationAspect(typeof(UserCommentValidator))]
        public IResult Update(UserComment entity)
        {
            _userCommentDal.Update(entity);
            return new SuccessResult(Messages.UpdatedComment);
        }
    }
}
