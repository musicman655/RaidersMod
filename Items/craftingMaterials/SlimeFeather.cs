using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
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
            item.damage = 53;
            item.consumable = true;
            item.rare = ItemRarityID.LightRed;
            item.shoot = ProjectileType<Items.projectiles.SlimeFeather_Projectile>(); 
            item.value = 100;
            item.shootSpeed = 10f;
            item.ammo = AmmoID.None;
            item.knockback = 1f;
        }
        
    }
}
