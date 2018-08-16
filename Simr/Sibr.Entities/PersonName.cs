namespace Sibr.Entities
{
    public class PersonName : Entity
    {
        public PersonName()
        {
            this.GivenName = string.Empty;
            this.FullMiddleName = string.Empty;
            this.FamilyName = string.Empty;
        }

        public string FamilyName { get; set; }

        public string FullMiddleName { get; set; }

        public string GivenName { get; set; }
    }
}