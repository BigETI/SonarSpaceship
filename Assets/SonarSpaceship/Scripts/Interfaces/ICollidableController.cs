namespace SonarSpaceship
{
    public interface ICollidableController : IBehaviour
    {
        float MaximalDamage { get; set; }

        bool IsExplosive { get; set; }

        float Bounciness { get; set; }

        void Collide();

        event CollidedDelegate OnCollided;
    }
}
