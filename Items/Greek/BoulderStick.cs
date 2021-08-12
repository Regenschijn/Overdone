using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;
using Overdone.Base;
using Overdone.Combo;

namespace Overdone.Items.Greek {
    public class BoulderStick : DoubleUseDodoModItem {

        public override void SetStaticDefaults() {
            Tooltip.SetDefault( "Sisyphus' problems on a stick\nLMB: Smack. RMB: Shoot boulders" );
        }

        public override void SetDefaults() {
            item.damage = 13;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 30;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = ItemRarityID.LightRed;
            item.crit = 0;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shootSpeed = 10f;
            item.shoot = ProjectileID.Boulder;
            base.SetDefaults();
        }      
             
        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 1 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }

        protected override void SetLeftClickMode() {
            item.noMelee = false;
            item.mana = 1;
            item.melee = false;
            item.magic = true;
            item.useAnimation = 40;
            item.useTime = 40;
            ComboBuildPerHit = 3;
        }

        protected override void SetRightClickMode() {
            item.useStyle = 1;
            item.noMelee = true;
            item.mana = 0;
            item.melee = true;
            item.useTime = 30;
            item.useAnimation = 30;
            ComboBuildPerHit = 0;
        }

        public override bool ShootLeftClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            return true;
        }

        public override bool ShootRightClick( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            if ( !ComboManager.UseCombo( 10 ) ) return false;
            player.itemRotation = -20f * player.direction;
            player.itemLocation.Y = player.Center.Y;
            player.itemLocation.X = player.Center.X;
            Projectile.NewProjectile( position.X - 20f * player.direction, position.Y - 46, speedX * 1.85f, speedY * 1.85f, ProjectileID.Boulder, (int)((double)damage * 1.5), 10f, player.whoAmI, 0f, 0f );
            Main.PlaySound( SoundID.Item45, player.position );
            return false;
        }
        protected override Mythology Mythology => Mythology.Greek;

        protected override GodDomain GodDomain => GodDomain.Demi;
    }
}