using ContracterManager;

namespace UnitTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void AddContractorNegativeID()
    {
        ManagementService service = new ManagementService();
        int expectedLength = service.GetContractors().Count;

        service.AddContractor(-1, "FName", "LName", new decimal(1.1), new DateOnly(2024, 11, 11));
        int actualLength = service.GetContractors().Count;

        Assert.AreEqual(expectedLength, actualLength);
    }
    [TestMethod]
    public void AddContractorNegativeRate()
    {
        ManagementService service = new ManagementService();
        int expectedLength = service.GetContractors().Count();

        service.AddContractor(1, "FName", "LName", new decimal(-1), new DateOnly(2024, 11, 11));
        int actualLength = service.GetContractors().Count();

        Assert.AreEqual(expectedLength, actualLength);
    }
    [TestMethod]
    public void AddContractorWithIntRate()
    {
        ManagementService service = new ManagementService();
        int expectedLength = (service.GetContractors().Count() + 1);

        service.AddContractor(1, "FName", "LName", new decimal(1), new DateOnly(2024, 11, 11));
        int actualLength = service.GetContractors().Count();

        Assert.AreEqual(expectedLength, actualLength);
    }
    [TestMethod]
    public void AddContractorCorrectlyAddsToList()
    {
        ManagementService service = new ManagementService();
        service.AddContractor(1, "FName", "LName", new decimal(1.1), new DateOnly(2024, 11, 11));

        int expectedLength = 7;
        int actualLength = service.GetContractors().Count();

        Assert.AreEqual(expectedLength, actualLength);
    }



    [TestMethod]
    public void AddJobNegativeCost()
    {
        ManagementService service = new ManagementService();
        int expectedlength = service.GetJobs().Count();

        service.AddJob("testJob", -1);
        int actuallength = service.GetJobs().Count();
        
        Assert.AreEqual(expectedlength, actuallength);
    }
    [TestMethod]
    public void AddJobWithCorrectInputs()
    {
        ManagementService service = new ManagementService();
        int expectedlength = (service.GetJobs().Count() + 1);

        service.AddJob("testJob", 100);
        int actuallength = service.GetJobs().Count();

        Assert.AreEqual(expectedlength, actuallength);
    }



    [TestMethod]
    public void RemoveContractorCorrectlyRemoves()
    {
        ManagementService service = new ManagementService();
        int expectedLength = service.GetContractors().Count();

        service.AddContractor(1, "FName","LName", new decimal(1.1), new DateOnly(2024, 11, 11));
        int actualLength = service.GetContractors().Count();

        Assert.AreEqual(expectedLength, actualLength);
    }
    [TestMethod]
    public void RemoveContractorNonExistantContractor()
    {
        ManagementService service = new ManagementService();


        Contractor contractor = new(1, "FName", "LName", new decimal(1.1), new DateOnly(2024, 11, 11));

        service.RemoveContractor(contractor);

        int expectedLength = 6;
        int actualLength = service.GetContractors().Count;

        Assert.AreEqual(expectedLength, actualLength);
    }
    [TestMethod]
    public void RemoveContractorNullContractor()
    {
        ManagementService service = new ManagementService();


        Contractor contractor = null;

        service.RemoveContractor(contractor);

        int expectedLength = 6;
        int actualLength = service.GetContractors().Count;

        Assert.AreEqual(expectedLength, actualLength);
    }



    [TestMethod]
    public void GetContractorsCorrectOutput()
    {
        ManagementService service = new ManagementService();

        List<Contractor> contractors = service.GetContractors();

        int expectedLength = 6;
        int actualLength = contractors.Count;

        Assert.AreEqual(expectedLength, actualLength);
    }
    [TestMethod]
    public void GetContractorsIsNotReference()
    {
        ManagementService service = new ManagementService();

        List<Contractor> contractors = service.GetContractors();
        List<Contractor> contractors2 = service.GetContractors();

        Assert.AreNotSame(contractors, contractors2);
    }



    [TestMethod]
    public void GetJobsCorrectOutput()
    {
        ManagementService service = new ManagementService();

        List<Job> jobs = service.GetJobs();

        int expectedLength = 5;
        int actualLength = jobs.Count;

        Assert.AreEqual(expectedLength, actualLength);
    }
    [TestMethod]
    public void GetJobsIsNotReference()
    {
        ManagementService service = new ManagementService();

        List<Job> jobs = service.GetJobs();
        List<Job> jobs2 = service.GetJobs();

        Assert.AreNotSame(jobs, jobs2);
    }



    [TestMethod]
    public void GetAvailableJobsCorrectOutput()
    {
        ManagementService service = new ManagementService();
        List<Job> jobs = service.GetAvailableJobs();

        int expectedLength = 4;
        int actualLength = jobs.Count;

        Assert.AreEqual(expectedLength, actualLength);
    }
    [TestMethod]
    public void GetAvailableContractorsCorrectOutput()
    {
        ManagementService service = new ManagementService();
        List<Contractor> contractors = service.GetAvailableContractors();

        int expectedLength = 5;
        int actualLength = contractors.Count;

        Assert.AreEqual(expectedLength, actualLength);
    }



    [TestMethod]
    public void AssignJobContractorTaken()
    {
        ManagementService service = new ManagementService();
        List<Job> jobs = service.GetJobs();

        Job job = new Job("TestJob", 100);
        Contractor contractor = new Contractor(1, "FName", "LName", new decimal(1.1), new DateOnly(2024, 11, 11));
        service.AssignJob(jobs[1], contractor);

        string expected = "Contractor already assigned to a job";
        string result = service.AssignJob(job, contractor);

        Assert.AreEqual(expected, result);
        
    }
    [TestMethod]
    public void AssignJobJobTaken()
    {
        ManagementService service = new ManagementService();

        Job job = new Job("TestJob", 100);
        Contractor contractorForJob = new Contractor(2, "FName", "LName", new decimal(2.2), new DateOnly(2024, 11, 11));
        service.AssignJob(job, contractorForJob);

        Contractor contractor = new Contractor(1, "FName", "LName", new decimal(1.1), new DateOnly(2024, 11, 11));
        
        string expected = "Job has already been assigned";
        string result = service.AssignJob(job, contractor);

        Assert.AreEqual(expected, result);
    }
    [TestMethod]
    public void AssignJobJobCompleted()
    {
        ManagementService service = new ManagementService();

        Job job = new Job("TestJob", 1);
        job.Completed = true;

        Contractor contractor = new Contractor(1, "FName", "LName", new decimal(1.1), new DateOnly(2024, 11, 11));

        string expected = "Job has already been completed";
        string result = service.AssignJob(job, contractor);

        Assert.AreEqual(expected, result);
    }
    [TestMethod]
    public void AssignJobCorrectInputs()
    {
        ManagementService service = new ManagementService();

        Job job = new Job("TestJob", 100);
        Contractor contractor = new Contractor(1, "FName", "LName", new decimal(1.1), new DateOnly(2024, 11, 11));

        string expected = "Job successfully assigned";
        string result = service.AssignJob(job, contractor);

        Assert.AreEqual(expected, result);
    }



    [TestMethod]
    public void CompleteJobCorrectInput()
    {
        ManagementService service = new ManagementService();

        Job job = new Job("TestJob", 100);
        Contractor contractor = new Contractor(1, "FName", "LName", new decimal(1.1), new DateOnly(2024, 11, 11));

        service.AssignJob(job, contractor);
        service.CompleteJob(job);

        Tuple<bool, Contractor?> expectedTuple = new Tuple<bool, Contractor?>(true, null);
        Tuple<bool, Contractor?> actualTuple = new Tuple<bool, Contractor?>(job.Completed, job.AssignedContractor);

        Assert.AreEqual(expectedTuple, actualTuple);
    }



    [TestMethod]
    public void GetByCostNegativeMin()
    {
        ManagementService service = new ManagementService(); //1,2,3 all return null
    }
    [TestMethod]
    public void GetByCostNegativeMax()
    {
        ManagementService service = new ManagementService();
    }
    [TestMethod]
    public void GetByCostReversedMinMaxValues()
    {
        ManagementService service = new ManagementService();
    }
    [TestMethod]
    public void GetByCostCorrectInputs() // compare length
    {
        ManagementService service = new ManagementService();
    }
}