using System;
using System.Collections.Generic;
using System.Text;

namespace ACT7_CourseLevriers
{
    internal class Chien
    {
		private int _number;

		public int Number
		{
			get { return _number; }
			set { _number = value; }
		}

		private double _positionTop;

		public double  PositionTop
		{
			get { return _positionTop; }
			set { _positionTop = value; }
		}

		private double _positionLeft;

		public double PositionLeft
		{
			get { return _positionLeft; }
			set { _positionLeft = value; }
		}

		public Chien(int number, double positionTop, double positionLeft)
		{
			this._number = number;
			this._positionTop = positionTop;
			this._positionLeft = positionLeft;
		}

		// faire les fonctions de jeux




	}
}
