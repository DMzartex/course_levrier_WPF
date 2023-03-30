using System;
using System.Collections.Generic;
using System.Text;

namespace ACT7_CourseLevriers
{
    internal class Pari
    {
		private int _somme;

		public int Somme
		{
			get { return _somme; }
			set { _somme = value; }
		}

		private string _nameJoueur;

		public string NameJoueur
		{
			get { return _nameJoueur; }
			set { _nameJoueur = value; }
		}

		private int _numberChien;

		public int NumberChien
		{
			get { return _numberChien; }
			set { _numberChien = value; }
		}

		public Pari(int somme, string nameJoueur, int numberChien)
		{
			this._somme = somme;
		    this._nameJoueur= nameJoueur;
			this._numberChien = numberChien;
		}

	}
}
