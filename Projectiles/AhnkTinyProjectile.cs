using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class AhnkTinyProjectile : DodoModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Tiny Ahnk";
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.timeLeft = 90;
            Projectile.penetrate = 3;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Ranged;                    
        }

        public override void PostAI() {            
            Lighting.AddLight( Projectile.position + Projectile.velocity * 5, new Vector3( 1f, .5f, .5f ) );
        }

        public override void Kill( int timeLeft ) {
            Projectile.NewProjectile(
                Projectile.position.X,
                Projectile.position.Y,
                0, 0,
                ProjectileID.InfernoFriendlyBlast,
                (int) (Projectile.damage * 1.5f),
                Projectile.knockBack,
                Main.myPlayer
            );
        }

    }
}
