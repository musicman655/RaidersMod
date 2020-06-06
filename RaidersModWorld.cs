using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace RaidersMod
{
    public class RaidersModWorld : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if(ShiniesIndex != -1)
            {
                tasks.Insert(ShiniesIndex + 8,new PassLegacy("Generatin Planitium",GenPlanitium));
            }   
        }
        private void GenPlanitium(GenerationProgress progress)
        {
            progress.Message = "Generating Planitium";
            for(int k = 0;k < (int)(Main.maxTilesX * Main.maxTilesY) * 7E-5;k++)
            {
                int x = WorldGen.genRand.Next(0,Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.rockLayerLow,Main.maxTilesY - 200);
                Tile tile = Framing.GetTileSafely(x,y);
                if(tile.type == TileID.Mud && tile.active()){
                WorldGen.TileRunner(x,y,WorldGen.genRand.Next(3,6),WorldGen.genRand.Next(2,6),(ushort)ModContent.TileType<Tiles.Planitium_Ore_Tile>());
                }
            }
        }
      
    }
}