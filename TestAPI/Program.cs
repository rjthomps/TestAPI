using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Unity;
using Unity.Attributes;
using Unity.Injection;

namespace TestAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //IUnityContainer container = new UnityContainer();
            //container.RegisterType<ICar, BMW>();
            //container.RegisterType<ICar, Audi>("LuxuryCar");

            //// Register Driver type            
            //container.RegisterType<Driver>("LuxuryCarDriver",
            //    new InjectionConstructor(container.Resolve<ICar>("LuxuryCar")));

            //Driver driver1 = container.Resolve<Driver>();// injects default BMW
            //driver1.RunCar();

            //Driver driver2 = container.Resolve<Driver>("LuxuryCarDriver");// injects named Audi
            //driver2.RunCar();

            //////////////////////////////////////

            //IUnityContainer container2 = new UnityContainer();
            //ICar ford = new Ford();
            //container2.RegisterInstance<ICar>(ford); //creates an instance to use over and over

            //Driver driver5 = container2.Resolve<Driver>();
            //driver5.RunCar();
            //driver5.RunCar();

            //Driver driver6 = container2.Resolve<Driver>();
            //driver6.RunCar();

            ///////////////////////////////////////////

            var container = new UnityContainer();

            container.RegisterType<ICar, Audi>();
            container.RegisterType<ICarKey, AudiKey>();

            var driver = container.Resolve<Driver>();
            driver.RunCar();

            ///////////////////////////////////////////

            Console.ReadKey();
        }
    }

    public interface ICar
    {
        int Run();
    }

    public class BMW : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }
    }

    public class Ford : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }
    }

    public class Audi : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }

    }

    public interface ICarKey
    {

    }

    public class BMWKey : ICarKey
    {

    }

    public class AudiKey : ICarKey
    {

    }

    public class FordKey : ICarKey
    {

    }

    public class Driver
    {
        private ICar _car = null;
        private ICarKey _key = null;

        [InjectionConstructor]
        public Driver(ICar car, ICarKey key)
        {
            _car = car;
            _key = key;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} with {1} - {2} mile ", _car.GetType().Name, _key.GetType().Name, _car.Run());
        }
    }

    //public class Driver
    //{
    //    private ICar _car = null;

    //    public Driver(ICar car)
    //    {
    //        _car = car;
    //    }

    //    public void RunCar()
    //    {
    //        Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
    //    }
    //}
}
