namespace WebApplication1.Models
{
    public class JobInitializer : System.Data.Entity.CreateDatabaseIfNotExists<JobsContext>
    {
        protected override void Seed(JobsContext context)
        {
            // default data
            context.LuJobTitles.Add(new LuJobTitle { Id = 0, JobTitleText = "driver" });
            context.Jobs.Add(new Jobs { JobDescription = "Some job 1", Id = 0, LuJobTitleId = 0 });
            context.Jobs.Add(new Jobs { JobDescription = "Some job 11", Id = 1, LuJobTitleId = 0 });
            context.Jobs.Add(new Jobs { JobDescription = "Some job 12", Id = 2, LuJobTitleId = 0 });

            context.LuJobTitles.Add(new LuJobTitle { Id = 1, JobTitleText = "driller" });
            context.Jobs.Add(new Jobs { JobDescription = "Some job 2", Id = 3, LuJobTitleId = 1 });
            context.Jobs.Add(new Jobs { JobDescription = "Some job 21", Id = 4, LuJobTitleId = 1 });
            context.Jobs.Add(new Jobs { JobDescription = "Some job 22", Id = 5, LuJobTitleId = 1 });

            context.LuJobTitles.Add(new LuJobTitle { Id = 2, JobTitleText = "drammer" });
            context.Jobs.Add(new Jobs { JobDescription = "Some job 3", Id = 6, LuJobTitleId = 2 });
            context.Jobs.Add(new Jobs { JobDescription = "Some job 31", Id = 7, LuJobTitleId = 2 });
            context.Jobs.Add(new Jobs { JobDescription = "Some job 312", Id = 8, LuJobTitleId = 2 });

            base.Seed(context);
        }
    }

}