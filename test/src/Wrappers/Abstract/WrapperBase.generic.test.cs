using NUnit.Framework;
using Shouldly;
using TournamentsEnhanced.Wrappers.Abstract;

namespace TournamentsEnhanced.UnitTests
{
  public class WrapperBaseGenericTests
  {
    private GenericWrapperBaseImpl sut;
    private readonly object unwrappedObject = new object();

    [Test]
    public void Null_IsStatic()
    {
      GenericWrapperBaseImpl.Null.ShouldBe(GenericWrapperBaseImpl.Null);
    }

    [Test]
    public void Null_IsNotNull()
    {
      GenericWrapperBaseImpl.Null.ShouldNotBeNull();
    }

    [Test]
    public void Null_HasNullUnwrappedObject()
    {
      GenericWrapperBaseImpl.Null.UnwrappedObject.ShouldBeNull();
    }

    [Test]
    public void Ctor_ArgBecomesUnwrappedObject()
    {
      sut = new GenericWrapperBaseImpl(unwrappedObject);

      sut.UnwrappedObject.ShouldBe(unwrappedObject);
    }

    [Test]
    public void Ctor_NoArgsBecomesNullUnwrappedObject()
    {
      sut = new GenericWrapperBaseImpl();

      sut.IsNull.ShouldBeTrue();
    }

    [Test]
    public void Ctor_IsNullShouldBeFalse()
    {
      sut = new GenericWrapperBaseImpl(unwrappedObject);

      sut.IsNull.ShouldBeFalse();
    }

    private class GenericWrapperBaseImpl : WrapperBase<GenericWrapperBaseImpl, object>
    {
      public GenericWrapperBaseImpl() { }
      public GenericWrapperBaseImpl(object obj) : base(obj) { }
    }
  }
}