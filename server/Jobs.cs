static class JobsManager
{
    static List<Job> jobs = new();
   

    static public async void Add(string id){

        Job job = new() { Id = id,Value = null };
        jobs.Add(job);

        //This wait simulates the process length.
        await Task.Delay(9000);

        Random rnd = new Random();
        //simulate calcuation result
        job.Value = rnd.Next(10000,100000);
        jobs.Remove(job);
    }

    static public string GetAsync(CancellationToken cancellationToken,string id){
        Job job = jobs.Find(j => j.Id == id);

        while (!cancellationToken.IsCancellationRequested)
        {
            if (job.Value != null){ return job.Value.ToString(); }
        }

        return null;          
    }

       
}

class Job{
    public string Id;
    public int? Value;
}