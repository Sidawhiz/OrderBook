using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TEngineServer.Core;


IHost Engine = TEngineServerHostBuilder.BuildTradingEngineServer();
//Console.WriteLine("Entered2");

TEngineServerServiceProvider.ServiceProvider = Engine.Services; // All the services registered in hostare accessible via this global class
{
    using var scope = TEngineServerServiceProvider.ServiceProvider.CreateScope();
    //Console.WriteLine("Entered");
    await Engine.RunAsync().ConfigureAwait(false);
}


// Part 1:
// Entry from line number 8 ... where Engine host is created  .... this builds the server also while adding services to it
// which includes option service - (Option service is necessary for configuration of json to class)
//   after adding option service configuration is loaded from json to particular class
// Singleton service is added to host : Singleton service is Dependency Injection which requires interface and class and a single instance services throughout
// finally as a host which service is hosted that is added i.e TEngineServer - this is where TEngineServer's entry point is located

// logger has to be added via constructor .. TEngineServerConfiguration service was already added .. this is used in constructor as Ioption
// ExecuteAsync is abstract method of backgroundservice that needs to be implemented ... this is where server loop is added
// ExecuteAsync is protected class. To use it publicly Run method is developed which isn't necessary

// TEngineServiceProvider is just storing all the services of Engine to a private class

// RunAsync is called on Engine which is property of Ihost and added host is TEngineServer here...
// from here server starts by constructing required objects of host and entering executeasync loop

// Part 2
// Logging libraray is to be implemented with different log levels
// logging from now on won't be o console but will be to file or database i.e textlogger
// log levels refer to debug level, information level, warning level, error level

