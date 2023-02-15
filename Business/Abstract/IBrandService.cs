using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        bool Add(Brand brand);
        bool Delete(Brand brand);
        bool Update(Brand brand);
        List<Brand> GetAll();
    }
}
