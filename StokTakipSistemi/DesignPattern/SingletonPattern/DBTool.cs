using StokTakipSistemi.Models.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DesignPattern.SingletonPattern
{
    public class DBTool
    {
        public DBTool() { }

        static MyContext _dbInstance;

       public static MyContext DBInstance
        {
            get
            {
                if(_dbInstance == null) _dbInstance = new MyContext();
                return _dbInstance;
            }
        }
    }
}
