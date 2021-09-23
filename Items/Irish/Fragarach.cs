using Microsoft.Xna.Framework;
using Overdone.Base;
using Overdone.Combo;
using Overdone.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Overdone.Items.Irish {
    public class Fragarach : DoubleUseDodoModItem {
        private int _counter;

        public override void SetStaticDefaults() {
            Tooltip.SetDefault( "The sword of Nuada, the first high king. \n LMB: Slash attack with a air attack on the Xth attack. \n RMB: Consume 25 combo to get an attack speed buff. \n At 100 combo, your attacks gain extra armor penetration." );
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
            item.shootSpeed = 90f;
        }

        protected override void SetLeftClickMode() {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.noMelee = false;
            item.crit = (int)(7 + (ComboManager.Combo / 5));
        }

        protected override void SetRightClickMode() {
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.noMelee = true;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            _counter++;
            if ( _counter < 5 )
                return false;


            Projectile.NewProjectile( position.X - 8f, position.Y + 8f, speedX + (float)Main.rand.Next( -230, 230 ) / 100f, speedY + (float)Main.rand.Next( -230, 230 ) / 100f, ModContent.ProjectileType<FragarachSlash>(), damage, knockBack, (player).whoAmI, 0f, 0f );

            _counter = 0;
            return false;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            if ( !ComboManager.UseCombo( 10 ) ) return false;

            Projectile.NewProjectile( position.X, position.Y, speedX * 1.85f, speedY * 1.85f, ModContent.ProjectileType<FragarachSlash>(), (int)(damage * 1.5f), 10f, player.whoAmI, 0f, 0f );
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