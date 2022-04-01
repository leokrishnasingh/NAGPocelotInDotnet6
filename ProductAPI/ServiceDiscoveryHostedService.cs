
using Consul;

namespace ProductAPI.ServiceDiscoveryHostedService
{
    public class ServiceDiscoveryHostedService : IHostedService
    {
        private readonly IConfiguration _config;
        private readonly IConsulClient _consulClient;
        public string registrationId;
        public ServiceDiscoveryHostedService(IConfiguration configuration)
        {
            _config = configuration;
            _consulClient = new ConsulClient(config => 
            {
                config.Address = _config.GetValue<Uri>("ServiceConfig:ServiceDiscoveyAddress");
            });
        }


        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var serviceId = _config.GetValue<string>("ServiceConfig:ServiceID");
            var serviceName = _config.GetValue<string>("ServiceConfig:ServiceName");
            var serviceAddress = _config.GetValue<Uri>("ServiceConfig:ServiceAddress");

            registrationId = $"{serviceName}-{serviceId}";

            var registration = new AgentServiceRegistration
            {
                ID = serviceId,
                Name = serviceName,
                Address = serviceAddress.Host,
                Port = serviceAddress.Port
            };

            await _consulClient.Agent.ServiceRegister(registration,cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _consulClient.Agent.ServiceDeregister(registrationId,cancellationToken);
        }
    }
}