namespace Net35
{
    class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Item()
        {
            this.Name = string.Empty;
            this.Description = string.Empty;
        }

        public Item(string Name)
        {
            this.Name = Name;
            Description = string.Empty;
        }

        public Item(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
        }
    }
}
