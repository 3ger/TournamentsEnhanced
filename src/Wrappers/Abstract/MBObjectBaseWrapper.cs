using TaleWorlds.ObjectSystem;

namespace TournamentsEnhanced.Wrappers.Abstract
{
  public abstract class MBObjectBaseWrapper<W, T> : MBWrapperBase<W, T>
  where W : WrapperBase<T>, new()
  where T : MBObjectBase
  {
    public string StringId => UnwrappedObject.StringId;
  }
}