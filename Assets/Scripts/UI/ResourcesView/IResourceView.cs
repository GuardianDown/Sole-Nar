public interface IResourceView<ResourceType>
{
    string ID { get; }

    void SetResource(ResourceType value);
}
