using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace Overdone.Items
{
	public class Humblesmack : ModItem
	{

		private int counter;

		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Humblesmack"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("I came from humble besmackings");
		}

		public override void SetDefaults() 
		{
			item.damage = 5;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 21;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 10000;
			item.crit = 11;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

			item.shootSpeed = 6f;
			item.shoot = ProjectileID.Seed; 

		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			counter++;
			if (counter >= 3)
			{
				for (var i = 0; i < 3; i++)
				{
					Projectile.NewProjectile(position.X - 8f, position.Y + 8f, speedX + (float)Main.rand.Next(-230, 230) / 100f, speedY + (float)Main.rand.Next(-230, 230) / 100f, ProjectileID.Seed, damage, knockBack, ((Entity)player).whoAmI, 0f, 0f);
				}
				counter = 0;
			}
			return false;
		}


		public override void AddRecipes() 
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}