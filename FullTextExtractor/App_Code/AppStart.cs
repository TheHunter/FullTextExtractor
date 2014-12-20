using Autofac;
using Autofac.Integration.Wcf;
using TikaOnDotNet;

namespace FullTextExtractor
{
    public class AppStart
    {
        public static void AppInitialize()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<TextResearcher>();

            builder.Register(context => new TextExtractor())
                .As<ITextExtractor>()
                .SingleInstance();

            builder.RegisterType<TextResearcher>()
                .As<ITextResearcher>();

            AutofacHostFactory.Container = builder.Build();
        }
    }
}