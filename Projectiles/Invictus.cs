using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class Invictus : DodoModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Invictus";
            Projectile.width = 13;
            Projectile.height = 13;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 30;

            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            UseCombo = true;
        }

        public override void AI() {
            Player owner = Main.player[Projectile.owner]; 
            Projectile.light = 0.9f;
            Projectile.rotation += (float) Projectile.direction * 0.5f;
            int dustId = Dust.NewDust( new Vector2( Projectile.position.X, Projectile.position.Y + 2f ), Projectile.width + 4, Projectile.height + 4, DustID.Torch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default, 1.75f ); //Spawns dust
            Main.dust[dustId].noGravity = true;

            if ( Projectile.wet && Projectile.owner == Main.myPlayer ) {
                Projectile.Kill();
            }
        }
        public override void OnHitNPC( NPC n, int damage, float knockback, bool crit ) {
            Player owner = Main.player[Projectile.owner];
            var rand = Main.rand.Next( 2 );
            n.AddBuff( 24, 180 );
            base.OnHitNPC(n, damage, knockback, crit);
        }
    }
}

