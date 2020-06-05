using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria;
using RaidersMod.Items.craftingMaterials;
namespace RaidersMod.Items.armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class PlanitiumLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Planitium Leggings");
        }
        public override void SetDefaults()
        {
            item.Size = new Microsoft.Xna.Framework.Vector2(25);
            item.defense = 3;
            item.rare = 1;
            item.value = Item.buyPrice(0,0,10,0);
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