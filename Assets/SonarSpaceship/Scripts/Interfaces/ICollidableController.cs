namespace SonarSpaceship
{
    public interface ICollidableController : IBehaviour
    {
        float Bounciness { get; set; }

        void Collide();

        event CollidedDelegate OnCollided;
    }
}
