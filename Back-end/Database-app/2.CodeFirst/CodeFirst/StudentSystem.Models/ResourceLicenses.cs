namespace StudentSystem.Models
{
    public class ResourceLicenses
    {
        public int Id { get; set; }

        public string LicenseName { get; set; }

        public int ResourceId { get; set; }

        public Resources Resource { get; set; }
    }
}
