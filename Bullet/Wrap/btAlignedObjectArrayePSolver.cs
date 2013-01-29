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

public class btAlignedObjectArrayePSolver : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal btAlignedObjectArrayePSolver(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(btAlignedObjectArrayePSolver obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~btAlignedObjectArrayePSolver() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          BulletSoftBodyPINVOKE.delete_btAlignedObjectArrayePSolver(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public btAlignedObjectArrayePSolver() : this(BulletSoftBodyPINVOKE.new_btAlignedObjectArrayePSolver__SWIG_0(), true) {
  }

  public btAlignedObjectArrayePSolver(btAlignedObjectArrayePSolver otherArray) : this(BulletSoftBodyPINVOKE.new_btAlignedObjectArrayePSolver__SWIG_1(btAlignedObjectArrayePSolver.getCPtr(otherArray)), true) {
    if (BulletSoftBodyPINVOKE.SWIGPendingException.Pending) throw BulletSoftBodyPINVOKE.SWIGPendingException.Retrieve();
  }

  public int size() {
    int ret = BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_size(swigCPtr);
    return ret;
  }

  public ePSolver._ at(int n) {
    ePSolver._ ret = (ePSolver._)BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_at__SWIG_0(swigCPtr, n);
    return ret;
  }

  public void clear() {
    BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_clear(swigCPtr);
  }

  public void pop_back() {
    BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_pop_back(swigCPtr);
  }

  public void resizeNoInitialize(int newsize) {
    BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_resizeNoInitialize(swigCPtr, newsize);
  }

  public void resize(int newsize, ePSolver._ fillData) {
    BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_resize__SWIG_0(swigCPtr, newsize, (int)fillData);
  }

  public void resize(int newsize) {
    BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_resize__SWIG_1(swigCPtr, newsize);
  }

  public SWIGTYPE_p_ePSolver___ expandNonInitializing() {
    SWIGTYPE_p_ePSolver___ ret = new SWIGTYPE_p_ePSolver___(BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_expandNonInitializing(swigCPtr), false);
    return ret;
  }

  public SWIGTYPE_p_ePSolver___ expand(ePSolver._ fillValue) {
    SWIGTYPE_p_ePSolver___ ret = new SWIGTYPE_p_ePSolver___(BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_expand__SWIG_0(swigCPtr, (int)fillValue), false);
    return ret;
  }

  public SWIGTYPE_p_ePSolver___ expand() {
    SWIGTYPE_p_ePSolver___ ret = new SWIGTYPE_p_ePSolver___(BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_expand__SWIG_1(swigCPtr), false);
    return ret;
  }

  public void push_back(ePSolver._ _Val) {
    BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_push_back(swigCPtr, (int)_Val);
  }

  public int capacity() {
    int ret = BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_capacity(swigCPtr);
    return ret;
  }

  public void reserve(int _Count) {
    BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_reserve(swigCPtr, _Count);
  }

  public void swap(int index0, int index1) {
    BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_swap(swigCPtr, index0, index1);
  }

  public int findBinarySearch(ePSolver._ key) {
    int ret = BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_findBinarySearch(swigCPtr, (int)key);
    return ret;
  }

  public int findLinearSearch(ePSolver._ key) {
    int ret = BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_findLinearSearch(swigCPtr, (int)key);
    return ret;
  }

  public void remove(ePSolver._ key) {
    BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_remove(swigCPtr, (int)key);
  }

  public void initializeFromBuffer(SWIGTYPE_p_void buffer, int size, int capacity) {
    BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_initializeFromBuffer(swigCPtr, SWIGTYPE_p_void.getCPtr(buffer), size, capacity);
  }

  public void copyFromArray(btAlignedObjectArrayePSolver otherArray) {
    BulletSoftBodyPINVOKE.btAlignedObjectArrayePSolver_copyFromArray(swigCPtr, btAlignedObjectArrayePSolver.getCPtr(otherArray));
    if (BulletSoftBodyPINVOKE.SWIGPendingException.Pending) throw BulletSoftBodyPINVOKE.SWIGPendingException.Retrieve();
  }

}

}