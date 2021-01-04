using System.Collections.Generic;

using TaleWorlds.Core;

using TournamentsEnhanced.Wrappers.Abstract;

namespace TournamentsEnhanced.Wrappers.Core
{
  public class MBEquipmentElement : MBWrapperBase<MBEquipmentElement, EquipmentElement>
  {
    public static implicit operator EquipmentElement(MBEquipmentElement wrapper) => wrapper.UnwrappedObject;
    public static implicit operator MBEquipmentElement(EquipmentElement obj) => MBEquipmentElement.GetWrapperFor(obj);
  }

  public class MBEquipmentElementList : MBListBase<MBEquipmentElement, MBEquipmentElementList>
  {
    public static implicit operator List<EquipmentElement>(MBEquipmentElementList wrapperList) => wrapperList.Unwrap<MBEquipmentElement, EquipmentElement>();
    public static implicit operator MBEquipmentElementList(List<EquipmentElement> objectList) => (MBEquipmentElementList)objectList.Wrap<MBEquipmentElement, EquipmentElement>();
  }
}
