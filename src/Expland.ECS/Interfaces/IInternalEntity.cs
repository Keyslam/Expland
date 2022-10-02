namespace Expland.ECS;

internal interface IInternalEntity : IEntity {
    EntityID Id { get; }
}