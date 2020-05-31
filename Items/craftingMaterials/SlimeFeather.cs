using Terraria;
using Terraria.ModLoader;
namespace RaidersMod.Items.craftingMaterials
{
    public class SlimeFeather : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slime Feather");
        }
        public override void SetDefaults()
        {
            item.Size = new Microsoft.Xna.Framework.Vector2(20);
            item.material = true;
            item.maxStack = 99;
        }
        
    }
}