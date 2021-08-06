using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class ImhulluSpin : DodoModProjectile {

        public override void SetDefaults() {
            projectile.Size = new Vector2( 80 );
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.damage = 10;
            projectile.tileCollide = false;
        }        

        public override void AI() {            
            var player = Main.player[projectile.owner];
            if ( !player.channel )
                projectile.Kill();

            projectile.direction = player.direction;
            projectile.position = player.position + new Vector2( 50f, -20f );
            projectile.rotation += 1f;            
        }
    }
}

