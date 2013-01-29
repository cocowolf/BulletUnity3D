using UnityEngine;
using System.Collections;
using BulletCSharp;

[AddComponentMenu("BulletPhysics/BConstraint")]
public class BConstraint : MonoBehaviour {
	
	public enum ConstraintTypes
	{
		Point2Point = 0,
		Hinge = 1,
		Slider = 2,
		ConeTwist = 3,
		Gear = 4,
		Generic6Dof = 5,
	};
	
	public ConstraintTypes ConstraintType = ConstraintTypes.Point2Point;
	
	private SWIGTYPE_p_btTypedConstraint constraintPtr = null;
	
	public BRigidBody RigidBodyA = null;
	public BRigidBody RigidBodyB = null;
	public Vector3 PivotInA = new Vector3(0,0,0);
	public Vector3 PivotInB = new Vector3(0,0,0);
	public Vector3 AxisInA = new Vector3(0,1,0);
	public Vector3 AxisInB = new Vector3(0,1,0);
	
	
	
	//Point2Point type
	private btPoint2PointConstraint point2pointConstraint;
	
	
	//Hinge type
	private btHingeConstraint hingeConstraint;
	public bool useReferenceFrameAHinge = false;
	
	//sider type
	private btSliderConstraint sliderConstraint;
	public bool useLinearReferenceFrameASlider = false;
	public Vector3 RotationA = new Vector3(0,0,0);
	public Vector3 RotationB = new Vector3(0,0,0);
	
	//cone twist
	private btConeTwistConstraint coneTwistConstraint;
	
	//Gear 
	private btGearConstraint gearConstraint;
	public float GearConstraintRatio = 0.0f;
	
	//Generic6Dof
	private btGeneric6DofConstraint generic6Dof;
	public bool UseLinearLimit = false;
	public Vector3 LinearLowerLimit = new Vector3(-10,0,0);
	public Vector3 LinearUpperLimit = new Vector3(10,0,0);
	public bool UseAngularLimit = false;
	public Vector3 AngularLowerLimit = new Vector3(0,0,0);
	public Vector3 AngularUpperLimit = new Vector3(0,0,0);
	 
