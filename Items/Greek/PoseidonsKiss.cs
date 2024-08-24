using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Overdone.Base;
using Overdone.Projectiles;
using Overdone.Combo;

namespace Overdone.Items.Greek {
    public class PoseidonsKiss : DoubleUseOverdoneModItem {
        private int _counter;

        public override void SetStaticDefaults() {
            // DisplayName.SetDefault( "Poseidons Kiss" );
            // Tooltip.SetDefault( "Poseidons Trident \n LMB: Swing- why stab?. Every 5th hit is a crit with large knockback. \n RMB: Use 25 combo and mana to shoot Poseidons Kiss \n Passive: For every 25 combo, gain 1% crit chance." );
        }

        public override void SetDefaults() {
            Item.damage = 24;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 15;
            Item.value = 10000;
            Item.crit = 7;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shootSpeed = 8f;
            base.SetDefaults();
        }

        protected override void SetLeftClickMode() {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.noMelee = false;
            Item.mana = 0;
            Item.crit = (int) (7 + (ComboManager.Combo / 25f));
        }

        protected override void SetRightClickMode() {
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.noMelee = true;
            Item.mana = 25;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            _counter++;
            if ( _counter < 5 )
                return false;

            for ( var i = 0; i < 3; i++ ) {
                Item.knockBack = 15;
                Item.crit = 100;
            }
            _counter = 0;
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            if ( ComboManager.UseCombo( 25 ) ) {
                Projectile.NewProjectile( player.GetSource_FromAI(), position.X, position.Y, velocity.X * 1.85f, velocity.Y * 1.85f, ProjectileID.Typhoon, (int) (damage / 2f), 10f, player.whoAmI, 0f, 0f );
                SoundEngine.PlaySound( SoundID.Item45, player.position );
            }
            return false;
        }
        public override void AddRecipes() {
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 10 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }


        protected override Mythology Mythology => Mythology.Greek;
        protected override GodDomain GodDomain => GodDomain.Water;
    }
}