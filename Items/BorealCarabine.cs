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
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 14;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = 10000;
			Item.UseSound = SoundID.Item11;
			Item.crit = 1;
			Item.rare = 1;
			Item.autoReuse = true;

			Item.shootSpeed = 10f;
			Item.shoot = ProjectileID.PineNeedleFriendly; 

		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
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