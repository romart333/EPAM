namespace Task04
{
    using System;

    public interface ICreature : ISubject
    {
        int Speed { get; set; }

        void Move();
    }
}
