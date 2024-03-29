﻿using opensis.data.Interface;
using opensis.data.Models;
using opensis.data.ViewModels.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.IO;
using opensis.data.Helper;

namespace opensis.data.Repository
{
    public class UserRepository : IUserRepository
    {
        private CRMContext context;
        private static string EMAILMESSAGE = "Email address is not registered in the system";
        private static string PASSWORDMESSAGE = "Email + password combination is incorrect, try again";
        public UserRepository(IDbContextFactory dbContextFactory)
        {
            this.context = dbContextFactory.Create();
        }



        /// <summary>
        ///  ValidateUserLogin method is used for authentcatred the login process
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>

        public LoginViewModel ValidateUserLogin(LoginViewModel objModel)
        {
            LoginViewModel ReturnModel = new LoginViewModel();
            try
            {

                var decrypted = Utility.Decrypt(objModel.Password);
               
                string passwordHash = Utility.GetHashedPassword(decrypted );
                ReturnModel._tenantName = objModel._tenantName;
                //var encryptedPassword = EncodePassword(objModel.Password);
                var user = this.context?.TableUserMaster.FirstOrDefault(x => x.EmailAddress == objModel.Email && x.TenantId == objModel.TenantId 
                && x.PasswordHash == passwordHash);
                var correctEmailList = this.context?.TableUserMaster.Where(x => x.EmailAddress.Contains(objModel.Email)).ToList();
                var correctPasswordList = this.context?.TableUserMaster.Where(x => x.PasswordHash == passwordHash).ToList();
                if (user == null && correctEmailList.Count>0 && correctPasswordList.Count==0)
                {
                    ReturnModel.UserId = null;
                    ReturnModel._failure = true;
                    ReturnModel._message = PASSWORDMESSAGE;
                }
                else if (user == null && correctEmailList.Count == 0 && correctPasswordList.Count > 0) {
                    ReturnModel.UserId = null;
                    ReturnModel._failure = true;
                    ReturnModel._message = EMAILMESSAGE;
                }
                else if (user == null && correctEmailList.Count == 0 && correctPasswordList.Count == 0) {
                    ReturnModel.UserId = null;
                    ReturnModel._failure = true;
                    ReturnModel._message = PASSWORDMESSAGE;
                }
                else
                {
                    ReturnModel.UserId = user.UserId;
                    ReturnModel.TenantId = user.TenantId;
                    ReturnModel.Email = user.EmailAddress;
                    ReturnModel._failure = false;
                    ReturnModel._message = "";
                }
            }
            catch (Exception ex)
            {
                ReturnModel._failure = true;
                ReturnModel._message = ex.Message;
            }


            return ReturnModel;
        }

    }
}
