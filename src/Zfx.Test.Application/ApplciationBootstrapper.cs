using Autofac;
using FluentValidation;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using Zfx.Test.Application.Features.Circle;
using Zfx.Test.Application.Infrastructure.Validation;

namespace Zfx.Test.Application
{
    public static class ApplciationBootstrapper
    {
        public static ContainerBuilder BootstrapApplication(this ContainerBuilder builder) 
        {
            var mediatRConfiguration = MediatRConfigurationBuilder
            .Create(typeof(CircleForConsoleQueryHandler).Assembly)
            .WithAllOpenGenericHandlerTypesRegistered()
            .WithCustomPipelineBehavior(typeof(ValidationPipelineBehaviour<,>))
            .Build();

            builder.RegisterMediatR(mediatRConfiguration);
            AssemblyScanner.FindValidatorsInAssembly(typeof(CircleForConsoleQueryValidator).Assembly, true)
            .ForEach(result =>
            {
                builder.RegisterType(result.ValidatorType).AsImplementedInterfaces();
            });

            return builder;
        }
    }
}