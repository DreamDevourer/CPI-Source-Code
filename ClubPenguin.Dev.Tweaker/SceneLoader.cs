// Decompile from assembly: Assembly-CSharp.dll

using Disney.MobileNetwork;
using System;
using Tweaker.Core;

namespace ClubPenguin.Dev.Tweaker
{
	public static class SceneLoader
	{
		private static void LoadScene(string scene)
		{
			Service.Get<ZoneTransitionService>().LoadAsZoneOrScene(scene, "Loading", null);
		}

		[Invokable("SceneLoader.Boot")]
		private static void LoadBoot()
		{
			SceneLoader.LoadScene("Boot");
		}

		[Invokable("SceneLoader.Home")]
		private static void LoadHome()
		{
			SceneLoader.LoadScene("Home");
		}

		[Invokable("SceneLoader.Loading")]
		private static void LoadLoading()
		{
			SceneLoader.LoadScene("Loading");
		}

		[Invokable("SceneLoader.Settings")]
		private static void LoadSettings()
		{
			SceneLoader.LoadScene("Settings");
		}

		[Invokable("SceneLoader.Newsfeed")]
		private static void LoadNewsfeed()
		{
			SceneLoader.LoadScene("Newsfeed");
		}

		[Invokable("SceneLoader.Boardwalk")]
		private static void LoadBoardwalk()
		{
			SceneLoader.LoadScene("Boardwalk");
		}

		[Invokable("SceneLoader.Diving")]
		private static void LoadDiving()
		{
			SceneLoader.LoadScene("Diving");
		}

		[Invokable("SceneLoader.Beach")]
		private static void LoadBeach()
		{
			SceneLoader.LoadScene("Beach");
		}

		[Invokable("SceneLoader.MtBlizzard")]
		private static void LoadMtBlizzard()
		{
			SceneLoader.LoadScene("MtBlizzard");
		}

		[Invokable("SceneLoader.Town")]
		private static void LoadTown()
		{
			SceneLoader.LoadScene("Town");
		}

		[Invokable("SceneLoader.HerbertBase")]
		private static void LoadHerbertBase()
		{
			SceneLoader.LoadScene("HerbertBase");
		}

		[Invokable("SceneLoader.MtBlizzardSummit")]
		private static void LoadMtBlizzardSummit()
		{
			SceneLoader.LoadScene("MtBlizzardSummit");
		}

		[Invokable("SceneLoader.BoxDimension")]
		private static void LoadBoxDimension()
		{
			SceneLoader.LoadScene("BoxDimension");
		}

		[Invokable("SceneLoader.ClothingDesigner")]
		private static void LoadClothingDesigner()
		{
			SceneLoader.LoadScene("ClothingDesigner");
		}

		[Invokable("SceneLoader.CellPhoneApplet")]
		private static void LoadCellPhoneApplet()
		{
			SceneLoader.LoadScene("CellPhoneApplet");
		}

		[Invokable("SceneLoader.BaseIgloo")]
		private static void LoadBaseIgloo()
		{
			SceneLoader.LoadScene("BaseIgloo");
		}

		[Invokable("SceneLoader.DefaultIgloo")]
		private static void LoadDefaultIgloo()
		{
			SceneLoader.LoadScene("DefaultIgloo");
		}

		[Invokable("SceneLoader.IslandIgloo")]
		private static void LoadIslandIgloo()
		{
			SceneLoader.LoadScene("IslandIgloo");
		}

		[Invokable("SceneLoader.ForestIgloo")]
		private static void LoadForestIgloo()
		{
			SceneLoader.LoadScene("ForestIgloo");
		}

		[Invokable("SceneLoader.Beach_SunSet2018_Decorations")]
		private static void LoadBeach_SunSet2018_Decorations()
		{
			SceneLoader.LoadScene("Beach_SunSet2018_Decorations");
		}

		[Invokable("SceneLoader.Boardwalk_SunSet2018_Decorations")]
		private static void LoadBoardwalk_SunSet2018_Decorations()
		{
			SceneLoader.LoadScene("Boardwalk_SunSet2018_Decorations");
		}

		[Invokable("SceneLoader.Diving_SunSet2018_Decorations")]
		private static void LoadDiving_SunSet2018_Decorations()
		{
			SceneLoader.LoadScene("Diving_SunSet2018_Decorations");
		}

		[Invokable("SceneLoader.MtBlizzard_SunSet2018_Decorations")]
		private static void LoadMtBlizzard_SunSet2018_Decorations()
		{
			SceneLoader.LoadScene("MtBlizzard_SunSet2018_Decorations");
		}

		[Invokable("SceneLoader.Town_SunSet2018_Decorations")]
		private static void LoadTown_SunSet2018_Decorations()
		{
			SceneLoader.LoadScene("Town_SunSet2018_Decorations");
		}

		[Invokable("SceneLoader.Mg_bc_LoadScene")]
		private static void LoadMg_bc_LoadScene()
		{
			SceneLoader.LoadScene("Mg_bc_LoadScene");
		}

		[Invokable("SceneLoader.Mg_bc_GameScene")]
		private static void LoadMg_bc_GameScene()
		{
			SceneLoader.LoadScene("Mg_bc_GameScene");
		}

		[Invokable("SceneLoader.Mg_if_LoadScene")]
		private static void LoadMg_if_LoadScene()
		{
			SceneLoader.LoadScene("Mg_if_LoadScene");
		}

		[Invokable("SceneLoader.Mg_if_GameScene")]
		private static void LoadMg_if_GameScene()
		{
			SceneLoader.LoadScene("Mg_if_GameScene");
		}

		[Invokable("SceneLoader.Mg_pr_LoadScene")]
		private static void LoadMg_pr_LoadScene()
		{
			SceneLoader.LoadScene("Mg_pr_LoadScene");
		}

		[Invokable("SceneLoader.Mg_pr_GameScene")]
		private static void LoadMg_pr_GameScene()
		{
			SceneLoader.LoadScene("Mg_pr_GameScene");
		}

		[Invokable("SceneLoader.Mg_pt_GameScene")]
		private static void LoadMg_pt_GameScene()
		{
			SceneLoader.LoadScene("Mg_pt_GameScene");
		}

		[Invokable("SceneLoader.Mg_pt_LoadScene")]
		private static void LoadMg_pt_LoadScene()
		{
			SceneLoader.LoadScene("Mg_pt_LoadScene");
		}

		[Invokable("SceneLoader.Mg_ss_LoadScene")]
		private static void LoadMg_ss_LoadScene()
		{
			SceneLoader.LoadScene("Mg_ss_LoadScene");
		}

		[Invokable("SceneLoader.Mg_ss_GameScene")]
		private static void LoadMg_ss_GameScene()
		{
			SceneLoader.LoadScene("Mg_ss_GameScene");
		}

		[Invokable("SceneLoader.Mg_jr_LoadScene")]
		private static void LoadMg_jr_LoadScene()
		{
			SceneLoader.LoadScene("Mg_jr_LoadScene");
		}

		[Invokable("SceneLoader.Mg_jr_GameScene")]
		private static void LoadMg_jr_GameScene()
		{
			SceneLoader.LoadScene("Mg_jr_GameScene");
		}

		[Invokable("SceneLoader.ClassicMiniGames")]
		private static void LoadClassicMiniGames()
		{
			SceneLoader.LoadScene("ClassicMiniGames");
		}

		[Invokable("SceneLoader.EndCredits")]
		private static void LoadEndCredits()
		{
			SceneLoader.LoadScene("EndCredits");
		}
	}
}
