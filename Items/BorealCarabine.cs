using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace Overdone.Items
{
	public class BorealCarabine : ModItem
	{

		private int counter;

		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("BorealCarabine"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Need for Needles");
		}

		public override void SetDefaults() 
		{
			item.damage = 10;
			item.ranged = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 14;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 10000;
			item.UseSound = SoundID.Item11;
			item.crit = 1;
			item.rare = 1;
			item.autoReuse = true;

			item.shootSpeed = 10f;
			item.shoot = ProjectileID.PineNeedleFriendly; 

		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
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