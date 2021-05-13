using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Overdone.Base;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace Overdone.Items {
    public class BouquetBasic : DodoModItem {

        private int _shootTimeoutCounter;

        public override void SetStaticDefaults() {
            DisplayName.SetDefault( "Flink bouquet" );
            Tooltip.SetDefault( "Ik ga deze bloemen stuk slaan op je schouders!" );
        }

        public override void SetDefaults() {
            UseCombo = true;
            
            item.damage = 13;
            item.magic = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 17;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 2;
            item.value = 10000;
            item.crit = 13;
            item.rare = ItemRarityID.Blue;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;

            item.shootSpeed = 10f;
            item.shoot = ProjectileID.Leaf;
        }

        public override bool Shoot( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            _shootTimeoutCounter++;
            if ( _shootTimeoutCounter < 4 ) return false;

            for ( var i = 0; i < 7; i++ ) {
                Projectile.NewProjectile(
                    position.X - 8f,
                    position.Y + 8f,
                    speedX + Main.rand.Next( -130, 330 ) / 150f,
                    speedY + Main.rand.Next( -330, 130 ) / 150f,
                    ProjectileID.Leaf,
                    damage - 7,
                    knockBack,
                    player.whoAmI
                );
            }
            _shootTimeoutCounter = 0;
            return false;
        }


        public override void AddRecipes() {
            var recipe = new ModRecipe( mod );
            recipe.AddIngredient( ItemID.DirtBlock, 10 );
            recipe.AddTile( TileID.WorkBenches );
            recipe.SetResult( this );
            recipe.AddRecipe();
        }
    }
}