using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        bool Add(Color color);
        bool Delete(Color color);
        bool Update(Color color);
        List<Color> GetAll();
    }
}
