using System.Collections.Generic;

using TaleWorlds.Core;

using TournamentsEnhanced.Wrappers.Abstract;

namespace TournamentsEnhanced.Wrappers
{
  public class MBWeaponComponentData : CachedWrapperBase<MBWeaponComponentData, WeaponComponentData>
  {
    public static implicit operator WeaponComponentData(MBWeaponComponentData wrapper) => wrapper.UnwrapedObject;
    public static implicit operator MBWeaponComponentData(WeaponComponentData obj) => MBWeaponComponentData.GetWrapperFor(obj);
  }

  public class MBWeaponComponentDataList : List<MBWeaponComponentData>
  {
    public static implicit operator List<WeaponComponentData>(MBWeaponComponentDataList wrapperList) => wrapperList.Unwrap<MBWeaponComponentData, WeaponComponentData>();
    public static implicit operator MBWeaponComponentDataList(List<WeaponComponentData> objectList) => (MBWeaponComponentDataList)objectList.Wrap<MBWeaponComponentData, WeaponComponentData>();
  }
}
