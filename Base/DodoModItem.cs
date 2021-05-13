using Overdone.Combo;
using Terraria;
using Terraria.ModLoader;

namespace Overdone.Base {
    public abstract class DodoModItem : ModItem {
        protected bool UseCombo = false;
        protected int ComboBuildPerHit = 1;

        public override void OnHitNPC( Player player, NPC target, int damage, float knockBack, bool crit ) {
            if ( UseCombo ) {
                ComboManager.Add( ComboBuildPerHit );
            }
            base.OnHitNPC( player, target, damage, knockBack, crit );
        }
    }
}