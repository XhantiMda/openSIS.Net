﻿using opensis.data.Models;
using opensis.data.ViewModels.School;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace opensis.data.Interface
{
    public interface ISchoolRepository
    {
        public List<Schools> GetAllSchools();
        public List<Schools> AddSchools(Schools school);

        public SchoolAddViewModel AddSchool(SchoolAddViewModel school);
        public SchoolAddViewModel UpdateSchool(SchoolAddViewModel school);
        public SchoolAddViewModel ViewSchool(SchoolAddViewModel school);
        public SchoolListModel GetAllSchools(PageResult pageResult);

        public SchoolListModel GetAllSchoolList(SchoolListModel school);
        //Task<SchoolLogoUpdateModel> updateSchoolLogo(Guid guid, SchoolLogoUpdateModel schoolLogoUpdateModel);
    }
}
