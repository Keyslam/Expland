namespace Expland.ECS;

public interface IEntity {

    /// <summary>
    /// Get component by Type
    /// </summary>
    /// <typeparam name="T">Type of component to get</typeparam>
    /// <param name="ComponentType">Type of component to get</param>
    /// <returns>Component</returns>
    T GetComponent<T>(Type ComponentType) where T : IComponent;
    
    /// <summary>
    /// Gets component by Generic
    /// </summary>
    /// <typeparam name="T">Type of component to get</typeparam>
    /// <returns>Component</returns>
    T GetComponent<T>() where T : IComponent;

}