using Microsoft.Xna.Framework;
using Overdone.Base;
using Overdone.Combo;
using Overdone.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Irish {
    public class Moralltach : DoubleUseDodoModItem {
        private int _counter;

        public override void SetStaticDefaults() {
            Tooltip.SetDefault( "The sword of Aengus (Macan Óc). \n LMB: Attack in various ways. \n RMB: Consume 25 combo to get an attack damage buff. \n At 100 combo, your attacks gain extra armor penetration." );
        }

        public override void SetDefaults() {
            item.damage = 35;
            item.melee = true;
            item.width = 54;
            item.height = 54;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 12;
            item.value = 20000;
            item.crit = 4;
            item.rare = ItemRarityID.LightRed;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            base.SetDefaults();
            item.shootSpeed = 10f;
        }

        protected override void SetLeftClickMode() {
            item.noMelee = false;
        }

        protected override void SetRightClickMode() {
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.noMelee = true;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            var rand = Main.rand.Next( 3 );
            switch ( rand ) {
                case 0:
                    item.useStyle = ItemUseStyleID.SwingThrow;
                    item.noUseGraphic = false;
                    break;
                case 1:
                    item.useStyle = ItemUseStyleID.Stabbing;
                    item.noUseGraphic = false;
                    break;
                case 2:
                    item.useStyle = ItemUseStyleID.HoldingOut;
                    item.noUseGraphic = true;
                    item.shoot = ModContent.ProjectileType<MoralltachProjectile>();
                    break;
            }
            return true;


            Projectile.NewProjectile( position.X - 8f, position.Y + 8f, speedX + (float)Main.rand.Next( -230, 230 ) / 100f, speedY + (float)Main.rand.Next( -230, 230 ) / 100f, ModContent.ProjectileType<FragarachSlash>(), damage, 0, (player).whoAmI, 0f, 0f );

            _counter = 0;
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            if ( !ComboManager.UseCombo( 25 ) ) return false;

            player.AddBuff( ModContent.BuffType<Buffs.IrishFierceness>(), 1200 );
            Main.PlaySound( SoundID.Item45, player.position );
            return false;
        }
        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 10 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }


        protected override Mythology Mythology => Mythology.Irish;
        protected override GodDomain GodDomain => GodDomain.War | GodDomain.Crafts;
    }
}