namespace ToDoManager.Classes
{
    public class Case
    {
        string name;
        string desc;
        int status;
        public string[] statusList = new string[] { "Primary", "Secondary", "Done" };

        public Case()
        {
            this.name = null;
            this.desc = null;
            this.status = 0;
        }
        public Case(string name, string desc, int status)
        {
            this.name = name;
            this.desc = desc;
            this.status = status;
        }

        public Case(string name, string desc, string Status)
        {
            this.name = name;
            this.desc = desc;
            for (int i = 0; i < statusList.Length; i++) 
                if (Status == statusList[i]) status = i;
            
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
    }
}
