using System.Diagnostics;

namespace ToDoManager
{
    public class TagsList
    {
        public List<Tag> Tags;
        public TagsList() 
        {
            Tags = new List<Tag>();
        }
        public TagsList(List<Tag> tags)
        {
            Tags = tags;
        }
        public TagsList(Tag tag)
        {
            Tags = new List<Tag>();
            Tags.Add(tag);
        }
        public void New(Tag tag)
        {
            Tags.Add(tag);
        }
        public void Remove(Tag tag)
        {
            Tags.Remove(tag);
        }
        public void Update(Tag tag, int tag_id)
        {
            Tags[tag_id] = tag;
        }
    }
}
