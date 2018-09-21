using System;

namespace GangOfFour.Structural
{

    //Adapter Example
    public class Ratchet 
    {
	   private readonly String _currentDriver =  "1/2 Drive is currently in use";

       public Ratchet() 
       {
		   Console.WriteLine(_currentDriver);
       }
	   public virtual void Drive(){}
    }

    public class AdapterSocket : Ratchet
    {
        private Socket _socket = new Socket();

        public override void Drive()
        {
            _socket.ChangesDrive();
        }

    }

    class Socket{
        public void ChangesDrive()
        {
            Console.WriteLine("Drive changed to use a 1/4 Drive (female)");
        }
    }

    class AdapterPattern
    {
        static void Main()
        {

            Ratchet ratchet = new AdapterSocket();
	        ratchet.Drive(); 

            Console.ReadKey();
        }
    }
}
