// Decompiled with JetBrains decompiler
// Type: StarvationMod.ExamplePlugin
// Assembly: StarvingMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4A15FDF5-21E3-4CB5-8573-C3144BA04543
// Assembly location: C:\Users\admin\Downloads\StarvationMod\StarvationMod.dll

using BepInEx;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace StarvationMod
{
  [BepInPlugin("org.bepinex.plugins.starving", "Starvation Mod", "0.1.0")]
  [BepInProcess("valheim.exe")]
  public class ExamplePlugin : BaseUnityPlugin
  {
    private void Awake()
    {
      Debug.Log((object) "Starvation Mod. v.0.1.0");
      Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), (string) null);
    }

    private void Update()
    {
      if (!GLOBAL.starvationSystem.checkUpdate())
        return;
      GLOBAL.starvationSystem.update();
    }
  }
}
