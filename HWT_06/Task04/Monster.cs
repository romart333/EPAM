namespace Task04
{
    using System;

    public interface IMonster : ICreature
    {
        int Damage { get; set; }

        void AttackPlayer();
    }
}
