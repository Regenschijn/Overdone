using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class ArrowApollo : DodoModProjectile {
        public override void SetDefaults() {
            Projectile.width = 4;
            Projectile.height = 20;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 2;

            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.melee = false/* tModPorter Suggestion: Remove. See Item.DamageType */;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
        }

        public override void AI() {
            Player owner = Main.player[Projectile.owner]; 
            Projectile.light = 0.2f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            int dustId = Dust.NewDust( new Vector2( Projectile.position.X, Projectile.position.Y + 2f ), Projectile.width + 4, Projectile.height + 4, DustID.BubbleBurst_White, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default, 1.75f ); //Spawns dust
            Main.dust[dustId].noGravity = true; 
        }

        public override void OnHitNPC( NPC target, int damage, float knockback, bool crit ) {
            base.OnHitNPC(target, damage, knockback, crit);
            Player owner = Main.player[Projectile.owner];
            target.AddBuff( 20, 180 );
        }
    }
}