using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace SCServer.Core
{
    public static class IoC
    {
        private static IUnityContainer container;

        static IoC()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "unity.config");
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = filePath };
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");
            container = new UnityContainer();
            container.LoadConfiguration(unitySection);
        }

        public static T Resolve<T>()
        {
            return (T)container.Resolve<T>();
        }

        public static bool Exists<T>()
        {
            return container.IsRegistered<T>();
        }

        public static IUnityContainer Container
        {
            get
            {
                return container;
            }
        }
    }
}
