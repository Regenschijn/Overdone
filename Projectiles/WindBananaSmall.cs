using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class WindBananaSmall : DodoModProjectile {
        public override void SetDefaults() {
            projectile.Name = "Wind Banana";
            projectile.width = 28;
            projectile.height = 14;
            projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.timeLeft = 75;
            projectile.knockBack = 3;
            

            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            UseCombo = true;
        }

        public override void AI() {
            Player owner = Main.player[projectile.owner]; 
            projectile.light = 0.1f;
            if (projectile.velocity != Vector2.Zero) {
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            }
            int dustId = Dust.NewDust( new Vector2( projectile.position.X, projectile.position.Y + 2f ), projectile.width + 4, projectile.height + 4, DustID.Fire, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default, 0.75f ); //Spawns dust
            Main.dust[dustId].noGravity = true; 
        }        
    
    }
}

