static class JobsManager
{
    static List<Job> jobs = new();
   

    static public async void Add(string id){

        Job job = new() { Id = id, Status = "0", Value = null };
        jobs.Add(job);

        //This wait simulates the process length.
        for (int i = 1; i < 11; i++)
        {
            await Task.Delay(3000);
            //set status text like %10 %80
            job.Status = "%" + (i*10).ToString(); 
        }

        job.Status = "Completed";
        Random rnd = new Random();
        //simulate calcuation result
        job.Value = rnd.Next(10000,100000);
        jobs.Remove(job);
    }

    static public string Check(string id){
        Job job = jobs.Find(j => j.Id == id);
        if(job == null) return "Not Found";

        if(job.Status == "Completed") return job.Value.ToString();;

        return job.Status;         
    }
       
}

class Job{
    public string Id;
    public string Status;
    public int? Value;
}