namespace _02.ReformYourOwnCode.StudeSystemReformatted.Models
{
    public class ResourceLicense
    {
        public int Id { get; set; }

        public string LicenseName { get; set; }

        public int ResourceId { get; set; }

        public Resource Resource { get; set; }
    }
}
