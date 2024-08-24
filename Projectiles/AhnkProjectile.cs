using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class AhnkProjectile : OverdoneModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Ahnk";
            Projectile.width = 25;
            Projectile.height = 25;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 1;
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
            Player owner = Main.player[Projectile.owner]; //Makes a player variable of owner set as the player using the projectile
            Projectile.light = 0.5f;
            Projectile.rotation += (float) Projectile.direction * 0.5f;
            int dustId = Dust.NewDust( new Vector2( Projectile.position.X, Projectile.position.Y + 2f ), Projectile.width + 4, Projectile.height + 4, 36, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default, 0.75f ); //Spawns dust
            Main.dust[dustId].noGravity = true; //Makes dust not fall
        }
        public override void OnHitNPC( NPC n, int damage, float knockback, bool crit ) {
            Player owner = Main.player[Projectile.owner];
            var rand = Main.rand.Next( 2 );
            switch ( rand ) {
                case 0:
                    n.AddBuff( 24, 180 ); //On Fire! debuff for 3 seconds
                    break;
                case 1:
                    owner.statLife += 5; //Gives 5 Health
                    owner.HealEffect( 5, true ); //Shows you have healed by 5 health
                    break;
            }
            base.OnHitNPC(n, damage, knockback, crit);
        }
        //After the projectile is dead
        public override void Kill( int timeLeft ) {            
            Projectile.NewProjectile(
                Projectile.GetSource_FromThis(),
                Projectile.position.X,
                Projectile.position.Y,
                Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f, 
                ModContent.ProjectileType<AhnkTinyProjectile>(),
                (int) (Projectile.damage * 1.5f),
                Projectile.knockBack,
                Main.myPlayer
            );
        }
    }
}

