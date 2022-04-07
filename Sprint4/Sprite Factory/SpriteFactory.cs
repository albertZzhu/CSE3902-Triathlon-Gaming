using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Sprint4
{
	public class SpriteFactory
	{
		//its a singleton!
		private static SpriteFactory uniqueFactory;

		private static Dictionary<string, Sprite> spriteDict;

		private SpriteFactory(Microsoft.Xna.Framework.Content.ContentManager Content)
		{
			Texture2D npcAttackRight = Content.Load<Texture2D>("kirito_right_attack");
			Texture2D npcAttackFront = Content.Load<Texture2D>("kirito_front_attack");
			Texture2D npcAttackBack = Content.Load<Texture2D>("kirito_back_attack");

			CreateSprite(npcAttackRight, 6, 1, 6, "kirito_right_attack");
			CreateSprite(npcAttackFront, 4, 1, 4, "kirito_front_attack");
			CreateSprite(npcAttackBack, 4, 1, 4, "kirito_back_attack");

			Texture2D npcMoveRight = Content.Load<Texture2D>("kirito_move_right");
			Texture2D npcMoveLeft = Content.Load<Texture2D>("kirito_move_left");
			Texture2D npcMoveBack = Content.Load<Texture2D>("kirito_back_move");
			Texture2D npcMoveFront = Content.Load<Texture2D>("kirito_move_front");

			CreateSprite(npcMoveRight, 3, 1, 3, "kirito_move_right");
			CreateSprite(npcMoveLeft, 3, 1, 3, "kirito_move_left");
			CreateSprite(npcMoveBack, 3, 1, 3, "kirito_back_move");
			CreateSprite(npcMoveFront, 3, 1, 3, "kirito_move_front");

			//can rotate this in draw
			Texture2D projectileRight = Content.Load<Texture2D>("right_projectile");
			Texture2D projectileUp = Content.Load<Texture2D>("up_projectile");
			Texture2D projectileLeft = Content.Load<Texture2D>("left_projectile");
			Texture2D projectileDown = Content.Load<Texture2D>("down_projectile");

			Texture2D fireballright = Content.Load<Texture2D>("fireball_right");
			Texture2D fireballleft = Content.Load<Texture2D>("fireball_Left");
			Texture2D fireballup = Content.Load<Texture2D>("fireball_up");
			Texture2D fireballdown = Content.Load<Texture2D>("fireball_down");

			Texture2D npcStillRight = Content.Load<Texture2D>("kirito_right_still");
			Texture2D npcStillLeft = Content.Load<Texture2D>("kirito_left_still");
			Texture2D npcStillBack = Content.Load<Texture2D>("kirito_back_still");
			Texture2D npcStillFront = Content.Load<Texture2D>("kirito_front_still");

			CreateSprite(npcStillRight, 1, 1, 1, "kirito_right_still");
			CreateSprite(npcStillLeft, 1, 1, 1, "kirito_left_still");
			CreateSprite(npcStillBack, 1, 1, 1, "kirito_back_still");
			CreateSprite(npcStillFront, 1, 1, 1, "kirito_front_still");

			//pc sprites
			Texture2D attackRight = Content.Load<Texture2D>("right_throw");
			Texture2D attackLeft = Content.Load<Texture2D>("left_throw");
			Texture2D attackFront = Content.Load<Texture2D>("front_throw");
			Texture2D attackBack = Content.Load<Texture2D>("back_throw");

			CreateSprite(attackRight, 2, 3, 6, "right_throw");
			CreateSprite(attackLeft, 2, 3, 6, "left_throw");
			CreateSprite(attackFront, 2, 3, 5, "front_throw");
			CreateSprite(attackBack, 3, 2, 6, "back_throw");

			Texture2D moveRight = Content.Load<Texture2D>("right_move");
			Texture2D moveLeft = Content.Load<Texture2D>("left_move");
			Texture2D moveBack = Content.Load<Texture2D>("back_move");
			Texture2D moveFront = Content.Load<Texture2D>("front_move");

			CreateSprite(moveRight, 3, 3, 8, "right_move");
			CreateSprite(moveLeft, 3, 3, 8, "left_move");
			CreateSprite(moveFront, 3, 2, 4, "back_move");
			CreateSprite(moveBack, 4, 2, 6, "front_move");

			Texture2D stillRight = Content.Load<Texture2D>("right_still");
			Texture2D stillLeft = Content.Load<Texture2D>("left_still");
			Texture2D stillBack = Content.Load<Texture2D>("back_still");
			Texture2D stillFront = Content.Load<Texture2D>("front_still");

			CreateSprite(stillRight, 1, 1, 1, "right_still");
			CreateSprite(stillLeft, 1, 1, 1, "left_still");
			CreateSprite(stillFront, 1, 1, 1, "back_still");
			CreateSprite(stillBack, 1, 1, 1, "front_still");

			//damaged player sprites
			//hERE
			Texture2D damage_right = Content.Load<Texture2D>("damage_right");
			Texture2D damage_left = Content.Load<Texture2D>("damage_left");
			Texture2D damage_back = Content.Load<Texture2D>("damage_back");
			Texture2D damage_front = Content.Load<Texture2D>("damage_front");

			CreateSprite(damage_right, 2, 1, 2, "damage_right");
			CreateSprite(damage_left, 2, 1, 2, "damage_left");
			CreateSprite(damage_back, 2, 1, 2, "damage_back");
			CreateSprite(damage_front, 2, 1, 2, "damage_front");

			Texture2D damage_right_move = Content.Load<Texture2D>("damage_right_move");
			Texture2D damage_left_move = Content.Load<Texture2D>("damage_left_move");
			Texture2D damage_back_move = Content.Load<Texture2D>("damage_back_move");
			Texture2D damage_front_move = Content.Load<Texture2D>("damage_front_move");

			CreateSprite(damage_right_move, 3, 3, 8, "damage_right_move");
			CreateSprite(damage_left_move, 3, 3, 8, "damage_left_move");
			CreateSprite(damage_back_move, 4, 2, 6, "damage_back_move");
			CreateSprite(damage_front_move, 3, 2, 4, "damage_front_move");

			//hm....
			//Texture2D stillBrokenHeart = Content.Load<Texture2D>("resized heart");
			//Texture2D animatedDamage = Content.Load<Texture2D>("animatedDamage");

			//hmmmmm
			//SpriteFactory.CreateSprite(animatedDamage, 5, 4, 17, "animatedDamage");
			//SpriteFactory.CreateSprite(stillBrokenHeart, 1, 1, 1, "resized heart");

			Texture2D mudBlock = Content.Load<Texture2D>("mudBlock");
			Texture2D glassBlock = Content.Load<Texture2D>("glassBlock");
			Texture2D ironBlock = Content.Load<Texture2D>("ironBlock");
			Texture2D stoneBlock = Content.Load<Texture2D>("stoneBlock");

			Texture2D heart = Content.Load<Texture2D>("heart");
			Texture2D magicPortion = Content.Load<Texture2D>("magic_portion");
			Texture2D sword = Content.Load<Texture2D>("sword");
			Texture2D skeletonRight = Content.Load<Texture2D>("skeletonRight");
			Texture2D skeletonLeft = Content.Load<Texture2D>("skeletonLeft");
			Texture2D skeletonFront = Content.Load<Texture2D>("skeletonFront");
			Texture2D skeletonBack = Content.Load<Texture2D>("skeletonBack");

			CreateSprite(skeletonRight, 4, 1, 4, "skeletonRight");
			CreateSprite(skeletonLeft, 4, 1, 4, "skeletonLeft");
			CreateSprite(skeletonFront, 4, 1, 4, "skeletonFront");
			CreateSprite(skeletonBack, 4, 1, 4, "skeletonBack");

			CreateSprite(heart, 2, 3, 5, "heart");
			CreateSprite(magicPortion, 1, 1, 1, "magicPortion");
			CreateSprite(sword, 1, 1, 1,"sword");

			CreateSprite(projectileRight, 2, 2, 1, "projectileRight");
			CreateSprite(projectileLeft, 2, 2, 1, "projectileLeft");
			CreateSprite(projectileUp, 2, 2, 1, "projectileUp");
			CreateSprite(projectileDown, 2, 2, 1, "projectileDown");
			CreateSprite(fireballright, 8, 1, 1, "fireballright");
			CreateSprite(fireballleft, 8, 1, 1, "fireballleft");
			CreateSprite(fireballup, 8, 1, 1, "fireballup");
			CreateSprite(fireballdown, 8, 1, 1, "fireballdown");

			CreateSprite(mudBlock, 1, 1, 1, "mudBlock");
			CreateSprite(glassBlock, 1, 1, 1, "glassBlock");
			CreateSprite(ironBlock, 1, 1, 1, "ironBlock");
			CreateSprite(stoneBlock, 1, 1, 1, "stoneBlock");

			Texture2D block = Content.Load<Texture2D>("block");
			CreateSprite(block, 1, 1, 1, "block");
			Texture2D block110 = Content.Load<Texture2D>("block110");
			CreateSprite(block110, 1, 1, 1, "block110");
			Texture2D block12 = Content.Load<Texture2D>("block12");
			CreateSprite(block12, 1, 1, 1, "block12");
			Texture2D block13 = Content.Load<Texture2D>("block13");
			CreateSprite(block13, 1, 1, 1, "block13");
			Texture2D block15 = Content.Load<Texture2D>("block15");
			CreateSprite(block15, 1, 1, 1, "block15");
			Texture2D block32 = Content.Load<Texture2D>("block32");
			CreateSprite(block32, 1, 1, 1, "block32");
			Texture2D block41 = Content.Load<Texture2D>("block41");
			CreateSprite(block41, 1, 1, 1, "block41");
			Texture2D blueSand = Content.Load<Texture2D>("blueSand");
			CreateSprite(blueSand, 1, 1, 1, "blueSand");
			Texture2D blueSand12 = Content.Load<Texture2D>("blueSand12");
			CreateSprite(blueSand12, 1, 1, 1, "blueSand12");
			Texture2D blueSand32 = Content.Load<Texture2D>("blueSand32");
			CreateSprite(blueSand32, 1, 1, 1, "blueSand32");
			Texture2D bottomarch = Content.Load<Texture2D>("bottomarch");
			CreateSprite(bottomarch, 1, 1, 1, "bottomarch");
			Texture2D bottomgate = Content.Load<Texture2D>("bottomgate");
			CreateSprite(bottomgate, 1, 1, 1, "bottomgate");
			Texture2D bottomwall = Content.Load<Texture2D>("bottomwall");
			CreateSprite(bottomwall, 1, 1, 1, "bottomwall");
			Texture2D bottomwall11 = Content.Load<Texture2D>("bottomwall11");
			CreateSprite(bottomwall11, 1, 1, 1, "bottomwall11");
			Texture2D floor = Content.Load<Texture2D>("floor");
			CreateSprite(floor, 1, 1, 1, "floor");
			Texture2D leftgate = Content.Load<Texture2D>("leftgate");
			CreateSprite(leftgate, 1, 1, 1, "leftgate");
			Texture2D leftStatue = Content.Load<Texture2D>("leftStatue");
			CreateSprite(leftStatue, 1, 1, 1, "leftStatue");
			Texture2D leftwall = Content.Load<Texture2D>("leftwall");
			CreateSprite(leftwall, 1, 1, 1, "leftwall");
			Texture2D leftwall11 = Content.Load<Texture2D>("leftwall11");
			CreateSprite(leftwall11, 1, 1, 1, "leftwall11");
			Texture2D rightgate = Content.Load<Texture2D>("rightgate");
			CreateSprite(rightgate, 1, 1, 1, "rightgate");
			Texture2D rightStatue = Content.Load<Texture2D>("rightStatue");
			CreateSprite(rightStatue, 1, 1, 1, "rightStatue");
			Texture2D rightwall = Content.Load<Texture2D>("rightwall");
			CreateSprite(rightwall, 1, 1, 1, "rightwall");
			Texture2D rightwall11 = Content.Load<Texture2D>("rightwall11");
			CreateSprite(rightwall11, 1, 1, 1, "rightwall11");
			Texture2D stairs = Content.Load<Texture2D>("stairs");
			CreateSprite(stairs, 1, 1, 1, "stairs");
			Texture2D toparch = Content.Load<Texture2D>("toparch");
			CreateSprite(toparch, 1, 1, 1, "toparch");
			Texture2D topgate = Content.Load<Texture2D>("topgate");
			CreateSprite(topgate, 1, 1, 1, "topgate");
			Texture2D topwall = Content.Load<Texture2D>("topwall");
			CreateSprite(topwall, 1, 1, 1, "topwall");
			Texture2D topwall11 = Content.Load<Texture2D>("topwall11");
			CreateSprite(topwall11, 1, 1, 1, "topwall11");
			Texture2D water11 = Content.Load<Texture2D>("water11");
			CreateSprite(water11, 1, 1, 1, "water11");
			Texture2D water12 = Content.Load<Texture2D>("water12");
			CreateSprite(water12, 1, 1, 1, "water12");
			Texture2D water13 = Content.Load<Texture2D>("water13");
			CreateSprite(water13, 1, 1, 1, "water13");
			Texture2D water31 = Content.Load<Texture2D>("water31");
			CreateSprite(water31, 1, 1, 1, "water31");
			Texture2D water51 = Content.Load<Texture2D>("water51");
			CreateSprite(water51, 1, 1, 1, "water51");

			Texture2D bladetrap = Content.Load<Texture2D>("bladetrap");
			CreateSprite(bladetrap, 1, 1, 1, "bladetrap");
			Texture2D redGoriyaRight = Content.Load<Texture2D>("redGoriyaRight");
			CreateSprite(redGoriyaRight, 1, 2, 2, "redGoriyaRight");
			Texture2D redGoriyaLeft = Content.Load<Texture2D>("redGoriyaLeft");
			CreateSprite(redGoriyaLeft, 1, 2, 2, "redGoriyaLeft");
			Texture2D redGoriyaFront = Content.Load<Texture2D>("redGoriyaFront");
			CreateSprite(redGoriyaFront, 1, 2, 2, "redGoriyaFront");
			Texture2D redGoriyaBack = Content.Load<Texture2D>("redGoriyaBack");
			CreateSprite(redGoriyaBack, 1, 2, 2, "redGoriyaBack");
			Texture2D stalfos = Content.Load<Texture2D>("stalfos");
			CreateSprite(stalfos, 1, 2, 2, "stalfos");
			Texture2D key = Content.Load<Texture2D>("key");
			CreateSprite(key, 1, 1, 1, "key");
			Texture2D dragonFireball = Content.Load<Texture2D>("dragonFireball");
			CreateSprite(dragonFireball, 1, 1, 1, "dragonFireball");
			Texture2D blueBat = Content.Load<Texture2D>("blueBat");
			CreateSprite(blueBat, 2, 1, 2, "blueBat");
			Texture2D dragon = Content.Load<Texture2D>("dragon");
			CreateSprite(dragon, 4, 1, 4, "dragon");
			Texture2D itemHeart = Content.Load<Texture2D>("itemHeart");
			CreateSprite(itemHeart, 1, 1, 1, "itemHeart");
			Texture2D triforce = Content.Load<Texture2D>("triforce");
			CreateSprite(triforce, 1, 1, 1, "triforce");
			Texture2D map = Content.Load<Texture2D>("map");
			CreateSprite(map, 1, 1, 1, "map");
			Texture2D boomerang = Content.Load<Texture2D>("boomerang");
			CreateSprite(boomerang, 1, 1, 1, "boomerang");
			Texture2D blueGem = Content.Load<Texture2D>("blueGem");
			CreateSprite(blueGem, 1, 2, 2, "blueGem");
			Texture2D wallMasterLeft = Content.Load<Texture2D>("wallMasterLeft");
			CreateSprite(wallMasterLeft, 1, 2, 2, "wallMasterLeft");
			Texture2D wallMasterRight = Content.Load<Texture2D>("wallMasterRight");
			CreateSprite(wallMasterRight, 1, 2, 2, "wallMasterRight");
			Texture2D compass = Content.Load<Texture2D>("compass");
			CreateSprite(compass, 1, 1, 1, "compass");

			Texture2D pauseButton= Content.Load<Texture2D>("pauseButton");
			CreateSprite(pauseButton, 1, 1, 1, "pauseButton");
			Texture2D playButton = Content.Load<Texture2D>("playButton");
			CreateSprite(playButton, 1, 1, 1, "playButton");

			Texture2D dungeonmap = Content.Load<Texture2D>("dungeonmap");
			CreateSprite(dungeonmap, 1, 1, 1, "dungeonmap");

			Texture2D mapmarker = Content.Load<Texture2D>("mapmarker");
			CreateSprite(mapmarker, 1, 1, 1, "mapmarker");
		}

		public static SpriteFactory GetFactory(Microsoft.Xna.Framework.Content.ContentManager Content)
		{
			if (uniqueFactory == null)
			{
				spriteDict = new Dictionary<string, Sprite>();
				uniqueFactory = new SpriteFactory(Content);
			}
			return uniqueFactory;
		}

		//takes in info about whats to be made in create sprite method?
		//encapsulate sprite data? bitmap, col, rows, tFrames?
		public static ISprite CreateSprite(Texture2D bitMap, int columns, int rows, int totalFrames, String spriteName)
		{
			Sprite sprite = new Sprite();
			sprite.SetFrames(bitMap, columns, rows, totalFrames);
			spriteDict.Add(spriteName, sprite);
			return sprite;
		}

		public static ISprite GetSprite(String spriteName)
		{
			return spriteDict[spriteName];
		}

	}
}
