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

public class GrahamVector3 : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal GrahamVector3(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(GrahamVector3 obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~GrahamVector3() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          LinearMathPINVOKE.delete_GrahamVector3(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public GrahamVector3(btVector3 org, int orgIndex) : this(LinearMathPINVOKE.new_GrahamVector3(btVector3.getCPtr(org), orgIndex), true) {
    if (LinearMathPINVOKE.SWIGPendingException.Pending) throw LinearMathPINVOKE.SWIGPendingException.Retrieve();
  }

  public float m_angle {
    set {
      LinearMathPINVOKE.GrahamVector3_m_angle_set(swigCPtr, value);
    } 
    get {
      float ret = LinearMathPINVOKE.GrahamVector3_m_angle_get(swigCPtr);
      return ret;
    } 
  }

  public int m_orgIndex {
    set {
      LinearMathPINVOKE.GrahamVector3_m_orgIndex_set(swigCPtr, value);
    } 
    get {
      int ret = LinearMathPINVOKE.GrahamVector3_m_orgIndex_get(swigCPtr);
      return ret;
    } 
  }

}

}
