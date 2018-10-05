using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GangOfFour.Structural
{
    //Flyweight Pattern Example
    public class MarioCharacterFactory
    {
        private Dictionary<string, MarioSprite> _marioSprites = new Dictionary<string, MarioSprite>();
        public MarioCharacterFactory() {
            _marioSprites.Add("Super", new MarioSprite());
            _marioSprites.Add("Fire", new MarioSprite());
        }
        public MarioSprite GetMario(string key)
        {
            if(!_marioSprites.ContainsKey(key)) 
            {
                _marioSprites.Add(key, new MarioSprite());
                Console.WriteLine($"Mario Sprite with {key} was not found, so creating a new MarioSprite with power: {key}");
                return new MarioSprite();
            }

            var mario = (from marioSprite in _marioSprites
                            where marioSprite.Key ==  key
                           select marioSprite).First();


            return mario.Value;
        }
    }

    public interface IMario
    {
        void changeInto(string marioPower);
    }

    public class MarioSprite : IMario
    {
        public string character {get; private set;}
        public MarioSprite()
        {
            character = "Mario-V2";
        }
        public void changeInto(string marioPower)
        {
            Console.WriteLine($"MarioCharacter intrinsic state: {character}");
            Console.WriteLine($"MarioCharacter extrinsic state: {marioPower}");
        }
    }

    public class UniqueMarioSprite : IMario
    {
        public string character {get; private set;}
        public UniqueMarioSprite()
        {
            character = "Mario-UN-Plot-1";
        }
        public void changeInto(string marioPower)
        {
            Console.WriteLine($"MarioCharacter intrinsic state: {character}");
            Console.WriteLine($"MarioCharacter extrinsic state: {marioPower}");
        }
    }

    class FlyweigthPattern
    {
        static void Main()
        {
            //client
            MarioCharacterFactory factory = new MarioCharacterFactory();

            MarioSprite msFire = factory.GetMario("Fire");
            msFire.changeInto("Red Mario");

            MarioSprite msSuperFire = factory.GetMario("Fire");
            msSuperFire.changeInto("Big and Red Mario");

            MarioSprite msSuper = factory.GetMario("Super");
            msSuper.changeInto("Super Mario");

            MarioSprite msInvincible = factory.GetMario("Invinciple");
            msInvincible.changeInto("Indestrutable Mario");

            UniqueMarioSprite ufw = new UniqueMarioSprite();
            ufw.changeInto("Mario Cart");

            Console.ReadKey();
        }
    }
}
