using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;

namespace Overdone.Projectiles //where it's stored, replace Mod with the name of your mod. This file is stored in the folder \Mod Sources\(mod name, folder can't have spaces)\Projectiles.
{
    public class SpearOfOlyndicusProjectile : ModProjectile //the class of the projectile
    {
        public override void SetDefaults()
        {
            projectile.width = 2; //sprite is 2 pixels wide
            projectile.height = 20; //sprite is 20 pixels tall
            projectile.aiStyle = 0; //projectile moves in a straight line
            projectile.friendly  = true; //player projectile
            projectile.ranged = true; //ranged projectile
            projectile.timeLeft = 600; //lasts for 600 frames/ticks. Terraria runs at 60FPS, so it lasts 10 seconds.
        }

        public override void AI()
        {
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f);   //spawns dust behind it, this is a spectral light blue dust
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height); //makes dust based on tile
            Main.PlaySound(SoundID.Item10, projectile.position); //plays impact sound
        }


    }
}