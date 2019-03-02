using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DragAndDrapMVC.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void RegisterComponents()
        {
            var container = new Container();
            // register all your components with the container here 
            // it is NOT necessary to register your controllers 

        }
    }
}