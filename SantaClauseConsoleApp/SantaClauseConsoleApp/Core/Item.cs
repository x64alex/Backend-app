namespace SantaClauseConsoleApp
{
    class Item
    {
        public Item(int itemId,string itemType,string itemName)
        {
            int id = itemId;
            Name = itemName;
            Type = itemType;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
