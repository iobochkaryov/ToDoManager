namespace ToDoManager
{
    public class Tag
    {
        public string Name;
        public string Color;
        public Tag(string name, string color)
        {
            Name = name;
            Color = color;
        }
        public Tag(string name)
        {
            Name = name;
            Color = "#fff";
        }
    }
}
