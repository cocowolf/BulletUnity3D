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

public class btCapsuleShapeX : btCapsuleShape {
  private HandleRef swigCPtr;

  internal btCapsuleShapeX(IntPtr cPtr, bool cMemoryOwn) : base(BulletCollisionPINVOKE.btCapsuleShapeX_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(btCapsuleShapeX obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~btCapsuleShapeX() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          BulletCollisionPINVOKE.delete_btCapsuleShapeX(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public btCapsuleShapeX(float radius, float height) : this(BulletCollisionPINVOKE.new_btCapsuleShapeX(radius, height), true) {
  }

  public override string getName() {
    string ret = BulletCollisionPINVOKE.btCapsuleShapeX_getName(swigCPtr);
    return ret;
  }

}

}
