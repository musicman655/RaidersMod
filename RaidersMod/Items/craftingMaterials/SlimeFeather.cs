using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
namespace RaidersMod.Items.craftingMaterials
{
    public class SlimeFeather : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimy Feather");
        }
        public override void SetDefaults()
        {
            item.Size = new Microsoft.Xna.Framework.Vector2(20);
            item.material = true;
            item.maxStack = 99;
            item.damage = 25;
            item.consumable = true;
            item.rare = ItemRarityID.LightRed;
            item.shoot = ProjectileType<Items.projectiles.SlimeFeather_Projectile>();
            item.value = 100;
            item.shootSpeed = 10f;
            item.ammo = AmmoID.Gel;
            item.knockBack = 1f;
        }
        
    }
}
