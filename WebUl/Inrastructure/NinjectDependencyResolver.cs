using Domain.Abstract;
using Domain.AutoShop;
using Domain.Concrete;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {kernel.Bind<ISkodaRepository>().To<EFSkodaRepository>();
            /*// размещение привязок
            Mock<IAutoRepository> mock = new Mock<IAutoRepository>();
            mock.Setup(m => m.Autos).Returns(new List<Auto>
                {
                new Auto { NAME = "Auto City Skoda", ADRESS = "г. Москва, Новорижское шоссе, 9 км от МКАД", CITY = "Москва",TELEPHONE ="+7(495)737-77-78", SITE = "www.autocity-sk.ru" },
                 new Auto { NAME = "Изар-Авто", ADRESS = "г. Пенза, пр-т Победы, д. 121 (въезд с трассы М5)", CITY = "Пенза",TELEPHONE ="8(8412)20-00-20", SITE = "bmw-izar-avto.ru" },
                 new Auto { NAME = "PORSHE", ADRESS = "г. Казань, ул. Декабристов, 81В.", CITY = "Казань",TELEPHONE ="+7(843)52-62-911", SITE = "www.porsche-kazan.ru" },
                 new Auto { NAME = "Envy Motors", ADRESS = "г. Москва, ул. Привольная, 70, корп.1", CITY = "Москва",TELEPHONE ="+7(495)645-84-70", SITE = "www.envy-peugeot.ru" },
                 new Auto { NAME = "ВИКИНГИ", ADRESS = "г. Тольятти, ул. Громовой, д.51А", CITY = "Тольятти",TELEPHONE ="+7(8482)63-00-77", SITE = "vikingi.lada.ru" }
            });
            kernel.Bind<IAutoRepository>().ToConstant(mock.Object);*/

            kernel.Bind<IBMWRepository>().To<EFBMWRepository>();
            kernel.Bind<ILadaRepository>().To<EFLadaRepository>();
            kernel.Bind<IPeugeotRepository>().To<EFPeugeotRepository>();
            kernel.Bind<IPorsheRepository>().To<EFPorsheRepository>();


        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}