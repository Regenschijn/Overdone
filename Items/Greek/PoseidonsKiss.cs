using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Overdone.Base;
using Overdone.Projectiles;
using Overdone.Combo;

namespace Overdone.Items.Greek {
    public class PoseidonsKiss : DoubleUseDodoModItem {
        private int _counter;

        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Poseidons Kiss" );
            Tooltip.SetDefault( "Poseidons Trident \n LMB: Swing- why stab?. Every 5th hit is a crit with large knockback. \n RMB: Use 10 favor to lob a medusa head. \n Passive: For every 10 combo, gain 1% crit chance." );
        }

        public override void SetDefaults() {
            item.damage = 24;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 15;
            item.value = 10000;
            item.crit = 7;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 8f;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = false;
            item.mana = 0;
            item.crit = (int) (7 + (ComboManager.Combo / 5f));
        }

        protected override void SetRightClickMode() {
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.noMelee = true;
            item.mana = 8;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            _counter++;
            if ( _counter < 5 )
                return false;

            for ( var i = 0; i < 3; i++ ) {
                item.knockBack = 15;
                item.crit = 100;
            }
            _counter = 0;
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            if ( ComboManager.UseCombo( 25 ) ) {
                Projectile.NewProjectile( position.X, position.Y, speedX * 1.85f, speedY * 1.85f, ProjectileID.Typhoon, (int) (damage / 2f), 10f, player.whoAmI, 0f, 0f );
                Main.PlaySound( SoundID.Item45, player.position );
            }
            return false;
        }
        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 10 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }


        protected override Mythology Mythology => Mythology.Greek;
        protected override GodDomain GodDomain => GodDomain.Water;
    }
}