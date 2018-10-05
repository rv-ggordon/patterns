using System;
using System.Collections.Generic;

namespace GangOfFour.Structural
{
    //Decorator Pattern Example
    public abstract class PictureAbstraction
    {
        public abstract void Hang();
    }

    public class Picture : PictureAbstraction
    {
        public override void Hang()
        {
            Console.WriteLine("Picture.Hang() initialized");
        }
    }

    public class Decorator : PictureAbstraction
    {
        private PictureAbstraction picture;

        public void SetComponent(PictureAbstraction picture)
        {
            this.picture = picture;
        }

        public override void Hang()
        {
            if(null != picture)
            {
               picture.Hang();
            }
        }
    }

    public class Frame : Decorator
    {
        private string newState;
        public Frame() {
            newState = "Frame Created";
            BuildFrame();
        }
        public void BuildFrame()
        {
            Console.WriteLine($"Frame Status: {newState}");
            Console.WriteLine("Picture Frame Built");
        }
    }

    public class FrameSolid : Decorator
    {
       public override void Hang()
       {
           base.Hang();
           Console.WriteLine("Hung the new Solid Frame");
           AddedBehavior();
       } 

       public void AddedBehavior()
       {
            Console.WriteLine("Needed to add 50lb anchors to support painting");
       }
    }

    class DecoratorPattern
    {
        static void Main()
        {
            Picture picture = new Picture();
            Frame frame = new Frame();
            FrameSolid frameSolid = new FrameSolid();

            //link decorators
            frame.SetComponent(picture);
            frameSolid.SetComponent(frame);

            frameSolid.Hang();

            Console.ReadKey();
        }
    }
}
