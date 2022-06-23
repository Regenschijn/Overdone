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
			Item.damage = 5;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 21;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = 10000;
			Item.crit = 11;
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

			Item.shootSpeed = 6f;
			Item.shoot = ProjectileID.Seed; 

		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
			var recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}