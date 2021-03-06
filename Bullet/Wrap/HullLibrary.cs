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

public class HullLibrary : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal HullLibrary(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(HullLibrary obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~HullLibrary() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          LinearMathPINVOKE.delete_HullLibrary(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public SWIGTYPE_p_btAlignedObjectArrayT_int_t m_vertexIndexMapping {
    set {
      LinearMathPINVOKE.HullLibrary_m_vertexIndexMapping_set(swigCPtr, SWIGTYPE_p_btAlignedObjectArrayT_int_t.getCPtr(value));
    } 
    get {
      IntPtr cPtr = LinearMathPINVOKE.HullLibrary_m_vertexIndexMapping_get(swigCPtr);
      SWIGTYPE_p_btAlignedObjectArrayT_int_t ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_btAlignedObjectArrayT_int_t(cPtr, false);
      return ret;
    } 
  }

  public HullError CreateConvexHull(HullDesc desc, HullResult result) {
    HullError ret = (HullError)LinearMathPINVOKE.HullLibrary_CreateConvexHull(swigCPtr, HullDesc.getCPtr(desc), HullResult.getCPtr(result));
    if (LinearMathPINVOKE.SWIGPendingException.Pending) throw LinearMathPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public HullError ReleaseResult(HullResult result) {
    HullError ret = (HullError)LinearMathPINVOKE.HullLibrary_ReleaseResult(swigCPtr, HullResult.getCPtr(result));
    if (LinearMathPINVOKE.SWIGPendingException.Pending) throw LinearMathPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public HullLibrary() : this(LinearMathPINVOKE.new_HullLibrary(), true) {
  }

}

}
