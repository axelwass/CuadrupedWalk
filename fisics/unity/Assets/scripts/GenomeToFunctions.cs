﻿using UnityEngine;
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

		switch (genome.getFunctionType()==FunctioT.Olistic? genome.getSelector() : genome.getFunctionType()) {
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
		case FunctioT.FaseSync:
			backLeft1 = (new moveFunctionClassic(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0)));
			backLeft2 = (new moveFunctionClassic(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0)));
			backLeftShoulder = (new moveFunctionClassic(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0)));
			
			frontLeft1 = (new moveFunctionClassic(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0)));
			frontLeft2 = (new moveFunctionClassic(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0)));
			frontLeftShoulder = (new moveFunctionClassic(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0)));
			
			backRight1 =  (new moveFunctionClassic (genome.getAmplitude (0), genome.getPeriod (0), genome.getFase (0) + Mathf.PI, genome.getCenterAngle (0), genome.getStrength (0)));
			backRight2 =  (new moveFunctionClassic (genome.getAmplitude (1), genome.getPeriod (0), genome.getFase (1) + Mathf.PI, genome.getCenterAngle (1), genome.getStrength (0)));
			backRightShoulder =  (new moveFunctionClassic (genome.getAmplitude (2), genome.getPeriod (0), genome.getFase (2) + Mathf.PI, genome.getCenterAngle (2), genome.getStrength (0)));
			
			frontRight1 =  (new moveFunctionClassic (genome.getAmplitude (3), genome.getPeriod (0), genome.getFase (3) + Mathf.PI, genome.getCenterAngle (3), genome.getStrength (0)));
			frontRight2 =  (new moveFunctionClassic (genome.getAmplitude (4), genome.getPeriod (0), genome.getFase (4) + Mathf.PI, genome.getCenterAngle (4), genome.getStrength (0)));
			frontRightShoulder =  (new moveFunctionClassic (genome.getAmplitude (5), genome.getPeriod (0), genome.getFase (5) + Mathf.PI, genome.getCenterAngle (5), genome.getStrength (0)));
			
			secondPeriod = genome.getPeriod(0);
			
			break;
		case FunctioT.FaseSuperSync:
			backLeft1 = (new moveFunctionClassic(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0)));
			backLeft2 = (new moveFunctionClassic(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0)));
			backLeftShoulder = (new moveFunctionClassic(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0)));
			
			frontLeft1 = (new moveFunctionClassic(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(0) + Mathf.PI,genome.getCenterAngle(3),genome.getStrength(0)));
			frontLeft2 = (new moveFunctionClassic(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(1) + Mathf.PI,genome.getCenterAngle(4),genome.getStrength(0)));
			frontLeftShoulder = (new moveFunctionClassic(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(2) + Mathf.PI,genome.getCenterAngle(5),genome.getStrength(0)));
			
			backRight1 =  (new moveFunctionClassic (genome.getAmplitude (0), genome.getPeriod (0), genome.getFase (0) + Mathf.PI, genome.getCenterAngle (0), genome.getStrength (0)));
			backRight2 =  (new moveFunctionClassic (genome.getAmplitude (1), genome.getPeriod (0), genome.getFase (1) + Mathf.PI, genome.getCenterAngle (1), genome.getStrength (0)));
			backRightShoulder =  (new moveFunctionClassic (genome.getAmplitude (2), genome.getPeriod (0), genome.getFase (2) + Mathf.PI, genome.getCenterAngle (2), genome.getStrength (0)));
			
			frontRight1 =  (new moveFunctionClassic (genome.getAmplitude (3), genome.getPeriod (0), genome.getFase (0), genome.getCenterAngle (3), genome.getStrength (0)));
			frontRight2 =  (new moveFunctionClassic (genome.getAmplitude (4), genome.getPeriod (0), genome.getFase (1), genome.getCenterAngle (4), genome.getStrength (0)));
			frontRightShoulder =  (new moveFunctionClassic (genome.getAmplitude (5), genome.getPeriod (0), genome.getFase (2), genome.getCenterAngle (5), genome.getStrength (0)));
			
			secondPeriod = genome.getPeriod(0);
			
			break;
		case FunctioT.Fourier2:
			backLeft1 = (new MoveFunctionFourier2(genome.getAmplitude(0),genome.getAmplitude(6),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0)));
			backLeft2 = (new MoveFunctionFourier2(genome.getAmplitude(1),genome.getAmplitude(7),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0)));
			backLeftShoulder = (new MoveFunctionFourier2(genome.getAmplitude(2),genome.getAmplitude(8),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0)));
			
			frontLeft1 = (new MoveFunctionFourier2(genome.getAmplitude(3),genome.getAmplitude(9),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0)));
			frontLeft2 = (new MoveFunctionFourier2(genome.getAmplitude(4),genome.getAmplitude(10),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0)));
			frontLeftShoulder = (new MoveFunctionFourier2(genome.getAmplitude(5),genome.getAmplitude(11),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0)));
			
			backRight1 =  (new MoveFunctionFourier2 (genome.getAmplitude (0),genome.getAmplitude(6), genome.getPeriod (0), genome.getFase (0) + Mathf.PI, genome.getCenterAngle (0), genome.getStrength (0)));
			backRight2 =  (new MoveFunctionFourier2 (genome.getAmplitude (1),genome.getAmplitude(7), genome.getPeriod (0), genome.getFase (1) + Mathf.PI, genome.getCenterAngle (1), genome.getStrength (0)));
			backRightShoulder =  (new MoveFunctionFourier2 (genome.getAmplitude (2),genome.getAmplitude(8), genome.getPeriod (0), genome.getFase (2) + Mathf.PI, genome.getCenterAngle (2), genome.getStrength (0)));
			
			frontRight1 =  (new MoveFunctionFourier2 (genome.getAmplitude (3),genome.getAmplitude(9), genome.getPeriod (0), genome.getFase (3) + Mathf.PI, genome.getCenterAngle (3), genome.getStrength (0)));
			frontRight2 =  (new MoveFunctionFourier2 (genome.getAmplitude (4),genome.getAmplitude(10), genome.getPeriod (0), genome.getFase (4) + Mathf.PI, genome.getCenterAngle (4), genome.getStrength (0)));
			frontRightShoulder =  (new MoveFunctionFourier2 (genome.getAmplitude (5),genome.getAmplitude(11), genome.getPeriod (0), genome.getFase (5) + Mathf.PI, genome.getCenterAngle (5), genome.getStrength (0)));
			
			secondPeriod = genome.getPeriod(0);
			
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
		case FunctioT.Partida_FaseSync:
			backLeft1 = (new MoveFunctionPartida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(6),genome.getPeriod(1),genome.getFase(6),genome.getCenterAngle(6),genome.getStrength(1)));
			backLeft2 = (new MoveFunctionPartida(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(7),genome.getPeriod(1),genome.getFase(7),genome.getCenterAngle(7),genome.getStrength(1)));
			backLeftShoulder = (new MoveFunctionPartida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(8),genome.getPeriod(1),genome.getFase(8),genome.getCenterAngle(8),genome.getStrength(1)));
			
			frontLeft1 = (new MoveFunctionPartida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(9),genome.getPeriod(1),genome.getFase(9),genome.getCenterAngle(9),genome.getStrength(1)));
			frontLeft2 = (new MoveFunctionPartida(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(10),genome.getPeriod(1),genome.getFase(10),genome.getCenterAngle(10),genome.getStrength(1)));
			frontLeftShoulder = (new MoveFunctionPartida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(11),genome.getPeriod(1),genome.getFase(11),genome.getCenterAngle(11),genome.getStrength(1)));
			
			backRight1 = (new MoveFunctionPartida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0) + Mathf.PI,genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(6),genome.getPeriod(1),genome.getFase(6) + Mathf.PI,genome.getCenterAngle(6),genome.getStrength(1)));
			backRight2 = (new MoveFunctionPartida(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1) + Mathf.PI,genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(7),genome.getPeriod(1),genome.getFase(7) + Mathf.PI,genome.getCenterAngle(7),genome.getStrength(1)));
			backRightShoulder = (new MoveFunctionPartida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2) + Mathf.PI,genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(8),genome.getPeriod(1),genome.getFase(8) + Mathf.PI,genome.getCenterAngle(8),genome.getStrength(1)));
			
			frontRight1 = (new MoveFunctionPartida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3) + Mathf.PI,genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(9),genome.getPeriod(1),genome.getFase(9) + Mathf.PI,genome.getCenterAngle(9),genome.getStrength(1)));
			frontRight2 = (new MoveFunctionPartida(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4) + Mathf.PI,genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(10),genome.getPeriod(1),genome.getFase(10) + Mathf.PI,genome.getCenterAngle(10),genome.getStrength(1)));
			frontRightShoulder = (new MoveFunctionPartida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5) + Mathf.PI,genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(11),genome.getPeriod(1),genome.getFase(11) + Mathf.PI,genome.getCenterAngle(11),genome.getStrength(1)));
			
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
			backLeft1 = (new MoveFunctionPartidaFinalConstante(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(12),genome.getPeriod(1),genome.getFase(12),genome.getCenterAngle(12),genome.getStrength(1)));
			backLeft2 = (new MoveFunctionPartidaFinalConstante(genome.getAmplitude(1),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(13),genome.getPeriod(1),genome.getFase(13),genome.getCenterAngle(13),genome.getStrength(1)));
			backLeftShoulder = (new MoveFunctionPartidaFinalConstante(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(14),genome.getPeriod(1),genome.getFase(14),genome.getCenterAngle(14),genome.getStrength(1)));
			
			frontLeft1 = (new MoveFunctionPartidaFinalConstante(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(15),genome.getPeriod(1),genome.getFase(15),genome.getCenterAngle(15),genome.getStrength(1)));
			frontLeft2 = (new MoveFunctionPartidaFinalConstante(genome.getAmplitude(4),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(16),genome.getPeriod(1),genome.getFase(16),genome.getCenterAngle(16),genome.getStrength(1)));
			frontLeftShoulder = (new MoveFunctionPartidaFinalConstante(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(17),genome.getPeriod(1),genome.getFase(17),genome.getCenterAngle(17),genome.getStrength(1)));
			
			backRight1 =  (new MoveFunctionPartidaFinalConstante (genome.getAmplitude (6), genome.getPeriod (0), genome.getFase (6), genome.getCenterAngle (6), genome.getStrength (0),genome.getAmplitude(18),genome.getPeriod(1),genome.getFase(18),genome.getCenterAngle(18),genome.getStrength(1)));
			backRight2 =  (new MoveFunctionPartidaFinalConstante (genome.getAmplitude (7), genome.getPeriod (0), genome.getFase (7), genome.getCenterAngle (7), genome.getStrength (0),genome.getAmplitude(19),genome.getPeriod(1),genome.getFase(19),genome.getCenterAngle(19),genome.getStrength(1)));
			backRightShoulder =  (new MoveFunctionPartidaFinalConstante (genome.getAmplitude (8), genome.getPeriod (0), genome.getFase (8), genome.getCenterAngle (8), genome.getStrength (0),genome.getAmplitude(20),genome.getPeriod(1),genome.getFase(20),genome.getCenterAngle(20),genome.getStrength(1)));
			
			frontRight1 =  (new MoveFunctionPartidaFinalConstante (genome.getAmplitude (9), genome.getPeriod (0), genome.getFase (9), genome.getCenterAngle (9), genome.getStrength (0),genome.getAmplitude(21),genome.getPeriod(1),genome.getFase(21),genome.getCenterAngle(21),genome.getStrength(1)));
			frontRight2 =  (new MoveFunctionPartidaFinalConstante (genome.getAmplitude (10), genome.getPeriod (0), genome.getFase (10), genome.getCenterAngle (10), genome.getStrength (0),genome.getAmplitude(22),genome.getPeriod(1),genome.getFase(22),genome.getCenterAngle(22),genome.getStrength(1)));
			frontRightShoulder =  (new MoveFunctionPartidaFinalConstante (genome.getAmplitude (11), genome.getPeriod (0), genome.getFase (11), genome.getCenterAngle (11), genome.getStrength (0),genome.getAmplitude(23),genome.getPeriod(1),genome.getFase(23),genome.getCenterAngle(23),genome.getStrength(1)));
			
			secondPeriod = genome.getPeriod(1);
			
			break;
		case FunctioT.Partida_Classic_FaseSync_Fourier_Knee:
			backLeft1 = (new MoveFunctionPartida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0),genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(6),genome.getPeriod(1),genome.getFase(6),genome.getCenterAngle(6),genome.getStrength(1)));
			backLeft2 = (new MoveFunctionPartidaFourierRodilla(genome.getAmplitude(1),genome.getAmplitude(18),genome.getAmplitude(19),genome.getAmplitude(20),genome.getPeriod(0),genome.getFase(1),genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(7),genome.getPeriod(1),genome.getFase(7),genome.getCenterAngle(7),genome.getStrength(1)));
			backLeftShoulder = (new MoveFunctionPartida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2),genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(8),genome.getPeriod(1),genome.getFase(8),genome.getCenterAngle(8),genome.getStrength(1)));
			
			frontLeft1 = (new MoveFunctionPartida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3),genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(9),genome.getPeriod(1),genome.getFase(9),genome.getCenterAngle(9),genome.getStrength(1)));
			frontLeft2 = (new MoveFunctionPartidaFourierRodilla(genome.getAmplitude(4),genome.getAmplitude(21),genome.getAmplitude(22),genome.getAmplitude(23),genome.getPeriod(0),genome.getFase(4),genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(10),genome.getPeriod(1),genome.getFase(10),genome.getCenterAngle(10),genome.getStrength(1)));
			frontLeftShoulder = (new MoveFunctionPartida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5),genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(11),genome.getPeriod(1),genome.getFase(11),genome.getCenterAngle(11),genome.getStrength(1)));
			
			backRight1 = (new MoveFunctionPartida(genome.getAmplitude(0),genome.getPeriod(0),genome.getFase(0) + Mathf.PI,genome.getCenterAngle(0),genome.getStrength(0),genome.getAmplitude(12),genome.getPeriod(1),genome.getFase(12),genome.getCenterAngle(12),genome.getStrength(1)));
			backRight2 = (new MoveFunctionPartidaFourierRodilla(genome.getAmplitude(1),genome.getAmplitude(18),genome.getAmplitude(19),genome.getAmplitude(20),genome.getPeriod(0),genome.getFase(1) + Mathf.PI,genome.getCenterAngle(1),genome.getStrength(0),genome.getAmplitude(13),genome.getPeriod(1),genome.getFase(13),genome.getCenterAngle(13),genome.getStrength(1)));
			backRightShoulder = (new MoveFunctionPartida(genome.getAmplitude(2),genome.getPeriod(0),genome.getFase(2) + Mathf.PI,genome.getCenterAngle(2),genome.getStrength(0),genome.getAmplitude(14),genome.getPeriod(1),genome.getFase(14),genome.getCenterAngle(14),genome.getStrength(1)));
			
			frontRight1 = (new MoveFunctionPartida(genome.getAmplitude(3),genome.getPeriod(0),genome.getFase(3) + Mathf.PI,genome.getCenterAngle(3),genome.getStrength(0),genome.getAmplitude(15),genome.getPeriod(1),genome.getFase(15),genome.getCenterAngle(15),genome.getStrength(1)));
			frontRight2 = (new MoveFunctionPartidaFourierRodilla(genome.getAmplitude(4),genome.getAmplitude(21),genome.getAmplitude(22),genome.getAmplitude(23),genome.getPeriod(0),genome.getFase(4) + Mathf.PI,genome.getCenterAngle(4),genome.getStrength(0),genome.getAmplitude(16),genome.getPeriod(1),genome.getFase(16),genome.getCenterAngle(16),genome.getStrength(1)));
			frontRightShoulder = (new MoveFunctionPartida(genome.getAmplitude(5),genome.getPeriod(0),genome.getFase(5) + Mathf.PI,genome.getCenterAngle(5),genome.getStrength(0),genome.getAmplitude(17),genome.getPeriod(1),genome.getFase(17),genome.getCenterAngle(17),genome.getStrength(1)));
			
			secondPeriod = genome.getPeriod(1);
			
			break;
		case FunctioT.Media_Partida_Classic_FaseSync_Fourier_Knee:
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
			
			secondPeriod = genome.getPeriod(1);
			
			break;
			
		}
	}
}
