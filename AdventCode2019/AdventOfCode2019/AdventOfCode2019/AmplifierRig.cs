using System.Collections.Generic;
using static AdventOfCode2019.MagicSmokeComputer;

namespace AdventOfCode2019
{
    public class AmplifierRig
    {
        private List<long> _pgm;

        public AmplifierRig(List<long> pgm)
        {
            _pgm = pgm;
        }

        public long RunAmpCircuit(long phaseA, long phaseB, long phaseC, long phaseD, long phaseE, long startSignal)
        {
            var ampA = new MagicSmokeComputer(_pgm);
            ampA.InputPort = phaseA;
            ampA.InputPort = startSignal;
            ampA.Run();
            var ampB = new MagicSmokeComputer(_pgm);
            ampB.InputPort = phaseB;
            ampB.InputPort = ampA.OutputPort();
            ampB.Run();
            var ampC = new MagicSmokeComputer(_pgm);
            ampC.InputPort = phaseC;
            ampC.InputPort = ampB.OutputPort();
            ampC.Run();
            var ampD = new MagicSmokeComputer(_pgm);
            ampD.InputPort = phaseD;
            ampD.InputPort = ampC.OutputPort();
            ampD.Run();
            var ampE = new MagicSmokeComputer(_pgm);
            ampE.InputPort = phaseE;
            ampE.InputPort = ampD.OutputPort();
            ampE.Run();
            return ampE.OutputPort();
        }

        public long RunFeedbackAmpCircuit(long phaseA, long phaseB, long phaseC, long phaseD, long phaseE, long startSignal)
        {
            long finalOutput = 0;
            var ampA = new MagicSmokeComputer(_pgm);
            var ampB = new MagicSmokeComputer(_pgm);
            var ampC = new MagicSmokeComputer(_pgm);
            var ampD = new MagicSmokeComputer(_pgm);
            var ampE = new MagicSmokeComputer(_pgm);

            ampA.InputPort = phaseA;
            ampB.InputPort = phaseB;
            ampC.InputPort = phaseC;
            ampD.InputPort = phaseD;
            ampE.InputPort = phaseE;

            // start signal
            ampA.InputPort = startSignal;

            ProgramMode outputA = ProgramMode.Start;
            ProgramMode outputB = ProgramMode.Start;
            ProgramMode outputC = ProgramMode.Start;
            ProgramMode outputD = ProgramMode.Start;
            ProgramMode outputE = ProgramMode.Start;
            do
            {
                outputA = ampA.Run(outputA);
                ampB.InputPort = ampA.OutputPort();
                outputB = ampB.Run(outputB);
                ampC.InputPort = ampB.OutputPort();
                outputC = ampC.Run(outputC);
                ampD.InputPort = ampC.OutputPort();
                outputD = ampD.Run(outputD);
                ampE.InputPort = ampD.OutputPort();
                outputE = ampE.Run(outputE);
                finalOutput = ampE.OutputPort();
                ampA.InputPort = finalOutput;
                // TODO Do I need to test all?
            } while (outputE != ProgramMode.Stop);
            return finalOutput;
        }
    }
}
