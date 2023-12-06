using RESRTfull.Domain;

namespace RESTfull.API.DTO
{
    public class JobDTOMapper
    {
        public static JobDTO ToDto(Job job)
        {
            var jobDTO = new JobDTO
            {
                ID = job.ID,
                Position = job.Position,
                Organization = job.Organization,
                DateStart = job.DateStart,
                DateEnd = job.DateEnd
            };
            return jobDTO;
        }

        public static Job ToEntity(JobDTO jobDTO)
        {
            var job = new Job
            {
                ID = jobDTO.ID,
                Position = jobDTO.Position,
                Organization = jobDTO.Organization,
                DateStart = jobDTO.DateStart,
                DateEnd = jobDTO.DateEnd
            };
            return job;
        }
    }
}
