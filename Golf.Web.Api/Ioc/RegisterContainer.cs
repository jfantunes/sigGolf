using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Golfe.Data.Repository.Interfaces;
using Golfe.Data.Repository.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Golf.Web.Api.Ioc
{
    public class RegisterContainer
    {
        public static Container RegisterRepository()
        {

            var container = new Container();
            container.Options.DefaultScopedLifestyle=new WebApiRequestLifestyle();
            container.Register<ITarefasRepository, TarefaRepository>();
            container.Register<IOperacaoRepository, OperacaoRepository>();
            container.Register<IAreaJogoRepository, AreaJogoRepository>();
            container.Register<IMaquinasRepository, MaquinasRepository>();
            container.Register<IFuncionariosRepository, FuncionariosRepository>();
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            return container;
        }
    }
}