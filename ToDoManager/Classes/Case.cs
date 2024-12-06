namespace ToDoManager.Classes
{
    public class Case
    {
        string name;
        string desc;
        int status;
        public string[] statusList = new string[] { "Primary", "Secondary", "Done" };
        public TagsList tags;

        public Case()
        {
            this.name = null;
            this.desc = null;
            this.status = 0;
            tags = new TagsList();
        }
        public Case(string name, string desc, int status)
        {
            this.name = name;
            this.desc = desc;
            this.status = status;
            tags = new TagsList();
        }

        public Case(string name, string desc, string Status)
        {
            this.name = name;
            this.desc = desc;
            for (int i = 0; i < statusList.Length; i++) 
                if (Status == statusList[i]) status = i;
            tags = new TagsList();
        }
        public Case(string name, string desc, int status, TagsList Tags)
        {
            this.name = name;
            this.desc = desc;
            this.status = status;
            tags = Tags;
        }

        public Case(string name, string desc, string Status, TagsList Tags)
        {
            this.name = name;
            this.desc = desc;
            for (int i = 0; i < statusList.Length; i++)
                if (Status == statusList[i]) status = i;
            tags = Tags;
        }
        public string getName()
        {
            return name;
        }
        public string getDesc()
        {
            return desc;
        }
        public int getStatus()
        {
            return status;
        }
        public string getStatusValue()
        {
            return statusList[status];
        }
        public Tag getTags() // *****************Must be fixed, for now only 1 tag ****************************
        {
            return tags.Tags[0];
        }
        public void AddTag(Tag tag)
        {
            tags.New(tag);
        }
        public void removeTag(Tag tag)
        {
            tags.Remove(tag);
        }
        public void UpdateTag(Tag tag, int tagID)
        {
            tags.Update(tag, tagID);
        }
    }
}
