using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float mSpeed;
    [SerializeField]
    private Vector3[] mTargetPosition;
    private int mNowTarget;
    private bool mPatrolDirection;
    [SerializeField]
    private float mWaitTime;
    private bool mIsWait;
    private float mStartTime;
    void Start()
    {
        mNowTarget = 0;
        mPatrolDirection = true;
        if (mTargetPosition.Length > 0)
        {
            transform.position = mTargetPosition[0];
        }

        mIsWait = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (mTargetPosition.Length == 0) return;

        if(Vector3.Distance(transform.position,mTargetPosition[mNowTarget]) > 0.1f)
        {
            Vector3 direction = Vector3.Normalize(mTargetPosition[mNowTarget] - transform.position);
            Vector3 position = transform.position;
            position += direction * mSpeed * Time.deltaTime;

            transform.position = position;
            float ZRotation = Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x);
            Quaternion targetRotation = Quaternion.Euler(0.0f, 0.0f, ZRotation);


            transform.rotation = targetRotation;
        }
        else
        {
            if(!mIsWait)
            {
                transform.position = mTargetPosition[mNowTarget];
                mIsWait = !mIsWait;
                mStartTime = Time.time;
            }
            else
            {

                if(Time.time - mStartTime > mWaitTime)
                {
                    mNowTarget += mPatrolDirection ? 1 : -1;
                    if (mNowTarget >= mTargetPosition.Length || mNowTarget < 0)
                    {
                        mPatrolDirection = !mPatrolDirection;
                        mNowTarget += mPatrolDirection ? 1 : -1;
                    }

                    mIsWait = !mIsWait;
                }
              
            }
           
        
        }
    }
}
