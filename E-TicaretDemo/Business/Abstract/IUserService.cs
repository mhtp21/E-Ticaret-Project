﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<UserDetailDto>> GetUsersDetails();
        IDataResult<List<UserDetailDto>> GetUserDetailsById(int userId);
        IDataResult<User> GetByUserId(int userId);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IResult Add(User user);
        IResult EditProfil(User user);
        IResult EditPassword(UserForUpdateDto userForUpdateDto, string newPassword, string newPasswordVerify);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetUserByEmail(string email);
        IDataResult<User> GetById(int id);
    }
}
