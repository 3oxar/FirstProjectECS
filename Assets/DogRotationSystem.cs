using Unity.Entities;
using UnityEngine;
using UnityEngine.UIElements;

public class DogRotationSystem : ComponentSystem
{
    private EntityQuery _querty;

    protected override void OnCreate()
    {
        _querty = GetEntityQuery(ComponentType.ReadOnly<DogComponent>());
    }

    protected override void OnUpdate()
    {

        Entities.With(_querty).ForEach((Entity entity,Transform transform, DogComponent dogComponent) =>
        {
            var rotation = (transform.rotation.y + dogComponent.Rotation) / 1000;
            transform.Rotate(0, rotation, 0);
        });

    }

}
