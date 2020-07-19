using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using RaidersMod.Items.craftingMaterials;
namespace RaidersMod.Items.armor
{
    [AutoloadEquip(EquipType.Head)]
    public class PlanitiumHelm : ModItem
    {
          public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Planitium Helmet");
        }
        public override void SetDefaults()
        {
            item.defense = 2;
            item.rare = 2;
            item.Size = new Microsoft.Xna.Framework.Vector2(24);
            item.value = Item.buyPrice(0,0,15,0);
        }
        
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<PlanitiumChest>() && legs.type == ItemType<PlanitiumLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.buffImmune[BuffID.Poisoned] = true;
            player.statDefense += 3;
            player.setBonus = "Immune to Poisened\n        +3 Defense";
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Planitium_Bar>(),16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
