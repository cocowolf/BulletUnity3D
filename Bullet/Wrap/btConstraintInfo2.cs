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

public class btConstraintInfo2 : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal btConstraintInfo2(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(btConstraintInfo2 obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~btConstraintInfo2() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          BulletDynamicsPINVOKE.delete_btConstraintInfo2(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public float fps {
    set {
      BulletDynamicsPINVOKE.btConstraintInfo2_fps_set(swigCPtr, value);
    } 
    get {
      float ret = BulletDynamicsPINVOKE.btConstraintInfo2_fps_get(swigCPtr);
      return ret;
    } 
  }

  public float erp {
    set {
      BulletDynamicsPINVOKE.btConstraintInfo2_erp_set(swigCPtr, value);
    } 
    get {
      float ret = BulletDynamicsPINVOKE.btConstraintInfo2_erp_get(swigCPtr);
      return ret;
    } 
  }

  public SWIGTYPE_p_float m_J1linearAxis {
    set {
      BulletDynamicsPINVOKE.btConstraintInfo2_m_J1linearAxis_set(swigCPtr, SWIGTYPE_p_float.getCPtr(value));
    } 
    get {
      IntPtr cPtr = BulletDynamicsPINVOKE.btConstraintInfo2_m_J1linearAxis_get(swigCPtr);
      SWIGTYPE_p_float ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_float m_J1angularAxis {
    set {
      BulletDynamicsPINVOKE.btConstraintInfo2_m_J1angularAxis_set(swigCPtr, SWIGTYPE_p_float.getCPtr(value));
    } 
    get {
      IntPtr cPtr = BulletDynamicsPINVOKE.btConstraintInfo2_m_J1angularAxis_get(swigCPtr);
      SWIGTYPE_p_float ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_float m_J2linearAxis {
    set {
      BulletDynamicsPINVOKE.btConstraintInfo2_m_J2linearAxis_set(swigCPtr, SWIGTYPE_p_float.getCPtr(value));
    } 
    get {
      IntPtr cPtr = BulletDynamicsPINVOKE.btConstraintInfo2_m_J2linearAxis_get(swigCPtr);
      SWIGTYPE_p_float ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_float m_J2angularAxis {
    set {
      BulletDynamicsPINVOKE.btConstraintInfo2_m_J2angularAxis_set(swigCPtr, SWIGTYPE_p_float.getCPtr(value));
    } 
    get {
      IntPtr cPtr = BulletDynamicsPINVOKE.btConstraintInfo2_m_J2angularAxis_get(swigCPtr);
      SWIGTYPE_p_float ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
      return ret;
    } 
  }

  public int rowskip {
    set {
      BulletDynamicsPINVOKE.btConstraintInfo2_rowskip_set(swigCPtr, value);
    } 
    get {
      int ret = BulletDynamicsPINVOKE.btConstraintInfo2_rowskip_get(swigCPtr);
      return ret;
    } 
  }

  public SWIGTYPE_p_float m_constraintError {
    set {
      BulletDynamicsPINVOKE.btConstraintInfo2_m_constraintError_set(swigCPtr, SWIGTYPE_p_float.getCPtr(value));
    } 
    get {
      IntPtr cPtr = BulletDynamicsPINVOKE.btConstraintInfo2_m_constraintError_get(swigCPtr);
      SWIGTYPE_p_float ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_float cfm {
    set {
      BulletDynamicsPINVOKE.btConstraintInfo2_cfm_set(swigCPtr, SWIGTYPE_p_float.getCPtr(value));
    } 
    get {
      IntPtr cPtr = BulletDynamicsPINVOKE.btConstraintInfo2_cfm_get(swigCPtr);
      SWIGTYPE_p_float ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_float m_lowerLimit {
    set {
      BulletDynamicsPINVOKE.btConstraintInfo2_m_lowerLimit_set(swigCPtr, SWIGTYPE_p_float.getCPtr(value));
    } 
    get {
      IntPtr cPtr = BulletDynamicsPINVOKE.btConstraintInfo2_m_lowerLimit_get(swigCPtr);
      SWIGTYPE_p_float ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_float m_upperLimit {
    set {
      BulletDynamicsPINVOKE.btConstraintInfo2_m_upperLimit_set(swigCPtr, SWIGTYPE_p_float.getCPtr(value));
    } 
    get {
      IntPtr cPtr = BulletDynamicsPINVOKE.btConstraintInfo2_m_upperLimit_get(swigCPtr);
      SWIGTYPE_p_float ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_int findex {
    set {
      BulletDynamicsPINVOKE.btConstraintInfo2_findex_set(swigCPtr, SWIGTYPE_p_int.getCPtr(value));
    } 
    get {
      IntPtr cPtr = BulletDynamicsPINVOKE.btConstraintInfo2_findex_get(swigCPtr);
      SWIGTYPE_p_int ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_int(cPtr, false);
      return ret;
    } 
  }

  public int m_numIterations {
    set {
      BulletDynamicsPINVOKE.btConstraintInfo2_m_numIterations_set(swigCPtr, value);
    } 
    get {
      int ret = BulletDynamicsPINVOKE.btConstraintInfo2_m_numIterations_get(swigCPtr);
      return ret;
    } 
  }

  public float m_damping {
    set {
      BulletDynamicsPINVOKE.btConstraintInfo2_m_damping_set(swigCPtr, value);
    } 
    get {
      float ret = BulletDynamicsPINVOKE.btConstraintInfo2_m_damping_get(swigCPtr);
      return ret;
    } 
  }

  public btConstraintInfo2() : this(BulletDynamicsPINVOKE.new_btConstraintInfo2(), true) {
  }

}

}