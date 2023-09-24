namespace _GameLogic_.Castle.Systems
{
    public class CastleSystems : Feature
    {
        public CastleSystems(Contexts contexts)
        {
            Add(new InitializeCastleSystem(contexts));
        }
    }
}