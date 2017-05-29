//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


using System;
using System.Runtime.InteropServices;

namespace Noesis
{

public class StatusBarItem : ContentControl {
  internal new static StatusBarItem CreateProxy(IntPtr cPtr, bool cMemoryOwn) {
    return new StatusBarItem(cPtr, cMemoryOwn);
  }

  internal StatusBarItem(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
  }

  internal static HandleRef getCPtr(StatusBarItem obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.StatusBarItem_GetStaticType();
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public StatusBarItem() {
  }

  protected override IntPtr CreateCPtr(Type type, out bool registerExtend) {
    if ((object)type.TypeHandle == typeof(StatusBarItem).TypeHandle) {
      registerExtend = false;
      return NoesisGUI_PINVOKE.new_StatusBarItem();
    }
    else {
      return base.CreateExtendCPtr(type, out registerExtend);
    }
  }


  internal new static IntPtr Extend(string typeName) {
    IntPtr nativeType = NoesisGUI_PINVOKE.Extend_StatusBarItem(Marshal.StringToHGlobalAnsi(typeName));
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    return nativeType;
  }
}

}

