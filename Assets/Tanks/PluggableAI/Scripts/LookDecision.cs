using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision {

    
    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        // float speed =10f;
        // float m_AngleTolerance = 0.99f;
        // Transform m_Target = GameObject.FindGameObjectWithTag("Player");
        // Vector3 targetDir = m_Target.position - transform.position;
        // float step = speed * Time.fixedDeltaTime;
        // Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
         RaycastHit hit;
        // controller.enemyStats.m_DotValue = 0f;
        // m_DotValue = Vector3.Dot(targetDir.normalized, newDir.normalized);
        // if (m_DotValue > m_AngleTolerance)
        // {
        //     m_State = NavigationState.Moving;
        // }
       // Debug.DrawRay (controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.lookRange, Color.green);
        
        if (Physics.SphereCast (controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.enemyStats.lookRange)
            && hit.collider.CompareTag ("Player")) {
            controller.chaseTarget = hit.transform;
            return true;
        } else 
        {
            return false;
        }
    }


}