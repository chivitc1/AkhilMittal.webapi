using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessEntities;
using DataModels;

namespace BusinessServices
{
    public class AutoMapperConfig
    {
        public static void CreateMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductEntity>();
                cfg.CreateMap<Product, ProductEntity>();
            });
            
        }
    }

    public static class MyAutoMapperHelper
    {
        public static void CreateMap<TSource, TDest>()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TSource, TDest>();
            });
        }
    }
}
