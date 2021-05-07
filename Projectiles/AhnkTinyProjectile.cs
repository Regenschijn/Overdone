using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;

namespace Overdone.Projectiles {
    public class AhnkTinyProjectile : ModProjectile {
        public override void SetDefaults() {
            projectile.Name = "Tiny Ahnk";
            projectile.width = 16;
            projectile.height = 16;
            projectile.timeLeft = 90;
            projectile.penetrate = 3;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.ranged = true;                    
        }

        public override void PostAI() {            
            Lighting.AddLight( projectile.position + projectile.velocity * 5, new Vector3( 1f, .5f, .5f ) );
        }

        public override void Kill( int timeLeft ) {
            Projectile.NewProjectile(
                projectile.position.X,
                projectile.position.Y,
                0, 0,
                ProjectileID.InfernoFriendlyBlast,
                (int) (projectile.damage * 1.5f),
                projectile.knockBack,
                Main.myPlayer
            );
        }

    }
}
