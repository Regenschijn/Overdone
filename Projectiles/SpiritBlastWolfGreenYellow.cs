using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class SpiritBlastWolfGreenYellow : OverdoneModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Spirit Wolf";
            Projectile.width = 30;
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

        public override void AI() {
            Player owner = Main.player[Projectile.owner]; 
            Projectile.light = 0.1f;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            int dustId = Dust.NewDust( new Vector2( Projectile.position.X, Projectile.position.Y + 2f ), Projectile.width + 4, Projectile.height + 4, DustID.Blood, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default, 1.25f ); //Spawns dust
            Main.dust[dustId].noGravity = true; 
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            base.OnHitNPC( target, damage, knockback, crit );
            Player owner = Main.player[Projectile.owner];
            target.AddBuff( 20, 180 );
        }

    }
}

