using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace RaidersMod.Items.craftingMaterials
{
    public class Planitium_Ore : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plantium");
            Tooltip.SetDefault("used to craft a material from the jungle"); 
        }
        public override void SetDefaults()
        {
            item.Size = new Microsoft.Xna.Framework.Vector2(20);
            item.material = true;
            item.maxStack = 999;
            item.maxStack = Item.sellPrice(0,0,0,35);
        }
    }
}
