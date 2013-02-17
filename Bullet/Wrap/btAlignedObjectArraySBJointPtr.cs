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

public class btAlignedObjectArraySBJointPtr : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal btAlignedObjectArraySBJointPtr(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(btAlignedObjectArraySBJointPtr obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~btAlignedObjectArraySBJointPtr() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          BulletSoftBodyPINVOKE.delete_btAlignedObjectArraySBJointPtr(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public btAlignedObjectArraySBJointPtr() : this(BulletSoftBodyPINVOKE.new_btAlignedObjectArraySBJointPtr__SWIG_0(), true) {
  }

  public btAlignedObjectArraySBJointPtr(btAlignedObjectArraySBJointPtr otherArray) : this(BulletSoftBodyPINVOKE.new_btAlignedObjectArraySBJointPtr__SWIG_1(btAlignedObjectArraySBJointPtr.getCPtr(otherArray)), true) {
    if (BulletSoftBodyPINVOKE.SWIGPendingException.Pending) throw BulletSoftBodyPINVOKE.SWIGPendingException.Retrieve();
  }

  public int size() {
    int ret = BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_size(swigCPtr);
    return ret;
  }

  public SBJoint at(int n) {
    IntPtr cPtr = BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_at__SWIG_0(swigCPtr, n);
    SBJoint ret = (cPtr == IntPtr.Zero) ? null : new SBJoint(cPtr, false);
    return ret;
  }

  public void clear() {
    BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_clear(swigCPtr);
  }

  public void pop_back() {
    BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_pop_back(swigCPtr);
  }

  public void resizeNoInitialize(int newsize) {
    BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_resizeNoInitialize(swigCPtr, newsize);
  }

  public void resize(int newsize, SBJoint fillData) {
    BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_resize__SWIG_0(swigCPtr, newsize, SBJoint.getCPtr(fillData));
  }

  public void resize(int newsize) {
    BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_resize__SWIG_1(swigCPtr, newsize);
  }

  public SWIGTYPE_p_p_SBJoint expandNonInitializing() {
    SWIGTYPE_p_p_SBJoint ret = new SWIGTYPE_p_p_SBJoint(BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_expandNonInitializing(swigCPtr), false);
    return ret;
  }

  public SWIGTYPE_p_p_SBJoint expand(SBJoint fillValue) {
    SWIGTYPE_p_p_SBJoint ret = new SWIGTYPE_p_p_SBJoint(BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_expand__SWIG_0(swigCPtr, SBJoint.getCPtr(fillValue)), false);
    return ret;
  }

  public SWIGTYPE_p_p_SBJoint expand() {
    SWIGTYPE_p_p_SBJoint ret = new SWIGTYPE_p_p_SBJoint(BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_expand__SWIG_1(swigCPtr), false);
    return ret;
  }

  public void push_back(SBJoint _Val) {
    BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_push_back(swigCPtr, SBJoint.getCPtr(_Val));
  }

  public int capacity() {
    int ret = BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_capacity(swigCPtr);
    return ret;
  }

  public void reserve(int _Count) {
    BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_reserve(swigCPtr, _Count);
  }

  public void swap(int index0, int index1) {
    BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_swap(swigCPtr, index0, index1);
  }

  public int findBinarySearch(SBJoint key) {
    int ret = BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_findBinarySearch(swigCPtr, SBJoint.getCPtr(key));
    return ret;
  }

  public int findLinearSearch(SBJoint key) {
    int ret = BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_findLinearSearch(swigCPtr, SBJoint.getCPtr(key));
    return ret;
  }

  public void remove(SBJoint key) {
    BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_remove(swigCPtr, SBJoint.getCPtr(key));
  }

  public void initializeFromBuffer(SWIGTYPE_p_void buffer, int size, int capacity) {
    BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_initializeFromBuffer(swigCPtr, SWIGTYPE_p_void.getCPtr(buffer), size, capacity);
  }

  public void copyFromArray(btAlignedObjectArraySBJointPtr otherArray) {
    BulletSoftBodyPINVOKE.btAlignedObjectArraySBJointPtr_copyFromArray(swigCPtr, btAlignedObjectArraySBJointPtr.getCPtr(otherArray));
    if (BulletSoftBodyPINVOKE.SWIGPendingException.Pending) throw BulletSoftBodyPINVOKE.SWIGPendingException.Retrieve();
  }

}

}