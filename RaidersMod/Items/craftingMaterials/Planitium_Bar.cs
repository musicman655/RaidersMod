using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
namespace RaidersMod.Items.craftingMaterials
{
    public class Planitium_Bar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Planitium Bar");
            Tooltip.SetDefault("Infused with the power of the Jungle");
        }
        public override void SetDefaults()
        {
            item.Size = new Microsoft.Xna.Framework.Vector2(20);
            item.maxStack = 999;
            item.useStyle = 1;
            item.autoReuse = true;
            item.consumable = true;
            item.createTile = TileType<Tiles.Planitium_Bar_Tile>();
            item.value = Item.buyPrice(0,0,5,0);
            item.useTurn = true;
            item.placeStyle = 0;
            item.useAnimation = 8;
            item.useTime = 8;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Stinger,2);
            recipe.AddIngredient(ItemID.JungleSpores,1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}