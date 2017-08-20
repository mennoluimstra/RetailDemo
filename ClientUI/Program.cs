using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI
{
	class Program
	{
		static void Main()
		{
			AsyncMain().GetAwaiter().GetResult();
		}

		static async Task AsyncMain()
		{
			Console.Title = "ClientUI";

			var endPointConfiguration = new EndpointConfiguration("ClientUI");

			var transport = endPointConfiguration.UseTransport<LearningTransport>();

			var endpointInstance = await Endpoint.Start(endPointConfiguration)
				.ConfigureAwait(false);

			Console.WriteLine("Press Enter to exit...");
			Console.ReadLine();

			await endpointInstance.Stop()
				.ConfigureAwait(false);
		}
	}
}
