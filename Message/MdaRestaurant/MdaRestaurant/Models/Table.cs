using MdaRestaurant.Enums;

namespace MdaRestaurant.Models;

internal class Table
{
    public State State { get; set; }

    public int SeatsCount { get; set; }

    public int Id { get; set; }

    public Table(int id)
    {
        Id = id;
        State = State.Free;
        var rnd = new Random();
        SeatsCount = rnd.Next(2, 5);
    }

    public bool SetState(State state)
    {
        if (state == State)
            return false;

        State = state;
        return true;
    }
}
