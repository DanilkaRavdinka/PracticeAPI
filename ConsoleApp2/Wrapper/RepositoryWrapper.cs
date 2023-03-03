using ApiBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private apiapiContext _apiapiContext;
        
        public RepositoryWrapper(apiapiContext apiapiContext)
        {
            _apiapiContext = apiapiContext;
        }
        public void Save()
        {
            _apiapiContext.SaveChanges();
        }
    }
}
