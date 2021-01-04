using System.Collections.Generic;

using TaleWorlds.Core;

using TournamentsEnhanced.Wrappers.Abstract;

namespace TournamentsEnhanced.Wrappers.Core
{
  public class MBSaddleComponent : MBObjectBaseWrapper<MBSaddleComponent, SaddleComponent>
  {
    public static implicit operator SaddleComponent(MBSaddleComponent wrapper) => wrapper.UnwrappedObject;
    public static implicit operator MBSaddleComponent(SaddleComponent obj) => MBSaddleComponent.GetWrapperFor(obj);
  }

  public class MBSaddleComponentList : MBListBase<MBSaddleComponent, MBSaddleComponentList>
  {
    public static implicit operator List<SaddleComponent>(MBSaddleComponentList wrapperList) => wrapperList.Unwrap<MBSaddleComponent, SaddleComponent>();
    public static implicit operator MBSaddleComponentList(List<SaddleComponent> objectList) => (MBSaddleComponentList)objectList.Wrap<MBSaddleComponent, SaddleComponent>();
  }
}
