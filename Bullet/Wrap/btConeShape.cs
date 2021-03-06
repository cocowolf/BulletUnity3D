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

public class btConeShape : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;
  private SWIGTYPE_p_btCollisionShape swigWrapPtr;

  internal btConeShape(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
    swigWrapPtr = new SWIGTYPE_p_btCollisionShape(cPtr, true);
  }

  internal static HandleRef getCPtr(btConeShape obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~btConeShape() {
    Dispose();
  }

  public SWIGTYPE_p_btCollisionShape GetSwigPtr()
  {
      return swigWrapPtr;
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          BulletCollisionPINVOKE.delete_btConeShape(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
        swigWrapPtr = new SWIGTYPE_p_btCollisionShape(IntPtr.Zero, true);
      }
      GC.SuppressFinalize(this);
    }
  }

  public btConeShape(float radius, float height) : this(BulletCollisionPINVOKE.new_btConeShape(radius, height), true) {
  }

  public virtual SWIGTYPE_p_btVector3 localGetSupportingVertex(SWIGTYPE_p_btVector3 vec) {
    SWIGTYPE_p_btVector3 ret = new SWIGTYPE_p_btVector3(BulletCollisionPINVOKE.btConeShape_localGetSupportingVertex(swigCPtr, SWIGTYPE_p_btVector3.getCPtr(vec)), true);
    if (BulletCollisionPINVOKE.SWIGPendingException.Pending) throw BulletCollisionPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual SWIGTYPE_p_btVector3 localGetSupportingVertexWithoutMargin(SWIGTYPE_p_btVector3 vec) {
    SWIGTYPE_p_btVector3 ret = new SWIGTYPE_p_btVector3(BulletCollisionPINVOKE.btConeShape_localGetSupportingVertexWithoutMargin(swigCPtr, SWIGTYPE_p_btVector3.getCPtr(vec)), true);
    if (BulletCollisionPINVOKE.SWIGPendingException.Pending) throw BulletCollisionPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual void batchedUnitVectorGetSupportingVertexWithoutMargin(SWIGTYPE_p_btVector3 vectors, SWIGTYPE_p_btVector3 supportVerticesOut, int numVectors) {
    BulletCollisionPINVOKE.btConeShape_batchedUnitVectorGetSupportingVertexWithoutMargin(swigCPtr, SWIGTYPE_p_btVector3.getCPtr(vectors), SWIGTYPE_p_btVector3.getCPtr(supportVerticesOut), numVectors);
  }

  public float getRadius() {
    float ret = BulletCollisionPINVOKE.btConeShape_getRadius(swigCPtr);
    return ret;
  }

  public float getHeight() {
    float ret = BulletCollisionPINVOKE.btConeShape_getHeight(swigCPtr);
    return ret;
  }

  public virtual void calculateLocalInertia(float mass, SWIGTYPE_p_btVector3 inertia) {
    BulletCollisionPINVOKE.btConeShape_calculateLocalInertia(swigCPtr, mass, SWIGTYPE_p_btVector3.getCPtr(inertia));
    if (BulletCollisionPINVOKE.SWIGPendingException.Pending) throw BulletCollisionPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual string getName() {
    string ret = BulletCollisionPINVOKE.btConeShape_getName(swigCPtr);
    return ret;
  }

  public void setConeUpIndex(int upIndex) {
    BulletCollisionPINVOKE.btConeShape_setConeUpIndex(swigCPtr, upIndex);
  }

  public int getConeUpIndex() {
    int ret = BulletCollisionPINVOKE.btConeShape_getConeUpIndex(swigCPtr);
    return ret;
  }

  public virtual SWIGTYPE_p_btVector3 getAnisotropicRollingFrictionDirection() {
    SWIGTYPE_p_btVector3 ret = new SWIGTYPE_p_btVector3(BulletCollisionPINVOKE.btConeShape_getAnisotropicRollingFrictionDirection(swigCPtr), true);
    return ret;
  }

  public virtual void setLocalScaling(SWIGTYPE_p_btVector3 scaling) {
    BulletCollisionPINVOKE.btConeShape_setLocalScaling(swigCPtr, SWIGTYPE_p_btVector3.getCPtr(scaling));
    if (BulletCollisionPINVOKE.SWIGPendingException.Pending) throw BulletCollisionPINVOKE.SWIGPendingException.Retrieve();
  }

}

}
