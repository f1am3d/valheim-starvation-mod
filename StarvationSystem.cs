// Decompiled with JetBrains decompiler
// Type: StarvationMod.StarvationSystem
// Assembly: StarvingMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4A15FDF5-21E3-4CB5-8573-C3144BA04543
// Assembly location: C:\Users\admin\Downloads\StarvationMod\StarvationMod.dll

using StarvationMod.Api;
using UnityEngine;

namespace StarvationMod
{
  public class StarvationSystem
  {
    private Player player;
    private bool isStarving = false;
    private bool effectActive = false;
    private float interval = 30f;
    private float damage = 5f;
    private float timer;
    private float deltaTime = Time.deltaTime;

    public void setPlayerInstance(ref Player playerInstance) => this.player = playerInstance;

    public bool checkUpdate() => Object.op_Inequality((Object) this.player, (Object) null) && !((Character) this.player).IsDead();

    public void update()
    {
      if ((double) this.timer >= (double) this.interval)
        this.damageTick();
      else
        this.timer += this.deltaTime;
    }

    private void effectTick()
    {
      if (!this.isStarving && this.effectActive)
      {
        GLOBAL.playerApi.removeStatusEffect(StatusEffectList.Starving);
        this.effectActive = false;
      }
      else
      {
        if (!this.isStarving || this.effectActive)
          return;
        GLOBAL.playerApi.addStatusEffect(StatusEffectList.Starving);
        this.effectActive = true;
      }
    }

    private void damageTick()
    {
      if (this.getPlayerFood() == 0)
      {
        this.isStarving = true;
        this.damagePlayer();
      }
      else
        this.isStarving = false;
      this.timer = 0.0f;
    }

    private int getPlayerFood() => this.player.GetFoods().Count;

    private void damagePlayer() => ((Character) this.player).ApplyDamage(new HitData()
    {
      m_damage = {
        m_damage = this.damage
      }
    }, true, true, (HitData.DamageModifier) 0);
  }
}
