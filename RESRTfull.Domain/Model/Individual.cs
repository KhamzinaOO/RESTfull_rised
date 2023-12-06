namespace RESRTfull.Domain
{
    public class Individual
    {
        public Guid ID { get; set; }

        public Info? Information { get; set; } = new Info();
        public List<Job>? Jobs { get; set; } = new List<Job>();
        public List<Education>? Educations { get; set; } = new List<Education>();
        public List<Document>? Documents { get; set; } = new List<Document>();
        public DocForeignPassport? ForeignPassport { get; set; } = new DocForeignPassport();
        public DocInternationalPassport? InternationalPassport { get; set;} = new DocInternationalPassport();
        public DocRussianPassport? RussianPassport { get;set; } = new DocRussianPassport();
        public Address? PersonAddress { get; set; } = new Address();

        public void AddInfo(Info info)
        {
            Information = info;
        }
        public void AddJob(Job job)
        {
            Jobs.Add(job);
        }

        public void AddEducation(Education education)
        {
            Educations.Add(education);
        }

        public void AddDocument(Document document)
        {
            Documents.Add(document);
        }

        public void AddForeignPassport(DocForeignPassport docForeignPassport)
        {
            ForeignPassport = docForeignPassport;
        }

        public void AddRussianPassport(DocRussianPassport docRussianPassport)
        {
            RussianPassport = docRussianPassport;
        }

        public void AddInternationalPassport(DocInternationalPassport docInternational)
        {
            InternationalPassport = docInternational;
        }

        public void AddAddress(Address address)
        {
            PersonAddress = address;
        }

    }
}
