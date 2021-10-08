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
            projectile.Name = "Invictus";
            projectile.width = 13;
            projectile.height = 13;
            projectile.aiStyle = 0;
            projectile.penetrate = 1;
            projectile.timeLeft = 30;

            projectile.hide = false;
            projectile.ownerHitCheck = true;
            projectile.ranged = true;
            projectile.tileCollide = true;
            projectile.friendly = true;
            projectile.ignoreWater = false;
            UseCombo = true;
        }

        public override void AI() {
            Player owner = Main.player[projectile.owner]; 
            projectile.light = 0.9f;
            projectile.rotation += (float) projectile.direction * 0.5f;
            int dustId = Dust.NewDust( new Vector2( projectile.position.X, projectile.position.Y + 2f ), projectile.width + 4, projectile.height + 4, DustID.Fire, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default, 1.75f ); //Spawns dust
            Main.dust[dustId].noGravity = true; 
        }
        public override void OnHitNPC( NPC n, int damage, float knockback, bool crit ) {
            Player owner = Main.player[projectile.owner];
            var rand = Main.rand.Next( 2 );
            n.AddBuff( 24, 180 );
            base.OnHitNPC(n, damage, knockback, crit);
        }
    }
}

