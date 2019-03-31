using BookStore.Data.Repositories;
using BookStore.Domain.Contracts;
using BookStore.Utils;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace BookStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //DI
            var container = new UnityContainer();
            container.RegisterType<IBookRepository, BookRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
            //controller.RegisterType<IAuthorRepository,BookRepository>(new HierarchicalLifetimeManager())

            // Serviços e configuração da API da Web
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var Jsonformatters = formatters.JsonFormatter;
            var settings = Jsonformatters.SerializerSettings;

            Jsonformatters.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            settings.Formatting = Newtonsoft.Json.Formatting.Indented;

            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
