using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class SpearOfOlyndicusThrownProjectile : DodoModProjectile {
        public override void SetDefaults() {
            var proj = projectile;
            proj.width = 14;
            proj.height = 14;
            proj.aiStyle = 1;
            proj.friendly = true;
            proj.thrown = true;
            proj.penetrate = 1;
            proj.timeLeft = 300;
            aiType = 1;
        }

        public override void Kill( int timeLeft ) {
            Projectile proj = projectile;
            for ( var i = 0; i < 10; i++ ) {
                Dust.NewDust( proj.position, proj.width, proj.height + Main.rand.Next( 0, 8 ), DustID.Silver,
                    proj.velocity.X * 0.2f, proj.velocity.Y * 0.2f, 125, Color.White );
            }
        }

        public override bool OnTileCollide( Vector2 oldVelocity ) {
            projectile.Kill();
            Main.PlaySound( SoundID.Item, (int) projectile.position.X, (int) projectile.position.Y, 10, 1f, 0 );
            return false;
        }
    }
}