﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;

namespace TechXpress.BLL.Services.Contracts
{
    public interface IProductImageService:IService<ProductImg,int>
    {
        public bool AddRange(List<ProductImg> productImages);

        public void DeleteByProductId(int productId);
       
        
    }
}
