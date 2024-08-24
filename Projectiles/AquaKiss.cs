using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class AquaKiss : OverdoneModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Aquatic Kiss";
            Projectile.width = 24;
            Projectile.height = 30;
            Projectile.aiStyle = 1;
            Projectile.penetrate = 4;
            Projectile.timeLeft = 100;

            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            UseCombo = false;
        }

        public override void AI() {
            Player owner = Main.player[Projectile.owner]; 
            Projectile.light = 0.5f;

            if ( Projectile.wet && Projectile.owner == Main.myPlayer ) {
                Projectile.damage *= 2;
            }
        
    }
        public override void OnHitNPC( NPC n, int damage, float knockback, bool crit ) {
            Player owner = Main.player[Projectile.owner];
                    n.AddBuff( 103, 180 ); 
            }
        
    public override void Kill( int timeLeft ) {
        Projectile.NewProjectile(
            Projectile.GetSource_FromThis(),
                Projectile.position.X,
                Projectile.position.Y,
                Projectile.oldVelocity.X * 0.75f, Projectile.oldVelocity.Y * 0.5f, 
                ProjectileID.WaterStream,
                (int) (Projectile.damage * 1.5f),
                Projectile.knockBack,
                Main.myPlayer
            );
        }
    }
}

