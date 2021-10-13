using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class ApolloBlast : DodoModProjectile {
        public override void SetDefaults() {
            var proj = projectile;
            proj.width = 8;
            proj.height = 10;
            proj.aiStyle = 8;
            proj.friendly = true;
            proj.magic = true;
            proj.penetrate = 1;
            proj.timeLeft = 300;
            aiType = 1;
            UseCombo = false;
        }

        public override void AI() {
            Player owner = Main.player[projectile.owner]; 
            projectile.light = 0.9f;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            int dustId = Dust.NewDust( new Vector2( projectile.position.X, projectile.position.Y + 2f ), projectile.width + 4, projectile.height + 4, DustID.BubbleBurst_White, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default, 1.75f ); //Spawns dust
            Main.dust[dustId].noGravity = true; 
        }
        
        public override void Kill( int timeLeft ) {
            Projectile proj = projectile;
            for ( var i = 0; i < 10; i++ ) {
                Dust.NewDust( proj.position, proj.width, proj.height + Main.rand.Next( 0, 8 ), DustID.FireworkFountain_Red,
                    proj.velocity.X * 0.2f, proj.velocity.Y * 0.2f, 125, Color.Gold );
            }
        }

        public override bool OnTileCollide( Vector2 oldVelocity ) {
            projectile.Kill();
            Main.PlaySound( SoundID.Item, (int) projectile.position.X, (int) projectile.position.Y, 10, 1f, 0 );
            return false;
        }
    }
}