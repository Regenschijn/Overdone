using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class ReedsOfEnkiProjectile : DodoModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Abzu Reed";
            Projectile.width = 18;
            Projectile.height = 30;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 75;
            Projectile.knockBack = 3;

            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            UseCombo = true;
        }

        public override void AI() {
            Player owner = Main.player[Projectile.owner]; 
            Projectile.light = 0f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            int dustId = Dust.NewDust( new Vector2( Projectile.position.X, Projectile.position.Y + 2f ), Projectile.width + 4, Projectile.height + 4, DustID.Water_Jungle, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default, 1.25f ); //Spawns dust
            Main.dust[dustId].noGravity = true; 
        }
        public override void Kill( int timeLeft ) {
            Projectile proj = Projectile;
            for ( var i = 0; i < 10; i++ ) {
                Dust.NewDust( proj.position, proj.width, proj.height + Main.rand.Next( 0, 8 ), DustID.Water_Jungle,
                    proj.velocity.X * 0.2f, proj.velocity.Y * 0.2f, 125, Color.Aqua );
            }
        }
    }
}

