using Overdone.Combo;
using Terraria;
using Terraria.ModLoader;

namespace Overdone.Base {
    public class DodoModProjectile : ModProjectile {
        protected bool UseCombo = false;
        protected int ComboBuildPerHit = 1;

        public override void OnHitNPC( NPC target, int damage, float knockback, bool crit ) {
            if ( UseCombo ) {
                ComboManager.Add( ComboBuildPerHit );
            }
            base.OnHitNPC( target, damage, knockback, crit );
        }
    }
}