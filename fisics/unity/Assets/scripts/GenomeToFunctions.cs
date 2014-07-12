using UnityEngine;
using System.Collections;

public class GenomeToFunctions {

	public MoveFunction backLeft1;
	public MoveFunction backLeft2;
	public MoveFunction backLeftShoulder;

	public MoveFunction frontLeft1;
	public MoveFunction frontLeft2;
	public MoveFunction frontLeftShoulder;
	
	public 	MoveFunction backRight1;
	public 	MoveFunction backRight2;
	public MoveFunction backRightShoulder;
	
	public MoveFunction frontRight1;
	public 	MoveFunction frontRight2;
	public 	MoveFunction frontRightShoulder;

	public float secondPeriod;
	public float dominantPeriod;

	public GenomeToFunctions(Genome genome){

		dominantPeriod = genome.getPeriod (0);

		switch (genome.getFunctionType()) {
		case FunctioT.Classic:
			backLeft1 = (new moveFunctionClassic(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0)));
			backLeft2 = (new moveFunctionClassic(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0)));
			backLeftShoulder = (new moveFunctionClassic(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0)));
			
			frontLeft1 = (new moveFunctionClassic(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0)));
			frontLeft2 = (new moveFunctionClassic(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0)));
			frontLeftShoulder = (new moveFunctionClassic(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0)));
			
			backRight1 =  (new moveFunctionClassic (genome.getAmplitude (6), genome.getPeriod (0), genome.getFase (6), genome.getCenterAngle (6), genome.getStrength (0)));
			backRight2 =  (new moveFunctionClassic (genome.getAmplitude (7), genome.getPeriod (0), genome.getFase (7), genome.getCenterAngle (7), genome.getStrength (0)));
			backRightShoulder =  (new moveFunctionClassic (genome.getAmplitude (8), genome.getPeriod (0), genome.getFase (8), genome.getCenterAngle (8), genome.getStrength (0)));
			
			frontRight1 =  (new moveFunctionClassic (genome.getAmplitude (9), genome.getPeriod (0), genome.getFase (9), genome.getCenterAngle (9), genome.getStrength (0)));
			frontRight2 =  (new moveFunctionClassic (genome.getAmplitude (10), genome.getPeriod (0), genome.getFase (10), genome.getCenterAngle (10), genome.getStrength (0)));
			frontRightShoulder =  (new moveFunctionClassic (genome.getAmplitude (11), genome.getPeriod (0), genome.getFase (11), genome.getCenterAngle (11), genome.getStrength (0)));
			
			secondPeriod = genome.getPeriod(0);
			
			break;
		case FunctioT.Fourier_Med_Partida_FaseSync:
			backLeft1 = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(0),genome.getAmplitude(1),genome.getAmplitude(2),genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(4),genome.getPeriod(1),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(1)));
			backLeft2 = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(5),genome.getAmplitude(6),genome.getAmplitude(7),genome.getAmplitude(8),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(9),genome.getPeriod(1),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(1)));
			backLeftShoulder = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(10),genome.getAmplitude(11),genome.getAmplitude(12),genome.getAmplitude(13),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(14),genome.getPeriod(1),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(1)));
			
			frontLeft1 = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(15),genome.getAmplitude(16),genome.getAmplitude(17),genome.getAmplitude(18),genome.getPeriod(0),genome.getFase(6),genome.getCenterAngle(6),genome.getStrength(0),genome.getAmplitude(19),genome.getPeriod(1),genome.getFase(7),genome.getCenterAngle(7),genome.getStrength(1)));
			frontLeft2 = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(20),genome.getAmplitude(21),genome.getAmplitude(22),genome.getAmplitude(23),genome.getPeriod(0),genome.getFase(8),genome.getCenterAngle(8),genome.getStrength(0),genome.getAmplitude(24),genome.getPeriod(1),genome.getFase(9),genome.getCenterAngle(9),genome.getStrength(1)));
			frontLeftShoulder = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(25),genome.getAmplitude(26),genome.getAmplitude(27),genome.getAmplitude(28),genome.getPeriod(0),genome.getFase(10),genome.getCenterAngle(10),genome.getStrength(0),genome.getAmplitude(29),genome.getPeriod(1),genome.getFase(11),genome.getCenterAngle(11),genome.getStrength(1)));

			backRight1 = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(0),genome.getAmplitude(1),genome.getAmplitude(2),genome.getAmplitude(3),genome.getPeriod(0) + Mathf.PI,genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(30),genome.getPeriod(1),genome.getFase(12),genome.getCenterAngle(12),genome.getStrength(1)));
			backRight2 = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(5),genome.getAmplitude(6),genome.getAmplitude(7),genome.getAmplitude(8),genome.getPeriod(0) + Mathf.PI,genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(31),genome.getPeriod(1),genome.getFase(13),genome.getCenterAngle(13),genome.getStrength(1)));
			backRightShoulder = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(10),genome.getAmplitude(11),genome.getAmplitude(12),genome.getAmplitude(13),genome.getPeriod(0) + Mathf.PI,genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(32),genome.getPeriod(1),genome.getFase(14),genome.getCenterAngle(14),genome.getStrength(1)));
			
			frontRight1 = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(15),genome.getAmplitude(16),genome.getAmplitude(17),genome.getAmplitude(18),genome.getPeriod(0) + Mathf.PI,genome.getFase(6),genome.getCenterAngle(6),genome.getStrength(0),genome.getAmplitude(33),genome.getPeriod(1),genome.getFase(15),genome.getCenterAngle(15),genome.getStrength(1)));
			frontRight2 = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(20),genome.getAmplitude(21),genome.getAmplitude(22),genome.getAmplitude(23),genome.getPeriod(0) + Mathf.PI,genome.getFase(8),genome.getCenterAngle(8),genome.getStrength(0),genome.getAmplitude(34),genome.getPeriod(1),genome.getFase(16),genome.getCenterAngle(16),genome.getStrength(1)));
			frontRightShoulder = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(25),genome.getAmplitude(26),genome.getAmplitude(27),genome.getAmplitude(28),genome.getPeriod(0) + Mathf.PI,genome.getFase(10),genome.getCenterAngle(10),genome.getStrength(0),genome.getAmplitude(35),genome.getPeriod(1),genome.getFase(17),genome.getCenterAngle(17),genome.getStrength(1)));

			secondPeriod = genome.getPeriod(1);
			
			break;
		case FunctioT.Partida:
			backLeft1 = (new MoveFunctionPartida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(12),genome.getPeriod(1),genome.getFase(12),genome.getCenterAngle(12),genome.getStrength(1)));
			backLeft2 = (new MoveFunctionPartida(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(13),genome.getPeriod(1),genome.getFase(13),genome.getCenterAngle(13),genome.getStrength(1)));
			backLeftShoulder = (new MoveFunctionPartida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(14),genome.getPeriod(1),genome.getFase(14),genome.getCenterAngle(14),genome.getStrength(1)));
			
			frontLeft1 = (new MoveFunctionPartida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(15),genome.getPeriod(1),genome.getFase(15),genome.getCenterAngle(15),genome.getStrength(1)));
			frontLeft2 = (new MoveFunctionPartida(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(16),genome.getPeriod(1),genome.getFase(16),genome.getCenterAngle(16),genome.getStrength(1)));
			frontLeftShoulder = (new MoveFunctionPartida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(17),genome.getPeriod(1),genome.getFase(17),genome.getCenterAngle(17),genome.getStrength(1)));
			
			backRight1 =  (new MoveFunctionPartida (genome.getAmplitude (6), genome.getPeriod (0), genome.getFase (6), genome.getCenterAngle (6), genome.getStrength (0),genome.getAmplitude(18),genome.getPeriod(1),genome.getFase(18),genome.getCenterAngle(18),genome.getStrength(1)));
			backRight2 =  (new MoveFunctionPartida (genome.getAmplitude (7), genome.getPeriod (0), genome.getFase (7), genome.getCenterAngle (7), genome.getStrength (0),genome.getAmplitude(19),genome.getPeriod(1),genome.getFase(19),genome.getCenterAngle(19),genome.getStrength(1)));
			backRightShoulder =  (new MoveFunctionPartida (genome.getAmplitude (8), genome.getPeriod (0), genome.getFase (8), genome.getCenterAngle (8), genome.getStrength (0),genome.getAmplitude(20),genome.getPeriod(1),genome.getFase(20),genome.getCenterAngle(20),genome.getStrength(1)));
			
			frontRight1 =  (new MoveFunctionPartida (genome.getAmplitude (9), genome.getPeriod (0), genome.getFase (9), genome.getCenterAngle (9), genome.getStrength (0),genome.getAmplitude(21),genome.getPeriod(1),genome.getFase(21),genome.getCenterAngle(21),genome.getStrength(1)));
			frontRight2 =  (new MoveFunctionPartida (genome.getAmplitude (10), genome.getPeriod (0), genome.getFase (10), genome.getCenterAngle (10), genome.getStrength (0),genome.getAmplitude(22),genome.getPeriod(1),genome.getFase(22),genome.getCenterAngle(22),genome.getStrength(1)));
			frontRightShoulder =  (new MoveFunctionPartida (genome.getAmplitude (11), genome.getPeriod (0), genome.getFase (11), genome.getCenterAngle (11), genome.getStrength (0),genome.getAmplitude(23),genome.getPeriod(1),genome.getFase(23),genome.getCenterAngle(23),genome.getStrength(1)));
			
			secondPeriod = genome.getPeriod(1);
			
			break;
		case FunctioT.Partida_Classic_FaseSync:
			backLeft1 = (new MoveFunctionPartida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(6),genome.getPeriod(1),genome.getFase(6),genome.getCenterAngle(6),genome.getStrength(1)));
			backLeft2 = (new MoveFunctionPartida(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(7),genome.getPeriod(1),genome.getFase(7),genome.getCenterAngle(7),genome.getStrength(1)));
			backLeftShoulder = (new MoveFunctionPartida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(8),genome.getPeriod(1),genome.getFase(8),genome.getCenterAngle(8),genome.getStrength(1)));
			
			frontLeft1 = (new MoveFunctionPartida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(9),genome.getPeriod(1),genome.getFase(9),genome.getCenterAngle(9),genome.getStrength(1)));
			frontLeft2 = (new MoveFunctionPartida(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(10),genome.getPeriod(1),genome.getFase(10),genome.getCenterAngle(10),genome.getStrength(1)));
			frontLeftShoulder = (new MoveFunctionPartida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(11),genome.getPeriod(1),genome.getFase(11),genome.getCenterAngle(11),genome.getStrength(1)));
			
			backRight1 = (new MoveFunctionPartida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0) + Mathf.PI,genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(12),genome.getPeriod(1),genome.getFase(12),genome.getCenterAngle(12),genome.getStrength(1)));
			backRight2 = (new MoveFunctionPartida(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1) + Mathf.PI,genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(13),genome.getPeriod(1),genome.getFase(13),genome.getCenterAngle(13),genome.getStrength(1)));
			backRightShoulder = (new MoveFunctionPartida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2) + Mathf.PI,genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(14),genome.getPeriod(1),genome.getFase(14),genome.getCenterAngle(14),genome.getStrength(1)));
			
			frontRight1 = (new MoveFunctionPartida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3) + Mathf.PI,genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(15),genome.getPeriod(1),genome.getFase(15),genome.getCenterAngle(15),genome.getStrength(1)));
			frontRight2 = (new MoveFunctionPartida(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4) + Mathf.PI,genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(16),genome.getPeriod(1),genome.getFase(16),genome.getCenterAngle(16),genome.getStrength(1)));
			frontRightShoulder = (new MoveFunctionPartida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5) + Mathf.PI,genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(17),genome.getPeriod(1),genome.getFase(17),genome.getCenterAngle(17),genome.getStrength(1)));
			
			secondPeriod = genome.getPeriod(1);
			
			break;
		case FunctioT.PartidaFinalConstante:

			CircularEnumerator aEnum = genome.getAmplitudeEnumerator();
			CircularEnumerator caEnum = genome.getCenterAngleEnumerator();
			CircularEnumerator pEnum = genome.getPeriodEnumerator();
			CircularEnumerator fEnum = genome.getFaseEnumerator();
			CircularEnumerator sEnum = genome.getStrengthEnumerator();


			backLeft1 = (new MoveFunctionPartidaFinalConstante(aEnum,caEnum ,pEnum,fEnum,sEnum));
			backLeft2 = (new MoveFunctionPartidaFinalConstante(aEnum,caEnum ,pEnum,fEnum,sEnum));
			backLeftShoulder = (new MoveFunctionPartidaFinalConstante(aEnum,caEnum ,pEnum,fEnum,sEnum));
			
			frontLeft1 = (new MoveFunctionPartidaFinalConstante(aEnum,caEnum ,pEnum,fEnum,sEnum));
			frontLeft2 = (new MoveFunctionPartidaFinalConstante(aEnum,caEnum ,pEnum,fEnum,sEnum));
			frontLeftShoulder = (new MoveFunctionPartidaFinalConstante(aEnum,caEnum ,pEnum,fEnum,sEnum));
			
			backRight1 =  (new MoveFunctionPartidaFinalConstante(aEnum,caEnum ,pEnum,fEnum,sEnum));
			backRight2 =  (new MoveFunctionPartidaFinalConstante(aEnum,caEnum ,pEnum,fEnum,sEnum));
			backRightShoulder =  (new MoveFunctionPartidaFinalConstante(aEnum,caEnum ,pEnum,fEnum,sEnum));
			
			frontRight1 = (new MoveFunctionPartidaFinalConstante(aEnum,caEnum ,pEnum,fEnum,sEnum));
			frontRight2 =  (new MoveFunctionPartidaFinalConstante(aEnum,caEnum ,pEnum,fEnum,sEnum));
			frontRightShoulder =  (new MoveFunctionPartidaFinalConstante(aEnum,caEnum ,pEnum,fEnum,sEnum));
			
			secondPeriod = genome.getPeriod(1);
			
			break;
		case FunctioT.Media_Partida_Classic_FaseSync_Fourier_Knee:
			secondPeriod = genome.getPeriod(1);

			backLeft1 = (new MoveFunctionMediaPartida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(6),genome.getPeriod(1),genome.getFase(6),genome.getCenterAngle(6),genome.getStrength(1)));
			backLeft2 = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(1),genome.getAmplitude(18),genome.getAmplitude(19),genome.getAmplitude(20),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(7),genome.getPeriod(1),genome.getFase(7),genome.getCenterAngle(7),genome.getStrength(1)));
			backLeftShoulder = (new MoveFunctionMediaPartida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(8),genome.getPeriod(1),genome.getFase(8),genome.getCenterAngle(8),genome.getStrength(1)));

			frontLeft1 = (new MoveFunctionMediaPartida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(9),genome.getPeriod(1),genome.getFase(9),genome.getCenterAngle(9),genome.getStrength(1)));
			frontLeft2 = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(4),genome.getAmplitude(21),genome.getAmplitude(22),genome.getAmplitude(23),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(10),genome.getPeriod(1),genome.getFase(10),genome.getCenterAngle(10),genome.getStrength(1)));
			frontLeftShoulder = (new MoveFunctionMediaPartida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(11),genome.getPeriod(1),genome.getFase(11),genome.getCenterAngle(11),genome.getStrength(1)));
			
			backRight1 = (new MoveFunctionMediaPartida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0) + Mathf.PI,genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(12),genome.getPeriod(1),genome.getFase(12),genome.getCenterAngle(12),genome.getStrength(1)));
			backRight2 = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(1),genome.getAmplitude(18),genome.getAmplitude(19),genome.getAmplitude(20),genome.getPeriod(0),genome.getFase(1) + Mathf.PI,genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(13),genome.getPeriod(1),genome.getFase(13),genome.getCenterAngle(13),genome.getStrength(1)));
			backRightShoulder = (new MoveFunctionMediaPartida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2) + Mathf.PI,genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(14),genome.getPeriod(1),genome.getFase(14),genome.getCenterAngle(14),genome.getStrength(1)));

			frontRight1 = (new MoveFunctionMediaPartida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3) + Mathf.PI,genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(15),genome.getPeriod(1),genome.getFase(15),genome.getCenterAngle(15),genome.getStrength(1)));
			frontRight2 = (new MoveFunctionMediaPartidaFourierRodilla(genome.getAmplitude(4),genome.getAmplitude(21),genome.getAmplitude(22),genome.getAmplitude(23),genome.getPeriod(0),genome.getFase(4) + Mathf.PI,genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(16),genome.getPeriod(1),genome.getFase(16),genome.getCenterAngle(16),genome.getStrength(1)));
			frontRightShoulder = (new MoveFunctionMediaPartida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5) + Mathf.PI,genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(17),genome.getPeriod(1),genome.getFase(17),genome.getCenterAngle(17),genome.getStrength(1)));

			
			break;

		case FunctioT.Media_Partida_Classic_FaseSync_CosDoubleFrecuency_Knee:
			
			dominantPeriod = (genome.getPeriod (0) + genome.getPeriod (1))/2;
			secondPeriod = genome.getPeriod(2);
			
			backLeft1 = (new MoveFunctionMediaPartida(genome.getAmplitude(0),dominantPeriod,genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(6),secondPeriod,genome.getFase(6),genome.getCenterAngle(6),genome.getStrength(1)));
			backLeft2 = (new MoveFunctionCosDoubleFrecuency(genome.getAmplitude(1),genome.getPeriod(0),genome.getPeriod(1),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(7),secondPeriod,genome.getFase(7),genome.getCenterAngle(7),genome.getStrength(1)));
			backLeftShoulder = (new MoveFunctionMediaPartida(genome.getAmplitude(2),dominantPeriod,genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(8),secondPeriod,genome.getFase(8),genome.getCenterAngle(8),genome.getStrength(1)));
			
			frontLeft1 = (new MoveFunctionMediaPartida(genome.getAmplitude(3),dominantPeriod,genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(9),secondPeriod,genome.getFase(9),genome.getCenterAngle(9),genome.getStrength(1)));
			frontLeft2 = (new MoveFunctionCosDoubleFrecuency(genome.getAmplitude(4),genome.getPeriod(0),genome.getPeriod(1),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(10),secondPeriod,genome.getFase(10),genome.getCenterAngle(10),genome.getStrength(1)));
			frontLeftShoulder = (new MoveFunctionMediaPartida(genome.getAmplitude(5),dominantPeriod,genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(11),secondPeriod,genome.getFase(11),genome.getCenterAngle(11),genome.getStrength(1)));
			
			backRight1 = (new MoveFunctionMediaPartida(genome.getAmplitude(0),dominantPeriod,genome.getFase(0) + Mathf.PI,genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(12),secondPeriod,genome.getFase(12),genome.getCenterAngle(12),genome.getStrength(1)));
			backRight2 = (new MoveFunctionCosDoubleFrecuency(genome.getAmplitude(1),genome.getPeriod(0),genome.getPeriod(1),genome.getFase(1) + Mathf.PI,genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(13),secondPeriod,genome.getFase(13),genome.getCenterAngle(13),genome.getStrength(1)));
			backRightShoulder = (new MoveFunctionMediaPartida(genome.getAmplitude(2),dominantPeriod,genome.getFase(2) + Mathf.PI,genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(14),secondPeriod,genome.getFase(14),genome.getCenterAngle(14),genome.getStrength(1)));
			
			frontRight1 = (new MoveFunctionMediaPartida(genome.getAmplitude(3),dominantPeriod,genome.getFase(3) + Mathf.PI,genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(15),secondPeriod,genome.getFase(15),genome.getCenterAngle(15),genome.getStrength(1)));
			frontRight2 = (new MoveFunctionCosDoubleFrecuency(genome.getAmplitude(4),genome.getPeriod(0),genome.getPeriod(1),genome.getFase(4) + Mathf.PI,genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(16),secondPeriod,genome.getFase(16),genome.getCenterAngle(16),genome.getStrength(1)));
			frontRightShoulder = (new MoveFunctionMediaPartida(genome.getAmplitude(5),dominantPeriod,genome.getFase(5) + Mathf.PI,genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(17),secondPeriod,genome.getFase(17),genome.getCenterAngle(17),genome.getStrength(1)));
			
			
			break;


			
		}
	}
}
