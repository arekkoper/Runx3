namespace Code.Domain.Entities
{
    public class Player
    {
        public int Score { get; set; }
        public float Speed { get; set; }
        public float TimeToMaxSpeed { get; set; }
        public float TimeToLoseMaxSpeed { get; set; }
        public float ReverseMomentumMultiplier { get; set; }
        public float VelocityGainPerSecond { get { return Speed / TimeToMaxSpeed; } }
        public float VelocityLossPerSecond { get { return Speed / TimeToLoseMaxSpeed; } }
    }

}
