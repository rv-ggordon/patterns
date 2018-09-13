using System;

namespace GangOfFour.Creational
{
    public abstract class BuildingHomeFactory 
    {
        public abstract FloorPlanAbstract CreateFloor();
        public abstract RoomPlanAbstract CreateRoom();
    }


    public abstract class FloorPlanAbstract
    {
    }

    public abstract class RoomPlanAbstract
    {
          public abstract void Interact(FloorPlanAbstract f);
    }

    class FloorPlan1 : FloorPlanAbstract
    {
    }

    class RoomPlan1 : RoomPlanAbstract
    {
        public override void Interact(FloorPlanAbstract fp)
        {
            Console.WriteLine(this.GetType().Name + " is part of the  " + fp.GetType().Name);
        }
    }

    class HighFloorPlan2 : FloorPlanAbstract
    {
    }

    class HighRoomPlan2 : RoomPlanAbstract
    {
        public override void Interact(FloorPlanAbstract fp)
        {
            Console.WriteLine(this.GetType().Name + " is part of the " + fp.GetType().Name);
        }
    }

    
    class BuidlingFactory : BuildingHomeFactory
    {
        public override  FloorPlanAbstract CreateFloor()
        {
            Console.WriteLine("Floor plan created from " + this.GetType().Name);
            return new FloorPlan1();
        }

        public override RoomPlanAbstract CreateRoom()
        {
            Console.WriteLine("Room plan created from " + this.GetType().Name);
            return new RoomPlan1();
        }
    }

    class ResortFactory : BuildingHomeFactory
    {
        public override  FloorPlanAbstract CreateFloor()
        {
            Console.WriteLine("Floor plan created from " + this.GetType().Name);
            return new HighFloorPlan2();
        }

        public override RoomPlanAbstract CreateRoom()
        {
            Console.WriteLine("Room plan created from " + this.GetType().Name);
            return new HighRoomPlan2();
        }
    }

    class HighEndHomeFactory : BuildingHomeFactory
    {
        public override FloorPlanAbstract CreateFloor() 
        {
            Console.WriteLine("Floor plan created from " + this.GetType().Name);
            return new HighFloorPlan2();
        }

        public override RoomPlanAbstract CreateRoom()
        {
            Console.WriteLine("Room plan created from " + this.GetType().Name);
            return new HighRoomPlan2();
        }
    }

    public class Client
    {
        private RoomPlanAbstract _roomPlanAbstract;
        private FloorPlanAbstract _floorPlanAbstract;

        public Client(BuildingHomeFactory factory) 
        {
            _floorPlanAbstract = factory.CreateFloor();
            _roomPlanAbstract = factory.CreateRoom();
        }

        public void Run()
        {
            _roomPlanAbstract.Interact(_floorPlanAbstract);
        }

    }


    class AbstractFactoryMain
    {
        static void Main()
        {
            BuildingHomeFactory building = new BuidlingFactory();
            Client clientA = new Client(building);
            clientA.Run();

            BuildingHomeFactory factory2 = new HighEndHomeFactory();
            Client clientB = new Client(factory2);
            clientB.Run();

            ResortFactory factory3 = new ResortFactory();
            Client clientC = new Client(factory3);
            clientB.Run();

            Console.ReadKey();
        }
    }
}