	public bool OnBulletCreate()
	{
		if( ConstraintType == ConstraintTypes.Point2Point )
		{
			if( RigidBodyA != null && RigidBodyB == null )
			{
				btVector3 vecA = new btVector3(PivotInA.x,PivotInA.y,PivotInA.z);
				btRigidBody rA = RigidBodyA.GetRigidBody();
				if( rA == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				point2pointConstraint = new btPoint2PointConstraint(rA,vecA.GetSwigPtr());
				constraintPtr = point2pointConstraint.GetSwigPtr();
				return true;
			}
			else if( RigidBodyA != null && RigidBodyB != null )
			{
				btVector3 vecA = new btVector3(PivotInA.x,PivotInA.y,PivotInA.z);
				btRigidBody rA = RigidBodyA.GetRigidBody();
				if( rA == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				btVector3 vecB = new btVector3(PivotInB.x,PivotInB.y,PivotInB.z);
				btRigidBody rB = RigidBodyB.GetRigidBody();
				if( rB == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				point2pointConstraint = new btPoint2PointConstraint(rA,rB,vecA.GetSwigPtr(),vecB.GetSwigPtr());
				constraintPtr = point2pointConstraint.GetSwigPtr();
				return true;
			}
			
			return false;
		}
		else if( ConstraintType == ConstraintTypes.Hinge )
		{
			if( RigidBodyA != null && RigidBodyB == null )
			{
				btVector3 vecA = new btVector3(PivotInA.x,PivotInA.y,PivotInA.z);
				btVector3 axisA = new btVector3(AxisInA.x,AxisInA.y,AxisInA.z);
				btRigidBody rA = RigidBodyA.GetRigidBody();
				if( rA == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				hingeConstraint = new btHingeConstraint(rA,vecA.GetSwigPtr(),axisA.GetSwigPtr(),useReferenceFrameAHinge);
				constraintPtr = hingeConstraint.GetSwigPtr();
				return true;
			}
			else if( RigidBodyA != null && RigidBodyB != null )
			{
				btVector3 vecA = new btVector3(PivotInA.x,PivotInA.y,PivotInA.z);
				btVector3 axisA = new btVector3(AxisInA.x,AxisInA.y,AxisInA.z);
				btRigidBody rA = RigidBodyA.GetRigidBody();
				if( rA == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				btVector3 vecB = new btVector3(PivotInB.x,PivotInB.y,PivotInB.z);
				btVector3 axisB = new btVector3(AxisInB.x,AxisInB.y,AxisInB.z);
				btRigidBody rB = RigidBodyB.GetRigidBody();
				if( rB == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				hingeConstraint = new btHingeConstraint(rA,rB,vecA.GetSwigPtr(),vecB.GetSwigPtr(),axisA.GetSwigPtr(),axisB.GetSwigPtr(),useReferenceFrameAHinge);
				constraintPtr = hingeConstraint.GetSwigPtr();
				return true;
			}
			
			return false;
		}
		else if( ConstraintType == ConstraintTypes.Slider )
		{
			if( RigidBodyA != null && RigidBodyB == null )
			{
				btVector3 vecA = new btVector3(PivotInA.x,PivotInA.y,PivotInA.z);
				btQuaternion rot = new btQuaternion(RotationA.x,RotationA.y,RotationA.z);
				btTransform transA = new btTransform();
				transA.setIdentity();
				transA.setOrigin(vecA);
				transA.setRotation(rot);
				btRigidBody rA = RigidBodyA.GetRigidBody();
				if( rA == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				sliderConstraint = new btSliderConstraint(rA,transA.GetSwigPtr(),useLinearReferenceFrameASlider);
				constraintPtr = sliderConstraint.GetSwigPtr();
				return true;
			}
			else if( RigidBodyA != null && RigidBodyB != null )
			{
				btVector3 vecA = new btVector3(PivotInA.x,PivotInA.y,PivotInA.z);
				btQuaternion rotA = new btQuaternion(RotationA.x,RotationA.y,RotationA.z);
				btTransform transA = new btTransform();
				transA.setIdentity();
				transA.setOrigin(vecA);
				transA.setRotation(rotA);
				btRigidBody rA = RigidBodyA.GetRigidBody();
				if( rA == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				btVector3 vecB = new btVector3(PivotInB.x,PivotInB.y,PivotInB.z);
				btQuaternion rotB = new btQuaternion(RotationB.x,RotationB.y,RotationB.z);
				btTransform transB = new btTransform();
				transB.setIdentity();
				transB.setOrigin(vecB);
				transB.setRotation(rotB);
				btRigidBody rB = RigidBodyB.GetRigidBody();
				if( rB == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				sliderConstraint = new btSliderConstraint(rA,rB,transA.GetSwigPtr(),transB.GetSwigPtr(), useLinearReferenceFrameASlider);
				constraintPtr = sliderConstraint.GetSwigPtr();
				return true;
			}
			
			return false;
		}
		else if( ConstraintType == ConstraintTypes.ConeTwist )
		{
			if( RigidBodyA != null && RigidBodyB == null )
			{
				btVector3 vecA = new btVector3(PivotInA.x,PivotInA.y,PivotInA.z);
				btQuaternion rot = new btQuaternion(RotationA.x,RotationA.y,RotationA.z);
				btTransform transA = new btTransform();
				transA.setIdentity();
				transA.setOrigin(vecA);
				transA.setRotation(rot);
				btRigidBody rA = RigidBodyA.GetRigidBody();
				if( rA == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				coneTwistConstraint = new btConeTwistConstraint(rA,transA.GetSwigPtr());
				constraintPtr = coneTwistConstraint.GetSwigPtr();
				return true;
			}
			else if( RigidBodyA != null && RigidBodyB != null )
			{
				btVector3 vecA = new btVector3(PivotInA.x,PivotInA.y,PivotInA.z);
				btQuaternion rotA = new btQuaternion(RotationA.x,RotationA.y,RotationA.z);
				btTransform transA = new btTransform();
				transA.setIdentity();
				transA.setOrigin(vecA);
				transA.setRotation(rotA);
				btRigidBody rA = RigidBodyA.GetRigidBody();
				if( rA == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				btVector3 vecB = new btVector3(PivotInB.x,PivotInB.y,PivotInB.z);
				btQuaternion rotB = new btQuaternion(RotationB.x,RotationB.y,RotationB.z);
				btTransform transB = new btTransform();
				transB.setIdentity();
				transB.setOrigin(vecB);
				transB.setRotation(rotB);
				btRigidBody rB = RigidBodyB.GetRigidBody();
				if( rB == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				coneTwistConstraint = new btConeTwistConstraint(rA,rB,transA.GetSwigPtr(),transB.GetSwigPtr());
				constraintPtr = coneTwistConstraint.GetSwigPtr();
				return true;
			}
			
			return false;
		}
		else if( ConstraintType == ConstraintTypes.Gear )
		{
			if( RigidBodyA != null && RigidBodyB != null )
			{
				btVector3 axisA = new btVector3(AxisInA.x,AxisInA.y,AxisInA.z);
			    btVector3 axisB = new btVector3(AxisInB.x,AxisInB.y,AxisInB.z);
				btRigidBody rA = RigidBodyA.GetRigidBody();
				if( rA == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				btRigidBody rB = RigidBodyB.GetRigidBody();
				if( rB == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				gearConstraint = new btGearConstraint(rA,rB,axisA.GetSwigPtr(),axisB.GetSwigPtr(),GearConstraintRatio);
				constraintPtr = gearConstraint.GetSwigPtr();
				return true;
			}
			return false;
		}
		else if( ConstraintType == ConstraintTypes.Generic6Dof )
		{
			if( RigidBodyA != null && RigidBodyB != null )
			{
				btVector3 vecA = new btVector3(PivotInA.x,PivotInA.y,PivotInA.z);
				btQuaternion rotA = new btQuaternion(RotationA.x,RotationA.y,RotationA.z);
				btTransform transA = new btTransform();
				transA.setIdentity();
				transA.setOrigin(vecA);
				transA.setRotation(rotA);
				btRigidBody rA = RigidBodyA.GetRigidBody();
				if( rA == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				btVector3 vecB = new btVector3(PivotInB.x,PivotInB.y,PivotInB.z);
				btQuaternion rotB = new btQuaternion(RotationB.x,RotationB.y,RotationB.z);
				btTransform transB = new btTransform();
				transB.setIdentity();
				transB.setOrigin(vecB);
				transB.setRotation(rotB);
				btRigidBody rB = RigidBodyB.GetRigidBody();
				if( rB == null )
				{
					Debug.LogError("Can't Create Constraint for null RigidBody!");
					return false;
				}
				generic6Dof = new btGeneric6DofConstraint(rA,rB,transA.GetSwigPtr(),transB.GetSwigPtr(),useLinearReferenceFrameASlider);
				if( UseLinearLimit )
				{
				    btVector3 lowerVec = new btVector3(LinearLowerLimit.x,LinearLowerLimit.y,LinearLowerLimit.z);
				    btVector3 uppderVec = new btVector3(LinearUpperLimit.x,LinearUpperLimit.y,LinearUpperLimit.z);
				    generic6Dof.setLinearLowerLimit(lowerVec.GetSwigPtr());
				    generic6Dof.setLinearUpperLimit(uppderVec.GetSwigPtr());
				}
				if( UseAngularLimit )
				{
					btVector3 lowerVec = new btVector3(AngularLowerLimit.x,AngularLowerLimit.y,AngularLowerLimit.z);
				    btVector3 uppderVec = new btVector3(AngularUpperLimit.x,AngularUpperLimit.y,AngularUpperLimit.z);
				    generic6Dof.setAngularLowerLimit(lowerVec.GetSwigPtr());
				    generic6Dof.setAngularUpperLimit(uppderVec.GetSwigPtr());
				}
			 
				constraintPtr = generic6Dof.GetSwigPtr();
				return true;
			}
			
			return false;
		}
		
		return false;
	}
	
	public SWIGTYPE_p_btTypedConstraint GetConstraintPtr()
	{
		return constraintPtr;
	}
	
	public bool OnBulletExit()
	{
		return true;
	}
	
	
}
