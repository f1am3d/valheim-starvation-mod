// Decompiled with JetBrains decompiler
// Type: StarvationMod.PlayerSpawnPatch
// Assembly: StarvingMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4A15FDF5-21E3-4CB5-8573-C3144BA04543
// Assembly location: C:\Users\admin\Downloads\StarvationMod\StarvationMod.dll

using HarmonyLib;
using StarvationMod.Api;

namespace StarvationMod
{
  [HarmonyPatch(typeof (Game), "SpawnPlayer")]
  internal class PlayerSpawnPatch
  {
    private static bool Prefix() => true;

    private static void Postfix()
    {
      GLOBAL.playerApi = new PlayerApi(ref Player.m_localPlayer);
      GLOBAL.starvationSystem.setPlayerInstance(ref Player.m_localPlayer);
    }
  }
}
