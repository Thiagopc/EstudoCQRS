using System.Threading.Tasks;
using estudo.service.Services;
using Quartz;
using Quartz.Impl;

namespace estudo.service
{
    public class ServiceJob
    {
        public static void Build(){


             StdSchedulerFactory factory = new StdSchedulerFactory();

            // get a scheduler
             IScheduler scheduler =  factory.GetScheduler().Result;
             scheduler.Start().Wait();

            // // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<Job>()
                .WithIdentity("sync", "group")
                .Build();

            // // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("queue", "group")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
            .Build();

              scheduler.ScheduleJob(job, trigger).Wait();

        }
        



    }


    public class Job : IJob
    {
        private ServiceOut _service;
        public Job(){
            this._service = new ServiceOut();
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await this._service.Event();
        }
    }
}