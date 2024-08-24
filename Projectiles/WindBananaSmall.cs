using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class WindBananaSmall : OverdoneModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Wind Banana";
            Projectile.width = 28;
            Projectile.height = 14;
            Projectile.aiStyle = 0;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 75;
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
            if (Projectile.velocity != Vector2.Zero) {
                Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            }
            int dustId = Dust.NewDust( new Vector2( Projectile.position.X, Projectile.position.Y + 2f ), Projectile.width + 4, Projectile.height + 4, DustID.Torch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default, 0.75f ); //Spawns dust
            Main.dust[dustId].noGravity = true; 
        }        
    
    }
}

