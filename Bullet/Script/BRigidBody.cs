using UnityEngine;
using System.Collections;
using BulletCSharp;

[AddComponentMenu("BulletPhysics/BRigidBody")]
public class BRigidBody : MonoBehaviour {
	
 
	//bullet related objs
    private  btRigidBody rigidBodyObj = null;
	private btCollisionObject collisionObject = null;
	private btDefaultMotionState myMotionState = null;
	private btRigidBodyConstructionInfo rbInfo = null;
	
	
	//setup objs
    public float Mass = 0.0f;
	public float Friction = 0.5f;
	public BCollisionShape CollisionShapeObject = null;
	
 
	public btRigidBody GetRigidBody()
	{
		return rigidBodyObj;
	}
	
	void OnDrawGizmos() 
	{
		// draw itself
		
		
		
		// draw collision shape related to it.
		if( CollisionShapeObject == null ) 
		{
			CollisionShapeObject = GetComponent<BCollisionShape>();
		}
		
		// if collision shape and rigidbody in the same gameobject ,turn off collision debug draw.		
		if( CollisionShapeObject != null )
		{
			if( CollisionShapeObject.gameObject == gameObject )
				CollisionShapeObject.SetDebugDraw(false);
			else
				CollisionShapeObject.SetDebugDraw(true);
			
	        CollisionShapeObject.DebugDraw(transform.position,transform.rotation,transform.localScale,Color.red); 
		}
	}
	
	 
	
	public bool OnBulletCreate()
	{
		if( rigidBodyObj != null ) // have created!
		{
			return true;
		}
		
		if( CollisionShapeObject == null )   // if user not give a collision, search it on itself first!
		    CollisionShapeObject = GetComponent<BCollisionShape>();
		
		if( CollisionShapeObject == null )
		{
			Debug.LogError("Bullet RigidBody need a collision shape!");
			return false;
		}
		
		bool cResult = CollisionShapeObject.OnBulletCreate();
		
		if( cResult == false )
		{
			Debug.LogError("Collision Shape Create Error!");
			return false;
		}
		
		btTransform trans = new btTransform();
	    trans.setIdentity();
        btVector3 pos = new btVector3(transform.position.x,transform.position.y,transform.position.z);
	    trans.setOrigin(pos);
		trans.setRotation(new btQuaternion(transform.rotation.x,transform.rotation.y,transform.rotation.z,transform.rotation.w));
 
		//rigidbody is dynamic if and only if mass is non zero, otherwise static
		bool isDynamic = (Mass != 0.0f);

		btVector3 localInertia = new btVector3(0,0,0);
		if (isDynamic)
		{
			 CollisionShapeObject.CalculateLocalInertia(Mass,localInertia);
		}

		//using motionstate is recommended, it provides interpolation capabilities, and only synchronizes 'active' objects
		myMotionState = new btDefaultMotionState(trans);
		rbInfo = new btRigidBodyConstructionInfo(Mass,myMotionState.GetSwigPtr(),CollisionShapeObject.GetCollisionShapePtr(),localInertia.GetSwigPtr());
		rigidBodyObj = new btRigidBody(rbInfo);
		collisionObject = btCollisionObject.GetObjectFromSwigPtr(rigidBodyObj.GetCollisionObject());
		collisionObject.setFriction(Friction);
		return true;

	}
	
	public bool OnBulletExit()
	{
		if( CollisionShapeObject )
			CollisionShapeObject.OnBulletExit();
	
		return true;
	}
 
	void Update()
	{ 
		if( rigidBodyObj != null && myMotionState != null )
		{
		    btTransform ts = new btTransform();
            myMotionState.getWorldTransform(ts);
            btVector3 vecOut = ts.getOrigin();
			btQuaternion rot = ts.getRotation();
			gameObject.transform.position = new Vector3(vecOut.getX(),vecOut.getY(),vecOut.getZ());
			gameObject.transform.rotation = new Quaternion(rot.x(),rot.y(),rot.z(),rot.w());
		}
			 
	}
	 
}
