using System.Collections.Generic;

using TaleWorlds.Localization;

using TournamentsEnhanced.Wrappers.Abstract;

namespace TournamentsEnhanced.Wrappers
{
  public class MBTextObject : CachedWrapperBase<MBTextObject, TextObject>
  {
    public static implicit operator TextObject(MBTextObject wrapper) => wrapper.UnwrapedObject;
    public static implicit operator MBTextObject(TextObject obj) => MBTextObject.GetWrapperFor(obj);
  }

  public class MBTextObjectList : List<MBTextObject>
  {
    public static implicit operator List<TextObject>(MBTextObjectList wrapperList) => wrapperList.Unwrap<MBTextObject, TextObject>();
    public static implicit operator MBTextObjectList(List<TextObject> objectList) => (MBTextObjectList)objectList.Wrap<MBTextObject, TextObject>();
  }
}
