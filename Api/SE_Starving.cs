// Decompiled with JetBrains decompiler
// Type: StarvationMod.Api.SE_Starving
// Assembly: StarvingMod, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4A15FDF5-21E3-4CB5-8573-C3144BA04543
// Assembly location: C:\Users\admin\Downloads\StarvationMod\StarvationMod.dll

using UnityEngine;

namespace StarvationMod.Api
{
  public class SE_Starving : StatusEffect
  {
    [Header("SE_Starving")]
    public HitData.DamageTypes m_damage;
    public float m_damageInterval = 5f;
    private float m_timer;

    public virtual bool CanAdd(Character character) => !character.m_tolerateSmoke && base.CanAdd(character);

    public virtual void UpdateStatusEffect(float dt)
    {
      base.UpdateStatusEffect(dt);
      this.m_damage.m_poison = 5f;
      this.m_timer += dt;
      if ((double) this.m_timer <= (double) this.m_damageInterval)
        return;
      this.m_timer = 0.0f;
      this.m_character.ApplyDamage(new HitData()
      {
        m_point = this.m_character.GetCenterPoint(),
        m_damage = this.m_damage
      }, true, false, (HitData.DamageModifier) 0);
    }
  }
}
