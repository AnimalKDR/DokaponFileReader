using DokaponFileReader.DataFiles;
using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class DataItem 
    {
        public ItemData item { get; set; }

        public DataItem(EffectItemType itemType = EffectItemType.None, byte index = 0, string name = "None")
        {
            item = new ItemData(itemType, index, name);
        }

        public DataItem(ItemData item)
        {
            this.item = item;
        }
    }
}
