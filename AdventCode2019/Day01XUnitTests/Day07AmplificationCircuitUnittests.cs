using AdventOfCode2019;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode2019XUnitTests
{
    public class Day07AmplificationCircuitUnittests
    {

        [Fact]
        public void Day07Part1_Example02()
        {
            List<long> pgm = new List<long>(new long[] { 3, 15, 3, 16, 1002, 16, 10, 16, 1, 16, 15, 15, 4, 15, 99, 0, 0 });
            // sequence
            long[] phases = new long[] { 4, 3, 2, 1, 0 };

            AmplifierRig rig = new AmplifierRig(pgm);

            long output = rig.RunAmpCircuit(phases[0], phases[1], phases[2], phases[3], phases[4], 0);

            Assert.Equal(43210, output);
        }

        [Fact]
        public void Day07Part1_Example03()
        {
            List<long> pgm = new List<long>(new long[] { 3, 23, 3, 24, 1002, 24, 10, 24, 1002, 23, -1, 23, 101, 5, 23, 23, 1, 24, 23, 23, 4, 23, 99, 0, 0 });
            // sequence
            long[] phases = new long[] { 0, 1, 2, 3, 4 };

            AmplifierRig rig = new AmplifierRig(pgm);

            long output = rig.RunAmpCircuit(phases[0], phases[1], phases[2], phases[3], phases[4], 0);

            Assert.Equal(54321, output);
        }

        [Fact]
        public void Day07Part1_Example04()
        {
            List<long> pgm = new List<long>(new long[] { 3, 31, 3, 32, 1002, 32, 10, 32, 1001, 31, -2, 31, 1007, 31, 0, 33, 1002, 33, 7, 33, 1, 33, 31, 31, 1, 32, 31, 31, 4, 31, 99, 0, 0, 0 });
            // sequence
            long[] phases = new long[] { 1, 0, 4, 3, 2 };

            AmplifierRig rig = new AmplifierRig(pgm);

            long output = rig.RunAmpCircuit(phases[0], phases[1], phases[2], phases[3], phases[4], 0);

            Assert.Equal(65210, output);
        }

        [Fact]
        public void Day07Part1_TestSolution()
        {
            List<long> pgm = DayDataUtilities.ReadMagicSmokePgmFromFile("day07.txt");
            Assert.NotNull(pgm);
            long maxOutput = long.MinValue;

            for (long phaseA = 0; phaseA <= 4; phaseA++)
            {
                for (long phaseB = 0; phaseB <= 4; phaseB++)
                {
                    if (phaseA != phaseB)
                    {
                        for (long phaseC = 0; phaseC <= 4; phaseC++)
                        {
                            if (phaseA != phaseC && phaseB != phaseC)
                            {
                                for (long phaseD = 0; phaseD <= 4; phaseD++)
                                {
                                    if (phaseA != phaseD && phaseB != phaseD && phaseC != phaseD)
                                    {
                                        for (long phaseE = 0; phaseE <= 4; phaseE++)
                                        {
                                            if (phaseA != phaseE && phaseB != phaseE && phaseC != phaseE && phaseD != phaseE)
                                            {
                                                AmplifierRig rig = new AmplifierRig(pgm);

                                                long output = rig.RunAmpCircuit(phaseA, phaseB, phaseC, phaseD, phaseE, 0);

                                                if (output > maxOutput)
                                                {
                                                    maxOutput = output;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Assert.Equal(255840, maxOutput);
        }

        [Fact]
        public void Day07Part2_Example05()
        {
            List<long> pgm = new List<long>(new long[] { 3, 26, 1001, 26, -4, 26, 3, 27, 1002, 27, 2, 27, 1, 27, 26, 27, 4, 27, 1001, 28, -1, 28, 1005, 28, 6, 99, 0, 0, 5 });
            // sequence
            long[] phases = new long[] { 9, 8, 7, 6, 5 };

            AmplifierRig rig = new AmplifierRig(pgm);

            long output = rig.RunFeedbackAmpCircuit(phases[0], phases[1], phases[2], phases[3], phases[4], 0);

            Assert.Equal(139629729, output);
        }

        [Fact]
        public void Day07Part2_Example06()
        {
            List<long> pgm = new List<long>(new long[] { 3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,
                                                    -5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,
                                                    53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10 });
            // sequence
            long[] phases = new long[] { 9, 7, 8, 5, 6 };

            AmplifierRig rig = new AmplifierRig(pgm);

            long output = rig.RunFeedbackAmpCircuit(phases[0], phases[1], phases[2], phases[3], phases[4], 0);

            Assert.Equal(18216, output);
        }

        [Fact]
        public void Day07Part2_TestSolution()
        {
            List<long> pgm = DayDataUtilities.ReadMagicSmokePgmFromFile("day07.txt");
            Assert.NotNull(pgm);
            long minPhase = 5;
            long maxPhase = 9;
            long maxOutput = long.MinValue;

            for (long phaseA = minPhase; phaseA <= maxPhase; phaseA++)
            {
                for (long phaseB = minPhase; phaseB <= maxPhase; phaseB++)
                {
                    if (phaseA != phaseB)
                    {
                        for (long phaseC = minPhase; phaseC <= maxPhase; phaseC++)
                        {
                            if (phaseA != phaseC && phaseB != phaseC)
                            {
                                for (long phaseD = minPhase; phaseD <= maxPhase; phaseD++)
                                {
                                    if (phaseA != phaseD && phaseB != phaseD && phaseC != phaseD)
                                    {
                                        for (long phaseE = minPhase; phaseE <= maxPhase; phaseE++)
                                        {
                                            if (phaseA != phaseE && phaseB != phaseE && phaseC != phaseE && phaseD != phaseE)
                                            {
                                                AmplifierRig rig = new AmplifierRig(pgm);

                                                long output = rig.RunFeedbackAmpCircuit(phaseA, phaseB, phaseC, phaseD, phaseE, 0);

                                                if (output > maxOutput)
                                                {
                                                    maxOutput = output;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Assert.Equal(84088865, maxOutput);
        }
    }
}
