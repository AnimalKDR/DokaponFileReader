using DokaponFileReader.DataFiles;
using System.Collections.ObjectModel;

namespace DokaponFileReader
{
    public class DataEffectItem 
    {
        public EffectItemData item { get; set; }

        public DataEffectItem(EffectItemType itemType = EffectItemType.None, byte index = 0, string name = "None")
        {
            item = new EffectItemData(itemType, index, name);
        }

        public DataEffectItem(EffectItemData item)
        {
            this.item = item;
        }
    }
}
