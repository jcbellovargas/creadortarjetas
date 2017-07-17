using DataComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace BusinessComponents
{
    public class BaseBusinessComponent
    {
        protected BaseDataComponent base_dal = new BaseDataComponent();
        public BaseBusinessComponent(){}

        public void Dispose()
        {
            base_dal.Dispose();
        }

    }
}
