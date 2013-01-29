using UnityEngine;
using System.Collections;
using BulletCSharp;


[AddComponentMenu("BulletPhysics/BWorld")]
public class BWorld : MonoBehaviour {

	public enum BulletWorldType
	{
		DiscreteDynamics = 0,
		SoftRigidDynamics = 1,
	};
	
	// set objs
	public Vector3 Gravity = new Vector3(0, -10, 0);
	public BulletWorldType WorldType = BulletWorldType.DiscreteDynamics;
	
	
	
	
	// bullet objs
	private btCollisionWorld collisionWorld = null;
	private btDiscreteDynamicsWorld dynamicsWorld = null;
	private BRigidBody[] rigidBodyArray = null;
	private BConstraint[] constraintArray = null;
	private BSoftBody[] softBodyArray = null;
	
	private btDefaultCollisionConfiguration collisionConfiguration;
	private btCollisionDispatcher dispatcher;
	private btDbvtBroadphase overlappingPairCache;
	private btSequentialImpulseConstraintSolver solver;
  
	// soft body world
	private btSoftRigidDynamicsWorld softDynamicsWorld = null;
	private btSoftBodyWorldInfo softBodyWorldInfo;
	private btSoftBodyRigidBodyCollisionConfiguration softCollisionConfiguration;
	private btAxisSweep3 axisBroadphase;
	private btSparseSdf3 sparseSdf;
	
	void CreateSoftDynamicsWorld()
	{
		btVector3 gravityVec = new btVector3(Gravity.x, Gravity.y, Gravity.z);
		btCollisionObject tempObject = new btCollisionObject();
		btConstraintSetting tempObject2 = new btConstraintSetting();
		
		softBodyWorldInfo = new btSoftBodyWorldInfo();
		///collision configuration contains default setup for memory, collision setup. Advanced users can create their own configuration.
	    softCollisionConfiguration = new btSoftBodyRigidBodyCollisionConfiguration();				

	    ///use the default collision dispatcher. For parallel processing you can use a diffent dispatcher (see Extras/BulletMultiThreaded)
        dispatcher = new btCollisionDispatcher(softCollisionConfiguration.GetSwigPtr());
		softBodyWorldInfo.m_dispatcher = dispatcher.GetSwigPtr();
		
	    btVector3 worldAabbMin = new btVector3(-1000,-1000,-1000);
	    btVector3 worldAabbMax = new btVector3(1000,1000,1000);

	    axisBroadphase = new btAxisSweep3(worldAabbMin.GetSwigPtr(),worldAabbMax.GetSwigPtr(),32766);
        softBodyWorldInfo.m_broadphase = axisBroadphase.GetSwigPtr();
	    ///the default constraint solver. For parallel processing you can use a different solver (see Extras/BulletMultiThreaded)
	    solver = new btSequentialImpulseConstraintSolver();
       
        softDynamicsWorld = new btSoftRigidDynamicsWorld(dispatcher.GetSwigPtr(), axisBroadphase.GetSwigPtr(), solver.GetSwigPtr(), softCollisionConfiguration.GetSwigPtr());
        dynamicsWorld = btDiscreteDynamicsWorld.GetObjectFromSwigPtr(softDynamicsWorld.getDiscreteDynamicsWorld());
		SWIGTYPE_p_btCollisionWorld collisionWorldPtr = dynamicsWorld.getCollisionWorld();
		collisionWorld = btCollisionWorld.GetObjectFromSwigPtr(collisionWorldPtr);
        dynamicsWorld.setGravity(gravityVec.GetSwigPtr());
		softBodyWorldInfo.m_gravity = gravityVec.GetSwigPtr();
		btVector3 water_nomalVec = new btVector3(0,0,0);
		softBodyWorldInfo.air_density		=	1.2f;
	    softBodyWorldInfo.water_density	    =	0;
	    softBodyWorldInfo.water_offset		=	0;
	    softBodyWorldInfo.water_normal		=	water_nomalVec.GetSwigPtr();
		sparseSdf = softBodyWorldInfo.m_sparsesdf;
		sparseSdf.Initialize();
		AddBulletObjects();
		
	}
	
