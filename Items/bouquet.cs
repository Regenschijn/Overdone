using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace Overdone.Items
{
	public class Bouquet : ModItem
	{

		private int counter;

		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Bouquet"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Ik ga deze bloemen helemaal op je schouders kapotslaan!");
		}

		public override void SetDefaults() 
		{
			item.damage = 13;
			item.magic = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 17;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 2;
			item.value = 10000;
			item.crit = 13;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

			item.shootSpeed = 10f;
			item.shoot = ProjectileID.Leaf; 

		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			counter++;
			if (counter >= 4)
			{
				for (int i = 0; i < 7; i++)
				{
					Projectile.NewProjectile(position.X - 8f, position.Y + 8f, speedX + (float)Main.rand.Next(-130, 330) / 150f, speedY + (float)Main.rand.Next(-330, 130) / 150f, ProjectileID.FlowerPetal, damage - 7, knockBack, ((Entity)player).whoAmI, 0f, 0f);
				}
				counter = 0;
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