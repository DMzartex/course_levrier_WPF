//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;
//using System.Windows.Controls;
//using System.Windows.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Threading;


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
    }
}