	void AddBulletObjects()
	{
		// at the end add rigidbody to world	
		rigidBodyArray = GameObject.FindObjectsOfType(typeof(BRigidBody)) as BRigidBody[];
		if(rigidBodyArray != null && rigidBodyArray.Length > 0 )
		{
			foreach( var r in rigidBodyArray)
			{
				bool result = r.OnBulletCreate();
				if( result )
				    dynamicsWorld.addRigidBody(r.GetRigidBody());
				else
				{
					Debug.LogError("Rigid Body Create Error for GameObject:"+r.gameObject.name);
				}
			}
		}
		
		if( WorldType == BulletWorldType.SoftRigidDynamics )
		{
			softBodyArray = GameObject.FindObjectsOfType(typeof(BSoftBody)) as BSoftBody[];
			if(softBodyArray != null && softBodyArray.Length > 0 )
			{
				foreach( var r in softBodyArray)
				{
					bool result = r.OnBulletCreate(softBodyWorldInfo);
					if( result )
					    softDynamicsWorld.addSoftBody(r.GetSofyBodyObj());
					else
					{
						Debug.LogError("SoftBody Create Error for GameObject:"+r.gameObject.name);
					}
				}
			}
		}
		
		constraintArray = GameObject.FindObjectsOfType(typeof(BConstraint)) as BConstraint[];
		if(constraintArray != null && constraintArray.Length > 0 )
		{
			foreach( var r in constraintArray)
			{
				bool result = r.OnBulletCreate();
				if( result )
				    dynamicsWorld.addConstraint(r.GetConstraintPtr());
				else
				{
					Debug.LogError("Constraint Create Error for GameObject:"+r.gameObject.name);
				}
			}
		}
	}
	
	void CreateDiscreteDynamicsWorld()
	{
		 
		btVector3 gravityVec = new btVector3(Gravity.x, Gravity.y, Gravity.z);
		///collision configuration contains default setup for memory, collision setup. Advanced users can create their own configuration.
	    collisionConfiguration = new btDefaultCollisionConfiguration();				

	    ///use the default collision dispatcher. For parallel processing you can use a diffent dispatcher (see Extras/BulletMultiThreaded)
        dispatcher = new btCollisionDispatcher(collisionConfiguration.GetSwigPtr());

	    ///btDbvtBroadphase is a good general purpose broadphase. You can also try out btAxis3Sweep.
	    overlappingPairCache = new btDbvtBroadphase();
 
	    ///the default constraint solver. For parallel processing you can use a different solver (see Extras/BulletMultiThreaded)
	    solver = new btSequentialImpulseConstraintSolver();
      
        dynamicsWorld = new btDiscreteDynamicsWorld(dispatcher.GetSwigPtr(), overlappingPairCache.GetSwigPtr(), solver.GetSwigPtr(), collisionConfiguration.GetSwigPtr());

        SWIGTYPE_p_btCollisionWorld collisionWorldPtr = dynamicsWorld.getCollisionWorld();
		collisionWorld = btCollisionWorld.GetObjectFromSwigPtr(collisionWorldPtr);
		
        dynamicsWorld.setGravity(gravityVec.GetSwigPtr());
		
		
		AddBulletObjects();
 
	}
	
	void OnDrawGizmos() 
	{
		
	}
	
	void UpdateDiscreteDynamicsWorld()
	{
		dynamicsWorld.stepSimulation(Time.deltaTime);
	}
	
	void UpdateSoftDynamicsWorld()
	{
		 softDynamicsWorld.stepSimulation(Time.deltaTime);
		sparseSdf.GarbageCollect();
	}
	
	// Use this for initialization
	void Awake () 
	{
		if( WorldType == BulletWorldType.DiscreteDynamics )
			CreateDiscreteDynamicsWorld();
		else if( WorldType == BulletWorldType.SoftRigidDynamics)
			CreateSoftDynamicsWorld();
		
		 
	}
	
 
	
	// Update is called once per frame
	void Update ()
	{
        if( WorldType == BulletWorldType.DiscreteDynamics )
			UpdateDiscreteDynamicsWorld();
		else if( WorldType == BulletWorldType.SoftRigidDynamics )
			UpdateSoftDynamicsWorld();
 
	}
	
	void OnApplicationQuit()
	{
		OnBulletExit();
	}
	
	void OnBulletExit()
	{
		if(constraintArray != null && constraintArray.Length > 0 )
		{
			foreach( var r in constraintArray)
			{
				SWIGTYPE_p_btTypedConstraint c = r.GetConstraintPtr();
				if( c != null )
				    dynamicsWorld.removeConstraint(c);
				r.OnBulletExit();
			}
			constraintArray = null;
		}
		
		if(rigidBodyArray != null && rigidBodyArray.Length > 0 )
		{
			foreach( var r in rigidBodyArray)
			{
				btRigidBody rigid = r.GetRigidBody();
				if( rigid != null )
				    dynamicsWorld.removeRigidBody(rigid);
				r.OnBulletExit();
			}
			rigidBodyArray = null;
		}
		
		if( WorldType == BulletWorldType.SoftRigidDynamics && softBodyArray != null && softBodyArray.Length > 0 )
		{
			foreach( var r in softBodyArray)
			{
				btSoftBody sb = r.GetSofyBodyObj();
				if( sb != null )
				    softDynamicsWorld.removeSoftBody(sb);
				r.OnBulletExit();
			}
			softBodyArray = null;
		}
		
	}
}
