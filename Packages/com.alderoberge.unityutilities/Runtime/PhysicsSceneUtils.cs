using UnityEngine;

namespace AldeRoberge.UnityUtilities
{
    public static class PhysicsSceneUtils
    {
        public static bool Raycast(this PhysicsScene physicsScene, Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask)
        {
            return physicsScene.Raycast(ray.origin, ray.direction, out hitInfo, maxDistance, layerMask);
        }

        public static bool GetHitUnderMouse(this PhysicsScene scene, Camera camera, out RaycastHit hitInfo, float maxDistance = Mathf.Infinity, int layerMask = Physics.DefaultRaycastLayers, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            return scene.Raycast(ray.origin, ray.direction, out hitInfo, maxDistance, layerMask, queryTriggerInteraction);
        }
    }
}