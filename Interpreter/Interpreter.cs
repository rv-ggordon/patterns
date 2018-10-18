using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace GangOfFour.Behaviorial
{
    //Interpreter Pattern
    public abstract class Expression
    {
        public const string BLACK = "BK";
        public const string BROWN = "BR";
        public const string RED = "RD";
        public const string ORANGE = "OR";
        public const string GREEN = "GN";
        public const string BLUE = "BL";
        public const string VIOLET = "VT";
        public const string YELLOW = "YW";
        public const string WHITE = "WT";
        public const string GRAY = "GR";
        public Circuit context {get; set;}

        public void Interpret(Circuit newContext)
        {
            if(String.IsNullOrEmpty(newContext.resistors.First()))
               return;

            newContext.bandList = FetchResistorBands(newContext);
            context = newContext;
        }

        public abstract double Series();
        public abstract double Parallel();
        public string[] SplitStringInParts(string value)
        {
             char [] delimiters ={' ', ','};
             return value.Split(delimiters);
        }
        
         private List<ReistorBand> FetchResistorBands(Circuit context)
         {
             List<ReistorBand> bands = new List<ReistorBand>();
             foreach(string resistor in context.resistors) 
             {
                     int multiplier = getMultiplier(resistor.Substring(resistor.Length - 2));
                     string[] resistors = SplitStringInParts(resistor);
                     int bandSum = getBand(resistors);

                     bands.Add( 
                          new ReistorBand() 
                          {
                               name = resistor,
                               bandSum = bandSum, 
                               multiplier = multiplier 
                          }
                     );
             }
             return bands;
         }

         private int getBand(string[] band) 
         {
             int sumOfBands = 0;
             for(var i = 0; i < band.Length; i++)
             {
               switch(band[i])
               {
                 case Expression.BLACK: 
                    sumOfBands += 0;
                    break;
                 case Expression.BROWN: 
                    sumOfBands += 1;
                    break;
                 case Expression.RED:
                    sumOfBands += 2;
                    break;
                 case Expression.ORANGE:
                    sumOfBands += 3;
                    break;
                 case Expression.YELLOW: 
                    sumOfBands += 4;
                    break;
                 case Expression.GREEN:
                    sumOfBands += 5;
                    break;
                 case Expression.BLUE:
                    sumOfBands += 6;
                    break;
                 case Expression.VIOLET:
                    sumOfBands += 7;
                    break;
                 case Expression.GRAY:
                    sumOfBands += 8;
                    break;
                 case Expression.WHITE:
                    sumOfBands += 9;
                    break;
                 default: 
                    sumOfBands = 0;
                    return sumOfBands;
               }
             }
             return sumOfBands;
         }
         private int getMultiplier(string mult)
         {
             switch(mult)
             {
                 case Expression.BLACK:
                    return 1;
                 case Expression.BROWN:
                    return 10;
                 case Expression.RED: 
                    return 100;
                 case Expression.ORANGE:
                    return 1000;
                 case Expression.YELLOW:
                    return 10;
                 case Expression.GREEN:
                    return 100;
                 case Expression.BLUE: 
                    return 1000000;
                 default: return 0;
             }
         }
    }

    public class ReistorBand
    {
        public string name {get; set;}
        public int  bandSum {get; set;}
        public int  multiplier {get; set;}
    }

    public class ParallelExpression : Expression
    {
        public override double Parallel()
        {
            double totalResistorsInSeriesValueBottom = 0;
            List<ReistorBand> resistorBand = this.context.bandList;
            foreach (var rb in resistorBand) 
            {
                double currentBandSum = rb.bandSum * rb.multiplier;
                totalResistorsInSeriesValueBottom += 1/currentBandSum;
            }
            var ResistorsInParallelValue = 1/totalResistorsInSeriesValueBottom;
            Console.WriteLine("Parallel Circut Resistors Total: {0}", ResistorsInParallelValue);   
            return ResistorsInParallelValue; 
        }
        public override double Series()
        {
            return -1;
        }
    }
    public class SeriesExpression : Expression
    {
        public override double Series()
        { 
            var ResistorsInSeriesValue = this.context.bandList.Sum(x => x.bandSum * x.multiplier);
            Console.WriteLine("Series Circut Resistors Total: {0}", ResistorsInSeriesValue);   
            return ResistorsInSeriesValue;
        }
        public override double Parallel()
        {
            return -1;
        }
    }

    public class Circuit
    {
        public List<string> resistors {get; private set;} 
        public List<ReistorBand> bandList {get; set;}
        public Circuit() {
            this.resistors = new List<string>();
        }
        public void AddResistor(string rs) 
        {
            resistors.Add(rs);
        }

        private bool ValidateBands(string rs) 
        {
            //TODO
            /*
             * Only support 4 and 5 band resistors
             * There should only be " " and "," as delimiters between bands
             * There must be two identifiers to represent a reistor band
             * There must be at least two resistors added to a circuit
             * 
             */ 
            return false;
        }
    }

    class InterpreterPattern
    {
        static void Main()
        {
            //BK=black, BR=brown, RD=red etc
            string resistorBand1 = "BR,RD,BK"; //4 band & 5 band resistors no tolerance
            string resistorBand2 = "RD,BK,RD,RD";

            Circuit circuit = new Circuit();
            circuit.AddResistor(resistorBand1);
            circuit.AddResistor(resistorBand2);


            //store circuit configurations in list
            ArrayList list = new ArrayList();

            list.Add(new SeriesExpression());
            list.Add(new ParallelExpression());

            foreach (Expression exp in list)
            {
                exp.Interpret(circuit);
                exp.Series();
                exp.Parallel();
                printCircuit(circuit);
            }

            Console.ReadKey();
        }

        protected static void printCircuit(Circuit c)
        {
            foreach ( var resistor in c.bandList)
            {
              Console.WriteLine($"{resistor.name} = resistor ohms {resistor.bandSum * resistor.multiplier}");
            }
        }
    }
}
