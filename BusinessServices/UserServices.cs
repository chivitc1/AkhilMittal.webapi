﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels.unitofwork;

namespace BusinessServices
{
    /// <summary>
    /// Offers services for user specific operations
    /// </summary>
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Public method to authenticate user by user name and password.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Authenticate(string userName, string password)
        {
            var user = _unitOfWork.UserRepository.Get(u => u.UserName == userName && u.Password == password);
            if (user != null && user.UserId > 0)
            {
                return user.UserId;
            }
            return 0;
        }
    }
}
