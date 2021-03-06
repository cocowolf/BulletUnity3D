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

public class btCylinderShapeData : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal btCylinderShapeData(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(btCylinderShapeData obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~btCylinderShapeData() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          BulletCollisionPINVOKE.delete_btCylinderShapeData(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public SWIGTYPE_p_btConvexInternalShapeData m_convexInternalShapeData {
    set {
      BulletCollisionPINVOKE.btCylinderShapeData_m_convexInternalShapeData_set(swigCPtr, SWIGTYPE_p_btConvexInternalShapeData.getCPtr(value));
      if (BulletCollisionPINVOKE.SWIGPendingException.Pending) throw BulletCollisionPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      SWIGTYPE_p_btConvexInternalShapeData ret = new SWIGTYPE_p_btConvexInternalShapeData(BulletCollisionPINVOKE.btCylinderShapeData_m_convexInternalShapeData_get(swigCPtr), true);
      if (BulletCollisionPINVOKE.SWIGPendingException.Pending) throw BulletCollisionPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public int m_upAxis {
    set {
      BulletCollisionPINVOKE.btCylinderShapeData_m_upAxis_set(swigCPtr, value);
    } 
    get {
      int ret = BulletCollisionPINVOKE.btCylinderShapeData_m_upAxis_get(swigCPtr);
      return ret;
    } 
  }

  public string m_padding {
    set {
      BulletCollisionPINVOKE.btCylinderShapeData_m_padding_set(swigCPtr, value);
    } 
    get {
      string ret = BulletCollisionPINVOKE.btCylinderShapeData_m_padding_get(swigCPtr);
      return ret;
    } 
  }

  public btCylinderShapeData() : this(BulletCollisionPINVOKE.new_btCylinderShapeData(), true) {
  }

}

}
