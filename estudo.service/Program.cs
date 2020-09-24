using System;
using estudo.service.Services;
using Quartz;
using Quartz.Impl;

namespace estudo.service
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            // construct a scheduler factory
            ServiceJob.Build();
            new ServiceListener().Listener();
            Console.ReadKey();

        }
    }
}
