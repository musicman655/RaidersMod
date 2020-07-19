using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader;
using RaidersMod.Items.craftingMaterials;
namespace RaidersMod.Items.armor
{
    [AutoloadEquip(EquipType.Body)]
    public class PlanitiumChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Planitium Chestplate");
        }
        public override void SetDefaults()
        {
            item.defense = 4;
            item.rare = 2;
            item.Size = new Microsoft.Xna.Framework.Vector2(24);
            item.value = Item.buyPrice(0,0,20,0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Planitium_Bar>(),20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
