/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.8
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace BulletCSharp {

using System;
using System.Runtime.InteropServices;

public class Element : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Element(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(Element obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~Element() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          BulletSoftBodyPINVOKE.delete_Element(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public SWIGTYPE_p_void m_tag {
    set {
      BulletSoftBodyPINVOKE.Element_m_tag_set(swigCPtr, SWIGTYPE_p_void.getCPtr(value));
    } 
    get {
      IntPtr cPtr = BulletSoftBodyPINVOKE.Element_m_tag_get(swigCPtr);
      SWIGTYPE_p_void ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_void(cPtr, false);
      return ret;
    } 
  }

  public Element() : this(BulletSoftBodyPINVOKE.new_Element(), true) {
  }

}

}