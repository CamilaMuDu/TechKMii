using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechKMii.Layers.DAL;
using TechKMii.Layers.Entities;
using TechKMii.Layers.Interfaces;

namespace TechKMii.Layers.BLL
{
    public class RolBLL : IRolBLL
    {
        public List<Rol> GetAll()
        {
            IRolDAL dalRol = new RolDAL();
            return dalRol.GetAll();
        }
    }
}
