using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Data.Entity;

namespace DataComponents
{
    public class BaseDataComponent
    {
        protected LPPA_Model db = new LPPA_Model();
        public BaseDataComponent(){}

        public void Dispose()
        {
            db.Dispose();
        }
    }
}