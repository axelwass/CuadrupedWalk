using UnityEngine;
using System.Collections;

public class GenomaAFuncion {

	public FuncionDeMovimiento backLeft1;
	public FuncionDeMovimiento backLeft2;
	public FuncionDeMovimiento backLeftShoulder;

	public FuncionDeMovimiento frontLeft1;
	public FuncionDeMovimiento frontLeft2;
	public FuncionDeMovimiento frontLeftShoulder;
	
	public 	FuncionDeMovimiento backRight1;
	public 	FuncionDeMovimiento backRight2;
	public FuncionDeMovimiento backRightShoulder;
	
	public FuncionDeMovimiento frontRight1;
	public 	FuncionDeMovimiento frontRight2;
	public 	FuncionDeMovimiento frontRightShoulder;

	public float secondPeriod;
	public float dominantPeriod;

	public GenomaAFuncion(Genoma genome){

		dominantPeriod = genome.getPeriod (0);

		switch (genome.getFunctionType()) {
		case TipoFuncion.Clasica:
			backLeft1 = (new FM_Clasica(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0)));
			backLeft2 = (new FM_Clasica(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0)));
			backLeftShoulder = (new FM_Clasica(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0)));
			
			frontLeft1 = (new FM_Clasica(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0)));
			frontLeft2 = (new FM_Clasica(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0)));
			frontLeftShoulder = (new FM_Clasica(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0)));
			
			backRight1 =  (new FM_Clasica (genome.getAmplitude (6), genome.getPeriod (0), genome.getFase (6), genome.getCenterAngle (6), genome.getStrength (0)));
			backRight2 =  (new FM_Clasica (genome.getAmplitude (7), genome.getPeriod (0), genome.getFase (7), genome.getCenterAngle (7), genome.getStrength (0)));
			backRightShoulder =  (new FM_Clasica (genome.getAmplitude (8), genome.getPeriod (0), genome.getFase (8), genome.getCenterAngle (8), genome.getStrength (0)));
			
			frontRight1 =  (new FM_Clasica (genome.getAmplitude (9), genome.getPeriod (0), genome.getFase (9), genome.getCenterAngle (9), genome.getStrength (0)));
			frontRight2 =  (new FM_Clasica (genome.getAmplitude (10), genome.getPeriod (0), genome.getFase (10), genome.getCenterAngle (10), genome.getStrength (0)));
			frontRightShoulder =  (new FM_Clasica (genome.getAmplitude (11), genome.getPeriod (0), genome.getFase (11), genome.getCenterAngle (11), genome.getStrength (0)));
			
			secondPeriod = genome.getPeriod(0);
			
			break;
		case TipoFuncion.Fourier_Partida_FaseSync:
			backLeft1 = (new FM_Fourier_Partida(genome.getAmplitude(0),genome.getAmplitude(1),genome.getAmplitude(2),genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(4),genome.getPeriod(1),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(1)));
			backLeft2 = (new FM_Fourier_Partida(genome.getAmplitude(5),genome.getAmplitude(6),genome.getAmplitude(7),genome.getAmplitude(8),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(9),genome.getPeriod(1),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(1)));
			backLeftShoulder = (new FM_Fourier_Partida(genome.getAmplitude(10),genome.getAmplitude(11),genome.getAmplitude(12),genome.getAmplitude(13),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(14),genome.getPeriod(1),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(1)));
			
			frontLeft1 = (new FM_Fourier_Partida(genome.getAmplitude(15),genome.getAmplitude(16),genome.getAmplitude(17),genome.getAmplitude(18),genome.getPeriod(0),genome.getFase(6),genome.getCenterAngle(6),genome.getStrength(0),genome.getAmplitude(19),genome.getPeriod(1),genome.getFase(7),genome.getCenterAngle(7),genome.getStrength(1)));
			frontLeft2 = (new FM_Fourier_Partida(genome.getAmplitude(20),genome.getAmplitude(21),genome.getAmplitude(22),genome.getAmplitude(23),genome.getPeriod(0),genome.getFase(8),genome.getCenterAngle(8),genome.getStrength(0),genome.getAmplitude(24),genome.getPeriod(1),genome.getFase(9),genome.getCenterAngle(9),genome.getStrength(1)));
			frontLeftShoulder = (new FM_Fourier_Partida(genome.getAmplitude(25),genome.getAmplitude(26),genome.getAmplitude(27),genome.getAmplitude(28),genome.getPeriod(0),genome.getFase(10),genome.getCenterAngle(10),genome.getStrength(0),genome.getAmplitude(29),genome.getPeriod(1),genome.getFase(11),genome.getCenterAngle(11),genome.getStrength(1)));

			backRight1 = (new FM_Fourier_Partida(genome.getAmplitude(0),genome.getAmplitude(1),genome.getAmplitude(2),genome.getAmplitude(3),genome.getPeriod(0) + Mathf.PI,genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(30),genome.getPeriod(1),genome.getFase(12),genome.getCenterAngle(12),genome.getStrength(1)));
			backRight2 = (new FM_Fourier_Partida(genome.getAmplitude(5),genome.getAmplitude(6),genome.getAmplitude(7),genome.getAmplitude(8),genome.getPeriod(0) + Mathf.PI,genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(31),genome.getPeriod(1),genome.getFase(13),genome.getCenterAngle(13),genome.getStrength(1)));
			backRightShoulder = (new FM_Fourier_Partida(genome.getAmplitude(10),genome.getAmplitude(11),genome.getAmplitude(12),genome.getAmplitude(13),genome.getPeriod(0) + Mathf.PI,genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(32),genome.getPeriod(1),genome.getFase(14),genome.getCenterAngle(14),genome.getStrength(1)));
			
			frontRight1 = (new FM_Fourier_Partida(genome.getAmplitude(15),genome.getAmplitude(16),genome.getAmplitude(17),genome.getAmplitude(18),genome.getPeriod(0) + Mathf.PI,genome.getFase(6),genome.getCenterAngle(6),genome.getStrength(0),genome.getAmplitude(33),genome.getPeriod(1),genome.getFase(15),genome.getCenterAngle(15),genome.getStrength(1)));
			frontRight2 = (new FM_Fourier_Partida(genome.getAmplitude(20),genome.getAmplitude(21),genome.getAmplitude(22),genome.getAmplitude(23),genome.getPeriod(0) + Mathf.PI,genome.getFase(8),genome.getCenterAngle(8),genome.getStrength(0),genome.getAmplitude(34),genome.getPeriod(1),genome.getFase(16),genome.getCenterAngle(16),genome.getStrength(1)));
			frontRightShoulder = (new FM_Fourier_Partida(genome.getAmplitude(25),genome.getAmplitude(26),genome.getAmplitude(27),genome.getAmplitude(28),genome.getPeriod(0) + Mathf.PI,genome.getFase(10),genome.getCenterAngle(10),genome.getStrength(0),genome.getAmplitude(35),genome.getPeriod(1),genome.getFase(17),genome.getCenterAngle(17),genome.getStrength(1)));

			secondPeriod = genome.getPeriod(1);
			
			break;
		case TipoFuncion.Clasica_Partida:
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
		case TipoFuncion.Classic_Partida_FaseSync:
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
		case TipoFuncion.Rodilla_Fourier_Classic_FaseSync:
			secondPeriod = genome.getPeriod(1);

			backLeft1 = (new FM_Clasica_Partida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(6),genome.getPeriod(1),genome.getFase(6),genome.getCenterAngle(6),genome.getStrength(1)));
			backLeft2 = (new FM_Fourier_Partida(genome.getAmplitude(1),genome.getAmplitude(18),genome.getAmplitude(19),genome.getAmplitude(20),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(7),genome.getPeriod(1),genome.getFase(7),genome.getCenterAngle(7),genome.getStrength(1)));
			backLeftShoulder = (new FM_Clasica_Partida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(8),genome.getPeriod(1),genome.getFase(8),genome.getCenterAngle(8),genome.getStrength(1)));

			frontLeft1 = (new FM_Clasica_Partida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(9),genome.getPeriod(1),genome.getFase(9),genome.getCenterAngle(9),genome.getStrength(1)));
			frontLeft2 = (new FM_Fourier_Partida(genome.getAmplitude(4),genome.getAmplitude(21),genome.getAmplitude(22),genome.getAmplitude(23),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(10),genome.getPeriod(1),genome.getFase(10),genome.getCenterAngle(10),genome.getStrength(1)));
			frontLeftShoulder = (new FM_Clasica_Partida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(11),genome.getPeriod(1),genome.getFase(11),genome.getCenterAngle(11),genome.getStrength(1)));
			
			backRight1 = (new FM_Clasica_Partida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0) + Mathf.PI,genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(12),genome.getPeriod(1),genome.getFase(12),genome.getCenterAngle(12),genome.getStrength(1)));
			backRight2 = (new FM_Fourier_Partida(genome.getAmplitude(1),genome.getAmplitude(18),genome.getAmplitude(19),genome.getAmplitude(20),genome.getPeriod(0),genome.getFase(1) + Mathf.PI,genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(13),genome.getPeriod(1),genome.getFase(13),genome.getCenterAngle(13),genome.getStrength(1)));
			backRightShoulder = (new FM_Clasica_Partida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2) + Mathf.PI,genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(14),genome.getPeriod(1),genome.getFase(14),genome.getCenterAngle(14),genome.getStrength(1)));

			frontRight1 = (new FM_Clasica_Partida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3) + Mathf.PI,genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(15),genome.getPeriod(1),genome.getFase(15),genome.getCenterAngle(15),genome.getStrength(1)));
			frontRight2 = (new FM_Fourier_Partida(genome.getAmplitude(4),genome.getAmplitude(21),genome.getAmplitude(22),genome.getAmplitude(23),genome.getPeriod(0),genome.getFase(4) + Mathf.PI,genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(16),genome.getPeriod(1),genome.getFase(16),genome.getCenterAngle(16),genome.getStrength(1)));
			frontRightShoulder = (new FM_Clasica_Partida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5) + Mathf.PI,genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(17),genome.getPeriod(1),genome.getFase(17),genome.getCenterAngle(17),genome.getStrength(1)));

			
			break;

		case TipoFuncion.Rodilla_CosDoubleFrecuency_Partida_FaseSync:
			
			dominantPeriod = 2 * genome.getPeriod (0) * genome.getPeriod (1) /(genome.getPeriod (0) + genome.getPeriod (1));
			secondPeriod = genome.getPeriod(2);
			
			backLeft1 = (new FM_Clasica_Partida(genome.getAmplitude(0),dominantPeriod,genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(6),secondPeriod,genome.getFase(6),genome.getCenterAngle(6),genome.getStrength(1)));
			backLeft2 = (new FM_CosenoDobleFrecuencia_Partida(genome.getAmplitude(1),genome.getPeriod(0),genome.getPeriod(1),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(7),secondPeriod,genome.getFase(7),genome.getCenterAngle(7),genome.getStrength(1)));
			backLeftShoulder = (new FM_Clasica_Partida(genome.getAmplitude(2),dominantPeriod,genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(8),secondPeriod,genome.getFase(8),genome.getCenterAngle(8),genome.getStrength(1)));
			
			frontLeft1 = (new FM_Clasica_Partida(genome.getAmplitude(3),dominantPeriod,genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(9),secondPeriod,genome.getFase(9),genome.getCenterAngle(9),genome.getStrength(1)));
			frontLeft2 = (new FM_CosenoDobleFrecuencia_Partida(genome.getAmplitude(4),genome.getPeriod(0),genome.getPeriod(1),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(10),secondPeriod,genome.getFase(10),genome.getCenterAngle(10),genome.getStrength(1)));
			frontLeftShoulder = (new FM_Clasica_Partida(genome.getAmplitude(5),dominantPeriod,genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(11),secondPeriod,genome.getFase(11),genome.getCenterAngle(11),genome.getStrength(1)));
			
			backRight1 = (new FM_Clasica_Partida(genome.getAmplitude(0),dominantPeriod,genome.getFase(0) + Mathf.PI,genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(12),secondPeriod,genome.getFase(12),genome.getCenterAngle(12),genome.getStrength(1)));
			backRight2 = (new FM_CosenoDobleFrecuencia_Partida(genome.getAmplitude(1),genome.getPeriod(0),genome.getPeriod(1),genome.getFase(1) + Mathf.PI,genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(13),secondPeriod,genome.getFase(13),genome.getCenterAngle(13),genome.getStrength(1)));
			backRightShoulder = (new FM_Clasica_Partida(genome.getAmplitude(2),dominantPeriod,genome.getFase(2) + Mathf.PI,genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(14),secondPeriod,genome.getFase(14),genome.getCenterAngle(14),genome.getStrength(1)));
			
			frontRight1 = (new FM_Clasica_Partida(genome.getAmplitude(3),dominantPeriod,genome.getFase(3) + Mathf.PI,genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(15),secondPeriod,genome.getFase(15),genome.getCenterAngle(15),genome.getStrength(1)));
			frontRight2 = (new FM_CosenoDobleFrecuencia_Partida(genome.getAmplitude(4),genome.getPeriod(0),genome.getPeriod(1),genome.getFase(4) + Mathf.PI,genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(16),secondPeriod,genome.getFase(16),genome.getCenterAngle(16),genome.getStrength(1)));
			frontRightShoulder = (new FM_Clasica_Partida(genome.getAmplitude(5),dominantPeriod,genome.getFase(5) + Mathf.PI,genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(17),secondPeriod,genome.getFase(17),genome.getCenterAngle(17),genome.getStrength(1)));
			
			
			break;


			
		}
	}
}
