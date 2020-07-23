using Terraria.ModLoader;
using Terraria;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace RaidersMod
{
    public class RaidersModPlayer : ModPlayer
    {
        public static bool HelicopterMount = false;
        public override void ResetEffects()
        {
            HelicopterMount = false;
        }
        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            if(HelicopterMount)
            {
                layers.RemoveAll(match => !match.Name.Equals("MountBack") && !match.Name.Equals("MountFront"));
            }
        }
    }
}