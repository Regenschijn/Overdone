using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class SpiritBlastLion : OverdoneModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Spirit Lion";
            Projectile.width = 38;
            Projectile.height = 84;
            Projectile.aiStyle = 0;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 90;
            Projectile.knockBack = 3;

            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            UseCombo = true;
        }

        public override bool PreDraw( ref Color lightColor ) {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if ( Projectile.spriteDirection == -1 ) { 
                spriteEffects = SpriteEffects.FlipHorizontally;
                Texture2D texture = (Texture2D)ModContent.Request<Texture2D>( Texture );
            }
            return true;
        }

        public override void AI() {
            Player owner = Main.player[Projectile.owner]; 
            Projectile.light = 0.1f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            int dustId = Dust.NewDust( new Vector2( Projectile.position.X, Projectile.position.Y + 2f ), Projectile.width + 4, Projectile.height + 4, DustID.Enchanted_Gold, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default, 1.25f ); //Spawns dust
            Main.dust[dustId].noGravity = true; 
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            base.OnHitNPC( target, damage, knockback, crit );
            Player owner = Main.player[Projectile.owner];
            target.AddBuff( 24, 660 );
        }

    }
}

