using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace Overdone.Items
{
	public class HarpeSword : ModItem
	{

		private int counter;

		public override void SetStaticDefaults() 
		{
            // DisplayName.SetDefault("HarpeSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Used to decapitate Medusa");
		}

		public override void SetDefaults() 
		{
			item.damage = 17;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.knockBack = 15;
			item.value = 10000;
			item.crit = 27;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

			item.shootSpeed = 6f;
			item.shoot = ProjectileID.MedusaHead; 

		}






        public override bool AltFunctionUse( Player player ) {
            return true;
        }

        public override bool CanUseItem( Player player ) {
            if ( player.altFunctionUse == 2 ) {
                item.useStyle = 4;
                item.noMelee = true;
                item.mana = 5;
            }
            else {
                item.useStyle = 1;
                item.noMelee = false;
                item.mana = 0;
            }

            return base.CanUseItem( player );
        }

        public override bool Shoot( Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack ) {
            counter++;
            if ( counter >= 7 ) {
                for ( int i = 0; i < 3; i++ ) {
                    Projectile.NewProjectile( position.X - 8f, position.Y + 8f, speedX + (float)Main.rand.Next( -230, 230 ) / 100f, speedY + (float)Main.rand.Next( -230, 230 ) / 100f, ProjectileID.MedusaHead, damage, knockBack, ((Entity)player).whoAmI, 0f, 0f );
                }
                counter = 0;
            }

            if ( player.altFunctionUse == 2 ) {
                Projectile.NewProjectile( position.X, position.Y, speedX * 1.85f, speedY * 1.85f, ModContent.ProjectileType<Projectiles.HarpeSwordHead>(), (int)((double)damage * 1.5), 10f, ((Entity)player).whoAmI, 0f, 0f );
                Main.PlaySound( SoundID.Item45, ((Entity)player).position );
            }
            return false;
        }


        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}