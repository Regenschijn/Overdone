using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Overdone;
using Overdone.Base;

namespace Overdone.Projectiles {
    public class OrbCharm : DodoModProjectile {
        public override void SetDefaults() {
            Projectile.Name = "Charm Orb";
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 240;
            Projectile.knockBack = 2;

            Projectile.hide = false;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = true;
            Projectile.friendly = true;
            Projectile.ignoreWater = false;

            Projectile.light = 0.1f;

            UseCombo = false;
        }

        private int _delayCounter = 0;

        public override void AI() {            
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            int dustId = Dust.NewDust( new Vector2( Projectile.position.X, Projectile.position.Y + 2f ), Projectile.width + 4, Projectile.height + 4, DustID.PurpleTorch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default, 1.25f ); //Spawns dust
            Main.dust[dustId].noGravity = true;

            float maxDetectRadius = 400f; // The maximum radius at which a projectile can detect a target
            float projSpeed = 12f; // The speed at which the projectile moves towards the target

            _delayCounter++;

            if ( _delayCounter < 30 ) {
                return;
            }

            // Trying to find NPC closest to the projectile
            NPC closestNPC = FindClosestNPC( maxDetectRadius );
            if ( closestNPC == null )
                return;

            // If found, change the velocity of the projectile and turn it in the direction of the target
            // Use the SafeNormalize extension method to avoid NaNs returned by Vector2.Normalize when the vector is zero
            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize( Vector2.Zero ) * projSpeed;
            Projectile.rotation = Projectile.velocity.ToRotation();
        }

        // Finding the closest NPC to attack within maxDetectDistance range
        // If not found then returns null
        public NPC FindClosestNPC( float maxDetectDistance ) {
            NPC closestNPC = null;

            // Using squared values in distance checks will let us skip square root calculations, drastically improving this method's speed.
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            // Loop through all NPCs(max always 200)
            for ( int k = 0; k < Main.maxNPCs; k++ ) {
                NPC target = Main.npc[k];
                // Check if NPC able to be targeted. It means that NPC is
                // 1. active (alive)
                // 2. chaseable (e.g. not a cultist archer)
                // 3. max life bigger than 5 (e.g. not a critter)
                // 4. can take damage (e.g. moonlord core after all it's parts are downed)
                // 5. hostile (!friendly)
                // 6. not immortal (e.g. not a target dummy)
                if ( target.CanBeChasedBy() ) {
                    // The DistanceSquared function returns a squared distance between 2 points, skipping relatively expensive square root calculations
                    float sqrDistanceToTarget = Vector2.DistanceSquared( target.Center, Projectile.Center );

                    // Check if it is within the radius
                    if ( sqrDistanceToTarget < sqrMaxDetectDistance ) {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }

            return closestNPC;
        }




    }
}

