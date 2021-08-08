using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.DTOs;

namespace Business.Concerete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IResult EditPassword(UserForUpdateDto userForUpdateDto, string newPassword, string newPasswordVerify)
        {
            byte[] passwordHash, passwordSalt;
            IResult result = BusinessRules.Run(CheckPasswwordTheSame(newPassword, newPasswordVerify), CheckIsOldPasswordCorrect(userForUpdateDto));
            if (result != null)
            {
                return result;
            }
            HashingHelper.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);
            var updatePassword = new User
            {
                Id = userForUpdateDto.User.Id,
                Email = userForUpdateDto.User.Email,
                FirstName = userForUpdateDto.User.FirstName,
                LastName = userForUpdateDto.User.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = userForUpdateDto.User.Status
            };
            _userDal.Update(updatePassword);
            return new SuccessResult(Messages.UserUpdated);
        }
        [CacheRemoveAspect("IUserService.Get")]
        public IResult EditProfil(User user)
        {
            var updateUser = new User
            {
                Id =user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Status = user.Status
            };
            _userDal.Update(updateUser);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(i => i.Id == id));
        }
        [CacheAspect]
        public User GetByMail(string email)
        {
            return _userDal.Get(i => i.Email == email);
        }

        public IDataResult<User> GetByUserId(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(i => i.Id == userId));
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return new List<OperationClaim>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetUserByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(i => i.Email == email));
        }

        public IDataResult<List<UserDetailDto>> GetUserDetailsById(int userId)
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails(i=>i.UserId == userId));
        }

        public IDataResult<List<UserDetailDto>> GetUsersDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetUserDetails());
        }

        private IResult CheckIsOldPasswordCorrect(UserForUpdateDto userForUpdateDto)
        {
            var userToCheck = this.GetByMail(userForUpdateDto.User.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if(!HashingHelper.VerifyPasswordHash(userForUpdateDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.OldPasswordWrong);
            }
            return new SuccessResult();
        }

        private IResult CheckPasswwordTheSame(string newPassword, string newPasswordVerify)
        {
            var result = newPassword == newPasswordVerify;
            if (!result)
            {
                return new ErrorResult("Maalesef şifreler aynı değil");
            }
            return new SuccessResult();
        }
    }
}