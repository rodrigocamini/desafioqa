using Castle.DynamicProxy;
using NUnit.Framework;
using RodrigoDesafioCit.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RodrigoDesafioCit.Util
{
    public class InitClose
    {        
        [SetUp]
        public void NavegadorChrome()
        {
           
            DriverFactory.CreateInstance();

            DriverFactory.INSTANCE.Url = "http://automationpractice.com/index.php";
            DriverFactory.INSTANCE.Manage().Window.Maximize();

            #region [AutoInstance] atribute methods calls to auto instace pages and flows
            //Necessário para realizar a instanciação automática das páginas e fluxos
            this.ProxyGenerator = new ProxyGenerator();
            InjectPageObjects(CollectPageObjects(), null);
            #endregion
        }

        [TearDown]
        public void CloseAll()
        {           
            DriverFactory.INSTANCE.Close();
            DriverFactory.INSTANCE.Quit();
        }      

        #region Methodes needed to auto intance pages and flows [AutoInstance]
        //Esses métodos necessariamente precisam estar nesta classe, não funciona se estiverem em outro arquivo.
        private ProxyGenerator ProxyGenerator;

        private void InjectPageObjects(List<FieldInfo> fields, IInterceptor proxy)
        {
            foreach (FieldInfo field in fields)
            {
                field.SetValue(this, ProxyGenerator.CreateClassProxy(field.FieldType, proxy));
            }
        }

        private List<FieldInfo> CollectPageObjects()
        {
            List<FieldInfo> fields = new List<FieldInfo>();

            foreach (FieldInfo field in this.GetType().GetRuntimeFields())
            {
                if (field.GetCustomAttribute(typeof(AutoInstance)) != null)
                    fields.Add(field);
            }

            return fields;
        }
        #endregion
    }
}
