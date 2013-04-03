namespace FellowshipOneApi.Entities
{
    public class AttributeGroup
    {
        public long? Id { get; set; }
        public string Uri { get; set; }

        public string Name { get; set; }
        public GroupAttribute GroupAttribute { get; set; }
    }
}
