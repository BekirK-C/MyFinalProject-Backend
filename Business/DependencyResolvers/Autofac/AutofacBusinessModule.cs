using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    // WebAPI Startup'ın içinde kurduğumuz IoC yapısını burada Autofac ile kuruyoruz.
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();  // Startup'taki AddSingleton'a karşılık gelir.
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
        }
    }
}
