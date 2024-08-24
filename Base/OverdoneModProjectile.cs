using Overdone.Combo;
using Terraria;
using Terraria.ModLoader;

namespace Overdone.Base {
    public abstract class OverdoneModProjectile : ModProjectile {
        protected bool UseCombo = true;
        protected int ComboBuildPerHit = 1;
        protected int HitsBeforeComboHit = 1;
        private long _hitCount;

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            if ( UseCombo ) {
                _hitCount++;
                OnAddComboHit( _hitCount );
            }
            
            base.OnHitNPC( target, damage, knockBack, crit );
        }

        protected virtual void OnAddComboHit( long currentHitCount ) {
            if ( currentHitCount % HitsBeforeComboHit == 0 ) {
                ComboManager.Add( ComboBuildPerHit );
            }
        }        
    }
}