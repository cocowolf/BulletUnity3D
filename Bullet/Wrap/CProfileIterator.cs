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

public class CProfileIterator : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal CProfileIterator(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(CProfileIterator obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~CProfileIterator() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          LinearMathPINVOKE.delete_CProfileIterator(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public void First() {
    LinearMathPINVOKE.CProfileIterator_First(swigCPtr);
  }

  public void Next() {
    LinearMathPINVOKE.CProfileIterator_Next(swigCPtr);
  }

  public bool Is_Done() {
    bool ret = LinearMathPINVOKE.CProfileIterator_Is_Done(swigCPtr);
    return ret;
  }

  public bool Is_Root() {
    bool ret = LinearMathPINVOKE.CProfileIterator_Is_Root(swigCPtr);
    return ret;
  }

  public void Enter_Child(int index) {
    LinearMathPINVOKE.CProfileIterator_Enter_Child(swigCPtr, index);
  }

  public void Enter_Largest_Child() {
    LinearMathPINVOKE.CProfileIterator_Enter_Largest_Child(swigCPtr);
  }

  public void Enter_Parent() {
    LinearMathPINVOKE.CProfileIterator_Enter_Parent(swigCPtr);
  }

  public string Get_Current_Name() {
    string ret = LinearMathPINVOKE.CProfileIterator_Get_Current_Name(swigCPtr);
    return ret;
  }

  public int Get_Current_Total_Calls() {
    int ret = LinearMathPINVOKE.CProfileIterator_Get_Current_Total_Calls(swigCPtr);
    return ret;
  }

  public float Get_Current_Total_Time() {
    float ret = LinearMathPINVOKE.CProfileIterator_Get_Current_Total_Time(swigCPtr);
    return ret;
  }

  public SWIGTYPE_p_void Get_Current_UserPointer() {
    IntPtr cPtr = LinearMathPINVOKE.CProfileIterator_Get_Current_UserPointer(swigCPtr);
    SWIGTYPE_p_void ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_void(cPtr, false);
    return ret;
  }

  public void Set_Current_UserPointer(SWIGTYPE_p_void ptr) {
    LinearMathPINVOKE.CProfileIterator_Set_Current_UserPointer(swigCPtr, SWIGTYPE_p_void.getCPtr(ptr));
  }

  public string Get_Current_Parent_Name() {
    string ret = LinearMathPINVOKE.CProfileIterator_Get_Current_Parent_Name(swigCPtr);
    return ret;
  }

  public int Get_Current_Parent_Total_Calls() {
    int ret = LinearMathPINVOKE.CProfileIterator_Get_Current_Parent_Total_Calls(swigCPtr);
    return ret;
  }

  public float Get_Current_Parent_Total_Time() {
    float ret = LinearMathPINVOKE.CProfileIterator_Get_Current_Parent_Total_Time(swigCPtr);
    return ret;
  }

}

}
