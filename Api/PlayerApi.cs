// Decompiled with JetBrains decompiler
// Type: StarvationMod.Api.PlayerApi
// Assembly: StarvingMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4A15FDF5-21E3-4CB5-8573-C3144BA04543
// Assembly location: C:\Users\admin\Downloads\StarvationMod\StarvationMod.dll

using UnityEngine;

namespace StarvationMod.Api
{
  public class PlayerApi
  {
    private Player original;

    public PlayerApi(ref Player instance) => this.original = instance;

    private SEMan m_seman => ((Character) this.original).GetSEMan();

    public bool addStatusEffect(string name, bool resetTime = false) => Object.op_Implicit((Object) this.m_seman.AddStatusEffect(name, resetTime));

    public bool removeStatusEffect(string name, bool quiet = false) => this.m_seman.RemoveStatusEffect(name, quiet);
  }
}
