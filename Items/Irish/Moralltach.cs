using Microsoft.Xna.Framework;
using Overdone.Base;
using Overdone.Combo;
using Overdone.Projectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Irish {
    public class Moralltach : DoubleUseOverdoneModItem {

        public override void SetStaticDefaults() {
            Tooltip.SetDefault( "The sword of Aengus (Macan Óc). \n LMB: Attack in various ways. \n RMB: Consume 25 combo to get an attack damage buff. \n At 100 combo, your attacks gain extra armor penetration." );
        }

        public override void SetDefaults() {
            Item.damage = 35;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 54;
            Item.height = 54;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 12;
            Item.value = 20000;
            Item.crit = 4;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            base.SetDefaults();
            Item.shootSpeed = 10f;
        }

        protected override void SetLeftClickMode() {
            Item.noMelee = false;
        }

        protected override void SetRightClickMode() {
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.noMelee = true;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            var rand = Main.rand.Next( 3 );
            switch ( rand ) {
                case 0:
                    Item.useStyle = ItemUseStyleID.Swing;
                    Item.noUseGraphic = false;
                    break;
                case 1:
                    Item.useStyle = ItemUseStyleID.Thrust;
                    Item.noUseGraphic = false;
                    break;
                case 2:
                    Item.useStyle = ItemUseStyleID.Shoot;
                    Item.noUseGraphic = true;
                    Item.shoot = ModContent.ProjectileType<MoralltachProjectile>();
                    break;
            }
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack ) {
            if ( !ComboManager.UseCombo( 25 ) ) return false;

            player.AddBuff( ModContent.BuffType<Buffs.IrishFierceness>(), 1200 );
            SoundEngine.PlaySound( SoundID.Item45, player.position );
            return false;
        }
        public override void AddRecipes() {
            var recipe = CreateRecipe( );
            recipe.AddIngredient( ItemID.DirtBlock, 10 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.Register();
        }


        protected override Mythology Mythology => Mythology.Irish;
        protected override GodDomain GodDomain => GodDomain.Love;
    }
}