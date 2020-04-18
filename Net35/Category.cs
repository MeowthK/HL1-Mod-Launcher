using System.Collections.Generic;
using System.Linq;

namespace Net35
{
    class Category
    {
        public string Name { get; set; }
        public Item[] Items { get; set; }

        public Category()
        {
            this.Name = string.Empty;
        }

        public Category(string Name)
        {
            this.Name = Name;
        }

        public Category(string Name, Item[] Items)
        {
            this.Name = Name;
            this.Items = Items;
        }

        public void AddItem(Item item)
        {
            if (Items == null)
            {
                Item[] obj = { item };
                Items = obj;
            }
            else
            {
                List<Item> items = Items.ToList();
                items.Add(item);

                Items = items.ToArray();
            }
        }

        public override string ToString()
        {
            string r = this.Name;

            if (Items != null)
            {
                r += "\n";

                foreach (Item item in Items)
                    r += "<" + item.Name + ", " + item.Description + ">\n";
            }

            return r;
        }
    }
}
