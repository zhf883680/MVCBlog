using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyBlogByMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            using (var dbcontext = new MyBlogEntities())
            {
                var objectContext = ((System.Data.Entity.Infrastructure.IObjectContextAdapter)dbcontext).ObjectContext;
                var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappingCollection.GenerateViews(new List<EdmSchemaError>());
                //对程序中定义的所有DbContext逐一进行这个操作
            }
        }
        public void Application_Error()
        {
            //string strError;

            //strError = Server.GetLastError().ToString();

            //if (Context != null)

            //    Context.ClearError();

           // Response.Redirect("/Error.aspx?Msg=" +Server.UrlEncode(strError));
        }
    }
}
