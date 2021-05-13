using Overdone.Combo;
using Terraria;
using Terraria.ModLoader;

namespace Overdone.Base {
    public abstract class DodoModItem : ModItem {
        protected bool UseCombo = false;
        protected int ComboBuildPerHit = 1;
        protected int HitsBeforeComboHit = 1;
        private long _hitCount;

        public override void OnHitNPC( Player player, NPC target, int damage, float knockBack, bool crit ) {
            if ( UseCombo ) {
                _hitCount++;
                OnAddComboHit( _hitCount );
            }
            
            base.OnHitNPC( player, target, damage, knockBack, crit );
        }

        protected virtual void OnAddComboHit( long currentHitCount ) {
            if ( currentHitCount % HitsBeforeComboHit == 0 ) {
                ComboManager.Add( ComboBuildPerHit );
            }
        }
    }
}