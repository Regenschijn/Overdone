using Overdone.Combo;
using Terraria;
using Terraria.ModLoader;

namespace Overdone.Base {
    public abstract class OverdoneModItem : ModItem {
        /// <summary>
        /// Enable the use of combos.
        /// </summary>
        protected bool UseCombo = true;
        /// <summary>
        /// How many combo points you get per combo hit. (Recommended to increase the value with slow weapons)
        /// </summary>
        protected int ComboBuildPerHit = 1;
        /// <summary>
        /// The amount of hits needed before triggering a combo hit. (Recommended increase this value with fast weapons)
        /// </summary>
        protected int HitsBeforeComboHit = 1;
        private long _hitCount;
        
        protected abstract Mythology Mythology { get; }
        protected abstract GodDomain GodDomain { get; }

        public override void OnHitNPC( Player player, NPC target, int damage, float knockBack, bool crit ) {
            if ( UseCombo ) {
                _hitCount++;
                OnAddComboHit( _hitCount );
            }
            
            base.OnHitNPC( player, target, damage, knockBack, crit );
        }

        /// <summary>
        /// This method handles modifying stuff with combos
        /// </summary>
        /// <param name="currentHitCount">The current amount of hits with this weapon</param>
        protected virtual void OnAddComboHit( long currentHitCount ) {
            if ( currentHitCount % HitsBeforeComboHit == 0 ) {
                ComboManager.Add( ComboBuildPerHit );
            }
        }
    }
}