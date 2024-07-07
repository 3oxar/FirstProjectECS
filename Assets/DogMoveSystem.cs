using Unity.Entities;
using UnityEngine;

public class DogMoveSystem : ComponentSystem
{
    private EntityQuery _querty;

    protected override void OnCreate()
    {
        _querty = GetEntityQuery(ComponentType.ReadOnly<DogComponent>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_querty).ForEach((Entity entity, Transform transform, DogComponent dogComponent) =>
        {
            var position = transform.position;
            position.x += dogComponent.Speed / 10000;
            transform.position = position;
        });
    }
}
