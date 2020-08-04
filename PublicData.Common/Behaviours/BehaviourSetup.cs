using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PublicData.Common.Behaviours
{
    public static class BehaviourSetup
    {
        public static void AddBehaviourSetup(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }
    }
}
